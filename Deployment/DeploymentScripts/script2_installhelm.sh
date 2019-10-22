## install helm

#!/bin/sh
#variables
#Load config values
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired subscription
az account set --subscription $subscription

#set desired kubernetes
az aks get-credentials --resource-group $aksresourcegroup --name $aksname --overwrite-existing

#Initialize HELM and Tiller
helm init
## use '--tiller-tls-verify flag' extension'. Read https://helm.sh/docs/using_helm/#securing-your-helm-installation
