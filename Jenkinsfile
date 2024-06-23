pipeline {
    agent any
    stages {
        stage('build') {
            steps {
                echo 'Start Building'
                bat '''
                cd "C:\\Drive H Work\\DataStructure-Algorithm\\Algorithm\\LeetCode\\CSharpSolution\\CSharpLeetCodeSolution\\Solution"
                dotnet build
                '''
            }
        }
        stage('test') {
            steps {
                echo 'Start test'
                bat '''
                cd "C:\\Drive H Work\\DataStructure-Algorithm\\Algorithm\\LeetCode\\CSharpSolution\\CSharpLeetCodeSolution"
                dotnet test
                '''
            }
        }
    }

}