pipeline {
    agent any

    environment {
        IMAGE_NAME = 'pipelinetest'
        IMAGE_TAG = 'New'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build WebApplication1/WebApplication1.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test WebApplication1.sln --logger "trx;LogFileName=./WebApplication1.trx"'
            }
        }

        stage('Docker Build') {
            steps {
                // Build your Docker image
                script {
                    docker.build("${IMAGE_NAME}:${IMAGE_TAG}")
                }
            }
        }

        stage('Docker Push') {
            steps {
                script {
                    // Login to Docker Hub (or your Docker registry)
                    // Make sure to set your credentials in Jenkins credential store
                    docker.withRegistry('https://index.docker.io/v2/', 'DockerHub') {
                        // Push your Docker image
                        docker.image("${IMAGE_NAME}:${IMAGE_TAG}").push()
                    }
                }
            }
        }

        stage('Run Container') {
            steps {
                script {
                    // Stop the currently running container (if any)
                    sh 'docker rm -f ${IMAGE_NAME} || true'
                    // Run the new container
                    sh "docker run -d --name WebApplication1 -p 8000:80 ${IMAGE_NAME}:${IMAGE_TAG}"
                }
            }
        }
    }
}
