using System;
using System.Collections.Generic;
using System.Text;

namespace GalE_Core
{
    internal interface InterfaceMusic
    {
        public void start();
        public void stop();
        public void pause();
        public void resume();
        public void setMusic(string name);
        public void reset();
    }
}
