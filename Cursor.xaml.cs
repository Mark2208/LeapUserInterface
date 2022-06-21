using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindowsInput;

namespace LeapUserInterface
{
    /// <summary>
    /// Interaction logic for Cursor.xaml
    /// </summary>
    public partial class Cursor : Window
    {
        public double CursorRadius;

        private double ScreenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
        private double ScreenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

        public double x = 0;
        public double y = 0;

        ThreadSignal CURSORTHREAD_SIGNAL;
        Thread CursorThread;

        public Cursor()
        {
            InitializeComponent();
            
            CursorRadius = this.Width / 2;

            StartCursorThread();
            
        }

        


        public void UpdateCoordinates(string message)
        {
            string[] split = message.Split(':');
            if (split != null && !split[0].Equals("") && split.Count()==2)
            {
                double preview_x = Convert.ToDouble(split[0]);
                double preview_y = Convert.ToDouble(split[1]);


                if ((preview_x > x + 10 || preview_x < x - 10) && (preview_y > y + 10 || preview_y < y - 10))
                {
                    x = (x + preview_x + preview_x) / 3;
                    y = (y + preview_y + preview_y) / 3;
                }
                else
                {
                    x = (4*x + preview_x) / 5;
                    y = (4*y + preview_y) / 5;
                }
                
                
            }
            
        }

        private void MoveCursor()
        {
            Left = x;
            Top = ScreenHeight - y;
            
        }
 

        private void RunCursorThread()
        {
            
            while (CURSORTHREAD_SIGNAL == ThreadSignal.On)
            {
                
                Dispatcher.Invoke(() => MoveCursor());

                Thread.Sleep(30);
                
            }
        }

        public bool IsCursorThread()
        {
            if (CURSORTHREAD_SIGNAL == ThreadSignal.On) { return true; }
            else return false;
        }

        public void StartCursorThread()
        {
            CursorThread = new Thread(new ThreadStart(RunCursorThread));
            CURSORTHREAD_SIGNAL = ThreadSignal.On;
            CursorThread.Start();
        }

        public void StopCursorThread()
        {
            if (CURSORTHREAD_SIGNAL == ThreadSignal.On)
            {
                CURSORTHREAD_SIGNAL = ThreadSignal.Off;
                CursorThread.Abort();
            }
            CursorThread = null;
        }









    }
}
