FROM jenkins/jenkins:lts
USER root
RUN apt-get update && apt-get install -y nodejs npm sudo
RUN echo "jenkins ALL=(ALL) NOPASSWD: /usr/bin/apt-get, /bin/rm" >> /etc/sudoers
USER jenkins