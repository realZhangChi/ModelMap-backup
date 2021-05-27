using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage, ITransientDependency
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
