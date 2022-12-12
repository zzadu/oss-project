pipeline {
    agent any
    environment {

    }
    stages {
        stage("Git Clone") {
            steps {
                git 'https://github.com/zzadu/GMIdeaTeam.git'
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
        stage("Build Game") {
            steps {
                script {
                    app.inside {
                        sh "mkdir -p /build/"
                        sh "${env.UNITY_PATH}/Editor/Unity -quit -batchmode -nographics -buildTarget Standalone -projectPath \"/app\" -executeMethod BuildPlayer.BuildWindow -username zzadu08@naver.com -password Test1234 -serial SC-M7N9-C9X2-G6AW-NEAP-HYT3 -logFile - -quit"
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