using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FlightSimulator.Connection
{
    class Info
    {
        public bool Connected { get; set; } = false;
        public bool Stop { get; set; } = false;
        private TcpListener listener;
        private TcpClient client;
        private BinaryReader reader;



        // open server on recieved port and ip.
        public void Open(string ip, int port)
        {
            if (listener != null) Close();
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
        }

        public void Close() { if (client != null) { client.GetStream().Close(); client.Close(); } listener.Stop(); Connected = false; }

        public string[] Read()
        {
            if (!Connected)
            {
                Connected = true;
                try
                {
                    client = listener.AcceptTcpClient();
                    reader = new BinaryReader(client.GetStream());
                }
                // shutdown while trying to connect.
                catch (Exception)
                { Close(); }
            }
            
            // input variable.
            string recieved = ""; 
            char s;
            while ((s = reader.ReadChar()) != '\n') recieved += s;
            string[] param = recieved.Split(',');
            // take the longtitude and the latitude.
            string[] ret = { param[0], param[1] };
            return ret;

        }
    }
}
