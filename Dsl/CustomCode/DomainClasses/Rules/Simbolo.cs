using Microsoft.VisualStudio.Modeling;
using static Maxsys.VisualLAL.CustomCode.Utils.MessageBoxUtils;

namespace Maxsys.VisualLAL.CustomCode.Rules
{
    [RuleOn(typeof(Simbolo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SimboloAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var simbolo = e.ModelElement as Simbolo;
            var simboloName = simbolo.Nome;
            var mapaEntradas = LELMaps.Instance.Entries;

            while (mapaEntradas.Contains(simboloName))
                simboloName += "1";

            simbolo.Nome = simboloName;
            mapaEntradas.Add(simbolo);
        }
    }


    [RuleOn(typeof(Simbolo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SimboloChangeRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var simbolo = e.ModelElement as Simbolo;
            var mapaEntradas = LELMaps.Instance.Entries;
            var oldValue = e.OldValue as string;
            var newValue = e.NewValue as string;

            var contemNewValue = mapaEntradas.Contains(newValue);
            var contemElemento = mapaEntradas.Contains(e.ElementId);
            var newValueEhVazioOuNulo = string.IsNullOrWhiteSpace(newValue);

            if (!newValueEhVazioOuNulo)
            {
                if (!contemNewValue)
                {
                    if (!contemElemento)
                    {
                        mapaEntradas.Add(simbolo);
                    }
                    else
                    {
                        mapaEntradas.UpdateEntry(simbolo);
                    }
                }
                else//contemNewValue
                {
                    if (!mapaEntradas[newValue].EntradaId.Equals(simbolo.Id))
                    {
                        ShowError("Símbolo não pode ser vazio", "Símbolo Inválido");
                        simbolo.Nome = oldValue;
                    }
                }
            }
            else
            {
                ShowError("Símbolo não pode ser vazio", "Símbolo Inválido");
                simbolo.Nome = oldValue;
            }
        }
    }


    [RuleOn(typeof(Simbolo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SimboloDeleteRule : DeleteRule
    {
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var simbolo = e.ModelElement as Simbolo;
            LELMaps.Instance.Entries.Remove(simbolo);
        }
    }
}
