using Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Specification.ErrorLevelSpecification;
using Maxsys.VisualLAL.CustomCode.Validation;

namespace Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Validation
{
    public class PrincipioDaCircularidadeErrorLevelValidator : Validator<Simbolo>
    {
        public PrincipioDaCircularidadeErrorLevelValidator()
        {
            var cadaSimboloDeveReferenciarOuSerReferenciado = new CadaSimboloDeveReferenciarOuSerReferenciadoPorOutroSimboloSpecification();

            base.AddRule(nameof(cadaSimboloDeveReferenciarOuSerReferenciado),
                new Rule<Simbolo>(cadaSimboloDeveReferenciarOuSerReferenciado, 
                "Princípio da Circularidade quebrado: Símbolo deve referenciar ou ser referenciado por outro Símbolo."));
        }
    }
}
