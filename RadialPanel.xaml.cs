using LeapUserInterface.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeapUserInterface
{
    /// <summary>
    /// Interaction logic for RadialPanel.xaml
    /// </summary>
    public partial class RadialPanel : Window
    {


        SolidColorBrush RadialHoverOn = new SolidColorBrush(Color.FromRgb(125, 125, 125));
        SolidColorBrush RadialHoverOff = new SolidColorBrush(Color.FromRgb(23, 23, 23));

        public RadialPanel()
        {
            InitializeComponent();
            this.IsEnabledChanged += RadialPanel_IsEnabledChanged;
    
        }

     

      

        private void RadialPanel_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation()
            {
                From = (IsEnabled) ? 0 : 0.6,
                To = (IsEnabled) ? 0.6 : 0,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            
            BeginAnimation(OpacityProperty, da);
        }

        private void BackGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
                DragMove();
            }
        }

        public void EnableRadial(Ellipse ellipse)
        {
            if (ellipse.IsEnabled) { ellipse.IsEnabled = false; }

        }

        public void DisableRadial(Ellipse ellipse)
        {
            if (!ellipse.IsEnabled) { ellipse.IsEnabled = true; }

        }

        public void UpdateRadials(FileMapController fileMapController)
        {

            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ1)) { Radial_Q1.Fill = RadialHoverOn; EnableRadial(Radial_Q1); }
            else { Radial_Q1.Fill = RadialHoverOff; DisableRadial(Radial_Q1); }
            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ2)) { Radial_Q2.Fill = RadialHoverOn; EnableRadial(Radial_Q2); LBL_SkipForward.IsEnabled = true; }
            else { Radial_Q2.Fill = RadialHoverOff; DisableRadial(Radial_Q2);  }
            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ3)) { Radial_Q3.Fill = RadialHoverOn; EnableRadial(Radial_Q3); }
            else { Radial_Q3.Fill = RadialHoverOff; DisableRadial(Radial_Q3); }
            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ6)) { Radial_Q6.Fill = RadialHoverOn; EnableRadial(Radial_Q6); }
            else { Radial_Q6.Fill = RadialHoverOff; DisableRadial(Radial_Q6); }
            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ7)) { Radial_Q7.Fill = RadialHoverOn; EnableRadial(Radial_Q7); }
            else { Radial_Q7.Fill = RadialHoverOff; DisableRadial(Radial_Q7); }
            if (fileMapController.FM_GetFlagState(FileMapController.FM_IS_LQ8)) { Radial_Q8.Fill = RadialHoverOn; EnableRadial(Radial_Q8); }
            else { Radial_Q8.Fill = RadialHoverOff; DisableRadial(Radial_Q8); }
            
        }

      
    }
    
}
