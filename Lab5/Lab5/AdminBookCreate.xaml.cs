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
    public partial class AdminBookCreate : ContentPage
    {
        public AdminBookCreate()
        {
            InitializeComponent();
        }

        private void btnCreateBook_Clicked(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.bTitle = inputBookTitle.Text;
            newBook.bImg = inputBookImg.Text;
            newBook.bCost = inputBookCost.Text;

            Database db = new Database();

            if (db.CreateBook(newBook))
            {
                DisplayAlert("Thông báo", "Tạo sách thành công", "OK");
                Navigation.PushAsync(new AdminBookListPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Tạo sách không thành công", "OK");
            }

        }
    }
}