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
        private IntPtr hwndAct = IntPtr.Zero;
        private bool isCatching = false;

        public const String upperKey = "~!@#$%^&*()_+{}|:\"<>?";
        public const String lowerKey = "`1234567890-=[]\\;',./";

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
            hwndAct = WinAPI.GetForegroundWindow();
            textBoxHwnd.Text = "0x" + hwndAct.ToString("x");

            // get window text
            int textLength = WinAPI.GetWindowTextLength(hwndAct);
            StringBuilder str = new StringBuilder(textLength + 1);
            try
            {
                WinAPI.GetWindowText(hwndAct, str, str.Capacity);
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
                WinAPI.SendMessage(hwndAct, WinAPI.WM_CHAR, (int)text[i], 0);
            }
        }

        private void sendTextInput(IntPtr hwnd, String text)
        {
            this.Enabled = false;

            WinAPI.INPUT inputShift = new WinAPI.INPUT();
            inputShift.Type = 1;
            inputShift.ui.ki.wVk = WinAPI.VK_LSHIFT;
            WinAPI.INPUT[] theShiftInput = new WinAPI.INPUT[] { inputShift };

            WinAPI.INPUT input = new WinAPI.INPUT();
            WinAPI.SetForegroundWindow(hwnd);
            for (int i = 0; i < text.Length; i++)
            {
                input.Type = 1;
                input.ui.ki.wVk = text[i];

                if (char.IsLetter(text[i]) && char.IsLower(text[i]))
                {
                    input.ui.ki.wVk = char.ToUpper(text[i]);
                }
                else if (upperKey.Contains(text[i]) || lowerKey.Contains(text[i]))
                {
                    char lk = upperKey.Contains(text[i]) ? lowerKey[upperKey.IndexOf(text[i])] : text[i];
                    input.ui.ki.wVk = (ushort)(char.IsNumber(lk) ? lk : WinAPI.charToVK[lk]);
                }
                bool pressShift = char.IsLetter(text[i]) &&
                        ((WinAPI.GetKeyState(WinAPI.VK_CAPITAL) != 0) ^ char.IsUpper(text[i])); // upper case
                pressShift |= upperKey.Contains(text[i]);    // other

                // shift down (if neccessary)
                if (pressShift)
                {
                    sleep((int)numericUpDownSleepTime.Value);
                    theShiftInput[0].ui.ki.dwFlags = 0;
                    WinAPI.SendInput(1, theShiftInput, Marshal.SizeOf(inputShift));
                }
                // key down
                sleep((int)numericUpDownSleepTime.Value);
                WinAPI.INPUT[] theInput = new WinAPI.INPUT[] { input };
                WinAPI.SendInput(1, theInput, Marshal.SizeOf(input));
                sleep((int)numericUpDownSleepTime.Value);
                // key up
                sleep((int)numericUpDownSleepTime.Value);
                theInput[0].ui.ki.dwFlags = WinAPI.KEYEVENTF_KEYUP;
                WinAPI.SendInput(1, theInput, Marshal.SizeOf(input));
                // shift up
                if (pressShift)
                {
                    sleep((int)numericUpDownSleepTime.Value);
                    theShiftInput[0].ui.ki.dwFlags = WinAPI.KEYEVENTF_KEYUP;
                    WinAPI.SendInput(1, theShiftInput, Marshal.SizeOf(inputShift));
                }
            }
            this.Enabled = true;
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

        private void sleep(int ms)
        {
            if (ms > 0)
            {
                System.Threading.Thread.Sleep(ms);
            }

        }
	}
}
