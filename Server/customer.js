var express = require('express');
var router = express.Router();
var app = express();
var customers =  [
    {id: 101, name: "Mark Johnson", phone: 1999646465, location: 8.1},
    {id: 102, name: "Dave Maththew", phone: 2010565111, location: 8.7},
    {id: 103, name: "Clark Peterson", phone: 2008154564, location: 9},
    {id: 104, name: "Ann Claire", phone: 1957, location: 1.3}
];

router.get('/', function(req, res){
		res.json(customers);
     });

module.exports = router;