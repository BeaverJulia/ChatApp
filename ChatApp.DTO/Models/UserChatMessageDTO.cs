using System;

namespace ChatApp.DTO.Models
{
    public class UserChatMessageDto
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TimeStampString => TimeStamp.ToString("dd-MM-yyy, hh:mm:ss");
    }
}
