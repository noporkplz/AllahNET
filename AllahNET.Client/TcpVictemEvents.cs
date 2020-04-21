using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllahNET.Client
{
    /// <summary>
    /// الأحداث أو شيء من هذا
    /// </summary>
    public class TcpVictemEvents
    {
        #region الحمد لله رب العالمين

        private static TcpVictemEvents INS;

        public TcpVictemEvents()
        {
            _instance_ = this;
        }

        public static TcpVictemEvents _instance_
        {
            get
            {
                if (INS == null)
                    INS = new TcpVictemEvents();
                return INS;
            }
            private set
            {
                INS = value;
            }
        }

        #endregion

        public delegate void __D__CON__();
        public delegate void __D__DISCON__();
        public delegate void __D__PCKTRECV__(string ting);

        public event __D__CON__ OnConnected;
        public event __D__DISCON__ OnDisconnected;
        public event __D__PCKTRECV__ OnPacketReceived;

        public virtual void ___con___()
        {
            var _ = OnConnected;
            if (_ != null) _?.Invoke();
        }

        public virtual void ___discon___()
        {
            var __ = OnDisconnected;
            if (__ != null) __?.Invoke();
        }

        public virtual void ___recv___(string ting)
        {
            var ___ = OnPacketReceived;
            if (___ != null) ___?.Invoke(ting);
        }
    }
}
