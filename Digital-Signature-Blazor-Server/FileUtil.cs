using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signature_Blazor_Server
{
    public static class FileUtil
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
          => js.InvokeAsync<object>(
              "saveAsFile",
              filename,
              Convert.ToBase64String(data));
    }
}
