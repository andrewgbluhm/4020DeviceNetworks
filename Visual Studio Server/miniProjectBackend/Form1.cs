﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace miniProjectBackend
{
    public partial class Form1 : Form
    {
        delegate void SetChartCallback(string text);
        WebClient client = null;

        //Declare Variables for everyone's initial latitude and longitude
        //Allows for data to be read 3 different times
        string andrewlatitude = "0";
        string andrewlongitude = "0";
        string kwamelatitude = "0";
        string kwamelongitude = "0";
        string michaellatitude = "0";
        string michaellongitude = "0";
        string johnlatitude = "0";
        string johnlongitude = "0";
        string andrewlatitude2 = "0";
        string andrewlongitude2 = "0";
        string kwamelatitude2 = "0";
        string kwamelongitude2 = "0";
        string michaellatitude2 = "0";
        string michaellongitude2 = "0";
        string johnlatitude2 = "0";
        string johnlongitude2 = "0";
        string andrewlatitude3 = "0";
        string andrewlongitude3 = "0";
        string kwamelatitude3 = "0";
        string kwamelongitude3 = "0";
        string michaellatitude3 = "0";
        string michaellongitude3 = "0";
        string johnlatitude3 = "0";
        string johnlongitude3 = "0";

        //Variable declaration to read data from photo resistor 3 different times
        string andrewphoto = "0";
        string andrewphoto2 = "0";
        string andrewphoto3 = "0";
        string kwamephoto = "0";
        string kwamephoto2 = "0";
        string kwamephoto3 = "0";
        string michaelphoto = "0";
        string michaelphoto2 = "0";
        string michaelphoto3 = "0";
        string johnphoto = "0";
        string johnphoto2 = "0";
        string johnphoto3 = "0";

        //Color declaration to change between yellow and black depending on what area is lit up
        string andrewcolor1 = "red";
        string andrewcolor2 = "red";
        string andrewcolor3 = "red";
        string kwamecolor1 = "red";
        string kwamecolor2 = "red";
        string kwamecolor3 = "red";
        string michaelcolor1 = "red";
        string michaelcolor2 = "red";
        string michaelcolor3 = "red";
        string johncolor1 = "red";
        string johncolor2 = "red";
        string johncolor3 = "red";

        //Other group's variables
        string paullat = "0";
        string paullon = "0";
        float andrewUseCase = 0;
        float paulTemp = 0;
        float addisonBar = 0;
        string andrewusecaselong = "0";
        string andrewusecaselat = "0";
        string addylong = "0";
        string addylat = "0";

        public Form1()
        {
            //Visual Studio Given to initialize windows forms app
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Show map with given data points google maps API
            string key = "key=AIzaSyCBHEVxfj-gSGq4G4azWPqW0yf3bQgOAYc";
            string center = "center=33.937861,-84.520713";
            //string center = "center=34.01068,-83.99132";
            string zoom = "zoom=7";
            string scale = "scale=2";
            string size = "size=350x275";
            //string marker01 = "markers=size:tiny%7Ccolor:red%7C33.93974,-84.52169";
            //string marker02 = "markers=size:tiny%7Ccolor:blue%7C0,0";
            //Markers for everyone's long and lat at 3 different points
            string marker03 = "markers=size:tiny%7Ccolor:"+andrewcolor1+"%7C"+andrewlatitude+","+andrewlongitude;
            string marker04 = "markers=size:tiny%7Ccolor:" + kwamecolor1 + "%7C" + kwamelatitude + "," + kwamelongitude;
            string marker05 = "markers=size:tiny%7Ccolor:" + michaelcolor1 + "%7C" + michaellatitude + "," + michaellongitude;
            string marker06 = "markers=size:tiny%7Ccolor:" + johncolor1 + "%7C" + johnlatitude + "," + johnlongitude;
            string marker07 = "markers=size:tiny%7Ccolor:" + andrewcolor2 + "%7C" + andrewlatitude2 + "," + andrewlongitude2;
            string marker08 = "markers=size:tiny%7Ccolor:" + andrewcolor3 + "%7C" + andrewlatitude3 + "," + andrewlongitude3;
            string marker09 = "markers=size:tiny%7Ccolor:" + kwamecolor2 + "%7C" + kwamelatitude2 + "," + kwamelongitude2;
            string marker10 = "markers=size:tiny%7Ccolor:" + kwamecolor3 + "%7C" + kwamelatitude3 + "," + kwamelongitude3;
            string marker11 = "markers=size:tiny%7Ccolor:" + michaelcolor2 + "%7C" + michaellatitude2 + "," + michaellongitude2;
            string marker12 = "markers=size:tiny%7Ccolor:" + michaelcolor3 + "%7C" + michaellatitude3 + "," + michaellongitude3;
            string marker13 = "markers=size:tiny%7Ccolor:" + johncolor2 + "%7C" + johnlatitude2 + "," + johnlongitude2;
            string marker14 = "markers=size:tiny%7Ccolor:" + johncolor3 + "%7C" + johnlatitude3 + "," + johnlongitude3;

            //Other group long and lat
            string marker15 = "markers=size:tiny%7Ccolor:red%7C" + paullat+","+paullon;
            string marker16 = "markers=size:tiny%7Ccolor:red%7C" + addylat + "," + addylong;
            string marker17 = "markers=size:tiny%7Ccolor:red%7C" + andrewusecaselat + "," + andrewusecaselong;
            //Show map
            string other = "style=feature:poi|element:labels|visibility:off&";
            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://maps.googleapis.com/maps/api/staticmap?" + center + "&" + zoom + "&" 
                + scale + "&" + size + "&" + other + key +"&"+marker03+"&"+marker04+ "&" + marker05+ "&" + 
                marker06+ "&" + marker07+"&"+marker08+"&"+marker09 + "&" +marker10 + "&" +marker11
                + "&" +marker12 + "&" +marker13 + "&" +marker14+"&"+marker15+"&"+marker16+"&"+marker17);
            //Go to the address given and show it on the form app
            webBrowser1.Navigate(queryaddress.ToString());
        }

        //Test to make sure connection is working
        private void button2_Click(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            byte[] arr = client.DownloadData("http://10.8.0.9:4020/Andrew");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            textBox8.Text = thecloudresp;
        }

        //Another test to make sure connection is working
        private void button3_Click(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            byte[] arr = client.DownloadData("http://10.8.0.9:4020/John");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            textBox8.Text = thecloudresp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Start collecting data from Andrew BBB and photo resistor
            timer4.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Start collecting data from Kwame BBB and photo resistor
            timer7.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Start collecting data from Michael BBB and photo resistor
            timer10.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Start collecting data from John BBB and photo resistor
            timer13.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Photo API call
            byte[] arr = client.DownloadData("http://10.8.0.9:4020/photo");
            string thecloudresp = Encoding.UTF8.GetString(arr);
            textBox13.Text = thecloudresp;
            float thecloudresp2 = float.Parse(thecloudresp);
            andrewUseCase = thecloudresp2;

            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Latitude API call
            arr = client.DownloadData("http://10.8.0.9:4020/lat");

            thecloudresp = Encoding.UTF8.GetString(arr);
            textBox1.Text = thecloudresp;
            andrewusecaselat = thecloudresp;

            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Latitude API call
            arr = client.DownloadData("http://10.8.0.9:4020/lon");

            thecloudresp = Encoding.UTF8.GetString(arr);
            textBox9.Text = thecloudresp;
            andrewusecaselong = thecloudresp;

            if(andrewUseCase >= .5)
            {
                client = new WebClient();
                client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                //Paul group's sensor
                arr = client.DownloadData("http://136.55.163.58:4020/api/paul/temp");

                thecloudresp = Encoding.UTF8.GetString(arr);
                textBox12.Text = thecloudresp;
                thecloudresp2 = float.Parse(thecloudresp);
                paulTemp = thecloudresp2;

                client = new WebClient();
                client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                //Paul group's sensor
                arr = client.DownloadData("http://136.55.163.58:4020/api/paul/lat");

                thecloudresp = Encoding.UTF8.GetString(arr);
                textBox10.Text = thecloudresp;
                paullat = thecloudresp;

                client = new WebClient();
                client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                //Paul group's longitude
                arr = client.DownloadData("http://136.55.163.58:4020/api/paul/long");

                thecloudresp = Encoding.UTF8.GetString(arr);
                textBox11.Text = thecloudresp;
                paullon = thecloudresp;

                if(paulTemp >= 70)
                {
                    client = new WebClient();
                    client.Headers["User-Agent"] =
                        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                    //Addison group's pressure api call
                    arr = client.DownloadData("http://10.8.0.7:4020/addy/pres");

                    thecloudresp = Encoding.UTF8.GetString(arr);
                    textBox29.Text = thecloudresp;
                    thecloudresp2 = float.Parse(thecloudresp);
                    addisonBar = thecloudresp2;


                    client = new WebClient();
                    client.Headers["User-Agent"] =
                        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                    //Addison group's latitude api call
                    arr = client.DownloadData("http://10.8.0.7:4020/addy/lat");

                    thecloudresp = Encoding.UTF8.GetString(arr);
                    textBox30.Text = thecloudresp;
                    addylat = thecloudresp;

                    client = new WebClient();
                    client.Headers["User-Agent"] =
                        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                    //Addison group's longitude api call
                    arr = client.DownloadData("http://10.8.0.7:4020/addy/long");

                    thecloudresp = Encoding.UTF8.GetString(arr);
                    textBox31.Text = thecloudresp;
                    addylong = thecloudresp;

                    if(addisonBar >= 900)
                    {
                        client = new WebClient();
                        client.Headers["User-Agent"] =
                            "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                        client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                        //Tells BBB to turn red LED on
                        arr = client.DownloadData("http://10.8.0.9:4020/redLED");

                        //Gets message from BBB saying that door is opened
                        thecloudresp = Encoding.UTF8.GetString(arr);
                        textBox32.Text = thecloudresp;
                    }
                    else
                    {
                        textBox32.Text = "Pressure is not high enough.";
                        client = new WebClient();
                        client.Headers["User-Agent"] =
                            "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                        client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                        //Tells BBB to turn green LED on
                        arr = client.DownloadData("http://10.8.0.9:4020/greenLED");
                    }
                }
                else
                {
                    textBox32.Text = "Vehicle is still.";
                    client = new WebClient();
                    client.Headers["User-Agent"] =
                        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                    //Tells BBB to turn green LED on
                    arr = client.DownloadData("http://10.8.0.9:4020/greenLED");
                }
            }
            else
            {
                client = new WebClient();
                client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                //Tells BBB to turn green LED on
                arr = client.DownloadData("http://10.8.0.9:4020/greenLED");

                //Gets message back that the photo resistor does not detect light
                thecloudresp = Encoding.UTF8.GetString(arr);
                textBox32.Text = thecloudresp;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Latitude API call
            byte[] arr = client.DownloadData("http://10.8.0.9:4020/lat");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            textBox1.Text = thecloudresp;
            //If statements for allowing Andrew's latitude to be collected 3 different times
            if(andrewlatitude == "0")
            {
                andrewlatitude = thecloudresp;
                textBox1.Text = thecloudresp;
            }
            else if(andrewlatitude2 == "0")
            {
                andrewlatitude2 = thecloudresp;
                textBox1.Text = thecloudresp;
            }
            else if(andrewlatitude3 == "0")
            {
                andrewlatitude3 = thecloudresp;
                textBox1.Text = thecloudresp;
                timer4.Stop();
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Longitude API call
            arr = client.DownloadData("http://10.8.0.9:4020/lon");

            thecloudresp = Encoding.UTF8.GetString(arr);
            textBox9.Text = thecloudresp;
            //If statements for allowing Andrew's longitude to be collected 3 different times
            if (andrewlongitude == "0")
            {
                andrewlongitude = thecloudresp;
                textBox9.Text = thecloudresp;
            }
            else if (andrewlongitude2 == "0")
            {
                andrewlongitude2 = thecloudresp;
                textBox9.Text = thecloudresp;
            }
            else if (andrewlongitude3 == "0")
            {
                andrewlongitude3 = thecloudresp;
                textBox9.Text = thecloudresp;
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Andrew Photo API call
            arr = client.DownloadData("http://10.8.0.9:4020/photo");

            thecloudresp = Encoding.UTF8.GetString(arr);
            textBox13.Text = thecloudresp;
            //If statements for allowing Andrew's photo resistor data to be collected 3 different times
            if (andrewphoto == "0")
            {
                andrewphoto = thecloudresp;
                textBox13.Text = thecloudresp;
                textBox17.Text = thecloudresp;
                float thecloudresp2 = float.Parse(thecloudresp);
                //Determines if on campus light level is high or low
                if (thecloudresp2 > .25)
                {
                    andrewcolor1 = "yellow";
                }
                else
                {
                    andrewcolor1 = "black";
                }
            }
            else if (andrewphoto2 == "0")
            {
                andrewphoto2 = thecloudresp;
                textBox13.Text = thecloudresp;
                textBox18.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    andrewcolor2 = "yellow";
                }
                else
                {
                    andrewcolor2 = "black";
                }
            }
            else //if //(andrewphoto3 == "0")
            {
                andrewphoto3 = thecloudresp;
                textBox13.Text = thecloudresp;
                textBox19.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    andrewcolor3 = "yellow";
                }
                else
                {
                    andrewcolor3 = "black";
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Kwame Latitude API call
            byte[] arr = client.DownloadData("http://10.8.0.18:4020/lat");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Kwame's latitude data to be collected 3 different times
            if (kwamelatitude == "0")
            {
                kwamelatitude = thecloudresp;
                textBox2.Text = thecloudresp;
            }
            else if (kwamelatitude2 == "0")
            {
                kwamelatitude2 = thecloudresp;
                textBox2.Text = thecloudresp;
            }
            else if (kwamelatitude3 == "0")
            {
                kwamelatitude3 = thecloudresp;
                textBox2.Text = thecloudresp;
                timer7.Stop();
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Kwame Longitude API call
            arr = client.DownloadData("http://10.8.0.18:4020/lon");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Kwame's longitude data to be collected 3 different times
            if (kwamelongitude == "0")
            {
                kwamelongitude = thecloudresp;
                textBox3.Text = thecloudresp;
            }
            else if (kwamelongitude2 == "0")
            {
                kwamelongitude2 = thecloudresp;
                textBox3.Text = thecloudresp;
            }
            else if (kwamelongitude3 == "0")
            {
                kwamelongitude3 = thecloudresp;
                textBox3.Text = thecloudresp;
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Kwame Photo API call
            arr = client.DownloadData("http://10.8.0.18:4020/photo");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Kwame's photo resistor data to be collected 3 different times
            if (kwamephoto == "0")
            {
                kwamephoto = thecloudresp;
                textBox14.Text = thecloudresp;
                textBox20.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    kwamecolor1 = "yellow";
                }
                else
                {
                    kwamecolor1 = "black";
                }
            }
            else if (kwamephoto2 == "0")
            {
                kwamephoto2 = thecloudresp;
                textBox14.Text = thecloudresp;
                textBox21.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    kwamecolor2 = "yellow";
                }
                else
                {
                    kwamecolor2 = "black";
                }
            }
            else if (kwamephoto3 == "0")
            {
                kwamephoto3 = thecloudresp;
                textBox14.Text = thecloudresp;
                textBox22.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    kwamecolor3 = "yellow";
                }
                else
                {
                    kwamecolor3 = "black";
                }
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Michael Latitude API call
            byte[] arr = client.DownloadData("http://10.8.0.22:8020/lat");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Michael's latitude data to be collected 3 different times
            if (michaellatitude == "0")
            {
                michaellatitude = thecloudresp;
                textBox4.Text = thecloudresp;
            }
            else if (michaellatitude2 == "0")
            {
                michaellatitude2 = thecloudresp;
                textBox4.Text = thecloudresp;
            }
            else if (michaellatitude3 == "0")
            {
                michaellatitude3 = thecloudresp;
                textBox4.Text = thecloudresp;
                timer10.Stop();
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Michael Longitude API call
            arr = client.DownloadData("http://10.8.0.22:8020/lon");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Michael's longitude data to be collected 3 different times
            if (michaellongitude == "0")
            {
                michaellongitude = thecloudresp;
                textBox5.Text = thecloudresp;
            }
            else if (michaellongitude2 == "0")
            {
                michaellongitude2 = thecloudresp;
                textBox5.Text = thecloudresp;
            }
            else if (michaellongitude3 == "0")
            {
                michaellongitude3 = thecloudresp;
                textBox5.Text = thecloudresp;
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //Michael Photo API call
            arr = client.DownloadData("http://10.8.0.22:8020/photo");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing Michael's photo resistor data to be collected 3 different times
            if (michaelphoto == "0")
            {
                michaelphoto = thecloudresp;
                textBox15.Text = thecloudresp;
                textBox23.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    michaelcolor1 = "yellow";
                }
                else
                {
                    michaelcolor1 = "black";
                }
            }
            else if (michaelphoto2 == "0")
            {
                michaelphoto2 = thecloudresp;
                textBox15.Text = thecloudresp;
                textBox24.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    michaelcolor2 = "yellow";
                }
                else
                {
                    michaelcolor2 = "black";
                }
            }
            else if (michaelphoto3 == "0")
            {
                michaelphoto3 = thecloudresp;
                textBox15.Text = thecloudresp;
                textBox25.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    michaelcolor3 = "yellow";
                }
                else
                {
                    michaelcolor3 = "black";
                }
            }
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //John Latitude API call
            byte[] arr = client.DownloadData("http://10.8.0.17:4020/lat");

            string thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing John's latitude data to be collected 3 different times
            if (johnlatitude == "0")
            {
                johnlatitude = thecloudresp;
                textBox6.Text = thecloudresp;
            }
            else if (johnlatitude2 == "0")
            {
                johnlatitude2 = thecloudresp;
                textBox6.Text = thecloudresp;
            }
            else if (johnlatitude3 == "0")
            {
                johnlatitude3 = thecloudresp;
                textBox6.Text = thecloudresp;
                timer13.Stop();
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //John Longitude API call
            arr = client.DownloadData("http://10.8.0.17:4020/lon");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing John's longitude data to be collected 3 different times
            if (johnlongitude == "0")
            {
                johnlongitude = thecloudresp;
                textBox7.Text = thecloudresp;
            }
            else if (johnlongitude2 == "0")
            {
                johnlongitude2 = thecloudresp;
                textBox7.Text = thecloudresp;
            }
            else if (johnlongitude3 == "0")
            {
                johnlongitude3 = thecloudresp;
                textBox7.Text = thecloudresp;
            }

            // Create web client simulating IE6.
            client = new WebClient();
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
            //John Photo API call
            arr = client.DownloadData("http://10.8.0.17:4020/photo");

            thecloudresp = Encoding.UTF8.GetString(arr);
            //If statements for allowing John's photo resistor data to be collected 3 different times
            if (johnphoto == "0")
            {
                johnphoto = thecloudresp;
                textBox16.Text = thecloudresp;
                textBox26.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    johncolor1 = "yellow";
                }
                else
                {
                    johncolor1 = "black";
                }
            }
            else if (johnphoto2 == "0")
            {
                johnphoto2 = thecloudresp;
                textBox16.Text = thecloudresp;
                textBox27.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    johncolor2 = "yellow";
                }
                else
                {
                    johncolor2 = "black";
                }
            }
            else if (johnphoto3 == "0")
            {
                johnphoto3 = thecloudresp;
                textBox16.Text = thecloudresp;
                textBox28.Text = thecloudresp;
                //Determines if on campus light level is high or low
                float thecloudresp2 = float.Parse(thecloudresp);
                if (thecloudresp2 > .25)
                {
                    johncolor3 = "yellow";
                }
                else
                {
                    johncolor3 = "black";
                }
            }
        }
    }
}