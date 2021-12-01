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
    public partial class GuestBookListPage : ContentPage
    {
        User user = null;
        public GuestBookListPage()
        {
            InitializeComponent();
            InitBookList();
        }
        public GuestBookListPage(User user)
        {
            this.user = user;
            InitializeComponent();
            InitBookList();
        }

        void InitBookList()
        {
            if(user != null)
            {
                txtHello.Text = "Chào "+ user.username + "!";
            }
            Database db = new Database();

            List<Book> bookList = db.GetBookList();

            if(bookList == null) return;

            lstBook.ItemsSource = bookList;
        }

        private void lstBook_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)lstBook.SelectedItem;
            Navigation.PushAsync(new GuestBookDetailPage(selectedBook));
            
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage());
        }
    }
}