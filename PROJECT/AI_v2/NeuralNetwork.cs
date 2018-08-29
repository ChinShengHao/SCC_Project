using System;

namespace AI_v2
{
	public partial class NeuralNetwork
	{
		public const int X_Length = 5, H_Length = 10, Y_Length = 2;
		
		public int x_len, h_len, y_len;
		
		public Matrix Wxh, Why, Bh, By;
		
		public NeuralNetwork():this(true){}
		
		public NeuralNetwork(bool randomize)
		{
			this.x_len = X_Length;
			this.h_len = H_Length;
			this.y_len = Y_Length;
			
			if(randomize)
				Initialize();
		}
		
		public void Initialize()
		{
			const double scalar = 1.0;
			
			this.x_len = X_Length;
			this.h_len = H_Length;
			this.y_len = Y_Length;
			
			this.Wxh = Matrix.Randomize(x_len, h_len, scalar, true);
			this.Why = Matrix.Randomize(h_len, y_len, scalar, true);
			this.Bh = Matrix.Randomize(1, h_len, scalar, true);
			this.By = Matrix.Randomize(1, y_len, scalar, true);
		}
		
		public NeuralNetwork Clone()
		{
			var nn = new NeuralNetwork(false);
			nn.Wxh = this.Wxh.Clone();
			nn.Why = this.Why.Clone();
			nn.Bh = this.Bh.Clone();
			nn.By = this.By.Clone();
			return nn;
		}
		
		public Action Forward(Matrix m)
		{
			var a = Sigmoid(m.Dot(Wxh).Add(Bh));
			var yHat =  Sigmoid(a.Dot(Why).Add(By));
			return new Action(yHat.values[0, 0], yHat.values[0, 1]);
		}
		
		public Matrix Sigmoid(Matrix m)
		{
			var matrix = new Matrix(m.Row, m.Column);
			for(int i=0; i<m.Row; i++)
				for(int j=0; j<m.Column; j++)
					matrix.values[i,j] = 2.0/( 1 + Math.Pow(Math.E, - 4.9 * m.values[i,j] ) ) - 1.0;
			return matrix;
		}
	}
}

namespace AI_v2
{
	public partial class NeuralNetwork
	{
		public struct Action
		{
			public double turn, acc;
			public Action(double t, double a)
			{
				this.turn = t;
				this.acc = a;
			}
		}
	}
}
