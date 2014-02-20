namespace ChildProccess
{
    using System;
    using System.Reflection;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Type t =
                    Type.GetType(
                        "TypeScriptLanguageService.CompilerServices.FileHelpers, TypeScriptLanguageService, Version=0.9.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                MethodInfo typeScriptServicesPath = t.GetMethod(
                    "GetSetupLocation",
                    BindingFlags.Static | BindingFlags.NonPublic);
                Console.WriteLine(typeScriptServicesPath.Invoke(null, null));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}