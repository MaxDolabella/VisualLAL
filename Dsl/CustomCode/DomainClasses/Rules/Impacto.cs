using Microsoft.VisualStudio.Modeling;

namespace Maxsys.VisualLAL.CustomCode.Rules
{
    [RuleOn(typeof(Impacto), FireTime = TimeToFire.TopLevelCommit)]
    internal class ImpactoAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var impacto = e.ModelElement as Impacto;

            LELMaps.Instance.LinkMaps.AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(impacto);
        }
    }


    [RuleOn(typeof(Impacto), FireTime = TimeToFire.TopLevelCommit)]
    internal class ImpactoChangeRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var impacto = e.ModelElement as Impacto;

            LELMaps.Instance.LinkMaps.AtualizaMapaDeReferenciaAposAlteracaoDeSubEntrada(impacto);
        }
    }


    [RuleOn(typeof(Impacto), FireTime = TimeToFire.TopLevelCommit)]
    internal class ImpactoDeleteRule : DeleteRule
    {
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var impacto = e.ModelElement as Impacto;

            LELMaps.Instance.LinkMaps.RemoverReferenciasDeSubEntrada(impacto);
        }
    }
}
