using G2S1.BlazorServer.Data;
using G2S1.BlazorServer.Pages.Books.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace G2S1.BlazorServer.Pages.Books.Views
{
    public partial class BooksView
    {
        [Parameter] public Book Book { get; set; }
        private bool isLoading = true;

        private int FavoriteCountTotal { get; set; } = 0;
        
        PageComponent page;
        ConfirmComponent confirm;

        protected override async Task OnInitializedAsync()
        {
            //await Task.Delay(5000);
            Book = new Book { BookId = Guid.NewGuid(), Name = "Blazor Sin Fronteras" };
            isLoading = false;
        }

        private void OnPagePrintClick(int pageId)
        {
            snackBar.Add($"Imprimir Página {pageId}");
        }

        private void OnChangeStateClick()
        {
            page.ChangeState("Inactiva");
            confirm.ChangeState("Inactiva");
        }
    }
}