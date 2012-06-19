using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;
using Noesis.Javascript;
using System.Reflection;
using System.IO;

namespace rn
{
    internal static class JavascriptExtensions
    {
        public static void RunEmbeddedScript(this JavascriptContext context, string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (!assembly.GetManifestResourceNames().Contains(name))
            {
                throw new ApplicationException("Invalid embedded script name: " + name);
            }
            var script = new StreamReader(assembly.GetManifestResourceStream(name)).ReadToEnd();
            context.Run(script);
        }
    }
}
