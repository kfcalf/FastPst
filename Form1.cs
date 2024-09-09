using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace FastPst
{
    public partial class Form1 : Form
    {

        private const int WM_HOTKEY = 0x0312;        // Windows 消息：热键
        private int hotkeyId1 = 1;                   // 全局快捷键1 ID
        private int hotkeyId2 = 2;                   // 全局快捷键2 ID

        // 导入 Windows API 函数
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int KEYEVENTF_KEYDOWN = 0x0000;  // 键按下
        private const int KEYEVENTF_KEYUP = 0x0002;    // 键释放
        private const byte VK_CONTROL = 0x11;         // Ctrl 键的虚拟键码
        private const byte VK_HOME = 0x24;            // Home 键的虚拟键码
        private const byte VK_END = 0x23;             // End 键的虚拟键码
        private const byte VK_V = 0x56;               // V 键的虚拟键码
        private const byte VK_RETURN = 0x0D;          // Enter 键的虚拟键码


        // 引入 Windows API 函数 更新系统右键菜单 
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(int wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        // 事件常量
        private const int SHCNE_ASSOCCHANGED = 0x8000000; // 文件关联更改
        private const int SHCNF_FLUSH = 0x1000;           // 刷新系统缓存
        private const int SHCNF_FLUSHNOWAIT = 0x2000;     // 刷新但不等待

        public Form1()
        {
            InitializeComponent();

            chkSlashDirection.Checked = Properties.Settings.Default.isChecked;//获取check状态

            // 绑定 KeyDown 事件
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            textBox2.KeyDown += new KeyEventHandler(textBox2_KeyDown);

            // 加载保存的快捷键设置
            LoadHotkeys();
        }



        private void btnTopPaste_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                return;
            }
            string customHotkey1 = textBox1.Text;
            RegisterCustomHotKey(customHotkey1, hotkeyId1);
            SaveHotkeys();  // 保存设置

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            string customHotkey2 = textBox2.Text;
            RegisterCustomHotKey(customHotkey2, hotkeyId2);
            SaveHotkeys();  // 保存设置

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            string hotkey = GetHotkeyString(e);
            textBox1.Text = hotkey;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            string hotkey = GetHotkeyString(e);
            textBox2.Text = hotkey;
        }

        private string GetHotkeyString(KeyEventArgs e)
        {
            string hotkey = "";

            if (e.Control) hotkey += "Ctrl+";
            if (e.Alt) hotkey += "Alt+";
            if (e.Shift) hotkey += "Shift+";
            if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin) hotkey += "Win+";

            hotkey += e.KeyCode.ToString();
            return hotkey;
        }

        private void RegisterCustomHotKey(string hotkey, int hotkeyId)
        {
            string[] parts = hotkey.Split('+');
            int modifiers = 0;
            int key = 0;

            foreach (var part in parts)
            {
                switch (part.Trim().ToUpper())
                {
                    case "CTRL":
                        modifiers |= 0x0002; // MOD_CONTROL
                        break;
                    case "SHIFT":
                        modifiers |= 0x0004; // MOD_SHIFT
                        break;
                    case "ALT":
                        modifiers |= 0x0001; // MOD_ALT
                        break;
                    case "WIN":
                        modifiers |= 0x0008; // MOD_WIN
                        break;
                    default:
                        if (Enum.TryParse(part.Trim(), true, out Keys parsedKey))
                        {
                            key = (int)parsedKey;
                        }
                        break;
                }
            }

            UnregisterHotKey(this.Handle, hotkeyId);  // 如果之前注册过快捷键，先取消注册
            RegisterHotKey(this.Handle, hotkeyId, modifiers, key);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToInt32() == hotkeyId1)
                {
                    SendKeyCombination1();
                }
                else if (m.WParam.ToInt32() == hotkeyId2)
                {
                    SendKeyCombination2();
                }
            }
        }

        private void SendKeyCombination1()
        {
            // 第一个组合键：Ctrl + Home, Ctrl + V, Enter, Enter
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Ctrl down
            keybd_event(VK_HOME, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);    // Home down
            keybd_event(VK_HOME, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);      // Home up
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Ctrl up

            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Ctrl down
            keybd_event(VK_V, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);       // V down
            keybd_event(VK_V, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);         // V up
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Ctrl up

            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);  // Enter down
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);    // Enter up
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);  // Enter down
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);    // Enter up
        }

        private void SendKeyCombination2()
        {
            // 第二个组合键：Ctrl + End, Enter, Ctrl + V, Enter
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Ctrl down
            keybd_event(VK_END, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);     // End down
            keybd_event(VK_END, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);       // End up
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Ctrl up

            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);  // Enter down
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);    // Enter up

            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Ctrl down
            keybd_event(VK_V, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);       // V down
            keybd_event(VK_V, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);         // V up
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Ctrl up

            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);  // Enter down
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);    // Enter up
        }


        private void SaveHotkeys()
        {
            Properties.Settings.Default.Hotkey1 = textBox1.Text;
            Properties.Settings.Default.Hotkey2 = textBox2.Text;
            Properties.Settings.Default.Save();  // 保存设置到配置文件
        }

        private void LoadHotkeys()
        {
            textBox1.Text = Properties.Settings.Default.Hotkey1;
            textBox2.Text = Properties.Settings.Default.Hotkey2;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                RegisterCustomHotKey(textBox1.Text, hotkeyId1);
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RegisterCustomHotKey(textBox2.Text, hotkeyId2);
            }
            //btnTopPaste.PerformClick();
            //btnPaste.PerformClick();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //取消注册快捷键
            UnregisterHotKey(this.Handle, hotkeyId1);
            UnregisterHotKey(this.Handle, hotkeyId2);
        }

        private void emsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            // 判断是否为鼠标左键点击
            if (me.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized || !this.Visible)
                {
                    // 恢复窗口并显示在任务栏
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                }
                else
                {
                    // 最小化并隐藏窗口及任务栏图标
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Hide();
                }
            }
        }

        private void btnAddcopy_Click(object sender, EventArgs e)
        {
            try
            {
                // 添加右键菜单到所有文件类型
                AddContextMenu(@"*\shell\CopyFilePath", "复制路径", "shell32.dll,158", Application.ExecutablePath + " \"%1\"");

                // 添加右键菜单到所有文件夹类型
                AddContextMenu(@"Directory\shell\CopyFilePath", "复制路径", "shell32.dll,158", Application.ExecutablePath + " \"%1\"");

                // 添加右键菜单到所有文件系统对象
                AddContextMenu(@"AllFilesystemObjects\shell\CopyFilePath", "复制路径", "shell32.dll,158", Application.ExecutablePath + " \"%1\"");

                //MessageBox.Show("右键菜单项已成功添加!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblInfo.Text = "右键复制菜单项已成功添加!";
                LoadHotkeys();//防止上面的快捷键失效
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加右键菜单项时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddContextMenu(string subKey, string menuName, string icon, string command)
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(subKey))
                {
                    key.SetValue("", menuName);
                    key.SetValue("Icon", icon);

                    using (RegistryKey commandKey = key.CreateSubKey("command"))
                    {
                        commandKey.SetValue("", command);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("没有足够的权限添加右键菜单。请确保以管理员身份运行此程序。", "权限错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册表操作时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveContextMenu(string subKey)
        {
            try
            {
                // 打开注册表键并删除它
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(subKey, writable: true);
                if (key != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(subKey);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("没有足够的权限删除右键菜单。请确保以管理员身份运行此程序。", "权限错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册表操作时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnNoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 删除右键菜单项
                //RemoveContextMenu("HKEY_CLASSES_ROOT\\*\\shell\\CopyFilePath");
                //RemoveContextMenu("HKEY_CLASSES_ROOT\\Directory\\shell\\CopyFilePath");
                //RemoveContextMenu("HKEY_CLASSES_ROOT\\AllFilesystemObjects\\shell\\CopyFilePath");/这种删除方法不行
                RemoveContextMenu(@"*\shell\CopyFilePath");
                RemoveContextMenu(@"Directory\shell\CopyFilePath");
                RemoveContextMenu(@"AllFilesystemObjects\shell\CopyFilePath");
                // 通知系统文件关联已更改
                //SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                //MessageBox.Show("右键菜单项已成功删除!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblInfo.Text = "右键复制菜单项已成功删除!";
                LoadHotkeys();//防止上面的快捷键失效
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除右键菜单项时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRestartExPlorer_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                }

                Process.Start("explorer.exe");
                MessageBox.Show("资源管理器已重启。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重启资源管理器失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory());
        }

        private void chkSlashDirection_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isChecked = chkSlashDirection.Checked;
            Properties.Settings.Default.Save();  // 保存设置到配置文件
        }
    }
}
