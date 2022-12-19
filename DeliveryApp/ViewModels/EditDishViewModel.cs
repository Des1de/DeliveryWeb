namespace DeliveryApp.ViewModels
{
    public class EditDishViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public string? URL { get; set; }
        public IFormFile Image { get; set; }
    }
}
