FROM unityci/editor:ubuntu-2021.3.12f1-webgl-1 as gameBuilder
COPY . /app
WORKDIR /app
RUN $UNITY_PATH/Editor/Unity -quit -batchmode -nographics -buildTarget WebGL -projectPath "/" -executeMethod BuildPlayer.BuildWebGL -username zzadu08@naver.com -password Test1234 -serial SC-M7N9-C9X2-G6AW-NEAP-HYT3 -logFile -

FROM bitnami/node:9-prod
COPY --from=gameBuilder /build/Dino /app
COPY --from=gameBuilder /app/Dockerfile /app
COPY --from=gameBuilder /app/Jenkinsfile /app
COPY --from=gameBuilder /app/app.js /app
COPY --from=gameBuilder /app/package.json /app
WORKDIR /app
RUN npm install

CMD ["npm", "start"]
