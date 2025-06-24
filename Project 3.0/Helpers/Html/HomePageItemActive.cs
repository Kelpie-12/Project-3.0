using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public static HtmlString HomePageApartment(this IHtmlHelper helper, Apartment apartment, bool active = false)
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

            d.InnerHtml.AppendHtml(p);
            d.InnerHtml.AppendHtml(h2);
            d.InnerHtml.AppendHtml(helper.RouteLink($"Цена | {apartment.Price}", new { action = "ObjectsSingle", controller = "Objects", id = apartment.Id }, new { @class = "btn-get-started" }));


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

        public static HtmlString HomePageAgets(this IHtmlHelper helper, Agent agent)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "col-lg-4 col-md-6");
            div.MergeAttribute("data-aos", "fade-up");
            div.MergeAttribute("data-aos-delay", "100");
            div.InnerHtml.AppendHtml(DivClassMember(helper, ref agent));
            using (var writter = new StringWriter())
            {
                div.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }
        private static TagBuilder DivClassMember(this IHtmlHelper helper, ref Agent agent)
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
            TagBuilder h4 = new TagBuilder("h4"); h4.InnerHtml.Append($"{agent.FirstName} {agent.LastName}");
            meb.InnerHtml.AppendHtml(h4);
            TagBuilder span = new TagBuilder("span"); span.InnerHtml.Append("должность агента");
            meb.InnerHtml.AppendHtml(span);

            TagBuilder social = new TagBuilder("div");
            social.Attributes.Add("class", "social");
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

        //<div class="swiper-slide">
        //	 <div class="testimonial-item">
        //	 	<div class="stars">
        //	 		<i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
        //	 	</div>
        //	 	<p>
        //	 		Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus.Accusantium quam, ultricies eget id, aliquam eget nibh et.Maecen aliquam, risus at semper.
        //   
        //                     </p>
        //	 	<div class="profile mt-auto">
        //	 		<img src = "assets/img/testimonials/testimonials-1.jpg" class="testimonial-img" alt="">
        //	 		<h3>Saul Goodman</h3>
        //	 		<h4>Ceo &amp; Founder</h4>
        //	 	</div>
        //	 </div>
        //</div>
        public static HtmlString HomePageReview(this IHtmlHelper helper,Review review)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "swiper-slide");
            div.InnerHtml.AppendHtml(ReviewItem(helper,review));
            using (var writter = new StringWriter())
            {
                div.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }
        private static TagBuilder ReviewItem(this IHtmlHelper helper, Review review)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "testimonial-item");

            TagBuilder stars = new TagBuilder("div");
            stars.MergeAttribute("class", "stars");
            for (int i = 0; i < review.Mark; i++)
            {
                TagBuilder s = new TagBuilder("i");
                s.MergeAttribute("class", "bi bi-star-fill");
                stars.InnerHtml.AppendHtml(s);
            }

            TagBuilder p = new TagBuilder("p");
            p.InnerHtml.Append($"{review.Text}");
            TagBuilder data = new TagBuilder("p");
            data.InnerHtml.Append($"{review.Date.ToShortDateString()}");

            TagBuilder profil = new TagBuilder("div");
            profil.MergeAttribute("class", "profile mt-auto");

            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("class", "testimonial-img");
            img.MergeAttribute("src", "Ссылка на фото");
            img.MergeAttribute("alt", "");

            TagBuilder h3 = new TagBuilder("h3");
            h3.InnerHtml.Append($"{review.FirstName} {review.LastName}");
            TagBuilder h4 = new TagBuilder("h4");
            h4.InnerHtml.Append(review.JobTitle);

            profil.InnerHtml.AppendHtml(img);
            profil.InnerHtml.AppendHtml(h3);
            profil.InnerHtml.AppendHtml(h4);


            div.InnerHtml.AppendHtml(stars);
            div.InnerHtml.AppendHtml(p);
            div.InnerHtml.AppendHtml(data);
            div.InnerHtml.AppendHtml(profil);

            return div;
        }

    }
}
