using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public interface IFiler
    {
        void Save(string file, IFileable callBack);
        string Load();
        void SetString(string input);
    }
}