using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCalcolatriceLatoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte RESULTS_COMMAND = 0;

            Console.WriteLine("Insert server's IP: ");
            string address = Console.ReadLine();

            Console.WriteLine("Insert server's port: ");
            int port = int.Parse(Console.ReadLine());
            Console.Clear();

            Server server = new Server(address, port);
            byte ChoseMenu;
            float num1, num2;

            while (true)
            {
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("| ----------Quale Operazione Vuoi Effettuare?---------- |");
                Console.WriteLine("| 1) Somma                                              |");
                Console.WriteLine("| 2) Sottrazione                                        |");
                Console.WriteLine("| 3) Divisione                                          |");
                Console.WriteLine("| 4) Moltiplicazione                                    |");
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("Inserisci il numero corrispondente:");
                ChoseMenu = byte.Parse(Console.ReadLine());

                Console.WriteLine("Inserisci il primo numero:");
                num1 = float.Parse(Console.ReadLine());

                Console.WriteLine("Inserisci il secondo numero:");
                num2 = float.Parse(Console.ReadLine());

                server.Send(new Packet(ChoseMenu, num1, num2));

                byte[] data = server.Recive();

                if (data[0] != RESULTS_COMMAND)
                    throw new Exception("Somethings gone wrong, sorry");

                float result = BitConverter.ToSingle(data, 1);
                Console.WriteLine("Il risultato è: "+result);
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
