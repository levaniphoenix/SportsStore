﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
	public interface IProductService : ICrud<ProductModel>
	{
        IEnumerable<string> getAllCategories();

    }
}
