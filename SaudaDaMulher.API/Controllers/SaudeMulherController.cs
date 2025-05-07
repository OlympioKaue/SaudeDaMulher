using Microsoft.AspNetCore.Mvc;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;

namespace SaudaDaMulher.API.Controllers;

[Route("[controller]")]
[ApiController]
public class SaudeMulherController : ControllerBase
{
    [HttpPost(" v1- (registrar)")]
    public async Task<IActionResult> RegistrarMulher([FromServices] IRegistrosMulherUseCase registroMulher, CadastroMulheres cadastro)
    {
        var resposta = await registroMulher.Executar(cadastro);

        return Created(string.Empty, resposta);

        // REGISTROS DA MULHER.
    }

    [HttpGet(" v1 - (obterPerfil){idDaMulher:int}")]
    public IActionResult ObterMulher([FromRoute] int idDaMulher)
    {
        return Ok();

        // RETORNA O PERFIL DA MULHER, COM NOME, IDADE, ENDEREÇO, TELEFONE, EMAIL.
    }

}
