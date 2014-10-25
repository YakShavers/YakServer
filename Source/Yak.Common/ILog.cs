﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yak.Common
{
    public interface ILog
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}
