﻿using Microsoft.VisualStudio.Modeling;
using static Maxsys.VisualLAL.CustomCode.Utils.MessageBoxUtils;

namespace Maxsys.VisualLAL.CustomCode.Rules
{
    [RuleOn(typeof(Sinonimo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SinonimoAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var sinonimo = e.ModelElement as Sinonimo;

            var simboloName = sinonimo.Simbolo.Nome;
            var simboloSinonimosCont = (sinonimo.Simbolo.Sinonimos.Count).ToString();
            var sinonimoNome = $"{simboloName}Sinônimo{simboloSinonimosCont}";
            var mapaEntradas = VisualLALMapeamento.Instance.MapaEntradas;

            while (mapaEntradas.Contem(sinonimoNome))
                sinonimoNome += "1";
            sinonimo.Nome = sinonimoNome;

            mapaEntradas.Adicionar(sinonimo);
        }
    }


    [RuleOn(typeof(Sinonimo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SinonimoChangeRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var sinonimo = e.ModelElement as Sinonimo;

            var mapaEntradas = VisualLALMapeamento.Instance.MapaEntradas;
            var oldValue = e.OldValue as string;
            var newValue = e.NewValue as string;

            var contemNewValue = mapaEntradas.Contem(newValue);
            var contemElement = mapaEntradas.Contem(e.ElementId);
            var newValueEhVazioOuNulo = string.IsNullOrWhiteSpace(newValue);
            
            if (!newValueEhVazioOuNulo)
            {
                if (!contemNewValue)
                {
                    if (!contemElement)
                    {
                        mapaEntradas.Adicionar(sinonimo);
                    }
                    else
                    {
                        mapaEntradas.AtualizarEntrada(sinonimo);
                    }
                }
                else//contemNewValue
                {
                    if (!mapaEntradas[newValue].EntradaId.Equals(sinonimo.Id))
                    {
                        ShowError("Este nome já existe", "Sinônimo Inválido");
                        sinonimo.Nome = oldValue;
                    }
                }
            }
            else
            {
                ShowError("Sinônimo não pode ser vazio", "Sinônimo Inválido");
                sinonimo.Nome = oldValue;
            }
        }
    }


    [RuleOn(typeof(Sinonimo), FireTime = TimeToFire.TopLevelCommit)]
    internal class SinonimoDeleteRule : DeleteRule
    {
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);
            if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                return;
            var sinonimo = e.ModelElement as Sinonimo;
            var mapaEntradas = VisualLALMapeamento.Instance.MapaEntradas;
            mapaEntradas.Remover(sinonimo);
        }
    }
}
