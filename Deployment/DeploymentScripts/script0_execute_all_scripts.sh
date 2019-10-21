#sh ./script1_create_public_ip.sh

sleep 10s
#sh ./script2_installhelm.sh

sleep 10s
#sh ./script3_createcustomnamespace.sh

sleep 10s
#sh ./script4_getaccesstoregistry.sh

sleep 10s
#sh ./script5_installnginx.sh

sleep 10s
sh ./script6_create_crt_key.sh

sleep 10s
sh ./script7_setdns.sh

sleep 10s
sh ./script8_getdnsfqdn.sh

sleep 10s
sh ./script9_deployingress.sh

sleep 120s
sh ./script10_deployservices.sh