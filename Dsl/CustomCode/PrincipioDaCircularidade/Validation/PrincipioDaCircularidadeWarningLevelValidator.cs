using Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Specification.WarningLevelSpecification;
using Maxsys.VisualLAL.CustomCode.Validation;

namespace Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Validation
{
    public class PrincipioDaCircularidadeWarningLevelValidator : Validator<Simbolo>
    {
        public PrincipioDaCircularidadeWarningLevelValidator()
        {
            var cadaSimboloDeveReferenciar = new CadaSimboloDeveReferenciarOutroSimboloSpecification();
            var cadaSimboloDeveSerReferenciado = new CadaSimboloDeveSerReferenciadoPorOutroSimboloSpecification();

            base.AddRule(nameof(cadaSimboloDeveReferenciar),
                new Rule<Simbolo>(cadaSimboloDeveSerReferenciado,
                "Princípio da Circularidade: Este símbolo não referencia nenhum outro símbolo."));

            base.AddRule(nameof(cadaSimboloDeveReferenciar),
                new Rule<Simbolo>(cadaSimboloDeveSerReferenciado,
                "Princípio da Circularidade: Este símbolo não é referenciado por nenhum outro símbolo."));
        }
    }
}
