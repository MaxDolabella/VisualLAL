using Maxsys.VisualLAL.CustomCode.Validation;
using Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.ImpactoSpecification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.ImpactoValidation
{
    public class ImpactoValidator : Validator<Impacto>
    {
        public ImpactoValidator()
        {
            var textoNaoPodeSerVazio = new TextoNaoPodeSerVazioSpecification();
            var textoDeveSerUnicoEmSeuSimbolo = new TextoDeveSerUnicoEmSeuSimboloSpecification();

            base.AddRule(nameof(textoNaoPodeSerVazio), 
                new Rule<Impacto>(textoNaoPodeSerVazio, "Texto do Impacto não pode ser vazio."));

            base.AddRule(nameof(textoDeveSerUnicoEmSeuSimbolo),
                new Rule<Impacto>(textoDeveSerUnicoEmSeuSimbolo, "Texto do Impacto deve ser único em seu símbolo."));
        }
    }
}
