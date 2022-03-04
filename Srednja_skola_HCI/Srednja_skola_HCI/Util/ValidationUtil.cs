using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Srednja_skola_HCI.Util
{
    public abstract class ValidationUtil : ValidationRule
    {
        public abstract bool Validate(object o);
    }
}
