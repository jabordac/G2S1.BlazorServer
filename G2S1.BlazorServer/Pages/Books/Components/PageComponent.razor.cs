using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using G2S1.BlazorServer.Data;
using MudBlazor;

namespace G2S1.BlazorServer.Pages.Books.Components
{
    public partial class PageComponent
    {
        [CascadingParameter(Name = "Book")] public Book Book { get; set; }

        [Inject] private ISnackbar snackBar { get; set; }


        [Parameter] public int PageId { get; set; }
        [Parameter] public string State { get; set; }

        [Parameter] public RenderFragment TitleFragment { get; set; }
        [Parameter] public RenderFragment ContentFragment { get; set; }
        [Parameter] public EventCallback<int> OnPagePrintClick { get; set; }

        private int FavoriteCount { get; set; } = 0;
        [Parameter] public int FavoriteCountTotal { get; set; }
        [Parameter] public EventCallback<int> FavoriteCountTotalChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync");
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

        async Task OnFavoriteClick()
        {
            FavoriteCount++;
            FavoriteCountTotal++;
            await FavoriteCountTotalChanged.InvokeAsync(FavoriteCountTotal);
        }

        public void ChangeState(string state)
        {
            State = state;
            StateHasChanged();
        }
    }
}
