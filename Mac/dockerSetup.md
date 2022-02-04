# Install docker without docker desktop on mac
Intall hyperkit, minikube, docker, docker-compose
```shell
brew install hyperkit
brew install minikube
brew install docker
brew install docker-compose
```
Make hyperkit the default driver
```shell
minikube config set driver hyperkit
```
Start minikube
```shell
minikube start --driver=hyperkit 
```
Expose env variables 
```shell
eval $(minikube docker-env) 
```
Get IP, localhost with ports wont work with your docker containers, you have to use minikubes IP
```shell
minikube ip
```
Add the eval at the end of your shell config for example `~/.zshrc` so docker will be available in every CLI window from the beginnig

```shell
# ...
eval $(minikube docker-env)
```
