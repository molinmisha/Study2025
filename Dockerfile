FROM jenkins/jenkins:lts

USER root

# Установка Docker CLI и Node.js
RUN apt-get update && \
    apt-get install -y \
    ca-certificates \
    curl \
    gnupg \
    nodejs \
    npm && \
    curl -fsSL https://download.docker.com/linux/debian/gpg | gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg && \
    echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian $(lsb_release -cs) stable" | tee /etc/apt/sources.list.d/docker.list > /dev/null && \
    apt-get update && \
    apt-get install -y docker-ce-cli && \
    npm install -g npm@latest

# Для Windows: монтируем Docker через npipe
ENV DOCKER_HOST=npipe:////./pipe/docker_engine

USER jenkins