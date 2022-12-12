pipeline {
    agent any
    environment {
        REPOSITORY_NAME = 'oss-project'
    }
    stages {
        stage("Git Clone") {
            steps {
                git 'https://github.com/zzadu/oss-project.git'
            }
        }
        stage("Build image") {
            steps {
                script {
                    app = docker.build("zzadu/unity:latest")
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
        stage("Deploy to Slack") {
            when {
                branch 'master'
            }
        }

    }
}