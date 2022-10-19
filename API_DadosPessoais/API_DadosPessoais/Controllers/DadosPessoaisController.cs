using API_DadosPessoais.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DadosPessoais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosPessoaisController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Calcular(DadosDTO dados)
        {

            if (dados.DataNacimento != 0)
            {
                DateTime data = new DateTime(dados.DataNacimento);
                DateTime.DaysInMonth(data.Year, data.Month);
                dados.Idade = dados.Idade - data.Year;
            }

            var Idade = dados.Idade;

            return BadRequest(Idade);


        }

        public ActionResult<string> Calcular(ImcDTO dados)
        {
            var ResulImcDTO = new ImcDTO();


                if (dados.Altura == 0)
                {
                    return BadRequest("A altura não pode ser zero");
                }

                var resultado = dados.Peso / (dados.Altura * dados.Altura);
                var classificacao = "";

                if (resultado <= 18)
                {
                    classificacao = "Abaixo do Peso";
                }
                else if (resultado <= 25)
                {
                    classificacao = "Peso Normal";
                }
                else if (resultado <= 30)
                {
                    classificacao = "Acima do Peso";
                }
                else
                {
                    classificacao = "Obesidade";
                }

                var NovoImcDTO = new ImcDTO
                {
                    Nome = dados.Nome,
                    Altura = dados.Altura,
                    Peso = dados.Peso,
                    Resultado = Decimal.Round(resultado, 2),
                    Classificacao = classificacao,
                };

            NovoImcDTO.Add(ImcDTO);

            }

            return Ok(ImcDTO);
        }

    }
}
