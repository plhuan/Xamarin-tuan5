using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitPicker();
        }

        void InitPicker()
        {
            string[] pickerTypes = new string[]
            {
                "Admin",
                "Guest"
            };

            pickerUserType.ItemsSource = pickerTypes;
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            string selectedType = pickerUserType.SelectedItem.ToString();
            string username = inputName.Text.ToString();
            if(selectedType == "Admin")
            {
                Navigation.PushAsync(new AdminBookListPage(username));
            }
            else
            {
                Navigation.PushAsync(new GuestBookListPage());
            }
        }
    }
}
