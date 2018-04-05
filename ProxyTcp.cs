using System;
using System.Collections;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace MSProxy
{
    class ProxyTcp : TcpListener
    {
        static IPAddress SdIp = IPAddress.Parse("221.231.130.70");
        static string m_ip=null;
        int m_port;
        bool m_isStart = false;
        static Socket m_remote=null,m_client=null;
        static ArrayList instances=new ArrayList();
        byte[] RemoterecvData = new byte[5000];
        byte[] recvData = new byte[5000];
        public ProxyTcp(int port)
            : base(new IPEndPoint(SdIp, port))
        {
            m_port = port;
            instances.Add(this);
        }
        public int Port
        {
            get { return m_port; }
            set { m_port = value; }
        }
        public static String IP
        {
            get { return m_ip; }
            set { m_ip = value; }
        }
        void OnRemoteRcv(IAsyncResult ar)
        {
            Socket client = ar.AsyncState as Socket;
            if (client == null)
                return;
            try
            {
                int len = client.EndReceive(ar);
                if (m_client != null && len > 0)
                {
                    m_client.Send(RemoterecvData, len, SocketFlags.None);
                }
                client.BeginReceive(RemoterecvData, 0, 5000, SocketFlags.None, OnRemoteRcv, client);
            }
            catch { }
        }
        void OnClientProxy(IAsyncResult ar)
        {
            Socket client = ar.AsyncState as Socket;
            if (client == null)
                return;
            try
           {
            int len=client.EndReceive(ar);
            if (m_remote != null && len > 0)
            {
                    m_remote.Send(recvData, len, SocketFlags.None);
                }
            client.BeginReceive(recvData, 0, 5000, SocketFlags.None, OnClientProxy, client);
           }
            catch { }
        }
        void OnClientAccepted(IAsyncResult ar)
        {
            TcpListener listener = ar.AsyncState as TcpListener;
            if (listener == null)
                return;

            try
            {
                Socket client = listener.EndAcceptSocket(ar);
                if (m_client!=null&&m_client.Connected)
                    m_client.Close();
                if (m_remote!=null&&m_remote.Connected)
                    m_remote.Close();
                m_client = client;
                m_remote = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                m_remote.SendTimeout = 5000;
                //m_remote.Connect(m_ip, 80);
                m_remote.Connect(m_ip, m_port);
                m_remote.BeginReceive(RemoterecvData, 0, 5000, SocketFlags.None, OnRemoteRcv, m_remote);
                m_client.BeginReceive(recvData, 0, 5000, SocketFlags.None, OnClientProxy, m_client);
                listener.BeginAcceptSocket(OnClientAccepted, listener);
            }
            catch {  }
        }
        public bool Run()
        {
            try { 
            Start(2);
            BeginAcceptSocket(OnClientAccepted, this);
            m_isStart = true;
            }
            catch{
                //Console.WriteLine(String.Format("Port {0} error", m_port));
                return false;}
            return true;
            
        }
        public new void Stop()
        {
            if (m_isStart)
                base.Stop();
        }
        public static void CloseAll()
        {
            foreach (TcpListener i in instances)
            {
                i.Stop();
            }
            instances.Clear();
        }
    }
}
