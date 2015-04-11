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
                // 开始捕获窗口时的逻辑处理
                isCatching = true;
                buttonGetWindowName.Enabled = false;
                clearHwnd();
                this.Deactivate += new EventHandler(formDeactivate);
            }
        }

        private void buttonGetWindowName_MouseDown(object sender, MouseEventArgs e)
        {
            // 不论点左右键都清空 HWND
            clearHwnd();
        }

        private void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                addTextboxTextToListbox();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addTextboxTextToListbox();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            // 插入到选中项前面
            if (listBoxSend.SelectedIndex >= 0)
            {
                listBoxSend.Items.Insert(listBoxSend.SelectedIndex, textBoxAdd.Text);
            }
            else
            {
                addTextboxTextToListbox();
            }
        }

        private void listBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            // 按 Delete 删除选中项
            if (Keys.Delete == e.KeyCode)
            {
                if (listBoxSend.SelectedIndex >= 0)
                {
                    listBoxSend.Items.RemoveAt(listBoxSend.SelectedIndex);
                }
            }
            // 按 Enter 发送选中项
            if (Keys.Enter == e.KeyCode)
            {
                sendTextInListbox();
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
            // 选中的行
            int mouseIndex = listBoxSend.IndexFromPoint(new Point(e.X, e.Y));
            if (MouseButtons.Left == e.Button)
            {
                // 没点到则清空选择
                if (mouseIndex < 0 || mouseIndex >= listBoxSend.Items.Count)
                {
                    listBoxSend.SelectedItem = null;
                }
            }
            if (MouseButtons.Right == e.Button)
            {
                // 点右键，将该项文本填到输入框中，方便修改
                if (mouseIndex >= 0 && mouseIndex < listBoxSend.Items.Count)
                {
                    listBoxSend.SelectedIndex = mouseIndex;
                    textBoxAdd.Text = listBoxSend.SelectedItem.ToString();
                }
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
                "右键单击“捕获窗口”可取消捕获状态。\n" +
                "在TextBox中依次输入要添加的项，单击“添加”或按回车。\n" +
                "单击“插入”可在选中项前面插入一项。\n" +
                "在ListBox中选择要发送的项，按回车或双击或单击“发送”按钮，将内容发到目标窗口。按Delete键删除该项。\n" +
                "可按需修改ListBox的内容，右键单击项可将其内容复制到TextBox。\n" +
                "允许导入导出数据。\n" +
                "如果无法输入，可以取消勾选MSG。如果还是无法输入，可以在MSG右边设置按键延时，如100毫秒。";
            MessageBox.Show(helpText);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开文件";
            ofd.Filter = "文本文档 (*.txt) |*.txt|所有文件 (*.*) |*.*";
            ofd.Multiselect = false;
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadText(ofd.FileName);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存文件";
            sfd.Filter = "文本文档 (*.txt) |*.txt|所有文件 (*.*) |*.*";
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveText(sfd.FileName);
            }
        }

        private void FormCIA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("退出？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void checkBoxSendMsg_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownSleepTime.Enabled = !checkBoxSendMsg.Checked;
        }

        private void buttonCheckUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bssthu/ConsoleInputAssist/releases");
        }
    }
}
