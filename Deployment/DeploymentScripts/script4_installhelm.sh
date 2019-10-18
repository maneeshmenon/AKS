## install helm

#!/bin/sh
#variables
#subscription=f596069f-6c71-4b50-bc42-b3b2cb460b41
#aksresourcegroup=mmgitdemo-aks-rg
#aksname=mmgitdemo-aks

#Load config values
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired subscription
az account set --subscription $subscription

#set desired kubernetes
az aks get-credentials --resource-group $aksresourcegroup --name $aksname

#Initialize HELM and Tiller
helm init
## use '--tiller-tls-verify flag' extension'. Read https://helm.sh/docs/using_helm/#securing-your-helm-installation
