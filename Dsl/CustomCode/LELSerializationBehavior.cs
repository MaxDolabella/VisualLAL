using Maxsys.VisualLAL.CustomCode;
using Microsoft.VisualStudio.Modeling;
using System.Diagnostics;
using System.Linq;

namespace Maxsys.VisualLAL
{
    partial class VisualLALSerializationHelperBase
    {
        /// <summary>
        /// Customize Model Loading.
        /// </summary>
        /// <param name="serializationResult">Stores serialization result from the load operation.</param>
        /// <param name="partition">Partition in which the new LELDomain instance will be created.</param>
        /// <param name="fileName">Name of the file from which the LELDomain instance will be deserialized.</param>
        /// <param name="modelRoot">The root of the file that was loaded.</param>
        private void OnPostLoadModel(SerializationResult serializationResult, Partition partition, string fileName, LALDominio modelRoot)
        {
            //Debug.WriteLine("OnPostLoad");
        }

        // Fire PostLoad customization code whether Load succeeded or not
        // Provide a method in a partial class with the following signature:

        /// <summary>
        /// Customize Model and Diagram Loading.
        /// </summary>
        /// <param name="serializationResult">Stores serialization result from the load operation.</param>
        /// <param name="modelPartition">Partition in which the new DslLibrary instance will be created.</param>
        /// <param name="modelFileName">Name of the file from which the DslLibrary instance will be deserialized.</param>
        /// <param name="diagramPartition">Partition in which the new DslDesignerDiagram instance will be created.</param>
        /// <param name="diagramFileName">Name of the file from which the DslDesignerDiagram instance will be deserialized.</param>
        /// <param name="modelRoot">The root of the file that was loaded.</param>
        /// <param name="diagram">The diagram matching the modelRoot.</param>
        private void OnPostLoadModelAndDiagram(SerializationResult serializationResult, Partition modelPartition, string modelFileName, Partition diagramPartition, string diagramFileName, LALDominio modelRoot, VisualLALDiagram diagram)
        {
            //Debug.WriteLine("OnPostLoadModelAndDiagram");
            if (!serializationResult.Failed)
            {
                VisualLALMapeamento.Instance.SetStore(modelRoot.Store);
                var entries = VisualLALMapeamento.Instance.MapaEntradas;
                var links = VisualLALMapeamento.Instance.MapaReferencias;
                var simbolos = modelRoot.Simbolos;
                var sinonimos = modelRoot.Simbolos.SelectMany(s => s.Sinonimos);
                var nocoes = modelRoot.Simbolos.SelectMany(s => s.Nocoes);
                var impactos = modelRoot.Simbolos.SelectMany(s => s.Impactos);

                links.ApagarTudo();
                entries.ApagarTudo();

                

                foreach (var s in simbolos)
                {
                    //Debug.WriteLine(s.Nome);
                    entries.Adicionar(s);
                }

                foreach (var s in sinonimos)
                {
                    //Debug.WriteLine(s.Nome);
                    entries.Adicionar(s);
                }
                
                foreach (var n in nocoes)
                {
                    //Debug.WriteLine(n.Texto);
                    links.AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(n);
                }

                foreach (var b in impactos)
                {
                    //Debug.WriteLine(b.Texto);
                    links.AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(b);
                }

                return;
            }
            Debug.WriteLine("OnPostLoadModelAndDiagram Failed");
        }
    }
}
