using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VKGraphAnalisys
{
    class GraphBuilder
    {
        public static void Draw()
        {
            List<int> ids = FillIDsList(Form1.members);
            int n = Form1.members.Count;
            Form1.matrix = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                List<int> friendlist = Form1._ApiRequest.GetFriendList(Form1.members[i].Id);
                if (!friendlist.Any())
                {
                    for (int k = 0; k < n; k++)
                    {
                        Form1.matrix[i, k] = false;
                    }
                    continue;
                }
                for (int j = 0; j < friendlist.Count; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (friendlist[j] == ids[k])
                        {
                            Form1.matrix[i, k] = true;
                        }
                    }

                }
            }

            PlotForm plot = new PlotForm(Form1.matrix, Form1.members, Form1.txt);
            plot.ShowDialog();

        }
        static List<int> FillIDsList(List<Item> members)
        {
            List<int> res = new List<int>();
            foreach (Item i in members)
            {
                res.Add(i.Id);
            }

            return res;
        }
    }
}
