using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain.Model;
using SerwisPlanszowkowy.ViewModels;

namespace SerwisPlanszowkowy.Mappings
{
    public class DomainToViewModelMapping : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }


        public DomainToViewModelMapping()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<Game, GameDetailsViewModel>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Rate, RateViewModel>();
            CreateMap<News, NewsViewModel>();
            CreateMap<User, UserDetailsViewModel>();
            CreateMap<User, UserEditViewModel>();
            CreateMap<User, UserStatisticsViewModel>()
                .ForMember(dest => dest.NumberOfAddedComments, opts => opts.MapFrom(src => src.Comments.Count()))
                .ForMember(dest => dest.NumberOfAddedRates, opts => opts.MapFrom(src => src.Rates.Count()))
                .ForMember(dest => dest.NumberOfAddedReviews, opts => opts.MapFrom(src => src.Reviews.Count()))
                .ForMember(dest => dest.NumberOfAddedGameplays, opts => opts.MapFrom(src => src.Gameplays.Count()));
            CreateMap<Game, GameCreateEditViewModel>();
            CreateMap<Review, ReviewViewModel>();
        }
    }
}