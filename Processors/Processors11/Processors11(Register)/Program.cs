using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors11_Register_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            RegistryKey key = Registry.CurrentUser;
            var software = key.OpenSubKey(@"SOFTWARE\LH\RegistryTest",
                RegistryKeyPermissionCheck.ReadWriteSubTree,
                System.Security.AccessControl.RegistryRights.FullControl
                );
            var vc = software.ValueCount;
            var names = software.GetValueNames();
            var value = software.GetValue(names[0], 9, RegistryValueOptions.None);
            //var lh = software.CreateSubKey("LH");
            //var soft = lh.CreateSubKey("RegistryTest");
            //soft.SetValue("Test", 5, RegistryValueKind.DWord);
            */
        }
    }
}
