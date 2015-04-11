using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleInputAssist
{
    public static class WinAPI
    {
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]
        public static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("User32.DLL", EntryPoint = "SendInput")]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("User32.DLL", EntryPoint = "GetKeyState")]
        public static extern short GetKeyState(int nVirtKey);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint Type;   // 0=INPUT_MOUSE, 1=INPUT_KEYBOARD, 2=INPUT_HARDWARE
            public UNIONINPUT ui;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct UNIONINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
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
        public const int VK_OEM_1 = 0xBA;    // ;:
        public const int VK_OEM_2 = 0xBF;    // /?
        public const int VK_OEM_3 = 0xC0;    // `~
        public const int VK_OEM_4 = 0xDB;    // [{
        public const int VK_OEM_5 = 0xDC;    // \|
        public const int VK_OEM_6 = 0xDD;    // ]}
        public const int VK_OEM_7 = 0xDE;    // '"
        public const int VK_OEM_PLUS = 0xBB;    // +
        public const int VK_OEM_COMMA = 0xBC;   // ,
        public const int VK_OEM_MINUS = 0xBD;   // -
        public const int VK_OEM_PERIOD = 0xBE;  // .

        public static Dictionary<char, int> charToVK = new Dictionary<char, int>
        {
            {';', VK_OEM_1},
            {'/', VK_OEM_2},
            {'`', VK_OEM_3},
            {'[', VK_OEM_4},
            {'\\', VK_OEM_5},
            {']', VK_OEM_6},
            {'\'', VK_OEM_7},
            {'=', VK_OEM_PLUS},
            {'-', VK_OEM_MINUS},
            {',', VK_OEM_COMMA},
            {'.', VK_OEM_PERIOD},
        };
    }
}
