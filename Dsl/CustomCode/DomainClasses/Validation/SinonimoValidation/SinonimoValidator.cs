using Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SinonimoSpecification;
using Maxsys.VisualLAL.CustomCode.Validation;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.SinonimoValidation
{
    public class SinonimoValidator : Validator<Sinonimo>
    {
        public SinonimoValidator()
        {
            var nomeNaoPodeSerVazio = new NomeNaoPodeSerVazioSpecification();
            var nomeDeveSerUnico = new NomeDeveSerUnicoEntreTodosOsNomesDeSimbolosESinonimosSpecification();

            base.AddRule(nameof(nomeNaoPodeSerVazio),
                new Rule<Sinonimo>(nomeNaoPodeSerVazio, "Nome do Sinônimo não pode ser vazio."));

            base.AddRule(nameof(nomeDeveSerUnico),
                new Rule<Sinonimo>(nomeDeveSerUnico, "Nome do Sinônimo deve ser diferente de todos os outros nomes de símbolo e sinônimos."));
        }
    }
}
