using Microsoft.VisualStudio.Modeling.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return new SizeD((size.Width) + 0.1, (size.Height) + 0.1);// Add a little padding
        }
    }
}
