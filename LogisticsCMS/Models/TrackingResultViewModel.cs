namespace LogisticsCMS.Models
{
    public class TrackingResultViewModel
    {
        public string TrackingNumber { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string OriginCity { get; set; } = string.Empty;
        public string OriginDistrict { get; set; } = string.Empty;
        public string DestinationCity { get; set; } = string.Empty;
        public string DestinationDistrict { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CurrentStatus { get; set; } = string.Empty;
        public List<TrackingEventViewModel> Events { get; set; } = new();

        // Geçerli duruma göre progress bar'daki adım index'i (0-4).
        public int CurrentStepIndex =>
            CurrentStatus switch
            {
                "Gönderi Alındı" => 0,
                "Transfer Merkezinde" => 1,
                "Yolda" => 2,
                "Dağıtımda" => 3,
                "Teslim Edildi" => 4,
                _ => 0,
            };

        public bool IsDelivered => CurrentStatus == "Teslim Edildi";
    }
}
