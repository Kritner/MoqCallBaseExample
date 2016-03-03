using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqCallBaseExample.Business
{
    public interface ISomeDependency
    {
        void DoStuff();
    }

    public class Foo
    {

        const int _VALUE1 = 5;
        const int _VALUE2 = 10;

        public int CalculateSomeValue()
        {
            return CalculateSomeValue(_VALUE1);
        }

        public virtual int CalculateSomeValue(int value1)
        {
            return CalculateSomeValue(_VALUE1, _VALUE2);
        }

        public virtual int CalculateSomeValue(int value1, int value2)
        {
            return value1;

        }
    }
}
