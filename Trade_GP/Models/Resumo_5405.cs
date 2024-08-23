using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_GP.Models
{
    public class Resumo_5405
    {
        public int id_grupo { get; set; }
        public string cod_emp { get; set; }
        public string local { get; set; }
        public string material { get; set; }

        public Resumo_5405()
        {
        }

        public Resumo_5405(int id_grupo, string cod_emp, string local, string material)
        {
            this.id_grupo = id_grupo;
            this.cod_emp = cod_emp;
            this.local = local;
            this.material = material;
        }

        public void Zerar()
        {
            this.id_grupo = 1;
            this.cod_emp = "";
            this.local = "";
            this.material = "";
        }
    }
}
