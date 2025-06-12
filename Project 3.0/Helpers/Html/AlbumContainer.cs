using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace Project_3._0.Helpers.Html
{
    public static class AlbumContainer
    {
        public static HtmlString CreateBlogContainer(this IHtmlHelper helper)
        {
            //TagBuilder div = new TagBuilder("div");
            //div.Attributes.Add("class", "carousel-item active");
            //div.InnerHtml.AppendHtml(TagP(user.Desc));
            //div.InnerHtml.AppendHtml(TagDivMark(user.Mark.ToString()));
            //div.InnerHtml.AppendHtml(TagDivUserName(user.UserName));
            TagBuilder a = new TagBuilder(
                TagDivContainer(
                    TagDivRowCols1(
                        TagDivCol(
                            TagDivCardShadowSm(
                                TagDivCardBody(
                                    TagPCardText(
                                        TagDivDFlexJustifyContentBetweenAlignItemsCenter(
                                            TagDivBtnGroup()), "Это параграф")))),6)));



            using (var writter = new StringWriter())
            {
                a.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }

      

        private static TagBuilder TagDivContainer(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "container");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagDivRowCols1(TagBuilder tag, int count)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3");
            for (int i = 0; i < count; i++)
                div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagDivCol(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "col");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagDivCardShadowSm(TagBuilder tag)
        {
          
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "card shadow-sm");          

            TagBuilder svg = new TagBuilder("svg");
            svg.Attributes.Add("class", "bd-placeholder-img card-img-top");
            svg.Attributes.Add("width", "100%");
            svg.Attributes.Add("height", "225");
            svg.Attributes.Add("role", "img");
            svg.Attributes.Add("aria-label", "Placeholder: Эскиз");
            svg.Attributes.Add("focusable", "false");

            TagBuilder title = new TagBuilder("title");
            title.InnerHtml.Append("Placeholder");

            TagBuilder rect = new TagBuilder("rect");
            rect.Attributes.Add("width", "100%");
            rect.Attributes.Add("height", "100%");
            rect.Attributes.Add("fill", "#55595c");

            TagBuilder text = new TagBuilder("text");
            text.Attributes.Add("x", "50%");
            text.Attributes.Add("y", "50%");
            text.Attributes.Add("fill", "#eceeef");
            text.Attributes.Add("dy", ".3em");
            text.InnerHtml.Append("Эскиз");

            svg.InnerHtml.AppendHtml(title);
            svg.InnerHtml.AppendHtml(rect);
            svg.InnerHtml.AppendHtml(text);

            div.InnerHtml.AppendHtml(svg);
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagDivCardBody(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "card-body");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagPCardText(TagBuilder tag, string item)
        {
            TagBuilder p = new TagBuilder("p");
            p.Attributes.Add("class", "card-text");
            p.InnerHtml.Append(item);
            p.InnerHtml.AppendHtml(tag);
            return p;
        }
        private static TagBuilder TagDivDFlexJustifyContentBetweenAlignItemsCenter(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "d-flex justify-content-between align-items-center");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder TagDivBtnGroup()
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "btn-group");
            div.InnerHtml.AppendHtml(TagButton("Смотреть предложения"));
            div.InnerHtml.AppendHtml(TagButton("Предлжить своё"));
            return div;
        }
        private static TagBuilder TagButton(string item)
        {
            TagBuilder div = new TagBuilder("button");
            div.Attributes.Add("type", "button");
            div.Attributes.Add("class", "btn btn-sm btn-outline-secondary");
            div.InnerHtml.Append(item);
            //div.InnerHtml.AppendHtml(tag);
            return div;
        }

    }
}

