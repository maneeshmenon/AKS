#Install Ingress Controller using HELM

#namespace=kube-system
#customenamespace=aks-demo

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#get aks cluster location
akslocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $akslocation

publicipresourcegroupname="MC$delimiter$aksresourcegroup$delimiter$aksname$delimiter$akslocation"
echo $publicipresourcegroupname

#get the ip address associated with the load balancer
IP=$(az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep ipAddress | cut -d':' -f 2 | cut -d',' -f 1 | cut -d'"' -f 2)
echo $IP

helm install stable/nginx-ingress --namespace $customnamespace --name aks-demo --set controller.replicaCount=1 --set rbac.create=false --set controller.service.loadBalancerIP=$IP

while :
do
        status=$(kubectl get services | grep aks-demo-nginx-ingress-controller | awk {'print $4'} | column -t)
        echo $status

        if [ $status == $IP ]
        then
                echo 'ip address is assigned to the load  balancer'
                break
        else
               echo 'ip address is not yet assigned to the load balancer. Status will be checked after 30 seconds'
               sleep 30s
        fi
done
echo 'script execution complete'
