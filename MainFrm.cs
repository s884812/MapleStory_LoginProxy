using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;
using System.Diagnostics;
using System.IO;
namespace MSProxy
{
    public partial class MSProxyForm : Form
    {
       
        bool m_isExtend = false;
        bool m_isStart = false;
        string m_filepath = "";
        ///<summary> For CheckServer</summary>
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileString(string section, string key,
                                                          string def, StringBuilder retVal,
                                                          int size, string filePath);
        [DllImport("kernel32.dll",SetLastError=true, EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode)]
        private static extern UInt32 WritePrivateProfileString(string section, string key,
                                                             string val, string filePath);
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "GetLastError")]
        private static extern UInt32 GetLastError();
        public MSProxyForm()
        {
            InitializeComponent();
        }
        ///<summary> Extend Window </summary>
        private void m_statusStripMore_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (m_isExtend)
            {
                Height = 270;
                m_PanExtend.Visible = false;
                m_StatusLabelMore.Text = "显示更多↓";
            }
            else
            {
                Height = 400;
                m_PanExtend.Visible = true;
                m_StatusLabelMore.Text = "变小↑";
            }
            m_isExtend = !m_isExtend;
        }
        ///<summary> Load ini </summary>
        private void MSProxyForm_Load(object sender, EventArgs e)
        {
            Height = 270;
            m_PanExtend.Visible = false;
            StringBuilder sb=new StringBuilder(200);
            GetPrivateProfileString("conf", "ip", "127.0.0.1", sb, 199, "./mxdproxy.conf");
            m_TboxIP.Text = sb.ToString();
             GetPrivateProfileString("conf", "login", "8484", sb, 199, "./mxdproxy.conf");
            m_TboxLoginPort.Text = sb.ToString();
             GetPrivateProfileString("conf", "channel", "7575-7585", sb, 199, "./mxdproxy.conf");
            m_TboxChannelPort.Text = sb.ToString();
             GetPrivateProfileString("conf", "shop", "8600", sb, 199, "./mxdproxy.conf");
            m_TboxShopPort.Text = sb.ToString();
             GetPrivateProfileString("conf", "path", "", sb, 199, "./mxdproxy.conf");
            m_filepath = sb.ToString();
        }
        // beginconnect  callback
        private void TimeOutCallBack(IAsyncResult asyncresult)
        {
            try
            {
                Socket sock = asyncresult.AsyncState as Socket;
                sock.EndConnect(asyncresult);
            }
            catch
            {

            }
            TimeoutObject.Set();
        }
        // check server status return null if fail string[] = ver , path , locale no
        public string[] CheckServer(string testip, ushort testport)
        {
            byte[] buff = new byte[100];
            int tmp = 0;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.ReceiveTimeout = sock.SendTimeout = 1000;
            try
            {
                TimeoutObject.Reset();
                sock.BeginConnect(testip, (int)testport, TimeOutCallBack, sock);
                if (TimeoutObject.WaitOne(1000, true))
                {
                    if (!sock.Connected)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                tmp = sock.Receive(buff, 100, SocketFlags.None);
            }
            catch
            {
                return null;
            }


            if (tmp < 10) return null;
            string[] ret = new string[3];
            // read ver
            tmp = buff[2];
            tmp += (int)buff[3] << 8;
            ret[0] = tmp.ToString();
            // read path
            ret[1] = (buff[6] - 0x30).ToString();
            // read locale
            ret[2] = buff[15].ToString();
            sock.Close();
            return ret;
        }

        ///<summary> Parse Port String To Uint16 Ports </summary>
        ///<remarks> 1,2-5,6   To {1,2,3,4,5,6}</remarks>
        ///<returns> Uint16 array</returns>
        private Object [] ParseStringToPort(String s)
        {
            ArrayList ret=new ArrayList();
            if (s == "") return ret.ToArray();
            String[] commaSplit = s.Split(',');
            foreach (String i in commaSplit)
            {
                String[] toSplit = i.Split('-');
                UInt16 port=0;
                if (toSplit.Length > 1)
                {
                    UInt16 endPort = 0;
                    if (UInt16.TryParse(toSplit[0], out port) && UInt16.TryParse(toSplit[1], out endPort))
                    {
                        for (UInt16 j = port; j <= endPort; j++)
                        {
                            ret.Add(j);
                        }
                    }
                   
                } 
                else
                {
                      if(UInt16.TryParse(i, out port))
                          ret.Add(port);
                }
            }
                return ret.ToArray();
        }
        private bool StartProxy()
        {
            if(m_isStart)
                ProxyTcp.CloseAll();
            Object[] LoginPort = ParseStringToPort(m_TboxLoginPort.Text);
            if (LoginPort.Length == 1)
            {
                ProxyTcp proxytcp = new ProxyTcp((UInt16)LoginPort[0]);
                if (!proxytcp.Run())
                { MessageBox.Show("环回网卡没设置正确或者端口被占用(本地服务器无须使用转发功能)"); return false; };
            }
            Object[] ChannelPort = ParseStringToPort(m_TboxChannelPort.Text);
                foreach (UInt16 i in ChannelPort)
                {
                    ProxyTcp proxytcp = new ProxyTcp(i);
                    if (!proxytcp.Run())
                    { MessageBox.Show("环回网卡没设置正确或者端口被占用(本地服务器无须使用转发功能)"); return false; };
                }
            
            object[] ShopPort = ParseStringToPort(m_TboxShopPort.Text);
            if (ShopPort.Length == 1)
            {
                ProxyTcp proxytcp = new ProxyTcp((UInt16)ShopPort[0]);
                if (!proxytcp.Run())
                { MessageBox.Show("环回网卡没设置正确或者端口被占用(本地服务器无须使用转发功能)"); return false; };
            }
            return true;
        }
        private void m_btnStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(m_filepath))
            {
                MessageBox.Show("主文件未设置,请先设置");
                return;
            }
            Object[] LoginPort = ParseStringToPort(m_TboxLoginPort.Text);
            if ( LoginPort.Length != 1)
            {
                MessageBox.Show("服务器端口填写错误.");
                m_StatusLabel.Text = "服务器端口填写错误";
                return;
            }
            String[] ret = CheckServer(m_TboxIP.Text, (UInt16)LoginPort[0]);
            if(ret==null)
            {
                MessageBox.Show("服务器连接失败.");
                m_StatusLabel.Text = "服务器连接失败";
                return;
            }
            if (m_TboxIP.Text != "127.0.0.1")
            {ProxyTcp.IP = m_TboxIP.Text;
            if (!StartProxy())
            { m_StatusLabel.Text = "开启失败"; return; };
            m_isStart = true;
            m_StatusLabel.Text = "代理正在工作";}
            else
            {
                m_StatusLabel.Text = "直接打开本地服务器成功";
            }
            
            Process Maple = new Process();
            Maple.StartInfo.FileName = m_filepath;
            Maple.StartInfo.Arguments = "221.231.130.70" + " " + m_TboxLoginPort.Text;
            Maple.Start();
        }

        private void m_BtnCheck_Click(object sender, EventArgs e)
        {
            Object[] LoginPort = ParseStringToPort(m_TboxLoginPort.Text);
            if (LoginPort.Length < 1)
            {
                MessageBox.Show("服务器端口填写失败.");
                m_StatusLabel.Text = "服务器端口填写失败";
                return;
            }
            String[] ret = CheckServer(m_TboxIP.Text, (UInt16)LoginPort[0]);
            if (ret == null)
            {
                MessageBox.Show("服务器连接失败.");
                m_StatusLabel.Text = "服务器连接失败";
                return;
            }
            MessageBox.Show(string.Format("服务器版本:{0},小版本:{1},区域号:{2}", ret[0], ret[1], ret[2]));
        }

        private void MSProxyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProxyTcp.CloseAll();
            WritePrivateProfileString("conf", "path", m_filepath, "./mxdproxy.conf");
            WritePrivateProfileString("conf", "ip", m_TboxIP.Text, "./mxdproxy.conf");
            WritePrivateProfileString("conf", "login", m_TboxLoginPort.Text, "./mxdproxy.conf");
            WritePrivateProfileString("conf", "shop", m_TboxShopPort.Text, "./mxdproxy.conf");
            WritePrivateProfileString("conf", "channel", m_TboxChannelPort.Text, "./mxdproxy.conf");
        }

        private void m_BtnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MsMainFile|MapleStory.exe";
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_filepath = ofd.FileName;
            }
        }

        private void m_btnStop_Click(object sender, EventArgs e)
        {
            if (m_isStart) { 
            ProxyTcp.CloseAll();
            m_StatusLabel.Text = "代理停止工作";
            }
        }

        private void m_BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本软件协议为MIT,作者邮箱nowind@foxmail.com\n使用前建立ip为221.231.130.70的环回网卡\n本地服务器请填写IP为127.0.0.1", "关于");
        }
    }
}
