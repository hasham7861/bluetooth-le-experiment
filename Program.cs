using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BTConnector
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, BluetoothDeviceInfo> devices = new Dictionary<string, BluetoothDeviceInfo>();
            BluetoothClient client = new BluetoothClient();

            //The main console ui
            while (true)
            {
                Console.WriteLine("Type l for listening to new devices");
                Console.WriteLine("Type x for quiting program");
                Console.WriteLine("Type c for connecting to device");

                char command = Console.ReadLine()[0];

                if(command == 'x')
                {
                    client.Close();
                    break;
                } else if (command == 'l')
                {
                    scanAndGetAllDevices(client, devices);
                } else if(command == 'c')
                {
                    scanAndGetAllDevices(client, devices);
                    Console.WriteLine("Type the name of device you want to pair with");
                    string inputedDeviceName = Console.ReadLine();
                    // TODO: make use of this device name to attemp to pair with the device found in listening or start listening again

                    // TODO: fix code for connecting to bluetooth device
                    //if(devices.TryGetValue(inputedDeviceName, out BluetoothDeviceInfo device))
                    //{
                    //    BluetoothEndPoint ep = new BluetoothEndPoint(device.DeviceAddress, serviceClass);
                    //    client.Connect(ep);
                    //}

                }
            }
        }


        private static void scanAndGetAllDevices(BluetoothClient client, Dictionary<string, BluetoothDeviceInfo> devices)
        {
            Console.WriteLine("Discovering Devices...");
            foreach (var dev in client.DiscoverDevices())
            {
                Console.WriteLine("hello device:" + "-" + dev.DeviceAddress + "-" + dev.DeviceName);
                devices.Add(dev.DeviceName, dev);
            }
        }



    }
  
}