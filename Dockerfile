FROM jenkins/jenkins:lts

USER root

# ��������� ������������
RUN apt-get update && \
    apt-get install -y \
    nodejs \
    npm \
    docker.io \
    docker-compose

# ��������� jenkins � ������ docker
RUN usermod -aG docker jenkins

USER jenkins