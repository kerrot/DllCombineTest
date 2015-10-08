using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DllNeedLicence;
using System.Reflection;

namespace MyDll
{
    public class MyDll
    {
        public DllA DLL = new DllA();
        public int B;

        public MyDll()
        {
            B = DLL.A + 1;
        }

        public static Assembly GetAssembly(string a_name)
        {
            if (a_name.Contains("DllNeedLicence"))
            {
                return LoadAssembly("DllNeedLicence");
            }

            return null;
        }

        private static Assembly LoadAssembly(string a_name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();

            foreach (string name in names)
            {
                if (name.Contains(a_name))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                    {
                        if (stream != null)
                        {
                            Byte[] assemblyData = new Byte[stream.Length];

                            stream.Read(assemblyData, 0, assemblyData.Length);

                            return Assembly.Load(assemblyData);
                        }
                    }
                }
            }

            return null;
        }
    }
}
