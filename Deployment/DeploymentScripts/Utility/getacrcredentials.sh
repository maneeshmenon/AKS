#Encrpt the credentials and sav in config.conf

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

az acr credential show --resource-group $containerregistryresourcegroup  --name $containerregistryusername  | grep value |head -1 | cut -d'"' -f 4 > result
value=$(<result)
var1='s/^(containerregistrypassword[[:blank:]]*=[[:blank:]]*).*/\1'
var2=$value
var2tmp=$(echo $var2 | base64 -w 0)
var3='/'
var4="${var1}${var2tmp}${var3}"
rm result
sed -E $var4  config.conf > result
rm config.conf
mv result config.conf
