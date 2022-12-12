const express = require('express');

const PORT = 80;

const app = express();
app.get('/', function(req, res) {
    res.sendFile('/index.html');
});

app.listen(PORT);
console.log('Running on http://localhost:' + PORT);