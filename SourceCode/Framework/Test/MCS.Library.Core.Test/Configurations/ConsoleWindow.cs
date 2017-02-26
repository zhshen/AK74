using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Library.Core.Test.Configurations
{
    public enum WindowStateeMode
    {
        Normal = 0,
        Minimize = 1,
        Maximize = 2
    }

    public class ConsoleWindow
    {
        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }

        public WindowStateeMode WindowState
        {
            get;
            set;
        }
    }
}
