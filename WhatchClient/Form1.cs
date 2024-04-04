using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace WhatchClient
{
    public partial class Form1 : Form
    {
        TcpConnector _connector;
        Thread _thread;
        public Form1()
        {
            InitializeComponent();
            _connector = new TcpConnector("127.0.0.1", 8888);
            Task.Run(WaitServerMessage);
        }
        public void WaitServerMessage() {
            while (_connector.IsConnected())
            {
                string message = _connector.RecieveMessage();
                if (message != null && message != "")
                    label1.Invoke(new Action(()=> { label1.Text = message; }));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
             _connector.SendMessage(TimeZoneInfo.Local.Id);
        }
    }
}
