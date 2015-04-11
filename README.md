ConsoleInputAssist
==================

辅助输入，帮助调试需要输入大量信息，但输入格式不统一的程序。

###操作说明

- 单击“捕获窗口”按钮，然后单击要操纵的窗口，
此时Deactivate事件发生，通过GetForegroundWindow获得活动窗口句柄。

- 右键单击“捕获窗口”可取消捕获状态。

- 在TextBox中依次输入要添加的项，单击“添加”或按回车。

- 单击“插入”可在选中项前面插入一项。

- 在ListBox中选择要发送的项，按回车或双击或单击“发送”按钮，将内容发到目标窗口。按Delete键删除该项。

- 可按需修改ListBox的内容，右键单击项可将其内容复制到TextBox。

- 允许导入导出数据。

- 如果无法输入，可以取消勾选MSG。
如果还是无法输入，可以在MSG右边设置按键延时，如100毫秒。

###已知问题

- 中文支持。

- 不支持16bit应用程序。

==================

.Net 4.0


![CC-BY-NC 4.0](https://i.creativecommons.org/l/by-nc/4.0/88x31.png)

This work is licensed under a Creative Commons Attribution-NonCommercial 4.0 International License.
http://creativecommons.org/licenses/by-nc/4.0/

不允许商业使用。转载请注明出处、保留此信息。
