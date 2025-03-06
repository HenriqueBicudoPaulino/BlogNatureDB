namespace BlogNatureDB.Entities
{
    public class Denuncia:Entity<int>
    {
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public Endereco Endereco { get; set; }
    }
}