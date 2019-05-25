using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDEForm
{
    public class PDE
    {
        public const int MAX = 50;
        public int[,] m = new int[MAX, MAX];

        private int[] x = { -1, 0, 1, 0 };
        private int[] y = { 0, -1, 0, 1 };


        public PDE()
        {
            initArray();
        }

        private void initArray()
        {

            for(int i = 0; i < MAX; i++)
            {
                for(int j = 0; j < MAX; j++)
                {
                    m[i, j] = 100;
                }
            }
        }

        public bool safe(int x, int y)
        {
            return (x >= 0 && x < MAX && y >= 0 && y < MAX);

        }

        public bool pde(int[,] m)
        {
            int row, col;
            int[,] mc = new int[MAX, MAX];

            for (row = 0; row < MAX; row++)
            {
                for (col = 0; col < MAX; col++)
                {
                    List<int> s = new List<int>();
                    for (int i = 0; i < 4; i++)
                    {
                        int dx = row + x[i];
                        int dy = col + y[i];

                        if (safe(dx, dy))
                        {
                            s.Add(m[dx, dy]);
                        }
                    }
                    int pde = 0;

                    foreach (int v in s)
                    {
                        pde += v;
                    }

                    mc[row, col] = pde /= 4;
                }
            }
            int flag = 1;
            int c = 0;

            for (row = 0; row < MAX; row++)
            {
                for (col = 0; col < MAX; col++)
                {
                    m[row, col] = mc[row, col];
                }
            }

            for (row = 0; row < MAX; row++)
            {
                for (col = 0; col < MAX; col++)
                {
                    if (m[row, col] == 0)
                    {
                        c++;
                    }
                }
            }

            if (c == (MAX * MAX))
                return false;

            return true;
        }
    }
}
