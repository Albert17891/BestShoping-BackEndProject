namespace MarketApi.Model.Request.Product;

public class ProductRequest
{   
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}
