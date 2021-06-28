using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPConnectionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
            string host = textBox_Host.Text;
            int port = 0;
            if(!Int32.TryParse(textBox_Port.Text,out port))
            {
                MessageBox.Show("Port must be an integer!");
                return;
            }
            string username = textBox_Username.Text;
            string password = textBox_Password.Text;

            try
            {
                using (var client = new SftpClient(host, port, username, password))
                {
                    client.Connect();
                    textBoxLog.AppendText("Connected to "+host+Environment.NewLine);
                    textBoxLog.AppendText("Connection status "+client.IsConnected+Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                textBoxLog.AppendText(ex.Message);
                MessageBox.Show("Connection error:" + ex.Message);
            }
        }
    }
}
