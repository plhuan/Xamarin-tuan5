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
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            InitCartList();
        }
        void InitCartList()
        {
            Database db = new Database();

            List<Cart> cartList = db.GetCartList();
            
            if(cartList == null)
            {
                return;
            }

            List<Book> bookList = new List<Book>();
            int totalCost = 0;

            foreach(Cart cart in cartList)
            {
                int bookId = cart.bId;

                List<Book> temp = db.GetOneBook(bookId);

                if (temp == null) continue;
                if(temp.Count > 0)
                {
                    bookList.Add(temp.ElementAt(0));
                    totalCost += Int32.Parse(temp.ElementAt(0).bCost);
                }
            }

            lstCartBook.ItemsSource = bookList;
            txtSum.Text = totalCost.ToString();
        }

        private void lstCartBook_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}