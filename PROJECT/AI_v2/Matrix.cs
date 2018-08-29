using System;

namespace AI_v2
{
	public class Matrix
	{
		public readonly int Row, Column;
		public double[,] values;
		
		public Matrix(int row, int col)
		{
			this.Row = row;
			this.Column = col;
			this.values = new double[row, col];
			
		}
		
		public Matrix Clone()
		{
			var matrix = new Matrix(this.Row, this.Column);
			
			for(int i=0; i<matrix.Row; i++)
				for(int j=0; j<matrix.Column; j++)
					matrix.values[i, j] = this.values[i, j];
					
			return matrix;
		}
		
		public Matrix Add(Matrix m)
		{
			var matrix = new Matrix(this.Row, this.Column);
			
			for(int i=0; i<matrix.Row; i++)
				for(int j=0; j<matrix.Column; j++)
					matrix.values[i, j] = this.values[i, j] + m.values[i, j];
			return matrix;
		}
		public Matrix Multiply(Matrix m)
		{
			var matrix = new Matrix(this.Row, this.Column);
			
			for(int i=0; i<matrix.Row; i++)
				for(int j=0; j<matrix.Column; j++)
					matrix.values[i, j] *= m.values[i, j];
			return matrix;
		}
		public Matrix Dot(Matrix m)
		{
			var matrix = new Matrix(this.Row, m.Column);
			
			for (int i=0; i<this.Row; i++)
				for (int j=0; j<m.Column; j++)
				{
					double sum = 0;
					for (int k=0; k<this.Column; k++)
						sum += this.values[i,k] * m.values[k,j];
					matrix.values[i,j] = sum;
			  	}
			
			return matrix;
		}
		
		public static Matrix Randomize(int row, int col, double scalar, bool negative)
		{
			var m = new Matrix(row, col);
			if( negative )
				for(int i=0; i<row; i++)
					for(int j=0; j<col; j++)
						m.values[i, j] = scalar * ( 2 * MainForm.random.NextDouble() - 1 );
			else
				for(int i=0; i<row; i++)
					for(int j=0; j<col; j++)
						m.values[i, j] = scalar * MainForm.random.NextDouble();
			return m;
		}
		
	}
}