using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SerwisPlanszowkowy.Mappings
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMapping>();
             //   x.AddProfile<ViewModelToDomainMapping>();

            });
        }
    }
}