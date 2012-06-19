﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noesis.Javascript;

namespace rn
{
    class Program
    {

        public class SystemConsole
        {
            public SystemConsole() { }

            public void Print(string iString)
            {
                Console.WriteLine(iString);
            }
        }

        static void Main(string[] args)
        {

            // Initialize a context

            using (JavascriptContext context = new JavascriptContext())
            {

                // Setting external parameters for the context
                context.SetParameter("console", new SystemConsole());
                context.SetParameter("message", "Hello World !");
                context.SetParameter("number", 1);

                // Script
                string script = @"
        var i;
        for (i = 0; i < 5; i++)
            console.Print(message + ' (' + i + ')');
        number += i;
    ";

                // Running the script
                context.Run(script);

                // Getting a parameter
                Console.WriteLine("number: " + context.GetParameter("number"));
            }


            Console.ReadKey();

        }
    }
}
