pipeline {
    agent any

    environment {
        DOCKER_HOST = "npipe:////./pipe/docker_engine"  // ��� Windows
    }

    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', 
                         branches: [[name: '*/master']],
                         extensions: [],
                         userRemoteConfigs: [[url: 'https://github.com/molinmisha/Study2025']]])
            }
        }

        stage('Build Angular') {
            steps {
                dir('study2025.client') {
                    bat 'npm install'       // ���������� bat ������ sh ��� Windows
                    bat 'npm run build --prod'
                }
            }
        }

        stage('Build and Deploy') {
            steps {
                bat 'docker-compose --version'
                bat 'docker-compose up --build -d'
            }
        }
    }
}