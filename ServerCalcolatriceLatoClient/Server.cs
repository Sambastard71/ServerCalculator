using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCalcolatriceLatoClient
{
    class Server
    {
        EndPoint serverEndPoint;
        Socket socket;

        public Server(string address, int port)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Send(Packet packet)
        {
            socket.SendTo(packet.GetData(), serverEndPoint);
        }

        public byte[] Recive()
        {
            byte[] data = new byte[256];
            socket.Receive(data);
            
            return data;
        }
    }
}
