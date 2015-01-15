using Europa.Web.Ui.Adm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace Europa.Web.Ui.Adm.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this System.Web.WebPages.Html.HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();
            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", paginaUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }

    }
}