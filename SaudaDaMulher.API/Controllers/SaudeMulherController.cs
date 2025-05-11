using Microsoft.AspNetCore.Mvc;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.ObterRegistro;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;

namespace SaudaDaMulher.API.Controllers;

[Route("[controller]")]
[ApiController]
public class SaudeMulherController : ControllerBase
{
    [HttpPost("v1/registrar")]
    public async Task<IActionResult> RegistrarMulher([FromServices] IRegistrosMulherUseCase registroMulher, CadastroMulheres cadastro)
    {
        var resposta = await registroMulher.Executar(cadastro);

        return Created(string.Empty, resposta);

        // REGISTROS DA MULHER.
    }

    [HttpGet("v1/obterPerfil/{idDaMulher:int}")]
    public async Task<IActionResult> BuscarMulherRegistrada([FromServices] IObterRegistroMulherUseCase obterMulher, [FromRoute] int idDaMulher)
    {
        var resposta = await obterMulher.Executar(idDaMulher);
        return Ok(resposta);

        // RETORNA O PERFIL DA MULHER, COM NOME, IDADE, ENDEREÇO, TELEFONE, EMAIL.
    }

}
