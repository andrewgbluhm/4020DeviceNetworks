var b = require('bonescript');                  //standard library
const inputPin = "A0";                          //use analog input pin for tmp36
const Gpsd = require('node-gpsd-client');       //gps library
const green = "P9_41";                          //pin used for green led
const red = "P9_12";                            //pin used for red led

/* Required modules */
const http = require('http');
const path = require('path');

/* Required modules for GPS data */
const client = new Gpsd({
    port: 2947, // default
    hostname: 'localhost', // default
    autoReconnect: 5,
    parse: true
});

/* More GPS required modules */
client.on('connected', () => {
    client.watch({
    class: 'WATCH',
    json: true,
    scaled: true
    });
});

b.pinMode(green, b.OUTPUT);              //set pin mode to output for GPIO 
b.digitalWrite(green, b.HIGH);          //set green LED initially on

b.pinMode(red, b.OUTPUT);              //set pin mode to output for GPIO 
b.digitalWrite(red, b.LOW);             //set red LED initially off

/* Networking Variables */
const HOST = '10.8.0.9';
const PORT = 4020;

/* Variables used for reading data in from BBB */
var test = "-1";
var light = "-1";
var latitude = "-1";
var longitude = "-1";

//RESTful API server commands
const server = http.createServer((req, res) => {
    //Test button to make sure device can receive and send data
    if (req.url === path.normalize('/Andrew')) {
        console.log("Hello Andrew!");
        res.end("Hello Andrew!");
    }
    
    //Another test button to make sure device can receive and send data
    else if (req.url === path.normalize('/John')){
        console.log("Hello John!");
        res.end("Hello John!");
    }
    
    //API call to send latitude
    else if (req.url === path.normalize('/lat')){
        client.on('TPV', data => {
            //make sure latitude is being sent as a layer 7 string
            latitude = data.lat.toString();
            res.end(latitude);
        });
    }
    
    //API call to send longitude
    else if (req.url === path.normalize('/lon')){
        //GPSD commands from GPSD module
        client.on('TPV', data => {
            //make sure longitude is being sent as a layer 7 string
            longitude = data.lon.toString();
            res.end(longitude);//print
        });
    }
    
    else if (req.url === path.normalize('/photo')){
        test = b.analogRead(inputPin);//reads data coming from photo resistor pin
        light = test.toString();//make sure data is string
        console.log(light);
        res.end(light);//print
    }
    
    else if (req.url === path.normalize('/greenLED')){
        //API call to turn green LED on and red LED off
        b.digitalWrite(green, b.HIGH);
        b.digitalWrite(red, b.LOW);
        console.log("Door is closed!");
        res.end("Door is closed!");//sends back message that alerts user everything is ok
    }
    
    else if (req.url === path.normalize('/redLED')){
        //API call to turn green LED off and red LED on
        b.digitalWrite(green, b.LOW);
        b.digitalWrite(red, b.HIGH);
        console.log("Door is open!");
        res.end("Door is open!");//sends back message that alerts user that the door is open
    }
});

server.listen(PORT, HOST);//given networking command
client.connect();//given GPSD command