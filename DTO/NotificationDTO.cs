using System;

namespace VBTracker.DTO
{
    public class NotificationDTO
    {
        public string NotificationID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ClassID { get; set; }
        public string Priority { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsGlobal { get; set; }

        // Constructor mặc định
        public NotificationDTO() { }

        // Constructor có tham số
        public NotificationDTO(string notificationID, string title, string content, string createdBy,
                               DateTime createdDate, string classID, string priority, DateTime? expiryDate, bool isGlobal)
        {
            NotificationID = notificationID;
            Title = title;
            Content = content;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ClassID = classID;
            Priority = priority;
            ExpiryDate = expiryDate;
            IsGlobal = isGlobal;
        }
    }

}
