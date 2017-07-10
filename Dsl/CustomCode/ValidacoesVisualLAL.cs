using Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.ImpactoValidation;
using Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.NocaoValidation;
using Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.SimboloValidation;
using Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.SinonimoValidation;
using Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Validation;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Maxsys.VisualLAL
{
    /*
        To make this work, Validation is globally enabled under Editor in DSL Explorer, in DSL Definition.
        ValidationState attribute is also required to enable validation in specific classes.

        Each validation method is called on every instance of the type to which it applies.
        Validation methods are flagged by the ValidationMethod attribute.
        
        https://docs.microsoft.com/en-us/visualstudio/modeling/validation-in-a-domain-specific-language
    */

    [ValidationState(ValidationState.Enabled)]
    partial class Simbolo
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save | ValidationCategories.Open)]
        private void Validation(ValidationContext context)
        {
            var resultadoValidacao = new SimboloValidator().Validate(this);
            foreach (var erro in resultadoValidacao.Errors)
            {
                context.LogError(erro.Message, "ErroConsistencia", this);
            }
        }

        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save)]
        private void PrincipioDaCircularidadeValidation(ValidationContext context)
        {
            var resultadoValidacao = new PrincipioDaCircularidadeErrorLevelValidator().Validate(this);
            foreach (var erro in resultadoValidacao.Errors)
            {
                context.LogError(erro.Message, "ErroPrincipioDaCircularidade", this);
            }
        }
    }

    [ValidationState(ValidationState.Enabled)]
    partial class Nocao
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save | ValidationCategories.Open)]
        private void Validation(ValidationContext context)
        {
            var resultadoValidacao = new NocaoValidator().Validate(this);
            foreach (var erro in resultadoValidacao.Errors)
            {
                context.LogError(erro.Message, "ErroConsistencia", this);
            }
        }
    }

    [ValidationState(ValidationState.Enabled)]
    partial class Impacto
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save | ValidationCategories.Open)]
        private void ConsistencyValidation(ValidationContext context)
        {
            var resultadoValidacao = new ImpactoValidator().Validate(this);
            foreach (var erro in resultadoValidacao.Errors)
            {
                context.LogError(erro.Message, "ErroConsistencia", this);
            }
        }
    }

    [ValidationState(ValidationState.Enabled)]
    partial class Sinonimo
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save | ValidationCategories.Open)]
        private void Validation(ValidationContext context)
        {
            var resultadoValidacao = new SinonimoValidator().Validate(this);
            foreach (var erro in resultadoValidacao.Errors)
            {
                context.LogError(erro.Message, "ErroConsistencia", this);
            }
        }
    }
    
}
