using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Classes
{
    class Class1
    {


        int a, b, c;

        public bool verificariangulo(int a, int b, int c)
        {
            bool v =false;
            v = c < (a + b) && b < (a + c) && a < (b + c) ?  true : false;
            return v;
        }

    }
}
 