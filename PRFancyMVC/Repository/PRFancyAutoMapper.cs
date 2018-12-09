using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PRFancy;

namespace PRFancyMVC.Repository
{
    public class PRFancyAutoMapper<Source, Destination>
        where Source:class
        where Destination:class
    {
        public PRFancyAutoMapper()
        {
            Mapper.CreateMap<category, Models.Category>();//Product ko Models Product me karna hai
            Mapper.CreateMap<product, Models.product>();
            Mapper.CreateMap<Models.product,product>();
            Mapper.CreateMap<Models.Category, category>();
            Mapper.CreateMap<Models.user,user>();
            Mapper.CreateMap<user,Models.user>();
            Mapper.CreateMap<productImage, Models.ProductImage>();
        }
        public Destination Translate(Source obj)
        {
            return Mapper.Map<Source, Destination>(obj);
        }
    }
}