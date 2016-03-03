using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoqCallBaseExample.Business;

namespace MoqCallBaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Foo f = new Foo();
            Console.WriteLine(f.CalculateSomeValue());

        }
    }
}
