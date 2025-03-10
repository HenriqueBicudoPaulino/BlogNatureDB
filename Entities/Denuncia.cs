namespace BlogNatureDB.Entities
{
    public class Denuncia:Entity<int>
    {
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DateTime { get; set; }
        public string Responsavel { get; set; }
        public string Impactos { get; set; }
        public File Arquivo { get; set; }
        public bool Anonimato { get; set; }
    }
}