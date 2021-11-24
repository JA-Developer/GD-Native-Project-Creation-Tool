using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDNative_Project_Creator
{
    public class GDVersion
    {
        public string version { set; get; }
        public string godot_headers_url { set; get; }
        public string godot_cpp_url { set; get; }

        public GDVersion()
        {
            version = "";
            godot_headers_url = "";
            godot_cpp_url = "";

        }
    }
}
