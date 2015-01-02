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
    public partial class FormCIA : Form
    {
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]
        static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);

        private IntPtr hwndAct = IntPtr.Zero;
        private bool isCatching = false;

        public FormCIA()
        {
            InitializeComponent();
        }

        private void formDeactivate(object sender, EventArgs e)
        {
            this.Deactivate -= new EventHandler(formDeactivate);

            hwndAct = GetForegroundWindow();
            textBoxHwnd.Text = "0x" + hwndAct.ToString("x");

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

        private void buttonGetWindowName_Click(object sender, EventArgs e)
        {
            if (!isCatching)
            {
                isCatching = true;
                buttonGetWindowName.Enabled = false;
                hwndAct = IntPtr.Zero;
                textBoxWindowName.Text = "";
                textBoxHwnd.Text = "";
                this.Deactivate += new EventHandler(formDeactivate);
            }
        }
    }
}
