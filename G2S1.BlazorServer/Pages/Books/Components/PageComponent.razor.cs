using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using G2S1.BlazorServer.Data;
using MudBlazor;

namespace G2S1.BlazorServer.Pages.Books.Components
{
    public partial class PageComponent
    {
        [Inject] private ISnackbar snackBar { get; set; }

        [CascadingParameter(Name = "Book")] public Book Book { get; set; }
        [Parameter] public int PageId { get; set; }
        [Parameter] public EventCallback<int> OnPagePrintClick { get; set; }
        [Parameter] public RenderFragment TitleFragment { get; set; }
        [Parameter] public RenderFragment ContentFragment { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //StateHasChanged();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Console.WriteLine($"OnAfterRender: {firstRender}");
        }

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine("OnParametersSetAsync");
        }

        protected override bool ShouldRender()
        {
            Console.WriteLine("ShouldRender");
            return true;
        }

        private void OnPrintClick(int pageId)
        {
            OnPagePrintClick.InvokeAsync(pageId);
        }
    }
}
