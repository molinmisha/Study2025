pipeline {
    agent any
    stages {
      stage('Install Node.js') {
            steps {
                sh 'apt-get update && apt-get install -y nodejs npm'
            }
        }
        stage('Build Angular') {
            steps {
                dir('client') {
                    sh 'npm install'
                }
            }
        }
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], // Убедитесь, что ветка main существует в вашем репозитории
                         doGenerateSubmoduleConfigurations: false,
                         extensions: [],
                         userRemoteConfigs: [[url: 'https://github.com/molinmisha/Study2025']]])
            }
        }
        stage('Build and Deploy') {
            steps {
                sh 'docker-compose up --build -d'
            }
        }
    }
}