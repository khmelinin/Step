using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpWpf
{
    public class FtpFileSystemInfo
    {
        public FtpFileSystemInfo(string info)
        {
            var a = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Attributes = a[0];
            Size = a[4];
            Name = a[a.Length - 1];
            try
            {
                var year = Convert.ToInt32(a[a.Length - 2]);
                var day = Convert.ToInt32(a[a.Length - 3]);
                var month = a[a.Length - 4];
            }
            catch
            {

            }
        }
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime DateTime { get; set; }
        public string Attributes { get; set; }
    }
}
