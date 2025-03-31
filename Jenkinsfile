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
                    sh 'npm install'
                    sh 'npm run build --prod'
                }
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker build -t my-angular ./study2025.client && docker build -t my-api ./Study2025.Server && docker run -d -p 4200:80 my-angular && docker run -d -p 5000:80 my-api'
            }
        }
    }
}