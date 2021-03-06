#Install Ingress Controller using HELM

#variables
#Load config values
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired subscription
az account set --subscription $subscription

#set desired kubernetes
#az aks get-credentials --resource-group $aksresourcegroup --name $aksname --overwrite-existing

#get aks cluster location
akslocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $akslocation

#get resource group of public ip
publicipresourcegroupname="MC$delimiter$aksresourcegroup$delimiter$aksname$delimiter$akslocation"
echo $publicipresourcegroupname

#get the ip address to be associated with the load balancer
IP=$(az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep ipAddress | cut -d':' -f 2 | cut -d',' -f 1 | cut -d'"' -f 2)
echo $IP

#update repo with stable nginx
helm repo add stable https://kubernetes-charts.storage.googleapis.com/

#install nginx
#helm install aks-demo stable/nginx-ingress --namespace $customnamespace --set controller.replicaCount=1 --set rbac.create=false --set controller.service.loadBalancerIP=$IP
helm install aks-demo stable/nginx-ingress --namespace $customnamespace --set controller.replicaCount=1 --set rbac.create=false --set controller.
nodeSelector."beta\.kubernetes\.io/os"=linux --set defaultBackend.nodeSelector."beta\.kubernetes\.io/os"=linux --set controller.service.loadBalan
cerIP=$IP


#exit the script only when the load balancer is assigned the ip address.
sleep 5s
while :
do
        statusofip=$(kubectl get services  --namespace $customnamespace | grep aks-demo-nginx-ingress-controller | awk {'print $4'} | column -t)
        echo 'status of ip'
        echo $statusofip


        if [ "$statusofip" == "$IP" ]
        then
                echo 'ip address is assigned to the load  balancer'
                break
        fi

        echo 'ip address is not yet assigned to the load balancer. Status will be checked after 30 seconds'
        sleep 30s

done
echo 'script execution complete'
