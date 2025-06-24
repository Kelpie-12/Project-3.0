using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_3._0.Model.Domain;

namespace Project_3._0.Helpers.Html
{
    public static class ObjectPageItem
    {
        //<div class="col-xl-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
        //			<div class="card">
        //				<img src = "assets/img/properties/property-1.jpg" alt="" class="img-fluid">
        //				<div class="card-body">
        //					<span class="sale-rent">Rent | $1200</span>
        //					<h3><a href = "property-single.html" class="stretched-link">204 Mount Olive Road Two</a></h3>
        //					<div class="card-content d-flex flex-column justify-content-center text-center">
        //						<div class="row propery-info">
        //							<div class="col">Area</div>
        //							<div class="col">Beds</div>
        //							<div class="col">Baths</div>
        //							<div class="col">Garages</div>
        //						</div>
        //						<div class="row">
        //							<div class="col">340m2</div>
        //							<div class="col">5</div>
        //							<div class="col">2</div>
        //							<div class="col">1</div>
        //						</div>
        //					</div>
        //				</div>
        //			</div>
        //		</div>


        public static HtmlString ObjectItem(this IHtmlHelper helper, Project_3._0.Model.Domain.Object @object, int delay)
        {
            TagBuilder item = new TagBuilder("div");
            item.MergeAttribute("class", "col-xl-4 col-md-6");
            item.MergeAttribute("data-aos", "fade-up");
            item.MergeAttribute("data-aos-delay", delay.ToString());
            if (@object.TypeObject == "Квартира")
            {
                Apartment obj = (Apartment)@object;


                TagBuilder d = new TagBuilder("div");
                d.MergeAttribute("class", "card");

                TagBuilder div = new TagBuilder("div");
                div.MergeAttribute("class", "card-body");

                TagBuilder img = new TagBuilder("img");
                img.MergeAttribute("class", "img-fluid");
                if (obj.Photo.Count>0)
                {
                img.MergeAttribute("src", obj.Photo[0].Path);
                }
                else
                {
                    img.MergeAttribute("src", "");
                }




                    TagBuilder span = new TagBuilder("span");
                span.MergeAttribute("class", "sale-rent");
                span.InnerHtml.Append($"Цена | {obj.Price}");

                TagBuilder h3 = new TagBuilder("h3");
                h3.InnerHtml.AppendHtml(helper.RouteLink($"{obj.Citi} {obj.Street} {obj.House}",
                    new { action = "ObjectsSingle", controller = "Objects", id = obj.Id },
                    new { @class = "stretched-link" }));

                TagBuilder card = new TagBuilder("div");
                card.MergeAttribute("class", "card-content d-flex flex-column justify-content-center text-center");

                TagBuilder info = new TagBuilder("div");
                info.MergeAttribute("class", "row propery-info");

                info.InnerHtml.AppendHtml(DivInfo("Этаж"));
                info.InnerHtml.AppendHtml(DivInfo("Площадь"));
                info.InnerHtml.AppendHtml(DivInfo("Комнат"));
                info.InnerHtml.AppendHtml(DivInfo("Тип"));

                TagBuilder row = new TagBuilder("div");
                row.MergeAttribute("class", "row");

                row.InnerHtml.AppendHtml(DivInfoRow(obj.Floor));
                row.InnerHtml.AppendHtml(DivInfoRow(obj.AreaHouse));
                row.InnerHtml.AppendHtml(DivInfoRow(obj.Rooms));
                row.InnerHtml.AppendHtml(DivInfoRow(obj.TypeObject));

                card.InnerHtml.AppendHtml(info);
                card.InnerHtml.AppendHtml(row);


                div.InnerHtml.AppendHtml(span);
                div.InnerHtml.AppendHtml(h3);
                div.InnerHtml.AppendHtml(card);

                d.InnerHtml.AppendHtml(img);
                d.InnerHtml.AppendHtml(div);

                item.InnerHtml.AppendHtml(d);

            }
            using (var writter = new StringWriter())
            {
                item.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }

        private static TagBuilder DivInfo(string name)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "col");
            div.InnerHtml.Append(name);
            return div;
        }
        private static TagBuilder DivInfoRow(int n)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "col");
            div.InnerHtml.Append(n.ToString());
            return div;
        }
        private static TagBuilder DivInfoRow(string n)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "col");
            div.InnerHtml.Append(n);
            return div;
        }
    }
}
