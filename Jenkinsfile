pipeline {
    agent any

    stages {
        // Continuous Integration CI
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Install Dependencies') {
            steps {
                script {
                    echo '!!!!!!!!!!build!!!!!!!!!!!'
                    echo "Building tag: ${env.TAG_NAME}"
                }
            }
        }

         stage("Build for Tag") {
            when {
                expression { return env.TAG_NAME }
            }
            steps {
                script {
                    echo "Building tag: ${env.TAG_NAME}"
                }
            }
        }
    }
}

