using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using LeapUserInterface.Classes;


namespace LeapUserInterface
{

    public enum ThreadSignal
    {
        On, Off
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InputSimulationPerformer performer;
        public FileMapController fileMapController;
        public TrackerThread trackerThread;
        public RadialPanel radial_left = new RadialPanel();
        public Cursor cursor = new Cursor();
    
        public MainWindow()
        {
            
            InitializeComponent();

            fileMapController = new FileMapController(this);
            performer = new InputSimulationPerformer();
            trackerThread = new TrackerThread(this);
            this.Closed += MainWindow_Closed;

            trackerThread.StartTracking();
            

            WindowState = WindowState.Minimized;
 
            radial_left.Topmost = true;
            //Place Radial at bottom right
            double _x = (80 * System.Windows.SystemParameters.PrimaryScreenWidth)/100;
            double _y = (60 * System.Windows.SystemParameters.PrimaryScreenHeight)/100;
            radial_left.Left = _x;
            radial_left.Top = _y;
            radial_left.Show();

            cursor.Topmost = true;
            cursor.Show();

        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            trackerThread.StopTracking();
            cursor.StopCursorThread();
            Application curApp = Application.Current;
            curApp.Shutdown();
        }

        private void UpdateLeftSignalEllipse()
        {

            if(fileMapController.IsLeftPinching())
            {
                radial_left.Ellipse_LeftSignal.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            }
            else
            {
                radial_left.Ellipse_LeftSignal.Fill = new SolidColorBrush(Color.FromRgb(103, 103, 103));
            }
        }
        
        private void UpdateCursor()
        {
            if (!fileMapController.IsRightPinching())
            {
                cursor.UpdateCoordinates(fileMapController.FM_GetMessage(FileMapController.FM_R_POS));

                cursor.BackGrid.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
            {

                cursor.BackGrid.Background = new SolidColorBrush(Color.FromRgb(103, 103, 103));
            }
        }

        public void UpdateSystem()
        {
            
            fileMapController.FileMapHandles = trackerThread.FM_Handlers;
            fileMapController.Update();
            UpdateUI();
            
        }

        public void UpdateUI()
        {
            
            LBL_L_Hand.Content = fileMapController.FM_GetMessage(FileMapController.FM_LPALM_POS);

            UpdateCursor();
            UpdateLeftSignalEllipse();
            radial_left.UpdateRadials(fileMapController);
        }


        private void BT_Close_Click(object sender, RoutedEventArgs e)
        {

            trackerThread.StopTracking();
            cursor.StopCursorThread();
            Application curApp = Application.Current;
            curApp.Shutdown();
        }

        private void BackGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
  
        }

        private void BT_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BT_PauseTracking_Click(object sender, RoutedEventArgs e)
        {
            trackerThread.StopTracking();
            
        }

        private void BT_ResumeTracking_Click(object sender, RoutedEventArgs e)
        {
            if (!trackerThread.IsTracking())
            {

                trackerThread.StartTracking();
            }
            else
            {
                MessageBox.Show("Already Tracking!");
            }

        }

        
    }
}
