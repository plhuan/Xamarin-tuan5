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
        Cart cart = null;
        public GuestBookDetailPage(Book book)
        {
            this.book = book;
            InitializeComponent();
            InitBookDetail();
        }
        public GuestBookDetailPage(Cart selectedCart, Book selectedBook)
        {
            this.cart = selectedCart;
            this.book = selectedBook;
            InitializeComponent();
            InitBookDetail();
            InitButtonText();
        }
        
        void InitBookDetail()
        {
            eleBImg.Source = book.bImg;
            eleBTitle.Text = book.bTitle;
            eleBCost.Text = book.bCost;
        }
         
        void InitButtonText()
        {
            btnAddCart.Text = "Xoá khỏi giỏ";
        }
        void AddCart(Database db)
        {
            Cart newCart = new Cart();
            newCart.bId = book.bId;
            newCart.totalAmount = book.bCost;

            if (db.AddCart(newCart))
            {
                DisplayAlert("Thông báo", "Thêm vào giỏ hàng thành công", "OK");
                Navigation.PushAsync(new CartPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm sách không thành công", "OK");
            }
        }

        void RemoveFromCart(Database db)
        {
            if (db.RemoveCart(cart))
            {
                DisplayAlert("Thông báo", "Xoá sách khỏi giỏ hàng thành công", "OK");
                Navigation.PushAsync(new CartPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Xoá sách khỏi giỏ hàng không thành công", "OK");
            }
        }

        private void btnAddCart_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            if(this.cart == null)
            {
                AddCart(db);
                return;
            }

            RemoveFromCart(db);

        }
    }
}