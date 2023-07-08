using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatiTask
{
    internal class PathModel
    {
        RouteModel startNode = null;

        public PathModel() { }

        public bool buildPath(string[][] datas)
        {
            if (datas == null || datas.Length == 0) throw new Exception("Datos no proporcionados");
            List<string[]> pendind = datas.ToList();
            int maxAttemps = pendind.Count;
            int currentAttemp = 0;

            do
            {
                //Console.WriteLine("-------------------------------------------- ");
                //Console.WriteLine("Datos restantes: " + pendind.Count);
                int recursive = 0;
                for (int i = 0; i < pendind.Count; i++)
                {
                    string[] item = pendind[i];
                    //Console.WriteLine("De: " + item[0] + " A: " + item[1]);
                    bool inserted = false;
                    if (startNode == null)
                    {
                        startNode = new RouteModel();
                        startNode.Value = item[0].Trim();

                        RouteModel endNode = new RouteModel();
                        endNode.back = startNode;
                        endNode.Value= item[1].Trim();

                        startNode.nexts.Add(endNode);
                        inserted = true;
                    }
                    else
                    {
                        inserted = startNode.insertRoute(item[0].Trim(), item[1].Trim());
                        startNode = startNode.goToStart();
                    }

                    if (inserted)
                    {
                        pendind.Remove(item);
                        i--;
                    }
                    recursive++;
                }

                //Console.WriteLine("Inicio Actual: " + startNode.Value);
                //Console.WriteLine("Datos restantes: " + pendind.Count);
                if (pendind.Count == 0) break;
                currentAttemp++;
            } while (currentAttemp < maxAttemps);

            //Console.WriteLine("Datos restantes finales: " + pendind.Count);
            if (pendind.Count > 0) { return false; }
            return true;
        }

        public int longDistance()
        {
            return startNode.getDistante(1);
        }
    }
}
