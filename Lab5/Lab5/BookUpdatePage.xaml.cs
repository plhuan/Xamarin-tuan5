using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookUpdatePage : ContentPage
    {
        Book book;
        public BookUpdatePage()
        {
            InitializeComponent();
        }
        public BookUpdatePage(Book book)
        {
            this.book = book;
            InitializeComponent();
            InitBookData(book);
        }

        void InitBookData(Book book)
        {
            inputBookTitle.Text = book.bTitle;
            inputBookImg.Text = book.bImg;
            inputBookCost.Text = book.bCost;
        }

        private void btnUpdateBook_Clicked(object sender, EventArgs e)
        {
            Book changedBook = new Book();

            changedBook.bId = this.book.bId;
            changedBook.bTitle = inputBookTitle.Text;
            changedBook.bImg = inputBookImg.Text;
            changedBook.bCost = inputBookCost.Text;

            Database db = new Database();
            
            if(db.UpdateBook(changedBook))
            {
                Navigation.PushAsync(new AdminBookListPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Cập nhật không thành công", "OK");
            }

        }
    }
}