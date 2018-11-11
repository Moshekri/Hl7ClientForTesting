using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hl7ClientForTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentPath = Environment.CurrentDirectory;
            var data = File.ReadAllBytes(Path.Combine(currentPath, @"Queries\QRY_Q01.txt"));// (@"F:\GitHub\ADT-Server\ADTServer\Hl7MangerTests\TestResources\QRY_Q01.txt");
            SendMessage(data);
        }

        private void SendMessage(byte[] messageBytes)
        {
            TcpClient client = new TcpClient();
           
           
            try
            {
                client.Connect(IPAddress.Parse(txtIpAddress.Text), int.Parse(txtPort.Text));
                var netStream = client.GetStream();
                netStream.Write(messageBytes, 0, messageBytes.Length);
                netStream.Close();
                client.Close();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentPath = Environment.CurrentDirectory;
            var data = File.ReadAllBytes(Path.Combine(currentPath, @"Queries\oru_r01.txt"));
            SendMessage(data);
        }
    }
}
