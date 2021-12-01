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
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.username = inputUsername.Text;
            user.password = inputPassword.Text;

            Database db = new Database();

            List<User> userList = db.IsAccessUser(user);
            
            if(userList == null)
            {
                txtNotifice.Text = "Tài khoản hoặc mật khẩu không chình xác";
                return;
            }

            if(userList.Count > 0)
            {
                if (userList.ElementAt(0).isAdmin)
                {
                    Navigation.PushAsync(new AdminBookListPage());
                }
                else
                {
                    Navigation.PushAsync(new GuestBookListPage(userList.ElementAt(0)));
                }
                
            }
            else
            {
                txtNotifice.Text = "Tài khoản hoặc mật khẩu không chình xác";

            }

        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
