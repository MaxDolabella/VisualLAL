using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Linq;

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
            LELMaps.Instance.LinkMaps.AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(nocao);


            
            //var txt = nocaoComp.ShapeFields
            //    .Where(s => s.Nome == "HdrText")
            //    .FirstOrDefault() as TextField;

            //if (txt == null)
            //{
            //    System.Diagnostics.Debug.WriteLine($"txt null");
            //    return;
            //}



            //foreach (var item in nocaoComp.ShapeFields)
            //{
            //    System.Diagnostics.Debug.WriteLine($"ShapeFields.Nome={item.Nome}");
            //    if (item is TextField)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"item is TextField");
            //        var txt = item as TextField;
            //        System.Diagnostics.Debug.WriteLine($"txt.GetDisplayText(nocaoComp) = {txt.GetDisplayText(nocaoComp).ToString()}");
            //    }

            //    TextField textField = shapeElement.FindShapeField(textDecoratorName) as TextField;
            //}



            return;
            //foreach (var oChildShape in compartment.NestedChildShapes)
            //{
            //    if (oChildShape is ElementListCompartment)
            //    {
            //        var oCompartment = oChildShape as ElementListCompartment;
            //        System.Diagnostics.Debug.WriteLine($"oCompartment.Nome={oCompartment.Nome}");
            //    }
            //}
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

            LELMaps.Instance.LinkMaps.AtualizaMapaDeReferenciaAposAlteracaoDeSubEntrada(nocao);

            return;

            var compartment = PresentationViewsSubject.GetPresentation(nocao.Simbolo)
                .FirstOrDefault() as SimboloCompartment;

            if (compartment == null)
            {
                System.Diagnostics.Debug.WriteLine($"compartment null");
                return;
            }


            var nocaoComp = compartment.NestedChildShapes
                .Where(s => s is ElementListCompartment)
                .Where(s => (s as ElementListCompartment).Name == "NocaoCompartment")
                .FirstOrDefault() as ElementListCompartment;

            var txt = nocaoComp.ShapeFields
                .Where(s => s.Name == "HdrText")
                .FirstOrDefault() as TextField;

            if (txt == null)
            {
                System.Diagnostics.Debug.WriteLine($"txt null");
                return;
            }

            var size = DisplayText.Measure(txt, nocaoComp, nocao.Texto);

            if (compartment.Size.Width < size.Width)
            {
                compartment.Size = size;
            }

            
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

            LELMaps.Instance.LinkMaps.RemoverReferenciasDeSubEntrada(nocao);
        }
    }
}
