using Microsoft.VisualStudio.Modeling;

namespace Maxsys.VisualLAL.CustomCode.Rules
{
    [RuleOn(typeof(Nocao), FireTime = TimeToFire.TopLevelCommit)]
    internal class NocaoAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var nocao = e.ModelElement as Nocao;
            VisualLALMapeamento.Instance.Referencias.AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(nocao);
        }
    }


    [RuleOn(typeof(Nocao), FireTime = TimeToFire.TopLevelCommit)]
    internal class NocaoChangeRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var nocao = e.ModelElement as Nocao;

            VisualLALMapeamento.Instance.Referencias.AtualizaMapaDeReferenciaAposAlteracaoDeSubEntrada(nocao);
        }
    }


    [RuleOn(typeof(Nocao), FireTime = TimeToFire.TopLevelCommit)]
    internal class NocaoDeleteRule : DeleteRule
    {
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var nocao = e.ModelElement as Nocao;

            VisualLALMapeamento.Instance.Referencias.RemoverReferenciasDeSubEntrada(nocao);
        }
    }
}
