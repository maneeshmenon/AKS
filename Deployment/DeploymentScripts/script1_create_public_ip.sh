#create public ip resource. This IP will be used by the load balancer

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired subscription
az account set --subscription $subscription

#get aks cluster location
akslocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $akslocation

publicipresourcegroupname="MC$delimiter$aksresourcegroup$delimiter$aksname$delimiter$akslocation"
echo $publicipresourcegroupname

#create public ip address resource
az network public-ip create --resource-group $publicipresourcegroupname --name $publicipresourcename --sku Standard --allocation-method static --query publicIp.ipAddress -o tsv

