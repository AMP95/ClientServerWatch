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
    class WhatchSender
    {
        TcpConnector _connector;
        public WhatchSender() {
            _connector = new TcpConnector();
        }
        public void Start() {
              _connector.WaitClient();
              while (_connector.IsConnected())
              {
                  ResieveMessage();
              }
        }
        void ResieveMessage() {
            NetworkStream stream = _connector.Client.GetStream();
            StreamReader reader = new StreamReader(stream);
            string messageFromClient = reader.ReadLine();
            if (messageFromClient != null)
            {
                Console.WriteLine(messageFromClient);
                string messageToClient = TimeConverter(messageFromClient).ToString();
                _connector.SendMessage(messageToClient);
                Console.WriteLine(messageToClient);
            }
        }
        DateTime TimeConverter(string message) {
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(message);
            DateTime time =  TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
            return time;
        }
    }
}
