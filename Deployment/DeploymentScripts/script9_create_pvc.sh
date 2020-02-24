#Deploy the following applications

#Deploy pvc
#kubectl apply -f ~/gitclouddrive/AKS/Deployment/KUBECTL/PersistentVolumeClaim.yaml
helm install pvc  ~/gitclouddrive/AKS/Deployment/HELM/pvc
