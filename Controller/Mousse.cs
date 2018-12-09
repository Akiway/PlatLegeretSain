using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clock = PlatLegeretSain.Model.Clock;

namespace PlatLegeretSain.Controller
{
    class Mousse
    {
        public static void ChangeSpeed(object sender, EventArgs e)
        {
            if (Clock.Speed < 2)
            {
                Clock.Speed += 0.5;
            } else
            {
                Clock.Speed = 0.5;
            }
        }
    }
}
