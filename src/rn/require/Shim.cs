using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Noesis.Javascript;

namespace rn.require
{
    public class Shim
    {
        private readonly JavascriptContext context;
        private readonly string[] args;

        public Shim(JavascriptContext context, string[] args)
        {
            this.context = context;
            this.args = args;
        }

        public string[] Args()
        {
            return args;
        }

        public void ConsoleLog(string msg)
        {
            Console.WriteLine(msg);
        }

        public bool FsExists(string filename)
        {
            ConsoleLog("FsExists " + filename);
            return File.Exists(filename);
        }

        public string FsReadFileSync(string filename, string encoding)
        {
            ConsoleLog("FsReadFileSync" + filename);
            return File.ReadAllText(filename);
        }


        public object VmRunInThisContext(string code, string filename)
        {
            ConsoleLog("VmRunInThisContext " + code + " " + filename);

            if (string.IsNullOrEmpty(filename))
            {
                return context.Run(code);
            }

            return context.Run(code, filename);
        }


        public string PathResolve(string path)
        {
            ConsoleLog("PathResolve " + path);
            return Path.GetFullPath(path);
        }
    }
}