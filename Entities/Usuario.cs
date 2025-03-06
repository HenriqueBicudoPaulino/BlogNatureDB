namespace BlogNatureDB.Entities
{
    public class Usuario:Entity<int>
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

    }
}
