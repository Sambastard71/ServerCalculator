using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCalcolatrice
{
    public class Server
    {
        private delegate void GameCommand(byte[] data, EndPoint sender);

        private Dictionary<byte, GameCommand> commandsTable;
        byte RESULT_COMMAND = 0;

        private void Sum(byte[] data, EndPoint sender)
        {
            float num1 = BitConverter.ToSingle(data, 1);
            float num2 = BitConverter.ToSingle(data, 5);

            float result = num1 + num2;

            Packet resultPacket = new Packet(RESULT_COMMAND, result);
            Send(resultPacket, sender);

            Console.WriteLine(BitConverter.ToString(resultPacket.GetData()));
        }

        private void Subtraction(byte[] data, EndPoint sender)
        {
            float num1 = BitConverter.ToSingle(data, 1);
            float num2 = BitConverter.ToSingle(data, 5);

            float result = num1 - num2;

            Packet resultPacket = new Packet(RESULT_COMMAND, result);
            Send(resultPacket, sender);

            Console.WriteLine(BitConverter.ToString(resultPacket.GetData()));

        }

        private void Division(byte[] data, EndPoint sender)
        {
            float num1 = BitConverter.ToSingle(data, 1);
            float num2 = BitConverter.ToSingle(data, 5);

            if (num2 == 0)
                throw new DivideByZeroException("You Can't Divide By Zero");

            float result = num1 / num2;

            Packet resultPacket = new Packet(RESULT_COMMAND, result);
            Send(resultPacket, sender);

            Console.WriteLine(BitConverter.ToString(resultPacket.GetData()));
        }

        private void Multiplication(byte[] data, EndPoint sender)
        {
            float num1 = BitConverter.ToSingle(data, 1);
            float num2 = BitConverter.ToSingle(data, 5);

            float result = num1 * num2;

            Packet resultPacket = new Packet(RESULT_COMMAND, result);
            Send(resultPacket, sender);

            Console.WriteLine(BitConverter.ToString(resultPacket.GetData()));

        }

        private Itransport transport;
        
        public Server(Itransport gameTransport)
        {
            transport = gameTransport;

            commandsTable = new Dictionary<byte, GameCommand>();
            commandsTable[1] = Sum;
            commandsTable[2] = Subtraction;
            commandsTable[3] = Division;
            commandsTable[4] = Multiplication;
        }

        public void Start()
        {
            Console.WriteLine("Server Starto");

            while (true)
            {
                SingleStep();
            }
        }

        public void SingleStep()
        {
            EndPoint sender = transport.CreateEndPoint();
            byte[] data = transport.Recv(256, ref sender);

            Console.WriteLine(Encoding.UTF8.GetString(data));

            if (data != null)
            {
                byte gameCommand = data[0];
                if (commandsTable.ContainsKey(gameCommand))
                {
                    commandsTable[gameCommand](data, sender);
                }
            }
        }

        public bool Send(Packet packet, EndPoint endPoint)
        {
            return transport.Send(packet, endPoint);
        }
    }
}
