using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCalcolatrice
{
    public class Packet
    {
        private MemoryStream stream;
        private BinaryWriter writer;

        private static uint packetCounter;
        
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
        }

        public Packet()
        {
            stream = new MemoryStream();
            writer = new BinaryWriter(stream);
            id = ++packetCounter;
        }

        public Packet(params object[] elements) : this()
        {
            foreach (object element in elements)
            {
                if (element is byte)
                {
                    writer.Write((byte)element);
                }
                else if (element is float)
                {
                    writer.Write((float)element);
                }
                else
                {
                    throw new Exception("unknown type");
                }
            }
        }

        public byte[] GetData()
        {
            return stream.ToArray();
        }
    }
}
