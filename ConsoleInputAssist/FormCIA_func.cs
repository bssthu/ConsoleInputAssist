using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleInputAssist
{
	public partial class FormCIA
    {
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]
        static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.DLL")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        [DllImport("User32.DLL")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("User32.DLL", EntryPoint = "SendInput")]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("User32.DLL", EntryPoint = "GetKeyState")]
        static extern short GetKeyState(int nVirtKey);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint Type;   // 0=INPUT_MOUSE, 1=INPUT_KEYBOARD, 2=INPUT_HARDWARE
            public UNIONINPUT ui;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct UNIONINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_CHAR = 0x0102;
        public const uint KEYEVENTF_KEYUP = 2;
        public const int VK_CAPITAL = 0x14;
        public const int VK_LSHIFT = 0xA0;

        private IntPtr hwndAct = IntPtr.Zero;
        private bool isCatching = false;

        private void clearHwnd()
        {
            hwndAct = IntPtr.Zero;
            textBoxWindowName.Text = "";
            textBoxHwnd.Text = "";
        }

        private void formDeactivate(object sender, EventArgs e)
        {
            this.Deactivate -= new EventHandler(formDeactivate);

            // get hwnd
            hwndAct = GetForegroundWindow();
            textBoxHwnd.Text = "0x" + hwndAct.ToString("x");

            // get window text
            int textLength = GetWindowTextLength(hwndAct);
            StringBuilder str = new StringBuilder(textLength + 1);
            try
            {
                GetWindowText(hwndAct, str, str.Capacity);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            textBoxWindowName.Text = str.ToString();
            isCatching = false;
            buttonGetWindowName.Enabled = true;
        }

        private void addTextboxTextToListbox()
        {
            addItem(textBoxAdd.Text);
            if (checkBoxClearOnAdd.Checked)
            {
                textBoxAdd.Text = "";
            }
        }

        private void addItem(String text)
        {
            if (text != null)
            {
                listBoxSend.Items.Add(text);
            }
        }

        private void sendTextInListbox()
        {
            if (listBoxSend.SelectedIndex >= 0)
            {
                sendText(listBoxSend.SelectedItem.ToString(), checkBoxSendEnter.Checked);
            }
        }

        public void sendText(String text, bool addEnter)
        {
            if (hwndAct != IntPtr.Zero)
            {
                if (addEnter)
                {
                    text += '\r';
                }
                if (checkBoxSendMsg.Checked)
                {
                    sendTextMsg(hwndAct, text);
                }
                else
                {
                    sendTextInput(hwndAct, text);
                }
            }
        }

        private void sendTextMsg(IntPtr hwnd, String text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                SendMessage(hwndAct, WM_CHAR, (int)text[i], 0);
            }
        }

        private void sendTextInput(IntPtr hwnd, String text)
        {
            INPUT inputShift = new INPUT();
            inputShift.Type = 1;
            inputShift.ui.ki.wVk = VK_LSHIFT;
            INPUT[] theShiftInput = new INPUT[] { inputShift };

            INPUT input = new INPUT();
            SetForegroundWindow(hwnd);
            for (int i = 0; i < text.Length; i++)
            {
                input.Type = 1;
                input.ui.ki.wVk = text[i];
                if (char.IsLetter(text[i]) && char.IsLower(text[i]))
                {
                    input.ui.ki.wVk = char.ToUpper(text[i]);
                }
                bool pressShift = char.IsLetter(text[i]) && ((GetKeyState(VK_CAPITAL) != 0) ^ char.IsUpper(text[i])); // upper case
                
                // shift down (if neccessary)
                if (pressShift)
                {
                    theShiftInput[0].ui.ki.dwFlags = 0;
                    SendInput(1, theShiftInput, Marshal.SizeOf(inputShift));
                }
                // key down
                INPUT[] theInput = new INPUT[] { input };
                SendInput(1, theInput, Marshal.SizeOf(input));
                // key up
                theInput[0].ui.ki.dwFlags = KEYEVENTF_KEYUP;
                SendInput(1, theInput, Marshal.SizeOf(input));
                // shift up
                if (pressShift)
                {
                    theShiftInput[0].ui.ki.dwFlags = KEYEVENTF_KEYUP;
                    SendInput(1, theShiftInput, Marshal.SizeOf(inputShift));
                }
            }
        }

        private void loadText(String fileName)
        {
            listBoxSend.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader(fileName);
                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    addItem(line);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveText(String fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                foreach (String line in listBoxSend.Items)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
	}
}
