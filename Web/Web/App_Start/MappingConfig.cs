using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public static class MappingConfig
    {
        public static void AutoMapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                Service.Configure.AutoMapperConfiguration(cfg);
            });
        }
    }
}