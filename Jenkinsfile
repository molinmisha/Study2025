pipeline {
    agent any
    
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
                    // Используем Node.js, установленный в контейнере Jenkins
                    sh 'node --version'
                    sh 'npm --version'
                    sh 'npm install'
                    sh 'npm run build --prod'
                }
            }
        }
        
        stage('Build and Deploy') {
            steps {
                sh 'docker-compose --version'
                sh 'docker-compose up --build -d'
            }
        }
    }
}