#get the public ip address

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

## approach 1
az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep ipAddress | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2 > result

value=$(<result)
var1='s/^(IP[[:blank:]]*=[[:blank:]]*).*/\1'
var2=$value
var3='/'
var4="${var1}${var2}${var3}"
rm result
sed -E $var4  config.conf > result
rm config.conf
mv result config.conf

###approach 2
#kubectl get services --namespace aks-demo aks-demo-nginx-ingress-controller | awk {'print $4'} | column -t > result
#sed -e '/EXTERNAL-IP/d' result > result2
#rm result
#mv result2 result
#value=$(<result)
#var1='s/^(IP[[:blank:]]*=[[:blank:]]*).*/\1'
#var2=$value
#var3='/'
#var4="${var1}${var2}${var3}"
#rm result
#sed -E $var4  config.conf > result
#rm config.conf
#mv result config.conf
