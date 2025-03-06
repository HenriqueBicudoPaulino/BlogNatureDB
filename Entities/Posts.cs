namespace BlogNatureDB.Entities
{
    public class Posts : Entity<int>
    {
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime DataPost { get; set; }
        public int Likes { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
