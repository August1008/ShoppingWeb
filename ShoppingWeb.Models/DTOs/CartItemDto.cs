﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.DTOs
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
