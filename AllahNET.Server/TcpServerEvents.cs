using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllahNET.Server
{
    /// <summary>
    /// الأحداث أو شيء من هذا
    /// </summary>
    public class TcpServerEvents
    {
        #region الحمد لله رب العالمين

        private static TcpServerEvents INS;

        public TcpServerEvents()
        {
            _instance_ = this;
        }

        public static TcpServerEvents _instance_
        {
            get
            {
                if (INS == null)
                    INS = new TcpServerEvents();
                return INS;
            }
            private set
            {
                INS = value;
            }
        }

        #endregion

        public delegate void __D__CON__(Victem victem);
        public delegate void __D__DISCON__(Victem victem);
        public delegate void __D__PCKTRECV__(Victem victem, string packet);

        public event __D__CON__ OnVictemConnected;
        public event __D__DISCON__ OnVictemDisconnected;
        public event __D__PCKTRECV__ OnPacketReceived;

        public virtual void ___con___(Victem victem)
        {
            var handler = OnVictemConnected;
            if (handler != null) OnVictemConnected?.Invoke(victem);
        }

        public virtual void ___discon___(Victem victem)
        {
            var handler = OnVictemDisconnected;
            if (handler != null) OnVictemDisconnected?.Invoke(victem);
        }

        public virtual void ___recv___(Victem victem, string packet)
        {
            var handler = OnPacketReceived;
            if (handler != null) OnPacketReceived?.Invoke(victem, packet);
        }
    }
}
