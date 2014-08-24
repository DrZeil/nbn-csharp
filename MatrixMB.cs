/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using Accord.Math.Decompositions;
using Accord.Math;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// Matrix - allows to execute operations like in matlab
    /// </summary>
    public class MatrixMB
    {
        #region FIELDS
        /// <summary>
        /// Number of rows in matrix
        /// </summary>
        public int Rows = 0;

        /// <summary>
        /// Number of columns in matrix
        /// </summary>
        public int Cols = 0;

        /// <summary>
        /// Matrix data
        /// </summary>
        public double[][] Data;

        /// <summary>
        /// Matrix name
        /// </summary>
        public System.String Name = "";

        /// <summary>
        /// Lower matrix
        /// </summary>
        public MatrixMB L;

        /// <summary>
        /// Upper matrix
        /// </summary>
        public MatrixMB U;

        /// <summary>
        /// Permutations vector
        /// </summary>
        private int[] PermutationVector;

        /// <summary>
        /// Determinant of permutation matrix - for private use only
        /// </summary>
        private double detOfP = 1;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Is square matrix
        /// </summary>
        public bool IsSquare { get { return Rows == Cols; } }

        /// <summary>
        /// Minumum value in matrix
        /// </summary>
        public double MinValue
        {
            get
            {
                double min = this.Data[0][0];
                int row, col;
                for (col = 0; col < Cols; col++)
                {
                    for (row = 0; row < Rows; row++)
                    {
                        if (this.Data[row][col] < min) min = this.Data[row][col];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Maximum value in matrix
        /// </summary>
        public double MaxValue
        {
            get
            {
                double max = this.Data[0][0];
                int row, col;
                for (col = 0; col < Cols; col++)
                {
                    for (row = 0; row < Rows; row++)
                    {
                        if (this.Data[row][col] > max) max = this.Data[row][col];
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Gets lower triangular matrix
        /// </summary>
        public MatrixMB GetLowerMatrix
        {
            get
            {
                if (L == null) MakeLU();
                return L;
            }
        }

        /// <summary>
        /// Gets upper triangular matrix
        /// </summary>
        public MatrixMB GetUppperMatrix
        {
            get
            {
                if (U == null) MakeLU();
                return U;
            }
        }

        /// <summary>
        /// Gets inverted matrix
        /// </summary>
        /// <remarks>http://msdn.microsoft.com/en-us/magazine/jj863137.aspx"/</remarks>
        public MatrixMB Inverted
        {
            get
            {
                //same as mine below
                //MatrixMB inv = new MatrixMB(Rows, Cols);
                //inv.Data = Accord.Math.Matrix.Inverse(this.Data.ToMultidimensionalArray(Rows, Cols)).ToJaggedArray(Rows, Cols);
                //return inv;

                if (L == null) MakeLU();

                MatrixMB inv = new MatrixMB(Rows, Cols);

                for (int i = 0; i < Rows; i++)
                {
                    MatrixMB Ei = MatrixMB.Zeros(Rows, 1);
                    Ei[i, 0] = 1;
                    MatrixMB col = SolveWith(Ei);

                    for (int j = 0; j < Rows; j++) inv[j, i] = col[j, 0];
                }

                return inv;
            }
        }

        public MatrixMB SolveEquatation(MatrixMB other)
        {
            return this.Inverted * other;
            /*Accord version - the most accurate*/
            var m = Data.ToMultidimensionalArray(Rows,Cols).Solve(other.Data.ToMultidimensionalArray(other.Rows,other.Cols));
            //var m = Data.ToMultidimensionalArray().Inverse().Multiply(other.Data.ToMultidimensionalArray());
            MatrixMB tmp = new MatrixMB(m.GetLength(0), m.GetLength(1));

            tmp.Data = m.ToJaggedArray(tmp.Rows, tmp.Cols);
            return tmp;
        }

        /// <summary>
        /// MatrixMB data easier access
        /// </summary>
        /// <param name="row">int - row index</param>
        /// <param name="column">int - column index</param>
        /// <returns>double - value at row and column cross</returns>
        /// <remarks>For better performance use matrix Data property as it is direct data access</remarks>
        public double this[int row, int column]
        {
            get { return Data[row][column]; }
            set { Data[row][column] = value; }
        }

        /// <summary>
        /// Gets last column from matrix
        /// </summary>
        public MatrixMB LastColumn
        {
            get
            {
                return Col(Cols - 1);
            }
        }

        /// <summary>
        /// Gets permutation matrix
        /// </summary>
        public MatrixMB PermutationMatrix
        {
            get
            {
                if (L == null) MakeLU();

                MatrixMB matrix = Zeros(Rows, Cols);
                for (int i = 0; i < Rows; i++)
                {
                    matrix.Data[PermutationVector[i]][i] = 1;
                }
                return matrix;
            }
        }

        /// <summary>
        /// Gets matrix determinant
        /// </summary>
        public double Determinant
        {
            get
            {
                if (L == null) MakeLU();
                double det = detOfP;
                for (int i = 0; i < Rows; i++) det *= U.Data[i][i];
                return det;
            }
        }

        /// <summary>
        /// Gets matrix determinant
        /// </summary>
        public double Det
        {
            get
            {
                return Determinant;
            }
        }

        /// <summary>
        /// Check if matrix is vertical vector - [n,0]
        /// </summary>
        public bool IsVerticalVector
        {
            get
            {
                return Cols == 1;
            }
        }

        /// <summary>
        /// Check if matrix is horizontal vector - [0,n]
        /// </summary>
        public bool IsHorizontalVector
        {
            get
            {
                return Rows == 1;
            }
        }

        /// <summary>
        /// Check if matrix is vector
        /// </summary>
        public bool IsVector
        {
            get
            {
                return IsVerticalVector || IsHorizontalVector;
            }
        }

        /// <summary>
        /// Transpose matrix
        /// </summary>
        /// <returns>MatrixMB transposed</returns>
        public MatrixMB Transposed
        {
            get
            {
                try
                {
                    int row, col;
                    var mat = new MatrixMB(this.Cols, this.Rows);
                    for (row = 0; row < Rows; row++)
                    {
                        for (col = 0; col < Cols; col++)
                        {
                            mat.Data[col][row] = this.Data[row][col];
                        }
                    }
                    return mat;
                }
                catch (System.Exception ex)
                {
                    throw new MatrixException("Transposition error.", ex);
                }
            }
        }

        /// <summary>
        /// Check if matrix is filled with zeros only
        /// </summary>
        public bool HasOnlyZeros
        {
            get
            {
                int row, col, counter = 0;
                for (row = 0; row < Rows; row++)
                {
                    for (col = 0; col < Cols; col++)
                    {
                        if (this.Data[row][col] == 0)
                        {
                            counter++;
                        }
                    }
                }
                return counter == Rows * Cols;
            }
        }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="rows">int - number of rows</param>
        /// <param name="cols">int - number of columns</param>
        public MatrixMB(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            Data = new double[Rows][];

            for (int i = 0; i < Rows; i++)
            {
                Data[i] = new double[Cols];
            }
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="rows">int - number of rows</param>
        /// <param name="cols">int - number of columns</param>
        /// <param name="data">double[][] - data from other matrix</param>
        public MatrixMB(int rows, int cols, double[][] data)
        {
            Rows = rows;
            Cols = cols;
            //Data = data;
            this.Data = new double[Rows][];
            for (int r = 0; r < Rows; r++)
            {
                this.Data[r] = new double[Cols];
                for (int c = 0; c < Cols; c++)
                    this.Data[r][c] = data[r][c];
            }

        }

        /// <summary>
        /// Create Matrix
        /// </summary>
        /// <param name="rows">int - rows</param>
        /// <param name="cols">int - columns</param>
        /// <returns>Matrix</returns>
        public static MatrixMB Create(int rows, int cols)
        {
            return new MatrixMB(rows, cols);
        }
        #endregion

        #region BASIC
        /// <summary>
        /// Gets specified row
        /// </summary>
        /// <param name="row">int - row index</param>
        /// <returns>MatrixMB</returns>
        public MatrixMB Row(int row)
        {
            MatrixMB mat = new MatrixMB(1, this.Cols);
            mat.Data[0] = Data[row];
            return mat;
        }

        /// <summary>
        /// Gets row as Hashtable
        /// </summary>
        /// <param name="row">int - row index</param>
        /// <param name="data">Hashtable reference</param>
        public void RowAsHashtable(int row, ref System.Collections.Hashtable data)
        {
            data.Clear();
            for (int i = 0; i < this.Cols; i++)
            {
                data[i] = this.Data[row][i];
            }
        }

        public void ClearWithZeros()
        {
            this.FillWithNumber(0);
        }

        /// <summary>
        /// Gets specified column
        /// </summary>
        /// <param name="column">int - column index</param>
        /// <returns>MatrixMB</returns>
        public MatrixMB Col(int column)
        {
            MatrixMB matrix = new MatrixMB(Rows, 1);
            for (int i = 0; i < Rows; i++)
            {
                matrix.Data[i][0] = Data[i][column];
            }
            return matrix;
        }

        /// <summary>
        /// Get column
        /// </summary>
        /// <param name="column">int - column index</param>
        /// <returns>MatrixMB</returns>
        public MatrixMB GetCol(int column)
        {
            return Col(column);
        }

        /// <summary>
        /// Set column
        /// </summary>
        /// <param name="v">MatrixMB - column vector</param>
        /// <param name="column">int - column index</param>
        public void SetCol(MatrixMB v, int column)
        {
            for (int i = 0; i < Rows; i++)
            {
                Data[i][column] = v.Data[i][0];
            }
        }

        /// <summary>
        /// Fill matrix with value
        /// </summary>
        /// <param name="number">double - value to be set</param>
        public void FillWithNumber(double number)
        {
            try
            {
                int row, col;
                for (row = 0; row < Rows; row++)
                {
                    for (col = 0; col < Cols; col++)
                    {
                        Data[row][col] = number;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Matrix filling with number error.", ex);
            }
        }

        /// <summary>
        /// Gets value from mtrix
        /// </summary>
        /// <param name="row">int - row</param>
        /// <param name="col">int - column</param>
        /// <returns>double - value</returns>
        public double getValue(int row, int col)
        {
            if (col < this.Cols && row < this.Rows)
            {
                return Data[row][col];
            }
            else
            {
                throw new MatrixException(System.String.Format("Out of array range. Array size is: {0}x{1} but selected: {2}x{3}",
                    Rows, Cols, row, col));
            }
        }

        /// <summary>
        /// Set value in matrix
        /// </summary>
        /// <param name="row">int - row</param>
        /// <param name="col">int - column</param>
        /// <param name="value">double - value to set</param>
        public void setValue(int row, int col, double value)
        {
            if (col < this.Cols && row < this.Rows)
            {
                Data[row][col] = value;
            }
            else
            {
                throw new MatrixException(System.String.Format("Out of array range. Array size is: {0}x{1} but selected: {2}x{3}",
                    Rows, Cols, row, col));
            }
        }

        /// <summary>
        /// Sum all values in matrix
        /// </summary>
        /// <returns></returns>
        public double SumAllValues()
        {
            double sum = 0;
            int row, col;
            for (row = 0; row < Rows; row++)
            {
                for (col = 0; col < Cols; col++)
                {
                    sum += Data[row][col];
                }
            }
            return sum;
        }

        /// <summary>
        /// Execute operation on each value in matrix
        /// </summary>
        /// <param name="operation">MatrixValueOperation - operation type</param>
        /// <param name="number">double - value</param>
        public void Operation(MatrixAction operation, double number)
        {
            switch (operation)
            {
                case MatrixAction.Add:
                    {
                        AddNumber(number);
                    } break;
                case MatrixAction.Substract:
                    {
                        SubNumber(number);
                    } break;
                case MatrixAction.Multiply:
                    {
                        MulByNumber(number);
                    } break;
                case MatrixAction.Divide:
                    {
                        DivByNumber(number);
                    } break;
                case MatrixAction.Power:
                    {
                        PowerByNumber(number);
                    } break;
                case MatrixAction.Sqrt:
                    {
                        SqrtFromNumber();
                    } break;
                case MatrixAction.Abs:
                    {
                        AbsoluteNumber();
                    } break;
            }
        }

        /// <summary>
        /// Execute operation on each value in matrix
        /// </summary>
        /// <param name="operation">MatrixValueOperation - operation type</param>
        /// <param name="number">double - value</param>
        /// <returns>MatrixMB</returns>
        public MatrixMB OperationNew(MatrixAction operation, double number)
        {
            MatrixMB mat = this.Copy();
            switch (operation)
            {
                case MatrixAction.Add:
                    {
                        mat.AddNumber(number);
                    } break;
                case MatrixAction.Substract:
                    {
                        mat.SubNumber(number);
                    } break;
                case MatrixAction.Multiply:
                    {
                        mat.MulByNumber(number);
                    } break;
                case MatrixAction.Divide:
                    {
                        mat.DivByNumber(number);
                    } break;
                case MatrixAction.Power:
                    {
                        mat.PowerByNumber(number);
                    } break;
                case MatrixAction.Sqrt:
                    {
                        mat.SqrtFromNumber();
                    } break;
                case MatrixAction.Abs:
                    {
                        mat.AbsoluteNumber();
                    } break;
            }
            return mat;
        }

        /// <summary>
        /// Gets matrix copy
        /// </summary>
        /// <returns>Matrix</returns>
        public MatrixMB Copy()
        {
            return new MatrixMB(Rows, Cols, Data);
        }

        /// <summary>
        /// Gets value from first row
        /// </summary>
        /// <param name="position">int - position in first row</param>
        /// <returns>double - value</returns>
        public double ValueFirstRow(int position)
        {
            return this.Data[0][position];
        }

        /// <summary>
        /// Gets value from first column
        /// </summary>
        /// <param name="position">int - position in first column</param>
        /// <returns>double - value</returns>
        public double ValueFirstCol(int position)
        {
            return this.Data[position][0];
        }

        /// <summary>
        /// Gets value from last row
        /// </summary>
        /// <param name="position">int - position in last row</param>
        /// <returns>double - value</returns>
        public double ValueLastRow(int position)
        {
            return this.Data[Rows - 2][position];
        }

        /// <summary>
        /// Gets value from last column
        /// </summary>
        /// <param name="position">int - position in last column</param>
        /// <returns>double - value</returns>
        public double ValueLastCol(int position)
        {
            return this.Data[position][Cols - 2];
        }

        /// <summary>
        /// Create new matrix from specified set of columns
        /// </summary>
        /// <param name="start">int - position of first column</param>
        /// <param name="stop">int - position of last column</param>
        /// <returns>MatrixMB</returns>
        public MatrixMB CopyColumns(int start, int stop)
        {
            MatrixMB m = new MatrixMB(this.Rows, stop - start + 1);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = start, c = 0; j <= stop; j++, c++)
                {
                    m.Data[i][c] = this.Data[i][j];
                }
            }
            return m;
        }

        /// <summary>
        /// Copy columns from first to specified column
        /// </summary>
        /// <param name="stop">int - position of last column</param>
        /// <returns>MatrixMB from columns</returns>
        public MatrixMB CopyColumns(int stop)
        {
            return CopyColumns(0, stop);
        }

        /// <summary>
        /// Copy all data without last column
        /// </summary>
        /// <returns>MatrixMB</returns>
        public MatrixMB CopyColumnsWithoutLast()
        {
            return CopyColumns(0, Cols - 2);
        }
        /// <summary>
        /// Create new Matrix from specified set of rows
        /// </summary>
        /// <param name="start">int - position of first row in original Matrix</param>
        /// <param name="stop">int - position of last row in original Matrix</param>
        /// <returns>MatrixMB - new matrix from selected rows</returns>
        public MatrixMB CopyRows(int start, int stop)
        {
            MatrixMB m = new MatrixMB(stop - start + 1, this.Cols);
            for (int i = start, c = 0; i <= stop; i++, c++)
            {
                m.Data[c] = this.Data[i];
            }
            return m;
        }

        /// <summary>
        /// Create new Matrix from specified set of rows
        /// </summary>
        /// <param name="stop">int - position of last row</param>
        /// <returns>MatrixMB - new matrix from selected rows</returns>
        public MatrixMB CopyRows(int stop)
        {
            return CopyRows(0, stop);
        }
        #endregion

        #region ADVANCED
        /// <summary>
        /// Calculate lower and upper traingular matrix - this is LU decomposition of matrix
        /// </summary>
        public void MakeLU()
        {
            //try
            //{
            //    if (!IsSquare) throw new MatrixException("The matrix is not square!");
            //    var lu = new Accord.Math.Decompositions.LuDecomposition(this.Data.ToMultidimensionalArray(Rows, Cols));
            //    var l = lu.LowerTriangularFactor;
            //    var u = lu.UpperTriangularFactor;
            //    L = new MatrixMB(l.GetLength(0), l.GetLength(1), l.ToJaggedArray(l.GetLength(0), l.GetLength(1)));
            //    U = new MatrixMB(u.GetLength(0), u.GetLength(1), u.ToJaggedArray(u.GetLength(0), u.GetLength(1)));
            //    PermutationVector = lu.PivotPermutationVector;
            //}
            //catch (System.Exception ex)
            //{
            //    throw new System.Exception(ex.Message);
            //}

            //return;
            //--------------------------------------------------------------------

            if (!IsSquare) throw new MatrixException("The matrix is not square!");
            L = MatrixMB.Identity(Rows, Cols);
            U = this.Copy();

            PermutationVector = new int[Rows];
            for (int i = 0; i < Rows; i++) PermutationVector[i] = i;

            double p = 0;
            double pom2;
            int k0 = 0;
            int pom1 = 0;

            for (int k = 0; k < Rows - 1; k++)
            {
                p = 0;
                for (int i = k; i < Rows; i++)      // find the row with the biggest pivot
                {
                    if (System.Math.Abs(U.Data[i][k]) > p)
                    {
                        p = System.Math.Abs(U.Data[i][k]);
                        k0 = i;
                    }
                }
                if (p == 0)
                {
                    throw new MatrixException("Making LU: matrix is singular!");
                }
                pom1 = PermutationVector[k];
                PermutationVector[k] = PermutationVector[k0];
                PermutationVector[k0] = pom1;

                for (int i = 0; i < k; i++)
                {
                    pom2 = L.Data[k][i];
                    L.Data[k][i] = L.Data[k0][i];
                    L.Data[k0][i] = pom2;
                }

                if (k != k0) detOfP *= -1;

                for (int i = 0; i < Rows; i++)
                {
                    pom2 = U.Data[k][i];
                    U.Data[k][i] = U.Data[k0][i];
                    U.Data[k0][i] = pom2;
                }

                for (int i = k + 1; i < Rows; i++)
                {
                    L.Data[i][k] = U.Data[i][k] / U.Data[k][k];
                    for (int j = k; j < Rows; j++)
                    {
                        U.Data[i][j] -= L.Data[i][k] * U.Data[k][j];
                    }
                }
            }
        }

        /// <summary>
        /// Function resolves Ax = v in confirmity with solution vector 
        /// </summary>
        /// <param name="vector">Matrix - solution vector</param>
        /// <returns>Matrix</returns>
        public MatrixMB SolveWith(MatrixMB vector)
        {
            if (Rows != Cols) throw new MatrixException("Solve: Matrix is not square.");
            if (Rows != vector.Rows) throw new MatrixException("Solve: wrong number of results in solution vector.");
            if (L == null) MakeLU();

            MatrixMB b = new MatrixMB(Rows, 1);
            for (int i = 0; i < Rows; i++) b[i, 0] = vector[PermutationVector[i], 0];   // switch two items in "v" due to permutation matrix

            MatrixMB z = SubsForth(L, b);
            MatrixMB x = SubsBack(U, z);

            return x;

        }

        /// <summary>
        /// Transposes matrix in place
        /// </summary>
        public void TransposedInPlace()
        {
            this.Data = this.Transposed.Data;
        }
        #endregion

        #region OPERATIONS_ON_VALUE

        /// <summary>
        /// Add value to each value in matrix
        /// </summary>
        /// <param name="number">double - value</param>
        private void AddNumber(double number)
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] += number;
                }
            }
        }

        /// <summary>
        /// Substract value from each value in matrix
        /// </summary>
        /// <param name="number">double value</param>
        private void SubNumber(double number)
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] -= number;
                }
            }
        }

        /// <summary>
        /// Multiply each value in matrix by value
        /// </summary>
        /// <param name="number">double - value</param>
        private void MulByNumber(double number)
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] *= number;
                }
            }
        }

        /// <summary>
        /// Divide each value in matrix by given value
        /// </summary>
        /// <param name="number">double - value</param>
        private void DivByNumber(double number)
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    if (Data[row][col] != 0 && number != 0) Data[row][col] /= number;
                }
            }
        }

        /// <summary>
        /// Each value in matrix to power
        /// </summary>
        /// <param name="number">double - number</param>
        private void PowerByNumber(double number)
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] = System.Math.Pow(Data[row][col], number);
                }
            }
        }

        /// <summary>
        /// Sqrt from each value in matrix
        /// </summary>
        private void SqrtFromNumber()
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] = System.Math.Sqrt(Data[row][col]);
                }
            }
        }

        /// <summary>
        /// Calvulate absolute value for each value in matrix
        /// </summary>
        private void AbsoluteNumber()
        {
            int row, col;
            for (col = 0; col < Cols; col++)
            {
                for (row = 0; row < Rows; row++)
                {
                    Data[row][col] = System.Math.Abs(Data[row][col]);
                }
            }
        }
        #endregion

        #region LOAD_STORE
        /// <summary>
        /// Loads matrix from file
        /// </summary>
        /// <param name="filename">String - filename</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Load(System.String filename)
        {
            char splitter = ',';
            try
            {
                if (!System.IO.File.Exists(filename) || filename == "")
                {
                    throw new System.Exception("Cannot find file: " + filename);
                }

                string text;
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(filename, System.Text.Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                var lines = text.Split(new char[] { '\r', '\n' });
                var rows = lines.Length;
                foreach (var line in lines)
                {
                    if (line == "") rows--;
                }
                string[] splitted = lines[0].Split(new char[] { splitter });
                if (splitted.Length == 1)
                {
                    splitter = ' ';
                    splitted = lines[0].Split(new char[] { splitter });
                }
                if (splitted.Length == 1)
                {
                    splitter = ';';
                    splitted = lines[0].Split(new char[] { splitter });
                }
                if (splitted.Length == 1)
                {
                    splitter = '\t';
                    splitted = lines[0].Split(new char[] { splitter });
                }
                var cols = splitted.Length;
                for (int i = 0; i < splitted.Length; i++) { if (splitted[i] == "") cols--; }

                MatrixMB m = new MatrixMB(rows, cols);

                var row = 0;
                foreach (var line in lines)
                {
                    if (line != "")
                    {
                        var data = line.TrimEnd(new char[] { ',', ' ' }).Split(new char[] { splitter });
                        var col = 0;
                        foreach (var number in data)
                        {
                            if (number != "")
                            {
                                m.Data[row][col] = double.Parse(number.Replace('.', ',').Trim());
                                col++;
                            }
                        }
                        row++;
                    }
                }

                m.Name = System.IO.Path.GetFileNameWithoutExtension(filename);
                return m;
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Loading matrix from file error (splitter: " + splitter.ToString() + "). File: " + filename, ex);
            }
        }

        /// <summary>
        /// Save matrix to file
        /// </summary>
        /// <param name="filename">String - filename</param>
        /// <returns>bool - true if saved or false if failure</returns>
        public bool Store(System.String filename)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (var row = 0; row < Rows; row++)
                {
                    for (var col = 0; col < Cols; col++)
                    {
                        var txt = Data[row][col].ToString().Replace(',', '.') + ",";
                        if (Data[row][col] >= 0) txt = " " + txt;
                        int l = txt.Length;
                        while (l < 10)
                        {
                            txt += " ";
                            l++;
                        }

                        sb.Append(txt);
                    }
                    sb.AppendLine();
                }

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename))
                {
                    writer.Write(sb.ToString());
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region OPERATORS

        #region MATRIX_WITH_MATRIX
        /// <summary>
        /// Addition   of two matrices
        /// </summary>
        /// <param name="one">MatrixMB - first matrix</param>
        /// <param name="two">MatrixMB - second matrix</param>
        /// <returns>MatrixMB - new MatrixMB as a result of addition</returns>
        public static MatrixMB operator +(MatrixMB one, MatrixMB two)
        {
            try
            {
                if (one.Cols == two.Cols && one.Rows == two.Rows)
                {
                    var matrix = new MatrixMB(one.Rows, one.Cols);
                    int row, col;
                    for (row = 0; row < one.Rows; row++)
                    {
                        for (col = 0; col < one.Cols; col++)
                        {
                            matrix.Data[row][col] = one.Data[row][col] + two.Data[row][col];
                        }
                    }
                    return matrix;
                }
                else
                {
                    throw new System.Exception(System.String.Format("Cannot add two matrices. Matrix size doesn't match. Matrix one: {0}x{1}, Matrix two: {2}x{3}", one.Cols, one.Rows, two.Cols, two.Rows));
                }
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Matrix addition error", ex);
            }
        }

        /// <summary>
        /// Substraction of two matrices
        /// </summary>
        /// <param name="one">MatrixMB - first matrix</param>
        /// <param name="two">MatrixMB - second matrix</param>
        /// <returns>MatrixMB - new MatrixMB as a result of substraction</returns>
        public static MatrixMB operator -(MatrixMB one, MatrixMB two)
        {
            try
            {
                if (one.Cols == two.Cols && one.Rows == two.Rows)
                {
                    var matrix = new MatrixMB(one.Rows, one.Cols);
                    int row, col;
                    for (row = 0; row < one.Rows; row++)
                    {
                        for (col = 0; col < one.Cols; col++)
                        {
                            matrix.Data[row][col] = one.Data[row][col] - two.Data[row][col];
                        }
                    }
                    return matrix;
                }
                else
                {
                    throw new System.Exception(System.String.Format("Cannot substract two matrices. Matrix size doesn't match. Matrix one: {0}x{1}, Matrix two: {2}x{3}", one.Cols, one.Rows, two.Cols, two.Rows));
                }
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Matrix addition error", ex);
            }
        }

        /// <summary>
        /// Multiplying two matrices
        /// </summary>
        /// <param name="one">MatrixMB - first matrix</param>
        /// <param name="two">MatrixMB - second matrix</param>
        /// <returns>MatrixMB - new Matrix as a result of multiplication</returns>
        /// <remarks>tested according to https://www.youtube.com/watch?v=kuixY2bCc_0 </remarks>
        public static MatrixMB operator *(MatrixMB one, MatrixMB two)
        {
            var mat = new MatrixMB(one.Rows, two.Cols);
            if (one.Cols != two.Rows)
            {
                throw new MatrixException(
                    "Cannot multiply two matrices. Matrix one cols number doesn't match matrix two rows size. " +
                    System.String.Format("Matrix one: {0}x{1}, Matrix two: {2}x{3}", one.Cols, one.Rows, two.Cols, two.Rows));
            }
            else
            {
                for (int i = 0; i < one.Rows; i++)
                {
                    for (int j = 0; j < two.Cols; j++)
                    {
                        for (int k = 0; k < one.Cols; k++)
                        {
                            mat.Data[i][j] += one.Data[i][k] * two.Data[k][j];
                        }
                    }
                }
                return mat;
            }
        }

        /// <summary>
        /// Dividing two matrices
        /// </summary>
        /// <param name="one">MatrixMB - first matrix</param>
        /// <param name="two">MatrixMB - second matrix</param>
        /// <returns>MatrixMB - new MatrixMB as a result of dividing</returns>
        public static MatrixMB operator /(MatrixMB one, MatrixMB two)
        {
            return one * two.Inverted;
        }

        /// <summary>
        /// Left division
        /// </summary>
        /// <param name="one">MatrixMB - first matrix</param>
        /// <param name="two">MatrixMB - second matrix</param>
        /// <returns>MatrixMB - divided</returns>
        public static MatrixMB Left(ref MatrixMB one, ref MatrixMB two)
        {
            return one.Inverted * two;
        }


        /// <summary>
        /// Increase each value in matrix by one
        /// </summary>
        /// <param name="matrix">MatrixMB</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator ++(MatrixMB matrix)
        {
            try
            {
                int row, col;
                for (row = 0; row < matrix.Rows; row++)
                {
                    for (col = 0; col < matrix.Cols; col++)
                    {
                        matrix.Data[row][col]++;
                    }
                }
                return matrix;
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Matrix value increase by 1 error", ex);
            }
        }

        /// <summary>
        /// Decrease each value in matrix by one
        /// </summary>
        /// <param name="matrix">MatrixMB</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator --(MatrixMB matrix)
        {
            try
            {
                int row, col;
                for (row = 0; row < matrix.Rows; row++)
                {
                    for (col = 0; col < matrix.Cols; col++)
                    {
                        matrix.Data[row][col]--;
                    }
                }
                return matrix;
            }
            catch (System.Exception ex)
            {
                throw new MatrixException("Matrix value decrease by 1 error", ex);
            }
        }
        #endregion

        #region MATRIX_WITH_VALUE
        /// <summary>
        /// Adds value to each value in matrix
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <param name="number">double - value</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator +(MatrixMB mat, double number)
        {
            return mat.OperationNew(MatrixAction.Add, number);
        }

        /// <summary>
        /// Substract value from each value in matrix
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <param name="number">double - value</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator -(MatrixMB mat, double number)
        {
            return mat.OperationNew(MatrixAction.Substract, number);
        }

        /// <summary>
        /// Multiply each value in matrix by value
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <param name="number">double - value</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator *(MatrixMB mat, double number)
        {
            return mat.OperationNew(MatrixAction.Multiply, number);
        }

        /// <summary>
        /// Divide each value in matrix by value
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <param name="number">double - value</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB operator /(MatrixMB mat, double number)
        {
            return mat.OperationNew(MatrixAction.Divide, number);
        }
        #endregion
        #endregion

        #region STATIC
        /// <summary>
        /// Create matrix filled with ones
        /// </summary>
        /// <param name="rows">int - matrix rows number</param>
        /// <param name="cols">int - matrix cols number</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Ones(int rows, int cols)
        {
            MatrixMB m = new MatrixMB(rows, cols);
            m.FillWithNumber(1);
            return m;
        }

        /// <summary>
        /// Creates matrix filled with zeros
        /// </summary>
        /// <param name="rows">int - matrix rows number</param>
        /// <param name="cols">int - matrix cols number</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Zeros(int rows, int cols)
        {
            MatrixMB mat = new MatrixMB(rows, cols);
            mat.FillWithNumber(0);
            return mat;
        }

        /// <summary>
        /// Gets Jacobian row 1 x n
        /// </summary>
        /// <param name="length">int - number of data in such row</param>
        /// <returns>MatrixMB as horizontal vector</returns>
        public static MatrixMB JacobianRow(int length)
        {
            return MatrixMB.Zeros(1, length);
        }

        /// <summary>
        /// Creates identity matrix
        /// </summary>
        /// <param name="rows">int - matrix rows number</param>
        /// <param name="cols">int - matrix cols number</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Identity(int rows, int cols)
        {
            MatrixMB m = new MatrixMB(rows, cols);
            for (int i = 0; i < System.Math.Min(rows, cols); i++)
            {
                m.Data[i][i] = 1;
            }
            return m;
        }

        /// <summary>
        /// Matrix eye - with ones on diagonal
        /// </summary>
        /// <param name="size">int - matrix size</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Eye(int size)
        {
            MatrixMB m = new MatrixMB(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m.Data[i][j] = i == j ? 1 : 0;
                }
            }
            return m;
        }

        /// <summary>
        /// Creates random filled matrix
        /// </summary>
        /// <param name="rows">int - matrix rows numer</param>
        /// <param name="cols">int - matrix cols number</param>
        /// <param name="dispersion">int - randomize range</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB Random(int rows, int cols, int dispersion)
        {
            System.Random random = new System.Random();
            MatrixMB matrix = new MatrixMB(rows, cols);
            int max = dispersion;
            int min = -dispersion;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix.Data[i][j] = random.NextDouble() * (max - min) + min;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Function solves Ax = b for A as a lower triangular matrix
        /// </summary>
        /// <param name="A">MatrixMB - lower triangular matrix</param>
        /// <param name="b">MatrixMB</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB SubsForth(MatrixMB A, MatrixMB b)
        {
            if (A.L == null) A.MakeLU();
            int n = A.Rows;
            MatrixMB x = new MatrixMB(n, 1);

            for (int i = 0; i < n; i++)
            {
                x[i, 0] = b[i, 0];
                for (int j = 0; j < i; j++) x[i, 0] -= A[i, j] * x[j, 0];
                x[i, 0] = x[i, 0] / A[i, i];
            }
            return x;
        }

        /// <summary>
        /// Function solves Ax = b for A as an upper triangular matrix
        /// </summary>
        /// <param name="A">MatrixMB - upper triangular matrix</param>
        /// <param name="b">MatrixMB</param>
        /// <returns>MatrixMB</returns>
        public static MatrixMB SubsBack(MatrixMB A, MatrixMB b)
        {
            if (A.L == null) A.MakeLU();
            int n = A.Rows;
            MatrixMB x = new MatrixMB(n, 1);

            for (int i = n - 1; i > -1; i--)
            {
                x[i, 0] = b[i, 0];
                for (int j = n - 1; j > i; j--) x[i, 0] -= A[i, j] * x[j, 0];
                x[i, 0] = x[i, 0] / A[i, i];
            }
            return x;
        }
        #endregion

        #region OVERRIDES

        /// <summary>
        /// Check if object is Matrix - equal are Matrix and its derivates
        /// </summary>
        /// <param name="obj">object - some object</param>
        /// <returns>bool - true - same, false - sth. else</returns>
        public override bool Equals(object obj)
        {
            if (obj is MatrixMB)
            {
                try
                {
                    MatrixMB m = (MatrixMB)obj;
                    return this.Cols == m.Cols && this.Rows == m.Rows;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// MatrixMB hashcode
        /// </summary>
        /// <returns>int - hashcode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }//class
}//ns
