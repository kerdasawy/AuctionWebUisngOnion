using AutoMapper;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Infrastructure.ViewModel;

namespace AuctionWeb.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Bidder>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}
