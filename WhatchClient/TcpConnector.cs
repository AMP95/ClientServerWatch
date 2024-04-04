using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WhatchClient
{
    class TcpConnector
    {
        TcpClient _client;
        NetworkStream _stream;

        public TcpConnector(string IP, int port) {
            _client = new TcpClient(IP, port);
        }
        public void SendMessage(string messsage) {
            _stream = _client.GetStream();
            StreamWriter writer = new StreamWriter(_stream);
            writer.WriteLine(messsage);
            writer.Flush();
        }
        public string RecieveMessage() {
            _stream = _client.GetStream();
            StreamReader reader = new StreamReader(_stream);
            return reader.ReadLine();
        }
        public bool IsConnected() {
            return _client.Connected;
        }
    }
}
