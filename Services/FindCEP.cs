using System;
using System.Threading.Tasks;
using WebAPiFindCEP.Models;
using Correios;

namespace WebAPiFindCEP.Services
{
    public class FindCEP
    {
        public async Task<ResponseCorreios> BuscaCEP(string cep)
        {
            var DataHora = DateTime.Now;
            ResponseCorreios respCorreios = new ResponseCorreios();

            try
            {
                if (cep != string.Empty)
                {                    
                    CorreiosApi correios = new CorreiosApi();
                    var retorno = correios.consultaCEP(cep);

                    if (retorno != null)
                    {
                        respCorreios.cep = cep;
                        respCorreios.uf = retorno.uf;
                        respCorreios.cidade = retorno.cidade;
                        respCorreios.bairro = retorno.bairro;
                        respCorreios.complemento = retorno.complemento;
                        respCorreios.logradouro = retorno.end;
                        respCorreios.retorno = "OK";
                        respCorreios.DataHora = DataHora.ToString("MM/dd/yyyy HH:MM:ss");

                    }
                    else
                    {
                        respCorreios.cep = cep;
                        respCorreios.uf = "";
                        respCorreios.cidade = "";
                        respCorreios.bairro = "";
                        respCorreios.complemento = "";
                        respCorreios.logradouro = "";
                        respCorreios.retorno = "CEP NAO ENCONTRADO";
                        respCorreios.DataHora = DataHora.ToString("MM/dd/yyyy HH:MM:ss");
                      
                        
                    }

                    return respCorreios;
                }

                return null;

            }
            catch (Exception)
            {
                var responseCorreios = new ResponseCorreios
                {
                    cep = cep,
                    uf = "",
                    cidade = "",
                    bairro = "",
                    complemento = "",
                    logradouro = "",
                    retorno = "CEP NAO ENCONTRADO",
                    DataHora = DataHora.ToString("MM/dd/yyyy HH:MM:ss")
                };

                return responseCorreios;
            }
        }
    }
}