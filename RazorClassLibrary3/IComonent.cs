using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary3
{
  public interface IComonent
  {

    SemaphoreSlim? AsyncLock { get; }
    bool? IsOk { get; set; }
  }
}
