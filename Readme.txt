Pre-requisitos
Antes de comenzar, asegúrate de tener instalados los siguientes programas en tu máquina:

Node.js
Angular CLI
Visual Studio o Visual Studio Code (con la extensión de .NET Core)

Luego para ejecutarla de forma local  pueden usar la opcion de desplieque del proyecto en el visual estudio el cual le ejecutara tanto el back como el front
ademas pueden desplegar en un contenedor gracias a que la aplicacion esta previamente dockerizada

adicional se podria desplegar con el siguiente pipeline yaml usando kaniko para ejecutar el contenedor en el kubernete, sin embargo no lo pude probar por problemas con el docker en mi maquina

apiVersion: build.knative.dev/v1alpha1
kind: Build
metadata:
  name: NEWSHOREAIR
spec:
  source:
    git:
      url:  https://github.com/FelipeTorresP/NEWSHOREAIR
      revision: master
  template:
    name: kaniko
    steps:
      - name: build
        image: gcr.io/kaniko-project/executor:latest
        args:
          - --dockerfile=\NEWSHOREAIR\NEWSHOREAIR
          - --destination=NEWSHOREAIR:tag
          - --cache=true
          - --cache-ttl=48h
      - name: sonarqube
        image: sonarsource/sonar-scanner-cli:latest
        env:
          - name: SONAR_HOST_URL
            value: http://tu-sonarqube:9000
        args:
          - -Dsonar.projectKey=NEWSHOREAIR
          - -Dsonar.sources=.
          - -Dsonar.tests=.
          - -Dsonar.test.inclusions=**/*Test.cs
          - -Dsonar.cs.nunit.reportsPaths=/workspace/TestResult.xml
      - name: test
        image: mcr.microsoft.com/dotnet/sdk:6.0
        workingDir: /workspace/tests
        command:
          - "dotnet"
          - "test"
          - "--logger:trx"
          - "--results-directory=/workspace"
        volumeMounts:
          - name: workspace
            mountPath: /workspace
    timeout: 1h0m0s
  volumes:
    - name: workspace
      emptyDir: {}