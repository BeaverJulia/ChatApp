using System;
using System.Collections.ObjectModel;
using ChatApp.DTO;
using ChatApp.DTO.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly HubConnection hubConnection;
        private readonly string userName;
        private ObservableCollection<UserChatMessageDto> messages { get; } =
            new ObservableCollection<UserChatMessageDto>();

        public ChatPage(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            btnSend.Clicked += BtnSend_Clicked;
            lvMessages.ItemsSource = messages;
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://127.0.0.1:5000/")
                .Build();
            hubConnection.On<UserChatMessageDto>(Const.RECEIVE_MESSAGE, ReceiveMessage_Event);
            hubConnection.StartAsync();
        }

        private void ReceiveMessage_Event(UserChatMessageDto obj)
        {
            messages.Insert(0, obj);
        }

        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            var message = txtMessage.Text;
            if (string.IsNullOrWhiteSpace(message))
            {
                await DisplayAlert("Validation errors", "The Message is required", "Ok");
                return;
            }

            await hubConnection.SendAsync(Const.SEND_MESSAGE, new UserChatMessageDto
            {
                Message = message,
                Username = userName
            });
        }
    }
}