using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Packt.Shared;
public class DvdPlayer : IPlayable
{
    public void Pause()
    {
        WriteLine("DvdPlayer is pausing");
    }

    public void Play()
    {
        WriteLine("DvdPlayer is playing");
    }
}
