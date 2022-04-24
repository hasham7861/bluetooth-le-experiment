using System;
using System.Threading;
using System.Timers;
using InTheHand.Net.Sockets;

namespace BTConnector
{
    class Program
    {
        static void Main(string[] args)
        {

            //The main console ui
            while (true)
            {
                Console.WriteLine("Type l for listening to new devices");
                Console.WriteLine("Type x for quiting program");
                Console.WriteLine("Type c for connecting to device");

                char command = Console.ReadLine()[0];

                if(command == 'x')
                {
                    break;
                } else if (command == 'l')
                {
                    startDeviceListener();
                } else if(command == 'c')
                {
                    Console.WriteLine("Type the name of device you want to pair with");
                    string inputedDeviceName = Console.ReadLine(); 
                    // TODO: make use of this device name to attemp to pair with the device found in listening or start listening again

                }
            }
        }


        private static void startDeviceListener()
        {



            BluetoothClient client = new BluetoothClient();

            Console.WriteLine("Listening for bluetooth devices");



            foreach (var dev in client.DiscoverDevices())
            {
                Console.WriteLine("hello device:" + "-" + dev.DeviceAddress + "-" + dev.DeviceName);
            }


            client.Close();

        }

    }
  
}