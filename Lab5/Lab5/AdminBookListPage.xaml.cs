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
    public partial class AdminBookListPage : ContentPage
    {
        public AdminBookListPage()
        {
            InitializeComponent();
            ListBookInit("");
        }
        public AdminBookListPage(string username)
        {
            InitializeComponent();
            ListBookInit(username);
        }
        public void ListBookInit(string username)
        {
            txtHello.Text = username;
            Database db = new Database();
            List<Book> books = db.GetBookList();
            if (username != "")
            {
                txtHello.Text = "Chào " + username + "!";
            }
            if(books == null)
            {
                return;
            }

            lstBook.ItemsSource = books;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminBookCreate());
        }

        private void lstBook_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)lstBook.SelectedItem;

            Navigation.PushAsync(new AdminDetail(selectedBook));
        }
    }
}