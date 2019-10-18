#Deploy DeployIngress.yaml
#kubectl create -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngress.yaml
#helm install <path of folder>

#Delete Ingress
#kubectl delete -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngress.yaml
#helm list
#helm delete <deployment name>

#Deploy ingres with TLS
### Note: secret/tls-ingress-secret is used here ###
#kubectl create -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngressWithTLS.yaml
helm install ~/gitclouddrive/AKS/Deployment/HELM/ingresswithtls
