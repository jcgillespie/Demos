namespace DemoSite
{
	using System;
	using System.Drawing.Imaging;
	using System.IO;
	using System.Web;
	using System.Web.Mvc;

	using ZXing;
	using ZXing.Common;

	public static class HtmlHelperExtensions
    {
        public static IHtmlString GenerateQrCode(
            this HtmlHelper html,
            string value,
            string altText = "QR Code",
            int height = 250,
            int width = 250,
            int margin = 0)
        {
            var write = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options =
                    new EncodingOptions
                    {
                        Height = height,
                        Width = width,
                        Margin = margin,
                    }
            };
            using (var bitmap = write.Write(value))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Gif);
                var img = new TagBuilder("img");
                img.MergeAttribute("alt", altText);
                img.Attributes.Add(
                    "src",
                    string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(stream.ToArray())));
                return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
            }
        }
    }
}