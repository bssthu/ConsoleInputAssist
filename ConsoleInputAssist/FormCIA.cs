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
        public FormCIA()
        {
            InitializeComponent();
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

        private void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                addItem(textBoxAdd.Text);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addItem(textBoxAdd.Text);
        }

        private void listBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                if (listBoxSend.SelectedIndex >= 0)
                {
                    listBoxSend.Items.RemoveAt(listBoxSend.SelectedIndex);
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (listBoxSend.SelectedIndex >= 0)
            {
                listBoxSend.Items[listBoxSend.SelectedIndex] = textBoxAdd.Text;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            sendTextInListbox();
        }

        private void listBoxSend_DoubleClick(object sender, EventArgs e)
        {
            sendTextInListbox();
        }

        private void listBoxSend_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                sendTextInListbox();
            }
        }

        private void listBoxSend_Click(object sender, EventArgs e)
        {
            if (checkBoxSendOnClick.Checked)
            {
                sendTextInListbox();
            }
        }

        private void buttonEmpty_Click(object sender, EventArgs e)
        {
            listBoxSend.Items.Clear();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            String helpText = "单击“捕获窗口”按钮，然后单击要操纵的窗口。\n" +
                "在TextBox中依次输入要添加的项，单击“添加”或按回车。\n" +
                "在ListBox中选择要发送的项，双击或右键单击或单击“发送”按钮，将内容发到目标窗口。";
            MessageBox.Show(helpText);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
