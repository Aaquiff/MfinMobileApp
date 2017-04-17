var express = require('express');
var bodyParser = require('body-parser');
var multer = require('multer');
var upload = multer();

var app = express();

//app.use(cookieParser());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(upload.array());

app.use(express.static('public'));

app.use('/customers',require('./customer.js'));

app.get('/', function(req, res){
    res.send("<h1>Hello world!</h1>");
});

app.listen(3000);
console.log('Server Listening at localhost:3000');