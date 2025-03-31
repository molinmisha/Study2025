pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout([
                    $class: 'GitSCM',
                    branches: [[name: '*/master']],
                    extensions: [],
                    userRemoteConfigs: [[url: 'https://github.com/molinmisha/Study2025.git']]
                ])
            }
        }

        stage('Build Angular') {
            steps {
                dir('study2025.client') {
                    bat 'npm install'       // Заменили sh на bat
                    bat 'npm run build --prod'
                }
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker-compose up --build -d'  // Заменили sh на bat
            }
        }
    }
}