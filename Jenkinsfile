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
                sh 'rm -f /var/lib/apt/lists/lock && rm -f /var/cache/apt/archives/lock && apt-get update && apt-get install -y nodejs npm'
            }
        }
        stage('Build Angular') {
            steps {
                dir('study2025.client') {
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