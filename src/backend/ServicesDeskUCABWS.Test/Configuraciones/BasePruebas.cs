

using AutoMapper;
using ServicesDeskUCABWS.BussinessLogic.Mapper;
using Microsoft.EntityFrameworkCore;

namespace ServicesDeskUCABWS.Test.Configuraciones
{
    public class BasePrueba
    {
        protected IMapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EtiquetaMapper());
                cfg.AddProfile(new PlantillaMapper());
                cfg.AddProfile(new CargoMapper());
            });
            return config.CreateMapper();
        }

        // BdContext 

    }
}