using System;
using InTheHand.Net.Sockets;

namespace BTConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            BluetoothClient client = new BluetoothClient();

            Console.WriteLine("Listening for bluetooth devices");

            foreach (var dev in client.DiscoverDevices())
            {
                Console.WriteLine("hello device:" + "-" + dev.DeviceAddress + "-" + dev.DeviceName);

            }

            Console.ReadLine();
        }
    }
}