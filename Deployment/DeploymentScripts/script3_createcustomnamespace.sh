#create custome namespace, instead of using default namespace

#Load config values
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired subscription
az account set --subscription $subscription

#set desired kubernetes
az aks get-credentials --resource-group $aksresourcegroup --name $aksname --overwrite-existing

#approach 1: use kubectl
#kubectl apply -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployNamespace.yaml

#approach 2: Using HELM
helm install ~/gitclouddrive/AKS/Deployment/HELM/customnamespace

