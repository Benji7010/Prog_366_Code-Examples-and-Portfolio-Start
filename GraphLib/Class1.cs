using Prog_405_Code_Examples_and_Portfolio_Start;

namespace GraphLib
{
    public interface IGraph
    {
        public int V();
        public int E();
        public void AddEdge(int v, int w);
        public IIterator<int> Adj(int v);
        public String ToString();
    }
    
    public class Graph : IGraph
    {
        public Graph(int v) {}
        public Graph(string strIn) { }

        public void AddEdge(int v, int w)
        {
            throw new NotImplementedException();
        }

        public IIterator<int> Adj(int v)
        {
            throw new NotImplementedException();
        }

        public int E()
        {
            throw new NotImplementedException();
        }

        public int V()
        {
            throw new NotImplementedException();
        }
    }
}
