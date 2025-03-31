pipeline {
    agent any

    stages {
        stage('Build Angular') {
            steps {
                dir('client') {
                    script {
                        if (isUnix()) {
                            sh 'set -e; npm install; npm run build --prod'
                        } else {
                            bat 'npm install && npm run build --prod'
                        }
                    }
                }
            }
        }

        stage('Build .NET API') {
            steps {
                dir('server') {
                    sh 'set -e; dotnet restore; dotnet publish -c Release -o ./publish'
                }
            }
        }

        stage('Docker Build') {
            steps {
                sh 'set -e; docker-compose build'
            }
        }

        stage('Deploy') {
            steps {
                sh 'set -e; docker-compose up -d'
            }
        }
    }
}