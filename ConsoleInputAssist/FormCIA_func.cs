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

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]
        static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.DLL")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        [DllImport("User32.DLL")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam); 

        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_CHAR = 0x0102; 

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

        private void sendText(String text, bool addEnter)
        {
            if (hwndAct != IntPtr.Zero)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    SendMessage(hwndAct, WM_CHAR, (int)text[i], 0);
                }
                if (addEnter)
                {
                    SendMessage(hwndAct, WM_CHAR, (int)'\r', 0);
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
