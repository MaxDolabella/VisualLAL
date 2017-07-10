using Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.NocaoSpecification;
using Maxsys.VisualLAL.CustomCode.Validation;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.NocaoValidation
{
    public class NocaoValidator : Validator<Nocao>
    {
        public NocaoValidator()
        {
            var textoNaoPodeSerVazio = new TextoNaoPodeSerVazioSpecification();
            var textoDeveSerUnicoEmSeuSimbolo = new TextoDeveSerUnicoEmSeuSimboloSpecification();

            base.AddRule(nameof(textoNaoPodeSerVazio),
                new Rule<Nocao>(textoNaoPodeSerVazio, "Texto da Noção não pode ser vazio."));

            base.AddRule(nameof(textoDeveSerUnicoEmSeuSimbolo),
                new Rule<Nocao>(textoDeveSerUnicoEmSeuSimbolo, "Texto da Noção deve ser único em seu símbolo."));
        }
    }
}
