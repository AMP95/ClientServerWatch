using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WhatchServer
{
    class TcpConnector
    {
        public TcpClient Client { get; private set; }
        TcpListener _listener;
        public TcpConnector() {
            _listener = new TcpListener(IPAddress.Any, 8888);
        }
        public void WaitClient() {
            _listener.Start();
            Console.WriteLine("Ожидание подключения...");
            Client = _listener.AcceptTcpClient();
            Console.WriteLine("Клиент подключен.");
        }
        public void SendMessage(string message) {
            NetworkStream stream = Client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(message + "\n");
            writer.Flush();
        }
        public bool IsConnected() {
            return Client.Connected;
        }
    }
}
