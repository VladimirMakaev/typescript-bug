using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptServices
{
    using System.IO;

    static class Program
    {
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        [STAThread]
        static void Main()
        {
            string startupPath = Path.GetDirectoryName(@"c:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\");
            string configFile = Path.Combine(startupPath, "ChildProccess.exe.config");
            string assembly = Path.Combine(startupPath, "ChildProccess.exe");

            // Create the setup for the new domain:
            AppDomainSetup setup = new AppDomainSetup
                                       {
                                           ApplicationName = "ChildProcess",
                                           ShadowCopyFiles = "true",
                                           ConfigurationFile = configFile,
                                           ApplicationBase = startupPath
                                       };

            // Create the application domain. The evidence of this
            // running assembly is used for the new domain:
            AppDomain domain = AppDomain.CreateDomain(
                "ChildProcess",
                AppDomain.CurrentDomain.Evidence,
                setup);

            // Start MyApplication by executing the assembly:
            domain.ExecuteAssembly(assembly);

            // After the MyApplication has finished clean up:
            AppDomain.Unload(domain);
        }
    }
}
