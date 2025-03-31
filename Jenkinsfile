pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']],
                         doGenerateSubmoduleConfigurations: false,
                         extensions: [],
                         userRemoteConfigs: [[url: 'https://github.com/molinmisha/Study2025']]])
            }
        }
        stage('Install Node.js') {
            steps {
                sh 'apt-get update && apt-get install -y sudo nodejs npm'
            }
        }
        stage('Build Angular') {
            steps {
                dir('client') {
                    sh 'npm install'
                }
            }
        }
        stage('Build and Deploy') {
            steps {
                sh 'docker-compose up --build -d'
            }
        }
    }
}