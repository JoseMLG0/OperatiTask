using System;
using System.Collections.Generic;
using System.Text;

namespace OperatiTask
{

    internal class RouteModel
    {
        public string Value = null;
        public RouteModel back = null;
        public List<RouteModel> nexts = null;

        public RouteModel() { 
            Value = null;
            back= null;
            nexts= new List<RouteModel>();
        }

        public RouteModel returnBack()
        {
            return back;
        }

        public bool insertRoute(string origen, string destino)
        {
            RouteModel currentNode = searchValue(origen);


            if (currentNode == null)
            {
                //Console.WriteLine("Nodo de origen no encontrado " + origen);
                currentNode = searchValue(destino);
                if (currentNode != null)
                {
                    //Console.WriteLine("Nodo de destino encontrado " + destino);
                    currentNode.back = new RouteModel();
                    currentNode.back.Value = origen;
                    currentNode.back.nexts.Add(this);

                    return true;
                }
                return false;
            }
            else
            {
                RouteModel finded = currentNode.nexts.Find(x => x.Value == destino);
                if(finded == null)
                {
                    RouteModel aux = new RouteModel();
                    aux.Value = destino;
                    currentNode.nexts.Add(aux);
                    return true;
                }
            }
            return false;
        }

        public RouteModel searchValue(string valueToSearch)
        {
            if (Value == null) throw new Exception("Nodo sin datos");
            //Console.WriteLine("Valor nodo " + Value + " Buscando " + valueToSearch);
            if (Value.ToString().Equals(valueToSearch.ToString(), StringComparison.InvariantCulture)) return this;
            else
            {
                //Console.WriteLine("Destinos actuales " + nexts.Count);
                foreach (RouteModel item in nexts)
                {
                    RouteModel finded = item.searchValue(valueToSearch);
                    if (finded != null) { return finded; }
                }
            }

            // No encontrado
            return null;
        }

        public RouteModel goToStart()
        {
            if(this.back != null)
            {
                return this.back.goToStart();
            }
            return this;
        }

        public int getDistante(int currentDistance)
        {
            if(nexts.Count > 0)
            {
                int longDistance = 0;
                for (int i = 0; i < nexts.Count; i++)
                {
                    RouteModel aux = nexts[i];
                    int auxDistance = aux.getDistante(currentDistance+1);
                    if (auxDistance  > longDistance)
                    {
                        longDistance = auxDistance;
                    }
                }
                return longDistance;
            }
            return currentDistance;
        }
    }
}
