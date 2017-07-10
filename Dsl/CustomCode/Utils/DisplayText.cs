using Microsoft.VisualStudio.Modeling.Diagrams;
using System;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode
{
    public class DisplayText : TextField
    {
        private static DisplayText instance = new DisplayText();
        private DisplayText() : base("") { }

        public static SizeD Measure(TextField textField, ShapeElement shapeElement, string text)
        {
            var size = instance.MeasureDisplayText(text,
              textField.GetFont(shapeElement),
              textField.GetStringFormat(shapeElement),
              new SizeD(Double.MaxValue, Double.MaxValue));

            return new SizeD((size.Width) + 0.1, (size.Height));// Add a little padding
        }

        public static SizeD ObterTamanho(SimboloCompartment compartimento, SubEntrada subEntrada)
        {
            if (compartimento == null)
                return new SizeD(0,0);


            //nomeSubEntradaCompartimento
            string nomeSubEntradaCompartimento;
            if (subEntrada is Nocao)
                nomeSubEntradaCompartimento = "NocaoCompartment";
            else
                nomeSubEntradaCompartimento = "ImpactoCompartment";


            //subCompartimento
            var subCompartimento = compartimento.NestedChildShapes
                .Where(s => s is ElementListCompartment)
                .Where(s => (s as ElementListCompartment).Name.Equals(nomeSubEntradaCompartimento))
                .FirstOrDefault() as ElementListCompartment;

            if (subCompartimento == null)
                return new SizeD(0, 0);


            //textField
            var textField = subCompartimento.ShapeFields
                .Where(s => s.Name == "HdrText")
                .FirstOrDefault() as TextField;

            if (textField == null)
                return new SizeD(0, 0);


            //novoSize
            var novoSize = Measure(textField, compartimento, subEntrada.Texto);
            return novoSize;
        }
    }
}
