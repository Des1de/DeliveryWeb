namespace DeliveryApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }

        public string RestarauntAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public string? UserEmail { get; set; }

    }
}
