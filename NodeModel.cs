using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OperatiTask
{
    internal class NodeModel
    {
        public string Data { get; set; }
        public NodeModel Parent { get; set; }
        public NodeModel Left { get; set; }
        public NodeModel Right { get; set; }
        public NodeModel() {
            Data = null; Parent = null; Left = null; Right = null;
        }

        public bool insetChild(string child, string parent)
        {
            //Console.WriteLine("Nodo actual " + Parent);
            NodeModel currentNode = searchData(parent);
            if(currentNode == null) {
                //Console.WriteLine("Nodo Padre no encontrado " + parent);
                currentNode = searchData(child);
                if (currentNode != null)
                {
                    //Console.WriteLine("Nodo hijo encontrado " + currentNode.Data);
                    currentNode.Parent = new NodeModel();
                    currentNode.Parent.Left = this;
                    currentNode.Parent.Data = parent;
                    return true;
                }
                return false;
            }
            else
            {
                //Console.WriteLine("Nodo encontrado " + currentNode.Data);
                //Console.WriteLine("hijo izquierdo " + currentNode.Left?.Data);
               // Console.WriteLine("hijo derecho " + currentNode.Right?.Data);
                if (currentNode.Left == null)
                {
                    currentNode.Left = new NodeModel();
                    currentNode.Left.Parent = this;
                    currentNode.Left.Data = child;
                   // Console.WriteLine("hijo izquierdo " + currentNode.Left?.Data);
                    return true;
                }
                else if(currentNode.Right == null)
                {
                    currentNode.Right = new NodeModel();
                    currentNode.Right.Parent = this;
                    currentNode.Right.Data = child;
                   // Console.WriteLine("hijo derecho " + currentNode.Right?.Data);
                    return true;
                }
                //Console.WriteLine("Ambos nodos hijos ya registrados "+ parent);
            }
            return false;
        }

        public NodeModel searchData(string dataSearch)
        {
            if (Data == null) throw new Exception("Nodo sin datos");
          //  Console.WriteLine("Valor buscado: " + dataSearch + " Valor del nodo actual: " + Data);
           // Console.WriteLine(Data.ToString().Equals(dataSearch.ToString(), StringComparison.InvariantCulture));

            // Busco en el nodo actual
            if (Data.ToString().Equals(dataSearch.ToString(), StringComparison.InvariantCulture)) return this;
            else if (Right != null) return Right.searchData(dataSearch);
            else if (Left != null) return Left.searchData(dataSearch);

            // No encontrado
            return null;
        }

        public NodeModel getRoot(NodeModel currentNode)
        {
            if (currentNode.Parent == null) return currentNode;
            return getRoot(currentNode.Parent);
        }
    }
}
