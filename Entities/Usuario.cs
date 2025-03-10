namespace BlogNatureDB.Entities
{
    public class Usuario:Entity<int>
    {
        public string Sobrenome { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public string Telefone { get; set; }
    }
}
