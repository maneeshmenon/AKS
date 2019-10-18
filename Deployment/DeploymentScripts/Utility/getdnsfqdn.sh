#retrieve the fqdn dns name

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#get aks cluster location
akslocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $akslocation

publicipresourcegroupname="MC$delimiter$aksresourcegroup$delimiter$aksname$delimiter$akslocation"
echo $publicipresourcegroupname


## approach 1
#az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep fqdn | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2 > result

#value=$(<result)
#var1='s/^(FQDN[[:blank:]]*=[[:blank:]]*).*/\1'
#var2=$value
#var3='/'
#var4="${var1}${var2}${var3}"
#rm result
#sed -E $var4  config.conf > result
#rm config.conf
#mv result config.conf


## approach 1
value=$(az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep fqdn | cut -d':' -f 2 | cut -d ',' -f1 | cut -d'"' -f 2)

var1='s/^(dnsname[[:blank:]]*:[[:blank:]]*).*/\1'
var2=$value
var3='/'
var4="${var1}${var2}${var3}"
sed -E $var4  ~/gitclouddrive/AKS/Deployment/HELM/ingresswithtls/values.yaml > result
rm ~/gitclouddrive/AKS/Deployment/HELM/ingresswithtls/values.yaml
mv result ~/gitclouddrive/AKS/Deployment/HELM/ingresswithtls/values.yaml

dnsnameforingress=$value
