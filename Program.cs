using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FastPst
{
    internal static class Program
    {
        // 定义一个静态的 Mutex
        private static Mutex mutex = new Mutex(true, "{A-UNIQUE-IDENTIFIER}");

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args.Length > 0)
            {
                string filePath = args[0];
                if (Properties.Settings.Default.isChecked)
                {
                    filePath = filePath.Replace("\\", "/");
                }


                Clipboard.SetText(filePath); // 复制路径到剪贴板
                //MessageBox.Show("路径已复制到剪贴板：\n" + filePath, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            // 检查是否已有实例在运行
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {


                Application.Run(new Form1());

                // 释放 Mutex
                mutex.ReleaseMutex();
            }
            else
            {
                // 如果有实例正在运行，通知用户并聚焦到现有实例
                //MessageBox.Show("程序已经在运行。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BringExistingInstanceToFront();
            }


        }

        //[STAThread]
        //static void Main(string[] args)
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    if (args.Length > 0)
        //    {
        //        // 获取文件路径
        //        string filePath = args[0];
        //        Clipboard.SetText(filePath); // 复制到剪贴板
        //    }
        //    else
        //    {
        //        Application.Run(new Form1());
        //    }
        //}



        // 将已有实例置于最前面
        private static void BringExistingInstanceToFront()
        {
            // 获取当前运行中的进程
            var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            foreach (var process in System.Diagnostics.Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id)
                {
                    // 显示并激活窗口
                    IntPtr handle = process.MainWindowHandle;
                    if (IsIconic(handle)) ShowWindow(handle, SW_RESTORE);
                    SetForegroundWindow(handle);
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_RESTORE = 9;
    }
}
