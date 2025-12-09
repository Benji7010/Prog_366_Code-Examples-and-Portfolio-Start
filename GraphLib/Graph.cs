using Prog_405_Code_Examples_and_Portfolio_Start;

namespace GraphLib
{
    public interface IGraph<T>
    {
        public int V();
        public int E();
        public void AddEdge(int v, T w);
        public IIterator<int> Adj(int v);
        public String? ToString();
    }

    internal class VertexNode<T>
    {
        public T? Value { get; set; }
        public VertexNode<T>[] NextNodes { get; set; }

        public VertexNode(T? value)
        {
            Value = value;
            NextNodes = Array.Empty<VertexNode<T>>();
        }
        public void Append(T? value)
        {
            VertexNode<T>[] nextNodes = new VertexNode<T>[NextNodes.Length + 1];
            for (int i = 0; i < NextNodes.Length; i++)
            {
                nextNodes[i] = NextNodes[i];
            }
            NextNodes = nextNodes;
        }
        public T? Pop(int index)
        {
            VertexNode<T>[] nextNodes = new VertexNode<T>[NextNodes.Length - 1];
            for (int i = 0; i < NextNodes.Length - 1; i++)
            {
                nextNodes[i] = NextNodes[i];
            }
            T? value = NextNodes[NextNodes.Length-1].Value;
            NextNodes = nextNodes;
            return value;
        }
    }

    public class Graph<T> : IGraph<T>
    {
        private VertexNode<T>? start;
        
        public Graph(int v) 
        {
            if(v < 0)
            {
                VertexNode<T>? currentNode = new VertexNode<T>(default);
                for (int i = 1; i < v; i++)
                {
                    currentNode.Append(default);
                    currentNode = currentNode.NextNodes[0];
                }
            }
        }
        public Graph(string strIn) 
        { 
            throw new NotImplementedException();
        }

        public void AddEdge(int v, T w)
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
