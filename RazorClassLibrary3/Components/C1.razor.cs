using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RazorClassLibrary3.Components
{
  public class CBase : ComponentBase, IDisposable
  {
    [Inject]
    public IComonent c { get; set; }
    [Inject]

    public IJSRuntime js { get; set; }

    public int count { get; set; }
    [Parameter]
    public string? Dexc { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      await base.OnAfterRenderAsync(firstRender);


    }
    protected override async Task OnInitializedAsync()
    {
      await base.OnInitializedAsync();
      await c.AsyncLock.WaitAsync();
      if (c.IsOk == null)
      {
        c.IsOk = true;
      }
      c.AsyncLock.Release();
      Console.WriteLine($"{Dexc ?? ""} {this.GetHashCode()} {DateTime.UtcNow.ToString()}");
      _ = ReFresh();
    }

    private async Task ReFresh()
    {
      while (idDispose != true)
      {
        if (idDispose)
        {
          Console.WriteLine("still running");
        }
        await Task.Delay(1000);
        count = count + 1;
        this.StateHasChanged();
      }
    }
    bool idDispose = false;
    public void Dispose()
    {
      idDispose = true;
      Console.WriteLine($" dispose {Dexc ?? ""} {this.GetHashCode()} {DateTime.UtcNow.ToString()}");
    }
  }
}
