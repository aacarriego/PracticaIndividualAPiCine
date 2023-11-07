using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Funcion
    {
        // PK
        public int FuncionId { get; set; }

        /// FK1
        public int PeliculaId { get; set; }

        /// FK2
        public int SalaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public TimeSpan Horario { get; set; }

        public virtual Pelicula Pelicula { get; set; }

        public virtual Sala Sala { set; get; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
