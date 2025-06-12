using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace Project_3._0.Helpers.Html
{   
    public static class HomePageItemActive
    {
        //<div class="carousel-item active">
        //  <img src = "assets/img/hero-carousel/hero-carousel-1.jpg" alt="">
        //  <div class="carousel-container">
        //      <div>
        //          <p>Саратов</p>
        //          <h2><span>Ленина</span> 12 </h2>
        //          <a asp-controller="Properties" asp-action="PropertiesSingle" class="btn-get-started">Цена | $ 12.000</a>
        //      </div>
        //  </div>
        //</div>
        public static HtmlString CarouselItem(this IHtmlHelper helper)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "carousel-item active");
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", "");
            div.InnerHtml.AppendHtml(img);
            div.InnerHtml.AppendHtml(CarouselContainer(helper));
            using (var writter = new StringWriter())
            {
                div.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
            //return new HtmlString("");
        }
        private static TagBuilder CarouselContainer(this IHtmlHelper helper)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "carousel-container");
            TagBuilder d = new TagBuilder("div");
            TagBuilder p = new TagBuilder("p");
            p.InnerHtml.Append("Город");

            TagBuilder h2 = new TagBuilder("h2");
            h2.InnerHtml.Append("Дом");
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml.Append("Улица");
            h2.InnerHtml.AppendHtml(span);


            TagBuilder a = new TagBuilder("a");
            // string _a = $"<a asp-controller=\"Properties\" asp-action=\"PropertiesSingle\" asp-route-id=\"{1}\" class=\"btn-get-started > Цена | $12000 </a>";
            //RouteValueDictionary r = new RouteValueDictionary();
            //r.Add("asp-controller", "Properties");
            //r.Add("asp-action", "PropertiesSingle");
            //r.Add("asp-route-id", "1");           
            //a.Attributes.Add(new KeyValuePair<string, string?>("asp-controller", "Properties"));
            //a.Attributes.Add(new KeyValuePair<string, string?>("asp-action", "PropertiesSingle"));
            //a.Attributes.Add(new KeyValuePair<string, string?>("asp-route-id", "1"));
            // a.InnerHtml.AppendHtml(helper.RouteLink("Цена | $12000", new { action = "PropertiesSingle", controller = "Properties", id = 1 }));
            // a.MergeAttribute("asp-controller", "Properties");
            // a.MergeAttribute("asp-action", "PropertiesSingle");
            // a.MergeAttribute("asp-route-id", "1");

            // a.Attributes.Add("asp-controller", "Properties");
            // a.Attributes.Add("asp-action", "PropertiesSingle");
            // a.Attributes.Add("asp-route-id", "1");
            //string z =helper2.Html.RouteLink("Цена | $12000", new { action = "PropertiesSingle", controller = "Properties", id = 1 }).ToString();
            //helper.ActionLink("Цена | $12000", new { action = "PropertiesSingle", controller = "Properties", id = 1 }).ToString();
            a.Attributes.Add("href", new UriBuilder("https", "localhost", 7503, "Properties/PropertiesSingle").ToString());
      
            
            a.Attributes.Add("class", "btn-get-started");
            a.InnerHtml.Append("Цена | $12000");

            d.InnerHtml.AppendHtml(p);
            d.InnerHtml.AppendHtml(h2);
            d.InnerHtml.AppendHtml(a);


            div.InnerHtml.AppendHtml(d);

            return div;
        }
    }
}
