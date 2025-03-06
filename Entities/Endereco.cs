namespace BlogNatureDB.Entities
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public virtual EstadosBrasileiros Estados { get; set; }
    }
}
