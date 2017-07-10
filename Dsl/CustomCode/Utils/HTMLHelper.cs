using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Maxsys.VisualLAL.CustomCode.Utils
{
    public static class HTMLHelper
    {
        public static void ExportarHTMLVisualLAL(LALDominio dominio)
        {
            var documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var raizLAL = $@"{documentos}\VisualLAL\{dominio.Nome}";
            var raizLALEntradas = $@"{raizLAL}\Entradas";

            #region Diretórios
            if (Directory.Exists(raizLALEntradas))
            {
                var dirInfo = new DirectoryInfo(raizLALEntradas);
                foreach (var fileInfo in dirInfo.GetFiles())
                    fileInfo.Delete();
            }

            if (Directory.Exists(raizLAL))
            {
                var dirInfo = new DirectoryInfo(raizLAL);
                foreach (var fileInfo in dirInfo.GetFiles())
                    fileInfo.Delete();
            }

            Directory.CreateDirectory(raizLALEntradas);
            #endregion

            var simbolos = dominio.Simbolos;

            CriarHTMLPaginaIndex(raizLAL, dominio);

            foreach (var simbolo in simbolos)
                CriarHTMLPaginaSimbolo(raizLAL, simbolo);

        }
        static void CriarHTMLPaginaIndex(string raiz, LALDominio dominio)
        {
            var indexFilePath = $@"{raiz}\Index.html";
            var pageTitle = $"Index: {dominio.Nome}";
            var inPageTitle = $"Léxico Ampliado da Linguagem para {dominio.Nome}";
            var inPageDesc = $"{dominio.Descricao}";

            var contents = new List<string>();
            contents.Add($"<!DOCTYPE html>");
            contents.Add($"<html>");

            contents.Add($"<head>");
            contents.Add($"<title>{pageTitle}</title>");
            contents.Add($"</head>");

            contents.Add($"<body>");
            contents.Add($"<h2>{inPageTitle}</h2>");
            contents.Add($"<p>{inPageDesc}</p>");
            contents.Add($"<br>");
            contents.Add($"<hr>");
            contents.Add($"<br>");

            contents.Add($"<table>");
            foreach (var simbolo in dominio.Simbolos)
            {
                contents.Add($"<tr>");
                contents.Add($"<td><a href=\"Entradas\\{simbolo.Nome}.html\">{simbolo}</a></td>");
                contents.Add($"</tr>");
            }
            contents.Add($"</table>");

            contents.Add($"</body>");
            contents.Add($"</html>");

            File.WriteAllLines(indexFilePath, contents, Encoding.Default);
        }

        static void CriarHTMLPaginaSimbolo(string raiz, Simbolo simbolo)
        {
            var simboloFilePath = $@"{raiz}\Entradas\{simbolo.Nome}.html";
            var pageTitle = simbolo.Nome;

            var contents = new List<string>();
            contents.Add($"<!DOCTYPE html>");
            contents.Add($"<html>");

            contents.Add($"<head>");
            contents.Add($"<title>{simbolo.Nome}</title>");
            contents.Add($"</head>");

            contents.Add($"<body>");
            contents.Add($"<h2>{simbolo.ToString()}</h2>");
            contents.Add($"<hr>");
            contents.Add($"<br>");
            contents.Add($"<br>");

            contents.Add($"<h3>Noção:</h3>");
            contents.Add($"<p>");
            foreach (var nocao in simbolo.Nocoes)
            {
                var text = nocao.Texto;
                var references = VisualLALMapeamento.Instance.MapaReferencias
                    .Where(m => m.SubEntradaOrigemId.Equals(nocao.Id))
                    .Select(x => new { Entry = x.EntradaReferenciada, TargetSimboloId = x.SimboloDestinoId });

                foreach (var reference in references)
                {
                    var targetSimbolo = nocao.Store.ElementDirectory.FindElement(reference.TargetSimboloId) as Simbolo;
                    text = text.Replace(reference.Entry, $"<a href=\"{targetSimbolo.Nome}.html\">{reference.Entry}</a>");
                }
                contents.Add($"{text}<br>");
            }
            contents.Add($"</p>");
            contents.Add($"<br>");
            contents.Add($"<br>");

            contents.Add($"<h3>Impacto:</h3>");
            contents.Add($"<p>");
            foreach (var impacto in simbolo.Impactos)
            {
                var text = impacto.Texto;
                var references = VisualLALMapeamento.Instance.MapaReferencias
                    .Where(m => m.SubEntradaOrigemId.Equals(impacto.Id))
                    .Select(x => new { Entry = x.EntradaReferenciada, TargetSimboloId = x.SimboloDestinoId });

                foreach (var reference in references)
                {
                    var targetSimbolo = impacto.Store.ElementDirectory.FindElement(reference.TargetSimboloId) as Simbolo;
                    text = text.Replace(reference.Entry, $"<a href=\"{targetSimbolo.Nome}.html\">{reference.Entry}</a>");
                }
                contents.Add($"{text}<br>");
            }
            contents.Add($"</p>");

            contents.Add($"</body>");
            contents.Add($"</html>");

            File.WriteAllLines(simboloFilePath, contents, Encoding.Default);
        }
    }
}
