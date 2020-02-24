#Deploy Ingress service without TLS
#kubectl create -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngress.yaml
#kubectl delete -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngress.yaml

## Basic HELM commands
#helm install <path of folder>
#helm list
#helm delete <deployment name> --purge


#Deploy ingres with TLS
### Note: secret/tls-ingress-secret is used here ###
#kubectl create -f ~/gitclouddrive/AKS/Deployment/KUBECTL/DeployIngressWithTLS.yaml
helm install aks-demo-ingress ~/gitclouddrive/AKS/Deployment/HELM/ingresswithtls
