namespace OrdersMicroservice.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}