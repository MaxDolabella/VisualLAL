using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Collections.Generic;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.Utils
{
    public static class CompartmentHelper
    {
        public static void AjustarAoConteudo(Simbolo simbolo)
        {
            var compartimento = PresentationViewsSubject.GetPresentation(simbolo)
                    .FirstOrDefault() as SimboloCompartment;

            if (compartimento == null)
                return;

            var tamanhos = new List<SizeD>();

            foreach (var nocao in simbolo.Nocoes)
            {
                tamanhos.Add(DisplayText.ObterTamanho(compartimento, nocao));
            }

            foreach (var impacto in simbolo.Impactos)
            {
                tamanhos.Add(DisplayText.ObterTamanho(compartimento, impacto));
            }

            var maiorLargura = tamanhos.Max(s => s.Width);
            var novoSize = new SizeD(maiorLargura, compartimento.Size.Height);
            compartimento.Size = novoSize;
        }

        public static void AjustarAoPadrao(Simbolo simbolo)
        {
            var compartimento = PresentationViewsSubject.GetPresentation(simbolo)
                    .FirstOrDefault() as SimboloCompartment;

            if (compartimento == null)
                return;

            var novoSize = new SizeD(2, compartimento.Size.Height);
            compartimento.Size = novoSize;
        }
    }
}
