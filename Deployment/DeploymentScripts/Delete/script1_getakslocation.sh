#get AKS location

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf


##approach 1:
az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2 > result
value=$(<result)
var1='s/^(akslocation[[:blank:]]*=[[:blank:]]*).*/\1'
var2=$value
var3='/'
var4="${var1}${var2}${var3}"
rm result
sed -E $var4  config.conf > result
rm config.conf
mv result config.conf


#approach 2:
#az network public-ip list -o table | awk {'print $3'} | column -t > result
#sed -e '/Location/d;/---/d' result > result2
#rm result
#mv result2 result
#value=$(<result)
#var1='s/^(location[[:blank:]]*=[[:blank:]]*).*/\1'
#var2=$value
#var3='/'
#var4="${var1}${var2}${var3}"
#rm result
#sed -E $var4  config.conf > result
#rm config.conf
#mv result config.conf
