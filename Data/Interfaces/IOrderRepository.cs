﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> Orders { get; }
    }
}
