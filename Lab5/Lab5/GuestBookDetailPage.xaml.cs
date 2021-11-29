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
    public partial class GuestBookDetailPage : ContentPage
    {
        Book book;
        public GuestBookDetailPage(Book book)
        {
            this.book = book;
            InitializeComponent();
            InitBookDetail();
        }

        void InitBookDetail()
        {
            eleBImg.Source = book.bImg;
            eleBTitle.Text = book.bTitle;
            eleBCost.Text = book.bCost;
        }

        private void btnAddCart_Clicked(object sender, EventArgs e)
        {
            Cart newCart = new Cart();
            newCart.bId = book.bId;
            newCart.totalAmount = book.bCost;

            Database db = new Database();
            if (db.AddCart(newCart))
            {
                DisplayAlert("Thông báo", "Thêm vào giỏ hàng thành công", "OK");
                Navigation.PushAsync(new GuestBookListPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm sách không thành công", "OK");
            }

        }
    }
}