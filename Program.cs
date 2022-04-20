using System;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace BTConnector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            startDeviceWatcher();
            Console.ReadKey();

            // TODO: keep track of all the bluetooth devices that are currently available to us
            // TODO: only keep the bluetooth watcher on for some seconds upon button press
            // TODO: add command to connect to bluetooth device of choice
            
        }

        static void startDeviceWatcher()
        {
            // Query for extra properties you want returned
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

            DeviceWatcher deviceWatcher =
                         DeviceInformation.CreateWatcher(
                                 BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                 requestedProperties,
                                 DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            // Added, Updated and Removed are required to get all nearby devices
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            // EnumerationCompleted and Stopped are optional to implement.
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start the watcher.
            deviceWatcher.Start();


        }

        private static void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
            throw new NotImplementedException();
        }

        private static void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            Console.WriteLine(args);
        }

        private static void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate device)
        {
            //  Console.WriteLine(device.Id + "removed ====");
        }

        private static void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate device)
        {
          //   Console.WriteLine(device.Id + "---");
        }

        private static void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation device)
        {

          if(!String.IsNullOrEmpty(device.Name))
            {
               Console.WriteLine(device.Id + "---" + device.Name + "-" + device.IsEnabled);
            }
        }
    }
}
