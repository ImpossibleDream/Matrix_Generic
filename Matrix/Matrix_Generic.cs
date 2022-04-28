using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MMatrix<TRow, TColumn, TValue>
    {
        private TRow ROW;
        private TColumn COL;
        private TValue VALUE;

        private TRow[] matrix_row;
        private TColumn[] matrix_col;
        private TValue[,] matrix;
        public MMatrix(int size1,int size2)
        {
            matrix_row = new TRow[size1];
            matrix_col = new TColumn[size2];
            matrix = new TValue[size1, size2];
        }

        //row
        public TRow getRow(int row)
        {
            return matrix_row[row];
        }
        public void setRow(int row, TRow row1)
        {
            matrix_row[row] = row1;
        }

        //col
        public TColumn getCol(int col)
        {
            return matrix_col[col];
        }
        public void setCol(int col, TColumn col1)
        {
            matrix_col[col] = col1;
        }

        //value
        public TValue getValue(int row,int col)
        {
            return matrix[row,col];
        }
        public void setValue(int row, int col, TValue value)
        {
            matrix[row,col] = value;
        }

        public void Print(int row, int col)
        {
            //Console.WriteLine("Row " + "Column " + "Value");
            /*for (int i=0;i<row;i++)
            {
                for (int j=0;j<col;j++)
                {
                    Console.WriteLine(" " + getRow(i) + "    " + getCol(j) + "      " + getValue(i, j) + "\n");
                }
            }*/
            if (row>=0&&col>=0)
                Console.WriteLine(" " + getRow(row) +row+ "    " + getCol(col) +col+ "      " + getValue(row,col) + "\n");
        }
        public void RemoveRow(int row1,TRow row)
        {
            if (Math.Equals(getRow(row1),row))
            {
                row1 += 1;
            }
        }
        public void RemoveCol(int col1,TColumn col)
        {
            if (Math.Equals(getCol(col1),col))
            {
                col1 += 1;
            }
        }
        public MMatrix<TRow, TColumn, TValue> Transpose(TValue[,]m,int row,int col)
        {
            TValue t;
            for (int i=0;i<row;i++)
            {
                for (int j=0;j<i;j++)
                {
                    t = m[i,j];
                    m[i, j] = m[j, i];
                    m[j, i] = t;
                }
            }
            return MMatrix(getRow(row),getCol(col),getValue(col,row));
        }
    }
    class Matrix_Generic
    { 
        static void Main(string[] args)
        {
            //Matrix<string,string,int> m = new Matrix<string,string,int>();
            var m = new MMatrix<string, string, int>(9,9);

            int i, j;

            for (i=0;i<8; i++)
            {
                m.setRow(i, "row");
                
                for (j=0;j<8;j++)
                {
                    m.setCol(j, "col");
                    m.setValue(i, j, i + j);
                    m.Print(i,j);
                }
            }
            m.setValue(8, 8, 8);
            m.Print(8,8);

            m.RemoveRow(0, "row");
            
            //m.Print(9, 9);
            Console.WriteLine();
        }
    }
}