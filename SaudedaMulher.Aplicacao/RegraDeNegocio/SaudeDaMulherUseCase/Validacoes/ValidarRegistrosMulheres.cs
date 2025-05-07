using FluentValidation;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Validacoes
{
   public class ValidarRegistrosMulheres : AbstractValidator<CadastroMulheres>
    {
        public ValidarRegistrosMulheres()
        {
            RuleFor(validar => validar.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .Length(3, 50)
                .WithMessage("O nome deve ter entre 3 e 50 caracteres.");

            RuleFor(validar => validar.DataNascimento)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("A data de nascimento deve ser menor ou igual a data atual.");

            RuleFor(validar => validar.Endereco)
                .NotEmpty()
                .Length(5, 100)
                .WithMessage("É obrigátorio fornecer o endereço, O endereço deve ter entre 5 e 100 caracteres.");

            RuleFor(validar => validar.Telefone)
                .NotEmpty()
                .Matches(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$")
                .WithMessage("O telefone deve ter entre 8 a 9 dígitos, incluindo o DDD");

            RuleFor(validar => validar.Email)
                .NotEmpty()
                .WithMessage("O email é obrigatório.")
                .Must(EmailValido)
                .WithMessage("O email deve ser válido e pertencer a um dos seguintes domínios: outlook.com, gmail.com, hotmail.com, yahoo.com.");
        }


        private bool EmailValido(string? email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return false;
            }
            string valido = @"^[\w\.\-]+@(?:outlook\.com|gmail\.com|hotmail\.com|yahoo\.com)$";
            return Regex.IsMatch(email, valido, RegexOptions.IgnoreCase);
        }
    }
}
