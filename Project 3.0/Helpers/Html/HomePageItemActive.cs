using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Xml.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Project_3._0.Model.Domain;

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
        public static HtmlString CarouselItem(this IHtmlHelper helper, Apartment apartment, bool active = false)
        {
            TagBuilder div = new TagBuilder("div");
            if (active)
                div.Attributes.Add("class", "carousel-item active");
            else
                div.Attributes.Add("class", "carousel-item ");

            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", "");
            div.InnerHtml.AppendHtml(img);
            div.InnerHtml.AppendHtml(CarouselContainer(helper, apartment));
            using (var writter = new StringWriter())
            {
                div.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
            //return new HtmlString("");
        }
        private static TagBuilder CarouselContainer(this IHtmlHelper helper, Apartment apartment)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "carousel-container");
            TagBuilder d = new TagBuilder("div");
            TagBuilder p = new TagBuilder("p");
            p.InnerHtml.Append(apartment.Citi);

            TagBuilder h2 = new TagBuilder("h2");
            h2.InnerHtml.Append(apartment.House.ToString());
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml.Append(apartment.Street);
            h2.InnerHtml.AppendHtml(span);


            TagBuilder a = new TagBuilder("a");
            //string _a = $"/Properties/PropertiesSingle?id={apartment.ObjectId}";
            //a.Attributes.Add("href", _a /*new UriBuilder("https", "localhost", 7503, "Properties/PropertiesSingle").ToString()*/);
            //a.Attributes.Add("class", "btn-get-started");
            //a.InnerHtml.Append($"Цена | {apartment.Price}");
            a.InnerHtml.AppendHtml(helper.RouteLink($"Цена | {apartment.Price}", new { action = "PropertiesSingle", controller = "Properties", id = apartment.ObjectId }, new { @class = "btn-get-started" }));

            d.InnerHtml.AppendHtml(p);
            d.InnerHtml.AppendHtml(h2);
            d.InnerHtml.AppendHtml(a);


            div.InnerHtml.AppendHtml(d);

            return div;
        }


        //<div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
        //	<div class="member">
        //		<div class="pic"><img src = "assets/img/team/team-1.jpg" class="img-fluid" alt=""></div>
        //		<div class="member-info">
        //			<h4>Walter White</h4>
        //			<span>Chief Executive Officer</span>
        //			<div class="social">
        //				<a href = "" >< i class="bi bi-twitter-x"></i></a>
        //				<a href = "" >< i class="bi bi-facebook"></i></a>
        //				<a href = "" >< i class="bi bi-instagram"></i></a>
        //				<a href = "" >< i class="bi bi-linkedin"></i></a>
        //			</div>
        //		</div>
        //	</div>
        //</div>

        public static HtmlString HomePageAgets(this IHtmlHelper helper)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "col-lg-4 col-md-6");
            div.MergeAttribute("data-aos", "fade-up");
            div.MergeAttribute("data-aos-delay", "100");
            div.InnerHtml.AppendHtml(DivClassMember(helper));
            using (var writter = new StringWriter())
            {
                div.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }
        private static TagBuilder DivClassMember(this IHtmlHelper helper)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "member");

            TagBuilder pic = new TagBuilder("div");
            pic.Attributes.Add("class", "pic");
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("class", "img-fluid");
            img.Attributes.Add("src", "");
            pic.InnerHtml.AppendHtml(img);

            TagBuilder meb = new TagBuilder("div");
            meb.Attributes.Add("class", "member-info");
            TagBuilder h4 = new TagBuilder("h4"); h4.InnerHtml.Append("Имя агента");
            meb.InnerHtml.AppendHtml(h4);
            TagBuilder span = new TagBuilder("span"); span.InnerHtml.Append("должность агента");
            meb.InnerHtml.AppendHtml(span);

            TagBuilder social = new TagBuilder("div");
            social.Attributes.Add("class","social");
            TagBuilder a = new TagBuilder("a"); a.Attributes.Add("href", "ссылка на агента");
            TagBuilder i = new TagBuilder("i"); i.Attributes.Add("class", "bi bi-instagram");
            a.InnerHtml.AppendHtml(i);
            social.InnerHtml.AppendHtml(a);
            i = new TagBuilder("i"); i.Attributes.Add("class", "bi bi-telegram");
            a = new TagBuilder("a"); a.Attributes.Add("href", "ссылка на агента");
            a.InnerHtml.AppendHtml(i);
            social.InnerHtml.AppendHtml(a);

            meb.InnerHtml.AppendHtml(social);

            div.InnerHtml.AppendHtml(pic);
            div.InnerHtml.AppendHtml(meb);

            return div;
        }

    }
}
