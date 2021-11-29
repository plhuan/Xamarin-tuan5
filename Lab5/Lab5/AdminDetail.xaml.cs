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
    public partial class AdminDetail : ContentPage
    {
        Book book;
        public AdminDetail()
        {
            InitializeComponent();
        }
        public AdminDetail(Book book)
        {
            this.book = book;
            InitializeComponent();
            InitBookDetail();
        }

        void InitBookDetail ()
        {
            eleBTitle.Text = book.bTitle;
            eleBImg.Source = book.bImg;
            eleBCost.Text = book.bCost;
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();

            if (db.DeleteBook(book))
            {
                DisplayAlert("Thông báo", "Xoá thành công", "OK");
                Navigation.PushAsync(new AdminBookListPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Xoá không thành công", "OK");
            }
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new BookUpdatePage(book));
        }
    }
}