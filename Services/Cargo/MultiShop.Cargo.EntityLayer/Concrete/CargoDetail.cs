namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int Id { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
