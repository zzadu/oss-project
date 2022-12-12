FROM unityci/editor:ubuntu-2021.3.12f1-windows-mono-1
RUN mkdir -p /app
COPY . /app/
WORKDIR /app/