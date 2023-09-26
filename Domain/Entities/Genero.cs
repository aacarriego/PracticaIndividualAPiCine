using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Genero
    {

        // PK
        // [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneroId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }


        public virtual ICollection<Pelicula> Peliculas { get; set; }

        public Genero() { }
    }
}
