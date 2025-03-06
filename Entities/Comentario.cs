namespace BlogNatureDB.Entities
{
    public class Comentario : Entity<int>
    {
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime DataPost { get; set; }
        public int Likes { get; set; }
    }
}
