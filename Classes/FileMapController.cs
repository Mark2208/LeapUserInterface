using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace LeapUserInterface.Classes
{


    public enum ThreadSignal
    {
        On, Off
    }

    public class FileMapController
    {
        DateTime deltaTime = DateTime.Now;
        MainWindow instance;

        //Define FileMap names
        public const string FM_HAS_HANDS = "FM_HasHands";
        public const string FM_LPALM_POS = "FM_LPalm";

        public const string FM_IS_LQ1 = "FM_LQ1";
        public const string FM_IS_LQ2 = "FM_LQ2";
        public const string FM_IS_LQ3 = "FM_LQ3";
        public const string FM_IS_LQ6 = "FM_LQ6";
        public const string FM_IS_LQ7 = "FM_LQ7";
        public const string FM_IS_LQ8 = "FM_LQ8";

        public const string FM_IS_L_PINCH = "FM_LPinch";
        public const string FM_IS_L_GRAB = "FM_LGrab";

        public const string FM_IS_L_SWIPE_L = "FM_LSwipeL";
        public const string FM_IS_L_SWIPE_R = "FM_LSwipeR";

        public const string FM_R_POS = "FM_RPos";
        public const string FM_R_PINCH = "FM_RPinch";




        //Create File Maps
        public List<FileMapHandler> FileMapHandles = new List<FileMapHandler> {
            new FileMapHandler(FM_HAS_HANDS,2),
            new FileMapHandler(FM_LPALM_POS,15), //Left Palm Position(X;Y)
            new FileMapHandler(FM_IS_L_PINCH,2), //is Left Pinch(0 or 1)
            new FileMapHandler(FM_IS_L_GRAB,2), //is Palm Grabbing
            new FileMapHandler(FM_IS_LQ1,2),
            new FileMapHandler(FM_IS_LQ2,2),
            new FileMapHandler(FM_IS_LQ3,2),
            new FileMapHandler(FM_IS_LQ6,2),
            new FileMapHandler(FM_IS_LQ7,2),
            new FileMapHandler(FM_IS_LQ8,2),

            new FileMapHandler(FM_IS_L_SWIPE_L,2),
            new FileMapHandler(FM_IS_L_SWIPE_R,2),

            new FileMapHandler(FM_R_POS,15),
            new FileMapHandler(FM_R_PINCH,2)
 

        };

        public ThreadSignal TRACKING_SIGNAL;
        public Thread trackingThread_instance;


        public FileMapController(MainWindow _instance)
        {
            instance = _instance;
        }

        public FileMapHandler GetFileMap(string filemapName)
        {
            FileMapHandler dummyMap = new FileMapHandler("NULL", 0);
            foreach (FileMapHandler fileMap in FileMapHandles)
            {
                if (String.Equals(fileMap.Name, filemapName))
                {
                    return fileMap;
                }
            }
            return dummyMap;
        }

       public bool FM_GetFlagState(string filemapName)
       {

            FileMapHandler fileMap = GetFileMap(filemapName);
            
            string off = "0";
            if (!String.Equals(fileMap.Message, off) &&
                (!String.Equals(fileMap.Message, "")))

            { return true; }
            else { return false; }

         
       }

        public void FM_SetFlagState(string filemapName, string message)
        {
            FileMapHandler fileMap = GetFileMap(filemapName);
            fileMap.Message = message;
               

        }

        public String FM_GetMessage(string fileMapName)
        {
            FileMapHandler fileMap = GetFileMap(fileMapName);
            return fileMap.Message;
                
        }


        public bool FM_WasHeld(string fileMapName, double time_sec)
        {
            FileMapHandler fileMap = GetFileMap(fileMapName);
            if (fileMap.HoldTimeOn > TimeSpan.FromSeconds(time_sec))
            {
                fileMap.HoldTimeOn = TimeSpan.FromSeconds(0);
                return true;
            }
            else return false;
        }

        public bool FM_WasNotHeld(string fileMapName, double time_sec)
        {
            FileMapHandler fileMap = GetFileMap(fileMapName);
            if (fileMap.HoldTimeOff > TimeSpan.FromSeconds(time_sec))
            {
                fileMap.HoldTimeOff = TimeSpan.FromSeconds(0);
                return true;
            }
            else return false;
        }



        public bool IsLeftPinching()
        {
            if (FM_GetFlagState(FM_HAS_HANDS))
            {
                if(FM_GetFlagState(FM_IS_L_PINCH) || FM_GetFlagState(FM_IS_L_GRAB))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool IsRightPinching()
        {
            return FM_GetFlagState(FM_R_PINCH);
        }
        private void UpdateHoldTimes()
        {

            TimeSpan deltaTimeSpan = DateTime.Now - deltaTime;
            deltaTime = DateTime.Now;

            string off = "0";

            foreach (FileMapHandler fileMap in FileMapHandles)
            {
                if (String.Equals(fileMap.Message, off) || String.Equals(fileMap.Message,""))
                {
                    fileMap.HoldTimeOn = TimeSpan.FromSeconds(0);
                    fileMap.HoldTimeOff += deltaTimeSpan;
                }
                if (!String.Equals(fileMap.Message, off) && !String.Equals(fileMap.Message, ""))
                {
                    
                    fileMap.HoldTimeOn += deltaTimeSpan;
                    fileMap.HoldTimeOff = TimeSpan.FromSeconds(0);
                }
            }

        }

        public void Update()
        {

            UpdateHoldTimes();

            if (!FM_GetFlagState(FM_LPALM_POS))
            {
                instance.radial_left.IsEnabled = false;
            }

            if (FM_GetFlagState(FM_LPALM_POS))
            {
                instance.radial_left.IsEnabled = true;
            }

            if (FM_GetFlagState(FM_R_POS))
            {
                instance.cursor.Show();
            }
            else instance.cursor.Hide();


            if (instance.performer.IsPerformingAction == false && FM_GetFlagState(FM_HAS_HANDS) == true)
            {
                //Locks the Window thread from interruption
                instance.performer.IsPerformingAction = true;

                if (FM_GetFlagState(FM_IS_L_PINCH))
                {
                    if (FM_WasHeld(FM_IS_L_PINCH, 1)) { instance.performer.PausePlay(); }
                }

                if (FM_GetFlagState(FM_IS_L_GRAB))
                {
                    if (FM_WasHeld(FM_IS_L_GRAB, 2)) { instance.performer.SwitchTask("2"); }
                }

                if (FM_GetFlagState(FM_IS_L_SWIPE_L))
                {
                    if(FM_WasHeld(FM_IS_L_SWIPE_L, 0.025) && FM_WasNotHeld(FM_IS_L_SWIPE_R, 1)) { instance.performer.SkipBack(); FM_WasHeld(FM_IS_L_SWIPE_L, 0); }
                }

                if (FM_GetFlagState(FM_IS_L_SWIPE_R))
                {
        
                    if (FM_WasHeld(FM_IS_L_SWIPE_R, 0.025) && FM_WasNotHeld(FM_IS_L_SWIPE_L,1)) { instance.performer.SkipForward(); FM_WasHeld(FM_IS_L_SWIPE_L, 0); }
                }
               
                if (FM_GetFlagState(FM_IS_LQ1))
                {
                    if (FM_WasHeld(FM_IS_LQ1, 1.5)) { instance.performer.ScrollUp(); }
                }

                if (FM_GetFlagState(FM_IS_LQ2))
                {
                    if (FM_WasHeld(FM_IS_LQ2, 1.5)) { instance.performer.TabRight(); }
                }
                if (FM_GetFlagState(FM_IS_LQ3))
                {
                    if (FM_WasHeld(FM_IS_LQ3, 1.5)) { instance.performer.VolumeUp(); }
                }
                if (FM_GetFlagState(FM_IS_LQ6))
                {
                    if (FM_WasHeld(FM_IS_LQ6, 1.5)) { instance.performer.VolumeDown(); }
                }
                if (FM_GetFlagState(FM_IS_LQ7))
                {
                    if (FM_WasHeld(FM_IS_LQ7, 1.5)) { instance.performer.TabLeft(); }
                }
                if (FM_GetFlagState(FM_IS_LQ8))
                {
                    if (FM_WasHeld(FM_IS_LQ8, 1.5)) { instance.performer.ScrollDown(); }
                }


                if (FM_GetFlagState(FM_R_PINCH))
                {
                    if (FM_WasHeld(FM_R_PINCH, 1)) { instance.performer.MouseClick(instance.cursor.Left + instance.cursor.CursorRadius, instance.cursor.Top + instance.cursor.CursorRadius, instance.cursor); }
                }

                
                instance.performer.IsPerformingAction = false;


            }

        }


    }
}
