using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ModelMap.Desktop.Services.File;

namespace ModelMap.Desktop.Pages
{
    public partial class Index
    {
        private Lazy<Task<IJSObjectReference>> _jsTask;

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IFileService FileService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public Index()
        {
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./index.js").AsTask());
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

        }

        private async Task OnOpenSolutionClickedAsync()
        {
            var solutionPath = await FileService.SelectFileAsync();
        }

    }
}
