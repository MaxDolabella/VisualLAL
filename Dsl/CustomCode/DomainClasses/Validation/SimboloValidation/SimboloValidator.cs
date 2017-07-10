using Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SimboloSpecification;
using Maxsys.VisualLAL.CustomCode.Validation;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Validation.SimboloValidation
{
    public class SimboloValidator : Validator<Simbolo>
    {
        public SimboloValidator()
        {
            var nomeNaoPodeSerVazio = new NomeNaoPodeSerVazioSpecification();
            var nomeDeveSerUnico = new NomeDeveSerUnicoEntreTodosOsNomesDeSimbolosESinonimosSpecification();
            var deveTerPeloMenosUmaNocao = new DeveTerPeloMenosUmaNocaoSpecification();
            var deveTerPeloMenosUmImpacto = new DeveTerPeloMenosUmImpactoSpecification();
            

            base.AddRule(nameof(nomeNaoPodeSerVazio),
                new Rule<Simbolo>(nomeNaoPodeSerVazio, "Nome do Símbolo não pode ser vazio."));

            base.AddRule(nameof(nomeDeveSerUnico),
                new Rule<Simbolo>(nomeDeveSerUnico, "Nome do Símbolo deve ser diferente de todos os outros nomes de símbolo e sinônimos."));

            base.AddRule(nameof(deveTerPeloMenosUmaNocao),
                new Rule<Simbolo>(deveTerPeloMenosUmaNocao, "Símbolo deve ter pelo menos 1 noção."));

            base.AddRule(nameof(deveTerPeloMenosUmImpacto),
                new Rule<Simbolo>(deveTerPeloMenosUmImpacto, "Símbolo deve ter pelo menos 1 impacto."));
        }
    }
}
