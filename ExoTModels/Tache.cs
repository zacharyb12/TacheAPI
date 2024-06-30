using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoTModels
{
    public class Tache
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string Titre { get; set; }


        public DateTime Creation { get; set; }

        public bool Terminer { get; set; }
    }
}
