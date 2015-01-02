using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private IntPtr hwndAct = IntPtr.Zero;
        private bool isCatching = false;

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
                sendText(listBoxSend.SelectedItems.ToString(), checkBoxSendEnter.Checked);
            }
        }

        private void sendText(String text, bool addEnter)
        {
        }
	}
}
