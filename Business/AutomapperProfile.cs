using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Product, ProductModel>()
                .ForMember(p => p.ProductID, pm => pm.MapFrom(x => x.ProductID))
                .ForMember(p => p.Name, pm => pm.MapFrom(x => x.Name))
                .ForMember(p => p.Category, pm => pm.MapFrom(x => x.Category))
                .ForMember(p => p.Price, pm => pm.MapFrom(x => x.Price))
                .ForMember(p => p.Description, pm => pm.MapFrom(x => x.Description))
                .ReverseMap();

            CreateMap<Order, OrderModel>()
                .ForMember(p => p.OrderID, pm => pm.MapFrom(x => x.OrderID))
                .ForMember(p => p.Name, pm => pm.MapFrom(x => x.Name))
                .ForMember(p => p.Line1, pm => pm.MapFrom(x => x.Line1))
                .ForMember(p => p.Line2, pm => pm.MapFrom(x => x.Line2))
                .ForMember(p => p.Line3, pm => pm.MapFrom(x => x.Line3))
                .ForMember(p => p.City, pm => pm.MapFrom(x => x.City))
                .ForMember(p => p.Zip, pm => pm.MapFrom(x => x.Zip))
                .ForMember(p => p.Country, pm => pm.MapFrom(x => x.Country))
                .ForMember(p => p.GiftWrap, pm => pm.MapFrom(x => x.GiftWrap))
                .ReverseMap();

            CreateMap<OrderDetail, OrderDetailModel>()
                .ForMember(p => p.ProductID, pm => pm.MapFrom(x => x.ProductID))
                .ForMember(p => p.OrderID, pm => pm.MapFrom(x => x.OrderID))
                .ForMember(p => p.Quantity, pm => pm.MapFrom(x => x.Quantity))
                .ReverseMap();
        }
    }
}
