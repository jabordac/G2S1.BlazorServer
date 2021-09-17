using G2S1.BlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G2S1.BlazorServer.Pages.Books.Views
{
    public partial class BooksListView
    {
        [Inject] private IJSRuntime jsRuntime { get; set; }
        [Inject] private ISnackbar snackBar { get; set; }
        [Inject] private IDialogService dialogService { get; set; }
        //[Inject] private IBookService bookService { get; set; }

        private List<Book> Books { get; set; }
        private string searchString = string.Empty;
        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await UpdateGrid();
        }

        private async Task UpdateGrid()
        {
            isLoading = true;

            //Books = await bookService.GetAll();

            Books = new List<Book>
            {
                new Book { BookId = Guid.NewGuid(), Name = "Libro 1", AuthorId  = Guid.NewGuid(), Pages = 100, Price = 100.25, PublishDate = DateTime.Parse("01-05-2005"), State = true },
                new Book { BookId = Guid.NewGuid(), Name = "Libro 2", AuthorId  = Guid.NewGuid(), Pages = 200, Price = 75, PublishDate = DateTime.Parse("01-05-2005"), State = true },
                new Book { BookId = Guid.NewGuid(), Name = "Libro 3", AuthorId  = Guid.NewGuid(), Pages = 50, Price = 25, PublishDate = DateTime.Parse("01-05-2005"), State = false },
            };

            isLoading = false;
        }

        private bool FilterFunc(Book element)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (element.Pages.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }

        private async Task ShowBookModal(Guid? idBook, string accion)
        {
            //var parameters = new DialogParameters()
            //{
            //    { nameof(SetBookDialog.BookId), idBook},
            //    { nameof(SetBookDialog.Action), accion }
            //};

            //var options = new DialogOptions
            //{
            //    CloseButton = true,
            //    MaxWidth = MaxWidth.Large,
            //    FullWidth = true,
            //    DisableBackdropClick = true
            //};

            //var dialog = dialogService.Show<SetBookDialog>("Cargando...", parameters, options);
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    await UpdateGrid();
            //}
        }


        #region Eventos Grid

        private async Task OnAddBook()
        {
            await ShowBookModal(null, "ADD");
        }

        private async Task OnEditBook(Guid BookId)
        {
            await ShowBookModal(BookId, "EDIT");
        }

        private async Task OnViewBook(Guid BookId)
        {
            await ShowBookModal(BookId, "VIEW");
        }

        [JSInvokable]
        public async Task DisplayMessage()
        {
            snackBar.Add("Hola desde JS a C#");
        }


        private async Task OnDeleteBook(Guid BookId)
        {
            //await jsRuntime.InvokeVoidAsync("DisplayMessageJSToCS", DotNetObjectReference.Create(this));

            //bool response = await jsRuntime.DisplayMessageCSToJS("Hola desde JS");

            //if(response)
            //{
            //    snackBar.Add("Eliminar SI");
            //}
            //else
            //{
            //    snackBar.Add("Eliminar NO");
            //}

            //var parameters = new DialogParameters()
            //{
            //    { nameof(MessageBoxComponent.Style), MessageBoxComponent.DialogStyle.Question },
            //    { nameof(MessageBoxComponent.Title), "Eliminar Libro" },
            //    { nameof(MessageBoxComponent.Subtitle1), "¿Confirma la eliminación del registro seleccionado?" },
            //    { nameof(MessageBoxComponent.Subtitle2), null },
            //    { nameof(MessageBoxComponent.YesText), "Si" },
            //    { nameof(MessageBoxComponent.NoText), "No" },
            //    { nameof(MessageBoxComponent.CancelText), null },
            //};

            //var options = new DialogOptions
            //{
            //    CloseButton = false,
            //    MaxWidth = MaxWidth.Small,
            //    DisableBackdropClick = true
            //};

            //var dialog = dialogService.Show<MessageBoxComponent>("Iniciando...", parameters, options);
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    if ((bool)(result.Data ?? false))
            //    {
            //        snackBar.Add("Registro eliminado.", Severity.Success);
            //    }
            //}
        }

        #endregion

    }
}
