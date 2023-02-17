using Microsoft.JSInterop;

namespace Homework.Client.Services
{
    public class JsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Alert(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", message);
        }

        public async Task<string> Prompt(string message, string defaultValue = "")
        {
            return await _jsRuntime.InvokeAsync<string>("prompt", message, defaultValue);
        }

        public async Task<bool> Confirm(string message)
        {
            return await _jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
