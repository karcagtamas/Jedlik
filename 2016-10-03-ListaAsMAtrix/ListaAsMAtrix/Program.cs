using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAsMAtrix
{
    class Matrix<T>
    {
        private int R;//sor
        private int C;//oszlop
        private int Size;
        private List<T> M;
        private static Random r;

        public int Sorokszáma
        {
            get
            {
                return R;
            }

            set
            {
                R = value;
            }
        }

        public int Oszlopokszáma
        {
            get
            {
                return C;
            }

            set
            {
                C = value;
            }
        }

        public int Count
        {
            get
            {
                return R * C;
            }

            set
            {
                Size = value;
            }
        }

        static Matrix()
        {
            r = new Random();
        }
        public Matrix(int r, int c)
        {
            Sorokszáma = r;
            Oszlopokszáma = c;
            M = new List<T>(new T[r*c]);
            Count = Sorokszáma * Oszlopokszáma;
        }
        public T this[int r, int c]
        {
            get
            {
                if (r < Sorokszáma && c < Oszlopokszáma && r >= 0 && c >= 0) return M[r * Oszlopokszáma + c];
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (r < Sorokszáma && c < Oszlopokszáma && r >= 0 && c >= 0) M[r * Oszlopokszáma + c] = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public T this[int index]
        {
            get
            {
                if (index >=0 && index < Count) return M[index];
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Count) M[index] = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public static Matrix<T> operator + (Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Sorokszáma != m2.Sorokszáma || m1.Oszlopokszáma != m2.Oszlopokszáma)
            {
                throw new Exception("hü...");
            }
            Matrix<T> toReturn = new Matrix<T>(m1.Sorokszáma, m1.Oszlopokszáma);
            try
            {
                for (int i = 0; i < m1.M.Count; i++)
                {
                    toReturn.M[i] = (T)checked((dynamic)m1[i] + (dynamic)m2[i]);
                }
            }
            catch
            {
                throw new Exception("why?");
            }
            return toReturn;
        }
        
        /*public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Sorokszáma != m2.Sorokszáma || m1.Oszlopokszáma != m2.Oszlopokszáma) throw new Exception("Nem jóóóóó");
            Matrix<T> c = new Matrix<T>(m1.Sorokszáma, m1.Oszlopokszáma);
            for (int i = 0; i < m1.Sorokszáma; i++)
            {
                for (int j = 0; j < m2.Oszlopokszáma; j++)
                {
                    checked
                    {
                        switch (typeof(T).Name)
                        {
                            case "SByte": c[i, j] = (T)(object)(Convert.ToSByte(m1[i,j]) + Convert.ToSByte(m2[i,j]));  break;
                            case "Int16": c[i, j] = (T)(object)(Convert.ToInt16(m1[i, j]) + Convert.ToInt16(m2[i, j])); break;
                            case "Int32": c[i, j] = (T)(object)(Convert.ToInt32(m1[i, j]) + Convert.ToInt32(m2[i, j])); break;
                            case "Int64": c[i, j] = (T)(object)(Convert.ToInt64(m1[i, j]) + Convert.ToInt64(m2[i, j])); break;
                            case "Byte": c[i, j] = (T)(object)(Convert.ToByte(m1[i, j]) + Convert.ToByte(m2[i, j])); break;
                            case "UInt16": c[i, j] = (T)(object)(Convert.ToUInt16(m1[i, j]) + Convert.ToUInt16(m2[i, j])); break;
                            case "UInt32": c[i, j] = (T)(object)(Convert.ToUInt32(m1[i, j]) + Convert.ToUInt32(m2[i, j])); break;
                            case "UInt64": c[i, j] = (T)(object)(Convert.ToUInt64(m1[i, j]) + Convert.ToUInt64(m2[i, j])); break;
                            case "Char": c[i, j] = (T)(object)(Convert.ToChar(m1[i, j]) + Convert.ToChar(m2[i, j])); break;
                            case "Single": c[i, j] = (T)(object)(Convert.ToSingle(m1[i, j]) + Convert.ToSingle(m2[i, j])); break;
                            case "Double": c[i, j] = (T)(object)(Convert.ToDouble(m1[i, j]) + Convert.ToDouble(m2[i, j])); break;
                            case "Decimal": c[i, j] = (T)(object)(Convert.ToDecimal(m1[i, j]) + Convert.ToDecimal(m2[i, j])); break;
                            default: throw new Exception(String.Format("Ez se jó"));
                        }
                    }
                }
            }
            return c;
        }*/
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Sorokszáma != m2.Oszlopokszáma || m1.Oszlopokszáma != m2.Sorokszáma) throw new Exception("Ez a két tömb nem szorozható össze!");
            Matrix<T> c = new Matrix<T>(m1.Sorokszáma, m2.Oszlopokszáma);
            int db = 0;
            for (int i = 0; i < m1.Sorokszáma; i++)
            {
                for (int j = 0; j < m2.Oszlopokszáma; j++)
                {
                    int x = 0;
                    for (int k = 0; k < m1.Oszlopokszáma; k++)
                    {
                        x += checked((dynamic)m1[i, k] * (dynamic)m2[k, j]);
                    }
                    //c.M.Add(checked((dynamic)m1[i, j] * (dynamic)m2[j, i]));
                    c[db] = (T)(dynamic)x;
                    db++;
                }
            }
            return c;
        }
        public void Randomnumber(int min, int max)
        {
            if (min <= max && typeof(T).Name != "Char")
            {
                for (int i = 0; i < Count; i++)
                {
                    checked
                    {
                        M[i] = (T)(object)r.Next(min, max);
                    }
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sbTemp = new StringBuilder();
            int cwidth = M.Max(x=>x.ToString().Length) +1;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    sbTemp.Append(this[i, j].ToString().PadRight(cwidth));
                }
                sbTemp.Append("\n");
            }
            return sbTemp.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> m1 = new Matrix<int>(5, 5);
            Matrix<int> m2 = new Matrix<int>(5, 5);
            m1.Randomnumber(1, 100);
            m2.Randomnumber(1, 100);
            Matrix<int> m3 = m1 + m2;
            Console.WriteLine(m1.ToString());
            Console.WriteLine(m2.ToString());
            Console.WriteLine(m3.ToString());



            Matrix<int> m4 = new Matrix<int>(2, 3);
            Matrix<int> m5 = new Matrix<int>(3, 2);
            m4.Randomnumber(1 ,10);
            m5.Randomnumber(1, 10);
            Matrix<int> m6 = m4 * m5;
            Console.WriteLine(m4.ToString());
            Console.WriteLine(m5.ToString());
            Console.WriteLine(m6.ToString());
            Console.ReadKey();
        }
    }
}
