using System.Collections.Generic;

namespace VKGraphAnalisys
{
    public class ResponseGroup
    {
        public int Count { get; set; }
        public List<Item> Items { get; set; }
    }

    public class GroupRoot
    {
        public ResponseGroup Response { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public bool Can_access_closed { get; set; }
        public bool Is_closed { get; set; }
        public City City { get; set; }
    }

}

