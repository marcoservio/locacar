#!/bin/bash

HOST='proxy-locacar'
#HOST='nginx-clusterip'

while true
    do
	# ENDP=`expr $RANDOM % 3 + 1`
	# NUMB=`expr $RANDOM % 100 + 1`
	# #TEMP=`expr 1 + $(awk -v seed="$RANDOM" 'BEGIN { srand(seed); printf("%.4f\n", rand()) }')`
        
	# if [ $NUMB -le 55 ]; then
	#     curl --silent --output /dev/null http://${HOST}/topicos
    #     elif [ $NUMB -ge 56 ] && [ $NUMB -le 85 ] ; then
	#     curl --silent --output /dev/null http://${HOST}/topicos/$ENDP
    #     elif [ $NUMB -ge 86 ] && [ $NUMB -le 95 ] ; then
	#     curl --silent --output /dev/null --data '{"email":"moderador@email.com","senha":"123456"}' \
	# 	 --header "Content-Type:application/json" \
	# 	 --request POST http://${HOST}/auth
    #     elif [ $NUMB -ge 96 ] && [ $NUMB -le 98 ] ; then
	#     curl --silent --output /dev/null --data '{"email":"moderador@email.com","senha":"1234567"}' \
	#          --header "Content-Type:application/json" \
	#          --request POST http://${HOST}/auth
	# else
	#     curl --silent --output /dev/null http://${HOST}/topicos/0
    #     fi

	curl --silent --output /dev/null http://${HOST}/WeatherForecast
	curl --silent --output /dev/null http://${HOST}/WeatherForecast/teste

	sleep 0.50
done

