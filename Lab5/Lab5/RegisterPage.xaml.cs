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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if(inputPassword.Text != inputConfimPassword.Text)
            {
                txtNotifice.Text = "Mật khẩu không trùng khớp";
                return;
            }

            User user = new User();

            user.username = inputUsername.Text;
            user.password = inputPassword.Text;
            user.isAdmin = false;

            Database db = new Database();

            if (db.RegisterUser(user))
            {
                DisplayAlert("Thông báo", "Đăng ký thành công", "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                txtNotifice.Text = "Tên đăng nhập đã tồn tại";
            }
        }
    }
}