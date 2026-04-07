namespace LogisticsCMS.Models
{
    public class TrackingEventViewModel
    {
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TrackingStatus { get; set; } = string.Empty;

        // Timeline marker CSS sınıfı.
        public string MarkerClass =>
            TrackingStatus switch
            {
                "Teslim Edildi" => "delivered",
                "Dağıtımda" => "transit",
                "Yolda" => "transit",
                _ => "processing",
            };

        // Timeline'da gösterilecek Bootstrap icon.
        public string IconClass =>
            TrackingStatus switch
            {
                "Teslim Edildi" => "bi-check-circle-fill",
                "Dağıtımda" => "bi-truck",
                "Yolda" => "bi-arrow-right-circle-fill",
                "Transfer Merkezinde" => "bi-building",
                "Gönderi Alındı" => "bi-box-seam",
                _ => "bi-circle",
            };
    }
}
