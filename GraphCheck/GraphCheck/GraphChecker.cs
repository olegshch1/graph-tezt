using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GraphCheck
{
    /// <summary>
    /// Решаем задачу на матрице смежности из 1 варианта
    /// Здесь будем проверять вершины. Развернем ориентацию ребер и пройдемся от каждой вершины обходом в глубину. 
    /// Если из какой-то вершины мы сможем посетить все, то ответ найден
    /// </summary>
    public class GraphChecker
    {
        /// <summary>
        /// Будем хранить матрицу здесь
        /// </summary>
        public List<List<int>> Map { get; set; }

        /// <summary>
        /// храним информацию о посещенных вершинах
        /// </summary>
        private int[] verts;

        public GraphChecker(string path) {
            using (var reader = new StreamReader(path))
            {
                Map = new List<List<int>>();
                string line = reader.ReadLine();
                int index = 0;
                while (line != null)
                {
                    Map.Add(new List<int>());
                    for (var i = 0; i < line.Length; ++i)
                    {
                        Map[index].Add(line[i]);
                    }
                    index++;
                    line = reader.ReadLine();
                }
            }
            verts = new int[Map.Count];

        }

        /// <summary>
        /// транспонируем матрицу
        /// </summary>
        public void Reverse()
        {
            var temp=0;
            for (int i = 0; i < Map.Count(); ++i)
            {
                for (int j=i+1;j< Map.Count(); ++j)
                {
                    temp = Map[i][j];
                    Map[i][j] = Map[j][i];
                    Map[j][i] = temp;

                }
            } 
        }

        /// <summary>
        /// алгоритм обхода
        /// </summary>
        /// <param name="vertNumber"></param>
        private void DFS(int vertNumber)
        {
            verts[vertNumber] = 1;
            for(int i = 0;  i < Map.Count; ++i)
            {
                if (Map[vertNumber][i] == 1)
                {
                    DFS(i);
                }
            }
        } 

        /// <summary>
        /// Запускаем обход от каждой вершины и проверяем количество посещенных вершин. 
        /// Если количество равно общему числу вершин, то мы нашли нужную вершину
        /// </summary>
        /// <returns></returns>
        public bool DFSCheck()
        {
            for (int i = 0; i < Map.Count; ++i)
            {
                for (int j = 0; j < Map.Count; ++j) {
                    verts[j] = 0;
                }
                DFS(i);
                if (verts.Sum() == Map.Count())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
