using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IFilerView
    {
        void Start();
        void Stop();
        string Save();
        string[] Load();
        void Display<T>(T message);
    }
}
