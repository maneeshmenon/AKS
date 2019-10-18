#Deploy the following applications

#Deploy ApacheHttpd service
#kubectl apply -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployApacheHTTPDNodePort.yaml
helm install ~/gitclouddrive/AKS/Deployment/HELM/apachehttpd

#Deploy Frontend Web application
#kubectl apply -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployFrontendwebapp.yaml
helm install ~/gitclouddrive/AKS/Deployment/HELM/frontendwebapp

#Deploy Backend service
#kubectl apply -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployBackendservice.yaml
helm install ~/gitclouddrive/AKS/Deployment/HELM/backendservice
