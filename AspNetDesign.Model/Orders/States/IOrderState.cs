﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Orders.States
{
    public interface IOrderState
    {
        int Id { get; set; }
        OrderStatus Status { get; }
        bool CanAddProduct();
        void Submit(Order order);
    }
}
