﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using forms1.Modelo;
using GMap.NET;
using GMap.NET.MapProviders;
using RabbitMQ.Client;
using RestSharp;

namespace forms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            RestClient proxy = new RestClient("http://localhost:59123/Service1.svc");
            RestRequest request = new RestRequest("proyectos/" + ID, Method.GET, DataFormat.Json);
            IRestResponse<proyects> response = proxy.Execute<proyects>(request);
            textBox2.Text = response.Data.ID;
            textBox3.Text = response.Data.Nombre;
            textBox4.Text = response.Data.Ubicacion;
            textBox5.Text = response.Data.Precio;
            textBox6.Text = response.Data.estado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "moose.rmq.cloudamqp.com",
                VirtualHost = "zvgcbkxw",
                UserName = "zvgcbkxw",
                Password = "SYn_rxQDqttTasFcUpwTa7-7-5GzPUjW"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                BasicGetResult consumer = channel.BasicGet("proyecto", true);
                if (consumer != null)
                {
                    string resultado = Encoding.UTF8.GetString(consumer.Body.ToArray());
                    textBox7.Text = textBox7.Text + "\r\n" + "Mensaje: " + resultado;
                }
            }
            }

       

        private void Form1_Load(object sender, EventArgs e)
        {
          
            double lat = Convert.ToDouble("-12.0431800");
            double longt = Convert.ToDouble("-77.0282400");
            map.DragButton = MouseButtons.Right;
            map.MapProvider = GMapProviders.GoogleMap;      
            map.ShowCenter = false;
            map.Position = new PointLatLng(lat, longt);
            map.MinZoom = 3;
            map.MaxZoom = 100;
            map.Zoom = 10;

         }

        private void mapa_Click_1(object sender, EventArgs e)
        {
            if  (textBox4.Text == "La Molina")
                { 
            map.MapProvider = GMapProviders.GoogleMap;
            double lati = Convert.ToDouble("-12.076141178353835");
            double longti = Convert.ToDouble("-76.93139078718126");
            map.Position = new PointLatLng(lati, longti);
            map.MinZoom = 3;
            map.MaxZoom = 100;
            map.Zoom = 15;
            }
            else if (textBox4.Text == "Monterrico")
            {
                map.MapProvider = GMapProviders.GoogleMap;
                double lati = Convert.ToDouble("-12.109391527320884");
                double longti = Convert.ToDouble("-76.97167172629675");
                map.Position = new PointLatLng(lati, longti);
                map.MinZoom = 3;
                map.MaxZoom = 100;
                map.Zoom = 15;
            }
            else if (textBox4.Text == "Chosica")
            {
                map.MapProvider = GMapProviders.GoogleMap;
                double lati = Convert.ToDouble("-11.936177919969301");
                double longti = Convert.ToDouble("-76.69675893914795");
                map.Position = new PointLatLng(lati, longti);
                map.MinZoom = 3;
                map.MaxZoom = 100;
                map.Zoom = 15;
            }
        }
    }
}
