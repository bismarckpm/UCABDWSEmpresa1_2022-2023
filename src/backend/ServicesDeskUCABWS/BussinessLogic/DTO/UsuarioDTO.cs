using ServicesDeskUCABWS.Persistence.Entity;

namespace ServicesDeskUCABWS.BussinessLogic.DTO
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        public int iddept {get;set;}
        public string dept {get;set;}
    }
}