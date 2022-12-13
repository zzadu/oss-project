pipeline {
    agent any
    environment {
        REPOSITORY_NAME = 'oss-project'
        PROJECT_ID = 'my-project-362315'
        CLUSTER_NAME = 'kubernetes'
        LOCATION = 'asia-northeast3-a'
        CREDENTIALS_ID = 'gke'
    }
    stages {
        stage("Checkout code") {
            steps {
                checkout scm
            }
        }
        stage("Git Clone") {
            steps {
                git 'https://github.com/zzadu/oss-project.git'
            }
        }
        stage("Build image") {
            steps {
                script {
                    app = docker.build("zzadu/dino:latest")
                }
            }
        }
        stage("Push image") {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', 'dockerhub') {
                        app.push("latest")
                    }
                }
            }
        }
        stage('Deploy to GKE') {
			when {
				branch 'master'
			}
            steps{
                step([$class: 'KubernetesEngineBuilder', projectId: env.PROJECT_ID, clusterName: env.CLUSTER_NAME, location: env.LOCATION, manifestPattern: 'deployment.yaml', credentialsId: env.CREDENTIALS_ID, verifyDeployments: true])
            }
        }
    }
}