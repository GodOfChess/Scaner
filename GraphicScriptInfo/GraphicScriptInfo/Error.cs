using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GraphicScriptInfo
{
    class Error
    {
        public string ErrorMessage { get; set; }
        public IPAddress IpAddr { get; set; }
        public string[] bytes { get; set; }
    }
}
