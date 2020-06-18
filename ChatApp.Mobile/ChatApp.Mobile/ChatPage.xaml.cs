using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly string userName;

        public ChatPage(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }
    }
}