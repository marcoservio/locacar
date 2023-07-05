pipeline {
    agent any

    stages {
        stage('Clean Workspace') {
            steps {
                cleanWs()
            }
        }

        stage('Clean Kubernetes') {
            steps {
                script {
                    try {      
                        withKubeConfig([credentialsId: 'kube-config']) {        
                            sh 'helm uninstall locacar'
                        }
                    } catch (Exception e) {
                            sh "echo $e"
                    }
                }
            }
        }

        stage('Checkout Repository') {
            steps {
                script {
                    try {
                        git 'https://github.com/marcoservio/locacar.git'
                    } catch (Exception e) {
                        slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o checkout - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                        sh "echo $e"
                        currentBuild.result = 'ABORTED'
                        error('Erro')
                    }
                }
            }
        }

        stage('Database Setup') {
            steps {
                script {
                    dir('src/LocaCar.Api/') {
                        try {
                            sh 'docker-compose up -d'
                            sleep time: 30, unit: 'SECONDS'
                        } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Não foi possivel subir o Banco de Dados MySQL - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                        }
                    }
                }
            }
        }

        stage('Restore Dependencies') {
            steps {
                script {   
                    try {               
                        sh 'dotnet restore src/LocaCar.Api/'
                    } catch (Exception e) {
                        slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o restore - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                        sh "echo $e"
                        currentBuild.result = 'ABORTED'
                        error('Erro')
                    }
                }
            }
        }        

        stage('Run Tests') {
            steps {
                script {
                    try {
                        withEnv([
                            "MYSQL_HOST=localhost",
                            "MYSQL_PORT=3310",
                            "MYSQL_DATABASE=locacar",
                            "MYSQL_USER=root",
                            "MYSQL_PASSWORD=root"
                        ]) {
                            sh 'dotnet test tests/LocaCar.Tests.Unit/'
                            sh 'dotnet test tests/LocaCar.Tests.Integration/'
                        }
                    } catch (Exception e) {
                        slackSend (color: 'error', message: "[ FALHA ] Não foi possivel executar os testes - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                        sh "echo $e"
                        currentBuild.result = 'ABORTED'
                        error('Erro')
                    }
                }
            }
        }

        stage('Database Teardown') {
            steps {
                script {
                    dir('src/LocaCar.Api/') {
                        try {
                            sh 'docker-compose down'
                        } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Não foi possivel remover o Banco de Dados MySQL - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                        }
                    }
                }
            }
        }       

        stage('Build Project') {
            steps {
                script {
                    try {
                        sh 'dotnet build src/LocaCar.Api/'
                    } catch (Exception e) {
                        slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o build - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                        sh "echo $e"
                        currentBuild.result = 'ABORTED'
                        error('Erro')
                    }
                }
            }
        } 

        stage('SonarQube Check') {
            steps {
                script {
                    slackSend (color: 'warning', message: "Antes de prosseguir, por favor, verifique se o SonarQube está disponível e totalmente inicializado. Acesse [Janela de 5 minutos]: ${JOB_URL}", tokenCredentialId: 'slack-token')
                    timeout(time: 5, unit: 'MINUTES') {
                        input(id: 'sonarqube-check', message: 'Verificação do SonarQube', ok: 'Continuar')
                    }
                }
            }
        }       
        
        stage('SonarQube Analysis') {
            steps {
                script {
                    dir('src/LocaCar.Api') {
                        try {
                            withCredentials([string(credentialsId: 'sonar-token', variable: 'SONAR_TOKEN')]) {
                                sh 'export SONAR_SCANNER_OPTS="-Dfile.encoding=UTF-8"'
                                sh 'sudo /var/lib/jenkins/.dotnet/tools/dotnet-sonarscanner begin /k:"locacar" /d:sonar.host.url="http://localhost:9000" /d:sonar.verbose=true /d:sonar.token="${SONAR_TOKEN}"'
                                sh 'sudo dotnet build'
                                sh 'sudo /var/lib/jenkins/.dotnet/tools/dotnet-sonarscanner end /d:sonar.token="${SONAR_TOKEN}"'
                            }
                        } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Erro ao executar o SonarQube Analysis - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                        }
                    }
                }
            }
        }

        stage('Publish Project') {
            steps {
                script {
                    dir('src/LocaCar.Api') {
                        try {
                            sh 'dotnet publish -c Release -o publish'
                        } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o publish - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                        }
                    }
                }
            }
        }

        stage('Docker Image Build') {
            steps {
                script {
                    try {
                        dockerapp = docker.build("marcoservio/locacar:${env.BUILD_ID}", '-f ./src/LocaCar.Api/Dockerfile ./src/LocaCar.Api')
                    } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o build do Docker - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                    }
                }
            }
        }

        stage('Docker Image Push') {
            steps {
                script {
                    try {                    
                    docker.withRegistry('https://registry.hub.docker.com/', 'dockerhub') {
                        dockerapp.push('latest')
                        dockerapp.push("1.1.${env.BUILD_ID}")
                    }
                    } catch (Exception e) {
                            slackSend (color: 'error', message: "[ FALHA ] Não foi possivel fazer o push do Docker - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                            sh "echo $e"
                            currentBuild.result = 'ABORTED'
                            error('Erro')
                    }
                }
            }
        }

        stage('API Deployment') {
            steps {                
                script {
                    dir('helm') {
                        try {       
                            withKubeConfig([credentialsId: 'kube-config']) {
                               sh 'helm install locacar locacar/'
                            }
                        } catch (Exception e) {
                                slackSend (color: 'error', message: "[ FALHA ] Não foi possivel subir a API - ${BUILD_URL} em ${currentBuild.durationString}s", tokenCredentialId: 'slack-token')
                                sh "echo $e"
                                currentBuild.result = 'ABORTED'
                                error('Erro')
                        }
                    }
                }
            }
        }
        
        stage('Notification') {
            steps {
                slackSend (color: 'good', message: '[ Sucesso ] O novo build esta disponivel em: http://localhost/swagger/index.html ', tokenCredentialId: 'slack-token')
                sh 'sudo rm -rf *'
            }
        }
    }
}