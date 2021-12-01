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
            ListBookInit();
        }
        public AdminBookListPage(User user)
        {
            InitializeComponent();
            ListBookInit();
        }
        public void ListBookInit()
        {
            Database db = new Database();
            List<Book> books = db.GetBookList();
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