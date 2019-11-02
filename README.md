This material in github will provide user with hands on experience of setting up Azure Kubernetes Service (AKS), building container image(s),
storing image(s) in container registry and deploying the image(s)

A brief on the applications: A frontend application invokes the backend service. The frontend application displays the result returned by the backend service.
The backend service offers the ability to invoke three APIs and the frontend application can be configured to call any one of the APIs.

A brief on build: The following are provided. A Dockerfile each for both frontend and backend applications. YAML to perform build a container image using Azure DevOps

A brief on deployment: To make deployment easy, there are eleven Bash scripts. The scripts will help user understand a desired sequence during the deployment process
Each script executed in an ordered fashion helps deploy the frontend and backend applications in Azure Kubernetes Services.


A brief about learning: In Progress







Download Source
===============
Step 1: Open Azure Portal and setup Cloud Shell
Step 2: Create a directory name gitclouddrive
Step 3: In the new directory created, clone git source by executing the command 'git clone https://github.com/maneeshmenon/AKS.git'
Step 4: Take note of important folders
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
Step 1: Create an account in Azure DevOps. For example 'https://dev.azure.com/maneeshmenon/'
Step 2: Create a project in the account
Step 3: Under Project Settings, create a service connection named 'serviceconnectioncontainerregistry'. This is to gain access to ACS 
Step 4: Using pipelines -> build, create two build pipelines. Use the following YAML to perform build
    a. azure-pipelines-build-frontend.yml
		b. azure-pipelines-build-backend.yml

Note: While performing the build operation, choose your github repository as the source


Deploy
======

Step 1: Ensure that the config file is updated. Location of the file is gitclouddrive -> AKS -> Deployment -> DeploymentScripts -> config.conf
Step 2: Execute the bash scripts in the chronological order
