<p align="center"> <img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/> </p>



#	API de Aluguel de Carros(LocaCar)
Este é um projeto desenvolvido como parte da demonstração dos meus conhecimentos.

A aplicação é uma API que possibilita o gerenciamento de um serviço de aluguel de carros, oferecendo funcionalidades para criar, ler, atualizar e excluir registros de carros disponíveis para aluguel. A API permite que usuários realizem reservas de carros com opções de datas, horários e duração do aluguel.

A aplicação é containerizada utilizando Docker, o que facilita a execução e o isolamento da aplicação em ambientes consistentes. Além disso, ela pode ser implantada em um cluster Kubernetes, permitindo a escalabilidade e o gerenciamento eficiente dos recursos.

Para garantir agilidade e automatização de tarefas, a aplicação utiliza CI/CD (Integração Contínua/Entrega Contínua). Esse processo automatizado facilita a construção, teste, implantação e atualização da aplicação, tornando o ciclo de desenvolvimento mais eficiente e confiável.

Em resumo, a aplicação consiste em uma API containerizada com Docker, que possibilita o aluguel de carros e pode ser implantada em um ambiente Kubernetes, aproveitando os benefícios da automação fornecidos pelo CI/CD.



## Tecnologias Utilizadas
- .NET 6.0
- Entity Framework Core
- Identity
- XUnit
- MySQL
- Docker
- Kubernetes
- Helm
- SonarQube
- Prometheus
- Grafana
- Alertmanager - Slack
- NGINX
- Git
- GitHub
- Jenkins



## Pré-requisitos
+ .NET 6.0

+ Docker

+ Kubernetes



## Estrutura do Projeto
src/ - Contém o código-fonte da API em ASP.NET 6.0.
kubernetes/ - Contém os arquivos de configuração para implantar a API no Kubernetes.



## Funcionalidades
- Listar todos os carros disponíveis para aluguel.
- Buscar um carro por ID.
- Adicionar um novo carro ao catálogo de aluguel.
- Atualizar as informações de um carro existente.
- Excluir um carro do catálogo de aluguel.
- Realizar reservas de carros com opções de datas, horários e duração do aluguel.
- Verificar a disponibilidade de um carro para determinadas datas.
- Calcular o valor do aluguel com base na duração e no tipo de carro selecionado.
- Coletar métricas do Kubernetes (Kluster), Nginx e API pelo Prometheus.
- Enviar alertas de erro relacionados à API para o Slack por meio do Alertmanager.
- Visualizar e consultar as métricas no Grafana.



## Documentação da API 
Para obter mais informações sobre os endpoints e a funcionalidade da API de Aluguel de Carros(LocaCar), consulte a [documentação da API no Postman](https://documenter.getpostman.com/view/22241608/2s93sf1qnf).



## Implantação Local
1. Suba o Docker Compose da API:

   ```bash
   docker-compose up -d
   ```

2. Acesse a API em http://localhost/swagger



## Implantação no Kubernetes
Certifique-se de que seu cluster Kubernetes esteja em execução e configurado corretamente.

1. Entre no diretorio kubernetes e executar os comandos:

   ```bash
   kubectl create ns locacar
   kubectl apply -f kube-state-metrics/
   kubectl apply -f locacar/
   kubectl apply -f alertmanager/
   kubectl apply -f prometheus/ 
   kubectl apply -f grafana/ 
   kubectl apply -f mysql/ 
   kubectl apply -f nginx/ 
   kubectl apply -f client/ 
   ```

2. Verifique o status da implantação:

   ```
   kubectl get pods -n locacar
   ```

3. As portas utilizadas para acesso aos serviços são: 

   - 80 para a API.
   - 9090 para o Prometheus.
   - 9093 para o Alertmanager.
   - 3000 para o Grafana.

4. Caso seja necessário, você pode excluir tudo:

   ```
   kubectl delete ns locacar
   ```



## Implantação no Kubernetes Pelo Helm
Certifique-se de que seu cluster Kubernetes e o Helm esteja em execução e configurado corretamente.

1. Configure o value, passando o link correto do webhook do slack

2. Entre no diretorio helm e execute os comandos:

   ```bash
   helm install locacar locacar/
   ```

2. Verifique o status da implantação:

   ```
   kubectl get pods
   ````

4. Caso seja necessário, você pode excluir tudo:

   ```
   helm uninstall locacar
   ```



## Observações:
- Para receber mensagens do Alertmanager no Slack, crie um canal para receber os alerts e instale o "incoming-webhook" no Slack escolhendo o canal criado para receber os alerts. Copie a URL do webhook gerada e cole-a no arquivo "alertmanager-configmap.yaml" (slack_api_url).
- O ambiente kubernetes pode ser facilmente aplicado em qualquer provedor de nunvem sem muitas alterações.
- As métricas do kubernetes/prometheus podem ter algumas limitações ao serem executadas em um ambiente de nuvem ou pelo helm.



## Contribuição
Este projeto foi desenvolvido por:

- [marcoservio](https://github.com/marcoservio)

Sinta-se à vontade para contribuir com melhorias para este projeto. Basta fazer um fork, realizar as alterações e enviar um pull request. Será um prazer revisar e mesclar suas contribuições.



## Licença
Este projeto está licenciado sob a licença MIT.



## Recursos Adicionais
- [.NET](https://docs.microsoft.com/pt-br/dotnet/)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/)
- [XUnit](https://xunit.net/)
- [MySQL](https://dev.mysql.com/doc/)
- [Docker](https://docs.docker.com/)
- [Kubernetes](https://kubernetes.io/docs/home/)
- [Helm](https://helm.sh/docs/)
- [SonarQube](https://docs.sonarqube.org/latest/)
- [Prometheus](https://prometheus.io/docs/)
- [Grafana](https://grafana.com/docs/)
- [Alertmanager](https://prometheus.io/docs/alerting/latest/configuration/)
- [NGINX](https://nginx.org/en/docs/)
- [Git](https://git-scm.com/doc)
- [GitHub](https://docs.github.com/en)
- [Jenkins](https://www.jenkins.io/doc/)



## Contato
- Email: [marcoservio22@hotmail.com](mailto:marcoservio22@hotmail.com.com)

- GitHub: [marcoservio](https://github.com/marcoservio)

- LinkedIn: [Marco Servio](https://www.linkedin.com/in/marco-sérvio-366b2b137/)



Se você tiver alguma dúvida, sugestão ou quiser se conectar profissionalmente, sinta-se à vontade para entrar em contato por e-mail ou me encontrar no LinkedIn.



Agradeço por visitar este repositório e por verificar meu projeto API de Aluguel de Carros(LocaCar) em .NET 6.0