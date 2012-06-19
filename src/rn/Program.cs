using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;
using System.Reflection;
using System.IO;
using rn.require;

namespace rn
{
    class Program
    {

        static void Main(string[] args)
        {

            // Initialize a context

            using (JavascriptContext context = new JavascriptContext())
            {
                

                try
                {
                    // load shim
                    context.SetParameter("SHIM", new Shim(context, args));
                    context.RunEmbeddedScript("rn.require.shim.js");

                    // run r.js
                    context.RunEmbeddedScript("rn.require.r.js");

                }catch(JavascriptException e){

                    Console.WriteLine("JS Error ({0}): {1}", e.Line, e.Message);

                }

            }
            Console.WriteLine("Any key to quit");
            Console.ReadKey();

        }
    }
}
