using AutoMapper;
using BLL.ModelsDto;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Broker, BrokerDto>();
            CreateMap<BrokerDto, Broker>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Stock, StockDto>();
            CreateMap<StockDto, Stock>();

            CreateMap<CreateOrder, CreateOrderDto>();
            CreateMap<CreateOrderDto, CreateOrder>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
