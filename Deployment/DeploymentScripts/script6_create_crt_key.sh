#create certificate and key

#variables
#load external file
. ~/gitclouddrive/AKS/Deployment/DeploymentScripts/config.conf

echo $country
echo $state
echo $locality
echo $organization
echo $organizationalunit
echo $email

#get CN
akslocation=$(az aks show  --resource-group $aksresourcegroup -n $aksname | grep location | cut -d':' -f 2 | cut -d ',' -f 1 | cut -d'"' -f 2)
commonname=$DNSNAME.$akslocation.$suffix
echo $commonname

### Using OPENSSL, create crt and key
### CN has to be set. For example: mmgitdemo-aks-dns.southindia.cloudapp.azure.com
openssl req -new -newkey rsa:2048 -days 365 -nodes -x509 -keyout server.key -out server.crt -subj "/C=$country/ST=$state/L=$locality/O=$organization/OU=$organizationalunit/CN=$commonname/emailAddress=$email"

### Note: Upload the crt and key to cloud drive if certificate is created locally / from outside cloudshell

#Create a Kubernetes Secret
kubectl create secret tls tls-ingress-secret --key server.key --cert server.crt
