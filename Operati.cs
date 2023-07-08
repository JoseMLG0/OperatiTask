using System;
using System.Collections.Generic;

namespace OperatiTask
{
    public class Operati
    {
        public static bool TreeConstructor(string[] strArr)
        {
            if (strArr == null || strArr.Length == 0) { return false; }
            int len = strArr.Length;
            string[][] mainData = new string[len][];

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] aux1 = strArr[i].Replace('(', '\0').Replace(')', '\0').Split(',');
                aux1[0] = aux1[0].Trim();
                aux1[1] = aux1[1].Trim();

                mainData[i] = aux1;
            }

            TreeModel arbolBinario = new TreeModel();

            return arbolBinario.buildTree(mainData);
        }
        public static int FarthestNodes(string[] strArr)
        {
            if (strArr == null || strArr.Length == 0) { return 0; }
            int len = strArr.Length;
            string[][] mainData = new string[len][];

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] aux1 = strArr[i].Split('-');
                aux1[0] = aux1[0].Trim();
                aux1[1] = aux1[1].Trim();

                mainData[i] = aux1;
            }

            PathModel path = new PathModel();
            if (!path.buildPath(mainData))
            {
                throw new Exception("Error al construir el camino");
            }

            return path.longDistance();
        }

    }
}
