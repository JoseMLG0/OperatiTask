using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatiTask
{
    internal class TreeModel
    {
        NodeModel mainNode = null;

        public TreeModel() { }

        public bool buildTree(string[][] datas)
        {
            if (datas == null || datas.Length == 0) throw new Exception("Datos no proporcionados");
            List<string[]> pendind = datas.ToList();
            int maxAttemps = pendind.Count;
            int currentAttemp = 0;

            do
            {
                //Console.WriteLine("Datos restantes: " + pendind.Count);
                int recursive = 0;
                for (int i = 0; i < pendind.Count; i++)
                {
                    string[] item = pendind[i]; 
                    bool inserted = false;
                    if (mainNode == null)
                    {
                        mainNode = new NodeModel();
                        mainNode.Data = item[1].Trim();

                        mainNode.Left = new NodeModel();
                        mainNode.Left.Parent = mainNode;
                        mainNode.Left.Data = item[0].Trim();
                        inserted = true;
                    }
                    else
                    {
                        inserted = mainNode.insetChild(item[0].Trim(), item[1].Trim());
                        mainNode = mainNode.getRoot(mainNode);
                    }

                    if (inserted)
                    {
                        pendind.Remove(item);
                        i--;
                    }
                    recursive++;
                }

                //Console.WriteLine("Datos restantes: " + pendind.Count);
                if (pendind.Count == 0) break;
                currentAttemp++;
            } while (currentAttemp < maxAttemps);

            //Console.WriteLine("Datos restantes finales: " + pendind.Count);
            if (pendind.Count > 0) { return false; }
            return true;
        }

    }
}
