using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaudaDaMulher.API.Controllers
{
    [Route("prevenção")]
    [ApiController]
    public class ExamesPrevencaoController : ControllerBase
    {
        [HttpGet(" v1- (exames)")]
        public IActionResult ObterExames()
        {
            return Ok();

            // RETOTRNA TODOS OS EXAMES COM DESCRIÇÃO, RELATANDO QUAL A IDADE A SE FAZER, PRECAUCÇÕES ANTES DO EXAME.
        }

        [HttpGet(" v1 - (mês)")]
        public IActionResult ObterCampanha()
        {
            return Ok();

            // RETORNA O MÊS ATUAL, VERIFIQUE SE É O MES DE OUTRUBRO ROSA, MAIO ROXO, QUE É RELACIONADO A MULHER, NELE VOU MOSTRAR UM TEXTO AUTOEXPLICATIVO SOBRE A PREVENÇÃO.
        }



        // =============================================================================================================================================//
        //                                          ° LEMBRETES °                                                                                           //



        [HttpGet(" v1 - (lembretes)-{idDaMulher:int}")]
        public IActionResult EnviarLembrete([FromRoute] int idDaMulher)
        {
            return Ok();
        }

        [HttpGet(" v1 - (lembretes / educativos)-{idDaMulher:int}")]
        public IActionResult EnviarLembretesEducativos([FromRoute] int idDaMulher)
        {
            return Ok();

            // ENVIAR MENSAGENS MENSAIS OU SEMANAIS.
        }
    }
}
