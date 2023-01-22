﻿using MarketplaceManagement.Domain.Account;

namespace MarketplaceManagement.Domain.ProductModel;

public class Product
{
    public int Id { get; set; }
   // public string UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; }

    public List<UserProduct> UsersProducts { get; set; }
}
