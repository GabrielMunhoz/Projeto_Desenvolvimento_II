
using FluentValidation.Results;
using PlayersBook.Domain.DTOs;

namespace PlayersBook.Application.Validation.Validator
{
    public static class FluentResultAdapter
    {
        public static ErrorFieldDto VerificaErros(ValidationResult result)
        {
            if (!(result?.IsValid ?? true))
            {                
                if (result.Errors != null)
                {
                    var erro = new ErrorFieldDto();
                    foreach (var resultErro in result.Errors)
                    {
                        erro.Erros.Add(resultErro.ErrorMessage);
                    }
                    return erro;
                }
                return null;
            }
            return null;
        }
    }
}
