using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Resumo_5405_01
    {
        public string material { get; set; }
        public string descricao { get; set; }
        public string unid     { get; set; }
        public double fator    { get; set; }

        public Resumo_5405_01()
        {
            Zerar();
        }

      

        public void Zerar()
        {
            this.material = "";
            this.descricao = "";
            this.unid = "";
            this.fator = 0;
        }
    }
}
