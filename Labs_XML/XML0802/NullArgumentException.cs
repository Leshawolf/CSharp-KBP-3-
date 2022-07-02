using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML0802
{
   public class NullArgumentException:Exception
    {
        public NullArgumentException(string message): base(message) {}
    }
}
