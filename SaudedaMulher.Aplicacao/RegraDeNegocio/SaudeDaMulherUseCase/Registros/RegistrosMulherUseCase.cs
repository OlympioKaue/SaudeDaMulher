using FluentValidation.TestHelper;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Validacoes;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;
using SaudeDaMulher.Comunicacao.RespostaDTO;
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
        private readonly ISalvarDados _salvar;

        public RegistrosMulherUseCase(IMulheresRepositorio addMulheres, ISalvarDados salvar)
        {
            _addMulheres = addMulheres;
            _salvar = salvar;
        }


        public async Task<RespostaRegistroMulher> Executar(CadastroMulheres cadastro)
        {
            Validacoes(cadastro);

            // USE OUTRO MEIO DE MAPEAMENTO.

            // await _addMulheres.Add(// Vem Do Mapeamento //);
            await _salvar.SalvarDados();

            // return (retorne o mapeamento, mas lembre- se você precisa saber como faz);
            if(cadastro is null)
            {
                throw new Exception(new RespostaRegistroMulher
                {
                    Mensagem = "Erro ao registrar mulher",
                    Sucesso = false
                }.ToString());

            }

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
                return;
            }
        }
    }
}
