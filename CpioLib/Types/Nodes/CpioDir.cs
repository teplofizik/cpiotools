﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CpioLib.Types.Nodes
{
    class CpioDir : CpioNode
    {
        public CpioDir(string Path, string LocalPath) : base(Path, 
                                                             new byte[] { }, 
                                                             GetDirectoryInfo(LocalPath),
                                                             0x41edU)
        {
        }

        public CpioDir(string Path) : base(Path, 
                                           new byte[] { }, 
                                           GetDirectoryInfo(null),
                                           0x41edU)
        {
        }

        private static DateTime GetDirectoryInfo(string Dir)
        {
            if (Dir != null)
                return new DirectoryInfo(Dir).LastWriteTime;
            else
                return DateTime.Now;
        }

    }
}
