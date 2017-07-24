using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public enum Parts
    {
        Wall = (char)'#',
        Empty = (char)'-',
        Player = (char)'@',
        Goal = (char)'.',
        Block = (char)'$',
        BlockOnGoal = (char)'*',
        PlayerOnGoal = (char)'+'
    };

    public interface IFileable
    {
        int GetColumnCount();
        int GetRowCount();
        Parts WhatsAt(int row, int column);
    }
}
