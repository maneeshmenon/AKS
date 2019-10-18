#set dns to the public ip of the load balancer

#!/bin/bash

# variables: Public IP address and DNS Name to associate with the IP address
#IP="52.172.29.7"
#DNSNAME="mmgitdemo-aks-dns"

#get IP address
ipaddress=$(az network public-ip show --resource-group $publicipresourcegroupname --name $publicipresourcename  | grep ipAddress | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
echo $ipaddress

#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

# Get resource group and public ip name
#RESOURCEGROUP=$(az network public-ip list --query "[?ipAddress!=null]|[?contains(ipAddress, '$IP')].[resourceGroup]" --output tsv)
#PIPNAME=$(az network public-ip list --query "[?ipAddress!=null]|[?contains(ipAddress, '$IP')].[name]" --output tsv)

# Update public ip address with dns name
#az network public-ip update --resource-group $RESOURCEGROUP --name  $PIPNAME --dns-name $DNSNAME
