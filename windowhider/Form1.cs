/* windowhider v1.0
 * Hide windows by title or classname
 * MIT-Licensed, 2015-09-25, ed <irc.rizon.net>
 * https://github.com/9001/windowhider
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace windowhider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer tMain;
        string inipath;
        List<IntPtr> windows;
        Z.EnumWindowsProc enumWindowsProc;
        uint[] targetProcessId;
        string findtitle;
        string findclass;

        private void Form1_Load(object sender, EventArgs e)
        {
            tMain = new Timer();
            tMain.Tick += tMain_Tick;

            string ver = Application.ProductVersion;
            ver = ver.Substring(0, ver.Length - 4);
            this.Text += " v." + ver;

            inipath = System.IO.Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                    @"gtech\windowhider.ini");

            _ini.Text += inipath;
            try
            {
                int a = 0;
                string[] cfg = System.IO.File.ReadAllLines(inipath, Encoding.UTF8);
                if (cfg[10] != "EOF")
                    throw new Exception();

                _autostart.Checked = Convert.ToBoolean(cfg[++a]);
                _autohide.Checked = Convert.ToBoolean(cfg[++a]);
                _cTitle.Checked = Convert.ToBoolean(cfg[++a]);
                _title.Text = cfg[++a];
                _cClass.Checked = Convert.ToBoolean(cfg[++a]);
                _class.Text = cfg[++a];
                _cProc.Checked = Convert.ToBoolean(cfg[++a]);
                _proc.Text = cfg[++a];
                _freq.Text = cfg[++a];
            }
            catch (Exception ex)
            { }

            main_init();

            if (_autostart.Checked)
            {
                this.Left -= 9999;
                Timer t = new Timer();
                t.Interval = 250;
                t.Start();
                t.Tick += delegate(object oa, EventArgs ob)
                {
                    t.Stop();
                    this.Hide();
                    Application.DoEvents();
                    _doStart_Click(sender, e);
                };
            }
        }

        void saveconfig()
        {
            string parent = inipath.Replace("/", "\\");
            parent = parent.Substring(0, parent.LastIndexOf("\\"));
            System.IO.Directory.CreateDirectory(parent);
            System.IO.File.WriteAllText(inipath,
                Application.ProductVersion + "\r\n" +
                _autostart.Checked + "\r\n" +
                _autohide.Checked + "\r\n" +
                _cTitle.Checked + "\r\n" +
                _title.Text + "\r\n" +
                _cClass.Checked + "\r\n" +
                _class.Text + "\r\n" +
                _cProc.Checked + "\r\n" +
                _proc.Text + "\r\n" +
                _freq.Text + "\r\n" +
                "EOF", Encoding.UTF8);
        }

        void log(string msg)
        {
            Console.WriteLine(msg);
        }

        private void _doHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void _cTitle_CheckedChanged(object sender, EventArgs e)
        {
            _title.Enabled = _cTitle.Checked;
        }

        private void _cClass_CheckedChanged(object sender, EventArgs e)
        {
            _class.Enabled = _cClass.Checked;
        }

        private void _cProc_CheckedChanged(object sender, EventArgs e)
        {
            _proc.Enabled = _cProc.Checked;
        }

        private void _doStart_Click(object sender, EventArgs e)
        {
            string tStart = "S t a r t";
            string tStop = "S t o p";

            if (_doStart.Text == tStart)
            {
                _doStart.Text = tStop;
                _title.Tag = _title.Enabled;
                _class.Tag = _class.Enabled;
                _proc.Tag = _proc.Enabled;
                _title.Enabled = _class.Enabled = _proc.Enabled = _freq.Enabled = false;
                tMain.Interval = Convert.ToInt32(_freq.Text);
                saveconfig();

                findtitle = "";
                if (_cTitle.Checked)
                    findtitle = _title.Text;

                findclass = "";
                if (_cClass.Checked)
                    findclass = _class.Text;

                if (_autohide.Checked)
                    this.Hide();

                main_process();
                tMain.Start();
            }
            else
            {
                tMain.Stop();
                _doStart.Text = tStart;
                _title.Enabled = (bool)_title.Tag;
                _class.Enabled = (bool)_class.Tag;
                _proc.Enabled = (bool)_proc.Tag;
                _freq.Enabled = true;
            }
        }

        void tMain_Tick(object sender, EventArgs e)
        {
            main_process();
        }

        private void _ini_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("notepad", inipath));
        }

        private void _link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/9001/windowhider");
        }

        //
        // END GUI STUFF
        //

        void main_init()
        {
            windows = new List<IntPtr>();
            enumWindowsProc = new Z.EnumWindowsProc(report);
        }

        bool report(IntPtr hwnd, IntPtr lParam)
        {
            if (!Z.IsWindowVisible(hwnd))
                return true;

            if (targetProcessId.Length > 0)
            {
                uint windowpid;
                Z.GetWindowThreadProcessId(hwnd, out windowpid);
                if (!targetProcessId.Contains(windowpid))
                {
                    //log(windowpid + " is none of " + targetProcessId.Length + " processes for " + hwnd);
                    return true;
                }
            }

            //log("Window handle: " + hwnd);
            windows.Add(hwnd);
            return true;
        }

        void main_process()
        {
            if (_cProc.Checked)
            {
                Process[] procs = Process.GetProcessesByName("devenv");
                log("Found " + procs.Length + " process instances");
                if (procs.Length <= 0)
                    return;

                targetProcessId = new uint[procs.Length];
                for (int a = 0; a < procs.Length; a++)
                    targetProcessId[a] = (uint)procs[a].Id;
            }
            else targetProcessId = new uint[0];

            windows.Clear();
            Z.EnumWindows(enumWindowsProc, IntPtr.Zero);
            log("Found " + windows.Count + " windows");
            if (windows.Count <= 0)
                return;

            int nHidden = 0;
            foreach (IntPtr hwnd in windows)
            {
                if (!string.IsNullOrWhiteSpace(findtitle))
                {
                    int len = findtitle.Length + 8;
                    StringBuilder sb = new StringBuilder(len);
                    Z.GetWindowText(hwnd, sb, sb.Capacity);
                    if (sb.ToString() != findtitle)
                        continue;
                }
                if (!string.IsNullOrWhiteSpace(findclass))
                {
                    int len = findclass.Length + 8;
                    StringBuilder sb = new StringBuilder(len);
                    Z.GetClassName(hwnd, sb, sb.Capacity);
                    if (sb.ToString() != findclass)
                        continue;
                }
                nHidden++;
                foreach (bool hide in new bool[] { true })
                {
                    if (hide)
                    {
                        Z.SetWindowPosFlags flags =
                            Z.SetWindowPosFlags.SWP_HIDEWINDOW |
                            Z.SetWindowPosFlags.SWP_NOACTIVATE |
                            Z.SetWindowPosFlags.SWP_NOMOVE |
                            Z.SetWindowPosFlags.SWP_NOREPOSITION |
                            Z.SetWindowPosFlags.SWP_NOSIZE |
                            Z.SetWindowPosFlags.SWP_NOOWNERZORDER |
                            Z.SetWindowPosFlags.SWP_NOZORDER;

                        log("Hiding " + hwnd);
                        Z.SetWindowPos(hwnd,
                            (IntPtr)Z.SpecialWindowHandles.HWND_NOTOPMOST,
                            0, 0, 0, 0, flags);
                    }
                    else
                    {
                        Z.SetWindowPosFlags flags =
                            Z.SetWindowPosFlags.SWP_SHOWWINDOW |
                            Z.SetWindowPosFlags.SWP_NOMOVE |
                            Z.SetWindowPosFlags.SWP_NOREPOSITION |
                            Z.SetWindowPosFlags.SWP_NOSIZE |
                            Z.SetWindowPosFlags.SWP_NOOWNERZORDER |
                            Z.SetWindowPosFlags.SWP_NOZORDER;

                        log("Restoring " + hwnd);
                        Z.SetWindowPos(hwnd,
                            (IntPtr)Z.SpecialWindowHandles.HWND_TOPMOST,
                            0, 0, 0, 0, flags);
                    }
                    //System.Threading.Thread.Sleep(1000);
                }
            }
            log(nHidden + " windows hidden");
        }
    }
}