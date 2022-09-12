using AutoMapper;
using StockApplication.Data.Entities;
using StockApplication.Data.Models;
using StockApplication.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication.Domain.MappingProfile
{
    public class StockDetailsProfile : Profile
    {
        public StockDetailsProfile()
        {
            CreateMap<StockTickData, StockEntity>()
                .ForMember(src => src.StockShares, opt => opt.MapFrom(dest => dest.Shares))
                .ForMember(src => src.StockPrice, opt => opt.MapFrom(dest => dest.Price))
                .ForMember(src => src.StockSymbol, opt => opt.MapFrom(dest => dest.Symbol))
                .ForMember(src => src.BrokerId, opt => opt.MapFrom(dest => dest.BrokerId))
                .ForMember(src => src.StockDate, opt => opt.MapFrom(dest => dest.Created))
                .ForMember(src => src.StockId, opt => opt.Ignore());

            CreateMap<StockSymbol, TickerSymbol>()
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.TickerName));

            CreateMap<StockEntity, StockSymbolResponse>()
                .ForMember(src => src.StockShares, opt => opt.MapFrom(dest => dest.StockShares))
                .ForMember(src => src.StockPrice, opt => opt.MapFrom(dest => dest.StockPrice))
                .ForMember(src => src.StockSymbol, opt => opt.MapFrom(dest => dest.StockSymbol))
                .ForMember(src => src.BrokerId, opt => opt.MapFrom(dest => dest.BrokerId))
                .ForMember(src => src.StockDate, opt => opt.MapFrom(dest => dest.StockDate));
                                
            ;

        }
    }
}
