using FluentValidation.TestHelper;
using SaudedaMulher.Aplicacao.Mapster;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Validacoes;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;
using SaudeDaMulher.Comunicacao.RespostaDTO;
using SaudeDaMulher.Domain.Models;
using SaudeDaMulher.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulher.Registros
{
    public class RegistrosMulherUseCase : IRegistrosMulherUseCase
    {
        private readonly IMulheresRepositorio _addMulheres;
        private readonly IMapsterConfig _teste;
        private readonly ISalvarDados _salvar;

        public RegistrosMulherUseCase(IMulheresRepositorio addMulheres, ISalvarDados salvar,IMapsterConfig teste)
        {
            _addMulheres = addMulheres;
            _teste = teste;
            _salvar = salvar;
        }


        public async Task<RespostaRegistroMulher> Executar(CadastroMulheres cadastro)
        {
            Validacoes(cadastro);

           var mapear = _teste.Mapear<CadastroMulheres, Feminino>(cadastro);

            await _addMulheres.Add(mapear);
            await _salvar.SalvarDados();


            return new RespostaRegistroMulher
            {
                Mensagem = "Mulher registrada com sucesso",
                Sucesso = true,
               
            };
        }

        private void Validacoes(CadastroMulheres cadastro)
        {
            var validacao = new ValidarRegistrosMulheres();
            var resultadoDaValidacao = validacao.Validate(cadastro);

            if(resultadoDaValidacao.IsValid is false)
            {
                var erros = resultadoDaValidacao.Errors.Select(x => x.ErrorMessage).ToList();
                throw new Exception("erro ao registrar");
            }
        }
    }
}
