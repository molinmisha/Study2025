pipeline {
    agent any

    stages {
        stage('Prepare') {
            steps {
                deleteDir() // Очищаем workspace
                checkout([$class: 'GitSCM',
                    branches: [[name: '*/master']],
                    extensions: [],
                    userRemoteConfigs: [[url: 'https://github.com/molinmisha/Study2025.git']]
                ])
            }
        }

        stage('Build Angular') {
            steps {
                dir('study2025.client') {
                    sh 'npm install'
                    sh 'npm run build --prod'
                }
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker-compose up --build -d'
            }
        }
    }
}