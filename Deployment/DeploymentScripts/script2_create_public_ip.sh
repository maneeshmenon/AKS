#create public ip resource. This IP will be used by the load balancer

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#get aks cluster location
clusterlocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $clusterlocation

#create public ip address resource
#az network public-ip create --resource-group $publicipresourcegroupname --name $publicipresourcename --allocation-method static --query publicIp.ipAddress -o tsv

