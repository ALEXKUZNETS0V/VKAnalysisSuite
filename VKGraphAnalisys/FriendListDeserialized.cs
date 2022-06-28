using System.Collections.Generic;

namespace VKGraphAnalisys
{
    public class ResponseFriendList
    {
        public int Count { get; set; }
        public List<int> Items { get; set; }
    }

    public class FriendListRoot
    {
        public ResponseFriendList Response { get; set; }
    }
}
