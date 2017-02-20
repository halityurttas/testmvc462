using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Configure
    {
        public static void AutoMapperConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Data.TblTodo, Core.Models.TblTodo>();

            cfg.CreateMap<Core.Models.TblTodo, Data.TblTodo>();
        }
    }
}
