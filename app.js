const express = require('express');

const PORT = process.env.PORT || 80

const app = express();
app.use('/Build', express.static(path.join(__dirname, 'Build')));
app.get('/', function(req, res) {
    res.sendFile(__dirname + "/index.html")
})

app.listen(PORT);
console.log('Running on PORT ' + PORT);