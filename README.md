This material in github will provide user with hands on experience of setting up Azure Kubernetes Service (AKS), building container image(s),
storing image(s) in container registry and deploying the image(s)

A brief on the applications: A frontend application invokes the backend service. The frontend application displays the result returned by the backend service.
The backend service offers the ability to invoke three APIs and the frontend application can be configured to call any one of the APIs.

A brief on build: The following are provided. A Dockerfile each for both frontend and backend applications. YAML to perform build a container image using Azure DevOps

A brief on deployment: To make deployment easy, there are eleven Bash scripts. The scripts will help user understand a desired sequence during the deployment process
Each script executed in an ordered fashion helps deploy the frontend and backend applications in Azure Kubernetes Services.


A brief about learning: In Progress
1. Pod: https://kubernetes.io/docs/concepts/workloads/pods/
   A Pod (as in a pod of whales or pea pod) is a group of one or more containers (such as Docker containers), with shared storage/network, and a specification for how to run the containers.

2. Deployment: https://kubernetes.io/docs/concepts/workloads/controllers/deployment/
   A Deployment provides declarative updates for Pods and ReplicaSets.

3. Service: https://kubernetes.io/docs/concepts/services-networking/service/
   An abstract way to expose an application running on a set of Pods as a network service

4. Namespace: https://kubernetes.io/docs/concepts/overview/working-with-objects/namespaces/
   Kubernetes supports multiple virtual clusters backed by the same physical cluster. These virtual clusters are called namespaces

5. Nginx Ingress Controller: 
   https://kubernetes.io/docs/concepts/services-networking/ingress-controllers/
   https://www.nginx.com/products/nginx/kubernetes-ingress-controller
   With the NGINX Ingress Controller for Kubernetes, you get basic load balancing, SSL/TLS termination, support for URI rewrites, 
   and upstream SSL/TLS encryption

6. Persistent Volume Claim   
   https://kubernetes.io/docs/concepts/storage/persistent-volumes/
   A persistent volume is a piece of storage in the cluster that has been provisioned by an administrator or dynamically provisioned using Storage Classes. 
   A persistent volume claim is a request for storage by a user.

7. Typical use cases for deployment
   1. Create a deployment to rollout a replica set
   2. Rollback to an earlier deployment revision
   3. Scale up / down deployment
   4. Liveness and Readiness probe



Download Source
===============
1. Open Azure Portal and setup Cloud Shell
2. Create a directory name gitclouddrive
3. In the new directory created, clone git source by executing the command 'git clone https://github.com/maneeshmenon/AKS.git'
4. Take note of important folders
    1. gitclouddrive -> AKS -> Deployment -> DeploymentScripts has all the bash scripts
    2. gitclouddrive -> AKS -> Deployment -> HELM has Charts as required by HELM
    3. gitclouddrive -> AKS -> Deployment -> KUBECTL has metadata as required by KUBECTL

Note: Push the downloaded source to your preferred github repository. It will be useful during the build.

Pre-requisites
==============
1. Create resources
   1. Create Azure Kubernetes Service (AKS)
   2. Create Azure Container Registry (ACS)

2. Update the details of Azure resources in the configuration file at gitclouddrive -> AKS -> Deployment -> DeploymentScripts -> config.conf



Perform Build using Azure DevOps
================================
1. Create an account in Azure DevOps. For example 'https://dev.azure.com/maneeshmenon/'
2. Create a project in the account
3. Under Project Settings, create a service connection named 'serviceconnectioncontainerregistry'. This is to gain access to ACS 
4. Using pipelines -> build, create two build pipelines. Use the following YAML to perform build
   a. azure-pipelines-build-frontend.yml
   b. azure-pipelines-build-backend.yml

Note: While performing the build operation, choose your github repository as the source


Deploy
======
1. Ensure that the config file is updated. 
   Location of the file is gitclouddrive -> AKS -> Deployment -> DeploymentScripts -> config.conf
2. Execute the bash scripts in the chronological order


Testing
=======
1. Browse the following : https://<FQDN DNS name of load balancer>
2. Browse the following : https://<FQDN DNS name of load balancer>/frontendwebapp
3. Change the following to test further
   1. Select the desired backend service using appsettings.json file in the front end web application
