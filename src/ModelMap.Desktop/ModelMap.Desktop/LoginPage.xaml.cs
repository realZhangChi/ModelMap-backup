using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using ModelMap.Desktop.ViewModel;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, IPage, ITransientDependency
    {
        public LoginPage(LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            BindingContext = loginPageViewModel;
        }
    }
}