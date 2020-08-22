using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.PadraoDeProjeto.API.Entities
{
    public class Posicao
    {
        protected Posicao()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
