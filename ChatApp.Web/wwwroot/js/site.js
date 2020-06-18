(function() {
    var txtMessage = $('#txtMessage');
    var btnSend = $('#btnSend');
    var listMessages = $('#listMessages');
    var userName = $('#userName').val();
    var connection = new signalR.HubConnectionBuilder().withUrl('/ChatHub').build();
    $(btnSend).click(function() {
        var userMessage = $(txtMessage).val();
        connection.invoke('SendMessage',
            {
                Username: userName,
                Message: userMessage
            }).catch(function(error) {
                alert("can't");
                console.log(error);
        });
        $(txtMessage).val('');

    });
    connection.start().then(function() {
        console.log('Connected to the signalr hub');
        $(btnSend).removeAttr('disabled');
    });
    connection.on('ReceiveMessage',
        function(obj) {
            $(listMessages).prepend('<li>[ '
                + obj.timeStamp + ' ] '
                + '<span class="font-weigh-bold"> user: '
                + obj.username
                + '</span> | message '
                + obj.message + '</li>');
        });
})();