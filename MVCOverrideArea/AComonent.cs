using RazorClassLibrary3;

namespace MVCOverrideArea
{
  public class AComonent : IComonent, IDisposable
  {
    public AComonent()
    {
      AsyncLock = new SemaphoreSlim(1);
    }
    public bool? IsOk { get; set; }

    public SemaphoreSlim? AsyncLock { get; private set; }

    public void Dispose()
    {
      AsyncLock.Dispose();
      AsyncLock = null;
    }
  }
}
