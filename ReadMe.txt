start Jenkins server

docker run -p 8080:8080 -p 50000:50000 -v jenkins_home:/var/jenkins_home jenkins/jenkins:lts

http://localhost:8080/


docker run -p 8080:8080 -p 50000:50000 -v jenkins_home:/var/jenkins_home my-jenkins

docker run -d -p 8080:8080 -p 50000:50000 -v /var/run/docker.sock:/var/run/docker.sock -v jenkins_home:/var/jenkins_home --name jenkins my-jenkins