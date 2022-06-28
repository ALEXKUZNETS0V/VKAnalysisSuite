using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System;


namespace VKGraphAnalisys
{
    public partial class PlotForm : Form
    {
        public PlotForm(bool[,] matrix, List<Item> members, bool txt)
        {
            InitializeComponent();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph.LayoutAlgorithmSettings = new Microsoft.Msagl.Layout.MDS.MdsLayoutSettings();
            graph.LayoutAlgorithmSettings.EdgeRoutingSettings.EdgeRoutingMode = Microsoft.Msagl.Core.Routing.EdgeRoutingMode.StraightLine;
            graph.LayoutAlgorithmSettings.NodeSeparation = 3.0;
            graph.LayoutAlgorithmSettings.PackingMethod = Microsoft.Msagl.Core.Layout.PackingMethod.Columns;

            //create the graph content 
            for (int i = 1; i < members.Count; i++)
            {
                graph.AddNode(members[i].Id.ToString() +
                    "\n" + members[i].First_name + " " + members[i].Last_name);
            }
            for (int i = 0; i < members.Count; i++)
            {
                for (int j = 0; j < members.Count; j++)
                {
                    if (matrix[i, j] && members[i].Id != 0 && members[j].Id != 0)
                    {
                        graph.AddEdge(members[i].Id.ToString() +
                            "\n" + members[i].First_name + " " + members[i].Last_name,
                            members[j].Id.ToString() +
                            "\n" + members[j].First_name + " " + members[j].Last_name).Attr.ArrowheadLength = 0.1;
                    }
                }
            }





            //Вывод топа по количеству ребер
            List<Microsoft.Msagl.Drawing.Node> NodesSorted = new List<Microsoft.Msagl.Drawing.Node>();

            NodesSorted = graph.Nodes.OrderBy(node => -node.Edges.Count()).ToList();
            
            int topsize = NodesSorted.Count < 10 ? NodesSorted.Count : 10;
            string top = topsize.ToString() + " популярнейших:\n";
            for (int i = 0; i < topsize; i++)
                top += (i + 1).ToString() + ": " + NodesSorted[i].Id + ", " +
                    System.Math.Max(NodesSorted[i].InEdges.Count(), NodesSorted[i].OutEdges.Count()) + " друзей;\n";
            
            if (txt)
            {
                
                StreamWriter sw =
                    new StreamWriter(Environment.CurrentDirectory + "\\Статистика группы по пользователям.txt");
                for (int i = 0; i < NodesSorted.Count; i++)
                
                {
                    string name = NodesSorted[i].Id.Replace('\n', ' ') + ", " +
                    System.Math.Max(NodesSorted[i].InEdges.Count(), NodesSorted[i].OutEdges.Count()) + " друзей;\n";
                    sw.WriteLine(name);
                }
                sw.Close();
            }
            graph.AddNode(top);

            //graph.FindGeometryNode(top10).Center = (new Microsoft.Msagl.Core.Geometry.Point
            //    (graph.FindNode(top10).GeometryNode.Width / 2,
            //    graph.FindNode(top10).GeometryNode.Height / 2));
            //graph.FindNode(top10).GeometryNode.Center =
            //(new Microsoft.Msagl.Core.Geometry.Point(graph.FindNode(top10).GeometryNode.Width / 2, graph.FindNode(top10).GeometryNode.Height / 2));

            //var TopInfluencersSubgraph = new Microsoft.Msagl.Drawing.Subgraph("10 самых популярных");
            //Microsoft.Msagl.Core.Layout.Cluster geometryCluster = new Microsoft.Msagl.Core.Layout.Cluster() ;
            //TopInfluencersSubgraph.GeometryNode = geometryCluster;
            //geometryCluster.UserData = TopInfluencersSubgraph;
            //graph.RootSubgraph.AddSubgraph(TopInfluencersSubgraph);
            //TopInfluencersSubgraph.LayoutSettings = new Microsoft.Msagl.Layout.MDS.MdsLayoutSettings();
            //for (int i = 0; i < 10; i++)
            //    TopInfluencersSubgraph.AddNode(graph.AddNode(i+1.ToString() + ": " + NodesSorted[i].Id));
            //graph.RootSubgraph.AddSubgraph(TopInfluencersSubgraph);

            viewer.Graph = graph;
            //associate the viewer with the form 

            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
        }
    }
}
