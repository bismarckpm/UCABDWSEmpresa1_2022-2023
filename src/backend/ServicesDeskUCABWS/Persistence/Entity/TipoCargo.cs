namespace ServicesDeskUCABWS.Persistence.Entity
{
    public class TipoCargo
    {
        public int id {get; set;}

        public string? nombre {get; set;}
         public ICollection<ModeloJerarquicoCargos>? Jeraruia { get; set; }
       
    }
}