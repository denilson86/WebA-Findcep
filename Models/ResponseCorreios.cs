using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPiFindCEP.Models
{
    public class ResponseCorreios
    {
        public string cep { get; set; }
        public string logradouro { get; set; } = "";
        public string complemento { get; set; } = "";
        public string bairro { get; set; } = "";
        public string cidade { get; set; } = "";
        public string uf { get; set; } = "";
        public string ibge { get; set; } = "";
        public string retorno { get; set; } = "";
        public string DataHora { get; set; }
    }
}
