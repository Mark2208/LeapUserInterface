using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WindowsInput;

namespace LeapUserInterface.Classes
{
    public class InputSimulationPerformer
    {


        InputSimulator inputSimulator = new InputSimulator();
        public bool IsPerformingAction { get; set; } = false;



        public void SwitchTask(string TaskbarKey)
        {

            if (TaskbarKey == "2")
            {
                inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LWIN);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_2);
                Thread.Sleep(200);
                inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LWIN);
            }

        }

        public void PausePlay()
        {

            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
        }

        public void ScrollUp()
        {

            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.PRIOR);

        }

        public void ScrollDown()
        {

            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.NEXT);

        }

        public void SkipForward()
        {

            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_L);
            Thread.Sleep(100);

        }

        public void SkipBack()
        {

            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_J);
            Thread.Sleep(100);

        }
        public void VolumeUp()
        {
            for (int i = 0; i < 5; i += 1)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VOLUME_UP);
            }


        }
        public void VolumeDown()
        {
            for (int i = 0; i < 5; i += 1)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VOLUME_DOWN);
            }

        }

        public void TabLeft()
        {

            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.PRIOR);
            Thread.Sleep(200);
            inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);


        }

        public void TabRight()
        {

            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.NEXT);
            Thread.Sleep(200);
            inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);

        }

        public void MouseClick(double x, double y, Cursor cursor)
        {

            inputSimulator.Mouse.MoveMouseTo(x * 51, y * 90);

            cursor.Hide();
            inputSimulator.Keyboard.Mouse.LeftButtonClick();
            cursor.Show();
            
        }

        




    }       
}
