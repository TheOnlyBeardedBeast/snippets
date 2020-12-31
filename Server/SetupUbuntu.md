# Install docker
Remove old versions
```
sudo apt-get remove docker docker-engine docker.io containerd runc
```
Setup repo
```
$ sudo apt-get update

$ sudo apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg-agent \
    software-properties-common
    
$ curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

$ sudo apt-key fingerprint 0EBFCD88

$ sudo add-apt-repository \
   "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
   $(lsb_release -cs) \
   stable"
```

Install docker engine
```
$ sudo apt-get update
 $ sudo apt-get install docker-ce docker-ce-cli containerd.io
```

# Install fathom
Create volume
```
docker volume create fathom
```
Run fathom
```
docker run -d --name=fathom -p 8080:8080 -v fathom:/app usefathom/fathom:latest
```
Create fathom user
```
docker exec fathom ./fathom user add --email="your@email.com" --password="yourpassword"
```
SOURCE:
```
https://schaper.io/2018/07/using-fathom-with-postgres-and-docker/
```

# Install NGINX
Update packages
```
sudo apt-get update
```
Install nginx
```
sudo apt-get install nginx
```
Verify install
```
nginx -v
```
## Useful commands
Status
```
sudo systemctl status nginx
```
Start service
```
sudo systemctl start nginx
```
Autostart
```
sudo systemctl enable nginx
```
Stop service
```
sudo systemctl stop nginx
```
Stop autostart
```
sudo systemctl disable nginx
```
Reload
```
sudo systemctl reload nginx
```
Restart
```
sudo systemctl restart nginx
```
List traffic options
```
sudo ufw app list
```
Allow http and https traffic
```
sudo ufw allow 'nginx full'
```


# Host fathom docker through nginx proxy
Create a file with a name `analytics.example.com` in sites-enabled folder, you can create it from a copy of default.

```
server {
    listen        80;
    server_name   analytics.example.com;
    location / {
        proxy_pass         http://localhost:8080;
    }
}
```

Point your A dns setting to the server IP

# Install certification
Install certbot snap
```
sudo snap install --classic certbot 
```
Choose nginx
```
sudo certbot --nginx 
```

## Renev
```
sudo certbot renew 
```

