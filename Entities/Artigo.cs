using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogNatureDB.Entities
{
    public class Artigo : Entity<int>
    {
        public String Titulo { get; set; }
        public string SubTitulo { get; set; }
        public virtual ICollection<Topico> Topicos { get; set; }    
    }
}
