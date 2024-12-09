﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public string ProductId{ get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid? ProductPromotionId { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public ProductPromotion? ProductPromotion { get; set; }

    }
}
