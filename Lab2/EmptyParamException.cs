using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public class EmptyParamException : Exception
    {
        public override string Message => "Empty parameter";
    }
}
