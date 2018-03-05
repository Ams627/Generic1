using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic1
{
    class X
    {
        
    }
    internal class Program
    {
        static int P() { return 12334;}
        private static Func<object, object> R(Type t)
        {
            Func<int> f = P;
            var o = (object) f;
            var gentype = typeof(Func<,>);
            var typeargs = new[] {t, typeof(object)};
            var constructed = gentype.MakeGenericType(typeargs);
            var result = (Func<object, object>)Activator.CreateInstance(constructed, (Func<int>)P);
            return result;
        }
        private static void Main(string[] args)
        {
            try
            {
                var result = R(typeof(X));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
