using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace LeapUserInterface.Classes
{


    public class TrackerThread
    {

        MainWindow instance;
        ThreadSignal TRACKING_SIGNAL;
        Thread trackingThread_instance;
        public List<FileMapHandler> FM_Handlers { get; set; }

        public TrackerThread(MainWindow _instance)
        {
            instance = _instance;
        }

        void UpdateSystem()
        {
            instance.UpdateSystem();
        }

        void LoadHandlers()
        {
            this.FM_Handlers = instance.fileMapController.FileMapHandles;
        }

        void ReadFileMaps()
        {
            instance.Dispatcher.Invoke(() => LoadHandlers());
            while (TRACKING_SIGNAL == ThreadSignal.On)
            {
                
                string message = "";
                foreach (FileMapHandler mapHandle in FM_Handlers)
                {

                    // Assumes another process has created the memory-mapped file.
                    using (var mmf = MemoryMappedFile.CreateOrOpen(mapHandle.Name, 32))
                    {
                        using (var accessor = mmf.CreateViewAccessor())
                        {
                            byte[] strByte = new byte[mapHandle.Byte_size];
                            for (long j = 0; j < mapHandle.Byte_size; j++)
                            {
                                strByte[j] = accessor.ReadByte(j);

                            }
                            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                            message = enc.GetString(strByte);

                        }
                        if (TRACKING_SIGNAL == ThreadSignal.Off) { break; }
                        message = string.Join("", message.Split('\0'));
                        if (message[0] == 'n') { message = "0"; }
                        mapHandle.Message = message;

                    }
                }
                instance.Dispatcher.Invoke(() => UpdateSystem());
                Thread.Sleep(30);
            }

        }

        public bool IsTracking()
        {
            if (TRACKING_SIGNAL == ThreadSignal.On) { return true; }
            else return false;
        }

        public void StartTracking()
        {
            trackingThread_instance = new Thread(new ThreadStart(ReadFileMaps));
            TRACKING_SIGNAL = ThreadSignal.On;
            trackingThread_instance.Start();
        }

        public void StopTracking()
        {
            if (TRACKING_SIGNAL == ThreadSignal.On)
            {
                TRACKING_SIGNAL = ThreadSignal.Off;
                trackingThread_instance.Abort();
            }
            trackingThread_instance = null;
        }
    }
}

