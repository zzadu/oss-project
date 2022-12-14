const express = require('express');

const PORT = 80;

const app = express();
app.get('/', function(req, res) {
    res.sendFile(__dirname + "index.html");
    console.log('ok');
});

app.listen(PORT);
console.log('Running on PORT ' + PORT);