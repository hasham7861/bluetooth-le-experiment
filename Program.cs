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
                Console.WriteLine("Type x for quiting program");
                Console.WriteLine("Type c for connecting to device");

                char command = Console.ReadLine()[0];

                if(command == 'x')
                {
                    client.Close();
                    break;
                } 
                else if(command == 'c')
                {
                    scanAndGetAllDevices(client, devices);
                    Console.WriteLine("Type the name of device you want to pair with");
                    string inputedDeviceName = Console.ReadLine();

                    // TODO: fix code for connecting to bluetooth device
                    if(devices.TryGetValue(inputedDeviceName, out BluetoothDeviceInfo device))
                    {
                       
                        // This step is just for connecting to headset, and will require you to click on the notification on bottom right to click tap to connect bluetooth device
                        device.SetServiceState(BluetoothService.Handsfree, false);
                        BluetoothEndPoint ep = new BluetoothEndPoint(device.DeviceAddress, BluetoothService.Handsfree);
                        client.BeginConnect(ep, (data) => { Console.WriteLine("connecting..."); },true);
                    }

                }
            }
        }


        private static void scanAndGetAllDevices(BluetoothClient client, Dictionary<string, BluetoothDeviceInfo> devices)
        {
            Console.WriteLine("Discovering Devices...");
            foreach (var dev in client.DiscoverDevices())
            {
                Console.WriteLine("hello device:" + "-" + dev.DeviceAddress + "-" + dev.DeviceName);
                if(devices.TryGetValue(dev.DeviceName, out BluetoothDeviceInfo device) == false)
                {
                    devices.Add(dev.DeviceName, dev);
                }
               
            }
        }



    }
  
}