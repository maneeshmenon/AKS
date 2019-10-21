#set access to container registry from the custom namespace

#!/bin/sh
#variables
#containerregistry=mmgitdemoacr.azurecr.io
#containerusername=mmgitdemoacr
#containerpassword=DQcfcTUXE3LrKwPg8H6yh0FT/sFxySdM
#containeremailid=menon.maneesh@gmail.com
#customnamespace=aks-demo

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

#set desired kubernetes
az aks get-credentials --resource-group $aksresourcegroup --name $aksname --overwrite-existing

#setting context to custom namespace
kubectl config set-context $(kubectl config current-context) --namespace=$customnamespace

#get container registry password
containerregistrypassword=$(az acr credential show --resource-group $containerregistryresourcegroup  --name $containerregistryusername  | grep value |head -1 | cut -d'"' -f 4)
#echo $containerregistrypassword

#create secret for desired container registry
kubectl create secret docker-registry acrconnection --docker-server=$containerregistry --docker-username=$containerregistryusername --docker-password=$containerregistrypassword --docker-email=$containerregistryemailid

#configure registry access for kubernetes service - update
kubectl get serviceaccounts default -o yaml > ./serviceaccount.yml
echo "imagePullSecrets:" >> serviceaccount.yml
echo "- name: acrconnection" >> serviceaccount.yml

#configure registry access for kubernetes service - replace
kubectl replace serviceaccount default -f ./serviceaccount.yml
