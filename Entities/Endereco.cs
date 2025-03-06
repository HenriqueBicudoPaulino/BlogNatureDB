namespace BlogNatureDB.Entities
{
    public class Endereco : Entity<int>
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
    }
}
