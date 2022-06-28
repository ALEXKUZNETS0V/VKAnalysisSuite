using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKWallMLAnalyzer
{
    //Этот набор классов позволяет получить корректные объекты из JSON файла, возвращаемого методом VK API wall.get
    public class PostSource
    {
        public string Type { get; set; }
        public string Data { get; set; }
    }

    public class Comments
    {
        public int Count { get; set; }
        public int Can_post { get; set; }
        public bool Groups_can_post { get; set; }
    }

    public class Likes
    {
        public int Count { get; set; }
        public int User_likes { get; set; }
        public int Can_like { get; set; }
        public int Can_publish { get; set; }
    }

    public class Reposts
    {
        public int Count { get; set; }
        public int User_reposted { get; set; }
    }

    public class Views
    {
        public int Count { get; set; }
    }

    public class Donut
    {
        public bool Is_donut { get; set; }
    }

    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int With_padding { get; set; }
    }

    public class FirstFrame
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Video
    {
        public string Access_key { get; set; }
        public int Can_comment { get; set; }
        public int Can_like { get; set; }
        public int Can_repost { get; set; }
        public int Can_subscribe { get; set; }
        public int Can_add_to_faves { get; set; }
        public int Can_add { get; set; }
        public int Date { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<Image> Image { get; set; }
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public string Title { get; set; }
        public bool Is_favorite { get; set; }
        public string Track_code { get; set; }
        public string Type { get; set; }
        public int Views { get; set; }
        public string Platform { get; set; }
        public List<FirstFrame> First_frame { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Comments { get; set; }
    }

    public class Size
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
    }

    public class Photo
    {
        public int Album_id { get; set; }
        public int Date { get; set; }
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public bool Has_tags { get; set; }
        public string Access_key { get; set; }
        public List<Size> Sizes { get; set; }
        public string Text { get; set; }
        public int? Post_id { get; set; }
        public int User_id { get; set; }
    }

    public class Link
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public Photo Photo { get; set; }
        public bool Is_favorite { get; set; }
        public Button Button { get; set; }
        public string Target { get; set; }
    }

    public class Doc
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public string Ext { get; set; }
        public int Date { get; set; }
        public int Type { get; set; }
        public string Url { get; set; }
        public string Access_key { get; set; }
    }

    public class Attachment
    {
        public string Type { get; set; }
        public Video Video { get; set; }
        public Photo Photo { get; set; }
        public Link Link { get; set; }
        public Doc Doc { get; set; }
    }

    public class Action
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Button
    {
        public string Title { get; set; }
        public Action Action { get; set; }
    }

    public class CopyHistory
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public int From_id { get; set; }
        public int Date { get; set; }
        public string Post_type { get; set; }
        public string Text { get; set; }
        public List<Attachment> Attachments { get; set; }
        public PostSource Post_source { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public int From_id { get; set; }
        public int Owner_id { get; set; }
        public int Date { get; set; }
        public string Post_type { get; set; }
        public string Text { get; set; }
        public PostSource Post_source { get; set; }
        public Comments Comments { get; set; }
        public Likes Likes { get; set; }
        public Reposts Reposts { get; set; }
        public Views Views { get; set; }
        public bool Is_favorite { get; set; }
        public Donut Donut { get; set; }
        public double Short_text_rate { get; set; }
        public int Edited { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<CopyHistory> Copy_history { get; set; }
        public int? Carousel_offset { get; set; }

        public string Prediction { get; set; }
        public float Probability { get; set; }
    }

    public class Response
    {
        public int Count { get; set; }
        public List<Item> Items { get; set; }
    }

    public class WallRoot
    {
        public Response Response { get; set; }
    }
}
