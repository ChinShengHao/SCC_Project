using System;
using System.Drawing;

namespace AI_v2
{
	public class Dot
	{
		public const double maxVel = 10.0;
		public const double maxAcc = 1.0;
		
		public Color color;
		public int size;
		public double x, y;
		public double turn;
		public double vel, acc;
		public double score;
		public int step;
		public bool dead, reachGoal;
		
		public Matrix input;
		public NeuralNetwork brain;
		
		public Dot()
		{
			this.color = Color.Black;
			this.size = 10;
			this.x = MainForm.initialPosX;
			this.y = MainForm.initialPosY;
			this.turn = 0;
			this.vel = 0;
			this.acc = 0;
			this.score = 0;
			this.step = 0;
			this.dead = false;
			this.reachGoal = false;
			this.brain = new NeuralNetwork();
		}
		
		public Dot Clone()
		{
			var d = new Dot();
			d.color = this.color;
			d.brain = this.brain.Clone();
			return d;
		}
		
		public void Move()
		{
			if( this.dead )
				return;
			
			var matrix = new Matrix(1, 5);
			matrix.values[0, 0] = this.x/180.0 - 1;
			matrix.values[0, 1] = this.y/160.0 - 1;
			matrix.values[0, 2] = this.turn;
			matrix.values[0, 3] = this.vel/maxVel;
			matrix.values[0, 4] = this.acc/maxAcc;
			var action = brain.Forward(matrix);
			
			if( this.turn + action.turn > 1.0 || this.turn + action.turn < -1.0)
				this.turn = action.turn;
			else
				this.turn = this.turn + action.turn;
				
			if( this.acc + action.acc > maxAcc )
				this.acc = maxAcc;
			else if( this.acc + action.acc < -maxAcc )
				this.acc = -maxAcc;
			else
				this.acc = this.acc + action.acc;
				
			if( this.vel + this.acc > maxVel )
				this.vel = maxVel;
			else if( this.vel + this.acc < -maxVel )
				this.vel = -maxVel;
			else
				this.vel = this.vel + this.acc;
			
			this.x += this.vel * Math.Cos(this.turn * Math.PI * 2 );
			this.y -= this.vel * Math.Sin(this.turn * Math.PI * 2 );
			
			this.step++;
				
			if( this.step > MainForm.maxStep )
			{
				this.dead = true;
				CalculateFitness();
				return;
			}
			
			if( this.IsOutOfBound() )
			{
				this.dead = true;
				CalculateFitness();
				return;
			}
			else if( IsCollideAt(MainForm.goal) )
			{
				this.reachGoal = true;
				this.dead = true;
				CalculateFitness();
				return;
			}
			else
			{
				foreach(var o in MainForm.obstacles)
					if( IsCollideAt(o) )
					{
						this.dead = true;
						CalculateFitness();
						return;
					}
			}
		}
		
		public bool IsOutOfBound()
		{
			return ( this.x < 0 || this.x + this.size > 360 || this.y < 0 || this.y + this.size > 320);
		}
		
		public bool IsCollideAt(Rectangle rect)
		{
			return (rect.IntersectsWith(new Rectangle((int)this.x, (int)this.y, this.size, this.size)));
		}
		
		public double Distance(Rectangle r)
		{
			return Math.Sqrt( Math.Pow( this.x - r.X , 2) + Math.Pow( this.y - r.Y , 2) );
		}
		
		public void CalculateFitness()
		{
			if( this.reachGoal )
				this.score = 100000.0/Math.Pow(this.step,2);
			else 
			{
				var r = new Rectangle((int)this.x, (int)this.y, this.size, this.size);
				foreach(var e in MainForm.eliminateRegions)
				{
					if(e.IntersectsWith(r))
					{
						this.score = -1;
						return;
					}
				}
				
				this.score = 1.0/Math.Pow(Distance(MainForm.goal),2);
			}
		}
	}
}
