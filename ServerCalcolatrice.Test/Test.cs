using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ServerCalcolatrice.Test
{
    class Test
    {
        FakeTransport transport;
        Server server;

        [SetUp]
        public void SetUpTest()
        {
            transport = new FakeTransport();
            server = new Server(transport);
        }

        [Test]
        public void TestSumCommandBothPositive()
        {
            transport.ClientEnqueue(new Packet((byte)1, 2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(4.0f));
        }

        [Test]
        public void TestSubtractionCommandBothPositive()
        {
            transport.ClientEnqueue(new Packet((byte)2, 2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestDivisionCommandBothPositive()
        {
            transport.ClientEnqueue(new Packet((byte)3, 2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void TestMultiplicationCommandBothPositive()
        {
            transport.ClientEnqueue(new Packet((byte)4, 2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(4.0f));
        }

        [Test]
        public void TestSumCommandFirstPositive()
        {
            transport.ClientEnqueue(new Packet((byte)1, 2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestSubtractionCommandFirstPositive()
        {
            transport.ClientEnqueue(new Packet((byte)2, 2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(4.0f));
        }

        [Test]
        public void TestDivisionCommandFirstPositive()
        {
            transport.ClientEnqueue(new Packet((byte)3, 2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void TestMultiplicationCommandFirstPositive()
        {
            transport.ClientEnqueue(new Packet((byte)4, 2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-4.0f));
        }

        [Test]
        public void TestSumCommandSecondPositive()
        {
            transport.ClientEnqueue(new Packet((byte)1, -2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestSubtractionCommandSecondPositive()
        {
            transport.ClientEnqueue(new Packet((byte)2, -2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-4.0f));
        }

        [Test]
        public void TestDivisionCommandSecondPositive()
        {
            transport.ClientEnqueue(new Packet((byte)3, -2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void TestMultiplicationCommandSecondPositive()
        {
            transport.ClientEnqueue(new Packet((byte)4, -2.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-4.0f));
        }

        [Test]
        public void TestSumCommandBothNegative()
        {
            transport.ClientEnqueue(new Packet((byte)1, -2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-4.0f));
        }

        [Test]
        public void TestSubtractionCommandBothNegative()
        {
            transport.ClientEnqueue(new Packet((byte)2, -2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestDivisionCommandBothNegative()
        {
            transport.ClientEnqueue(new Packet((byte)3, -2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void TestMultiplicationCommandBothNegative()
        {
            transport.ClientEnqueue(new Packet((byte)4, -2.0f, -2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(4.0f));
        }

        [Test]
        public void TestSumCommandBothZero()
        {
            transport.ClientEnqueue(new Packet((byte)1, 0.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestSubtractionCommandBothZero()
        {
            transport.ClientEnqueue(new Packet((byte)2, 0.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestDivisionCommandBothZero()
        {
            transport.ClientEnqueue(new Packet((byte)3, 0.0f, 0.0f), "Samba", 9999);
            
            Assert.That(() => server.SingleStep(), Throws.InstanceOf<DivideByZeroException>());
        }

        [Test]
        public void TestMultiplicationCommandBothZero()
        {
            transport.ClientEnqueue(new Packet((byte)4, 0.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestSumCommandFirstZero()
        {
            transport.ClientEnqueue(new Packet((byte)1, 0.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(2.0f));
        }

        [Test]
        public void TestSubtractionCommandFirstZero()
        {
            transport.ClientEnqueue(new Packet((byte)2, 0.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(-2.0f));
        }

        [Test]
        public void TestDivisionCommandFirstZero()
        {
            transport.ClientEnqueue(new Packet((byte)3, 0.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestMultiplicationCommandFirstZero()
        {
            transport.ClientEnqueue(new Packet((byte)4, 0.0f, 2.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestSumCommandSecondZero()
        {
            transport.ClientEnqueue(new Packet((byte)1, 2.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(2.0f));
        }

        [Test]
        public void TestSubtractionCommandSecondZero()
        {
            transport.ClientEnqueue(new Packet((byte)2, 2.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(2.0f));
        }

        [Test]
        public void TestDivisionCommandSecondZero()
        {
            transport.ClientEnqueue(new Packet((byte)3, 2.0f, 0.0f), "Samba", 9999);

            Assert.That(() => server.SingleStep(), Throws.InstanceOf<DivideByZeroException>());
        }

        [Test]
        public void TestMultiplicationCommandSecondZero()
        {
            transport.ClientEnqueue(new Packet((byte)4, 2.0f, 0.0f), "Samba", 9999);

            server.SingleStep();

            FakeData data = transport.ClientDequeue();
            float result = BitConverter.ToSingle(data.data, 1);
            Assert.That(result, Is.EqualTo(0.0f));
        }

    }
}
