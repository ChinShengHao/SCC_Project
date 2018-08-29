using System;
using System.Collections;
using System.Collections.Generic;

namespace AI_v2
{
	public class Population
	{
		public const int PopulationSize = 100;
		public const double CrossRate = 0.20;
		public const double MutateRate = 0.01;
		
		public int generation;
		
		public Dot[] dots;
		public Dot champion;
		
		public Population()
		{
			generation = 1;
			dots = new Dot[PopulationSize];
			for(int i=0; i<dots.Length;i++)
				dots[i] = new Dot();
		}
		
		public void NaturalSelection()
		{
			this.generation++;
			
			double passingScore = GetAverageScore();
			var elites = GetElites(passingScore);
			
			Dot best = GetBestDot();
			
			if( champion == null || best.size > champion.score )
				champion = best;
			
			for(int i=0; i<dots.Length;i++)
			{
				if( MainForm.random.Next()%2==0 )
				{
					//only best genes
					if( dots[i].score < 0 )
					{
						//replaced by crossing over of 2 random elites 
						dots[i] = CrossOver(GetRandomDot(elites).Clone(), GetRandomDot(elites).Clone(), 0.5);
						Mutate(dots[i], MutateRate * 2);
					}
					else
					{
						//do the normal crossing with any random elite
						dots[i] = CrossOver(GetRandomDot(elites).Clone(), dots[i], CrossRate);
						Mutate(dots[i], MutateRate);
					}
				}
				else
				{
					//champion genes
					if( dots[i].score < 0 )
					{
						//replaced by crossing over of 2 random elites 
						dots[i] = CrossOver(champion.Clone(), GetRandomDot(elites).Clone(), 0.5);
						Mutate(dots[i], MutateRate * 2);
					}
					else
					{
						//do the normal crossing with any random elite
						dots[i] = CrossOver(champion.Clone(), dots[i], CrossRate);
						Mutate(dots[i], MutateRate);
					}
				}
			}
			
		}
		
		public Dot GetRandomDot(Dot[] dots)
		{
			return dots[MainForm.random.Next()%dots.Length];
		}
		public Dot[] GetElites(double passingScore)
		{
			var list = new ArrayList();
			
			foreach(var d in dots)
				if( d.score >= passingScore )
					list.Add(d);
			
			Dot[] dot = new Dot[list.Count];
			for(int i=0; i<dot.Length; i++)
				dot[i] = (Dot)list[i];
			return dot;
		}
		public double GetAverageScore()
		{
			double sum = 0;
			int total = 0;
			for(int i=0; i<dots.Length;i++)
				if( dots[i].score > 0 )
				{
					total++;
					sum += dots[i].score;
				}
			return sum/total;
		}
		
		public Dot GetBestDot()
		{
			int index = 0;
			double score = dots[index].score;
			for(int i=0; i<dots.Length; i++)
				if( dots[i].score > score )
				{
					index = i;
					score = dots[i].score;
				}
			return dots[index];
		}
		
		public Dot CrossOver(Dot reference, Dot b, double rate)
		{
			Dot dot = new Dot();
			dot.brain = CrossOver(reference.brain, b.brain, rate);
			return dot;
		}
		public NeuralNetwork CrossOver(NeuralNetwork reference, NeuralNetwork b, double rate)
		{
			NeuralNetwork nn = new NeuralNetwork(false);
			nn.Wxh = CrossOver(reference.Wxh, b.Wxh, rate);
			nn.Why = CrossOver(reference.Why, b.Why, rate);
			nn.Bh = CrossOver(reference.Bh, b.Bh, rate);
			nn.By = CrossOver(reference.By, b.By, rate);
			return nn;
		}
		public Matrix CrossOver(Matrix reference, Matrix b, double rate)
		{
			Matrix m = new Matrix(reference.Row, reference.Column);
			for(int i=0; i<m.Row;i++)
				for(int j=0; j<m.Column; j++)
					m.values[i,j] = (MainForm.random.NextDouble()<rate)?reference.values[i,j]:b.values[i,j];
			return m;
		}
		
		public void Mutate(Dot a, double rate)
		{
			Mutate(a.brain, rate);
		}
		public void Mutate(NeuralNetwork a, double rate)
		{
			Mutate(a.Wxh, rate);
			Mutate(a.Why, rate);
			Mutate(a.Bh, rate);
			Mutate(a.By, rate);
		}
		public void Mutate(Matrix a, double rate)
		{
			for(int i=0; i<a.Row;i++)
				for(int j=0; j<a.Column; j++)
					a.values[i,j] = (MainForm.random.NextDouble()<rate)?MainForm.random.NextDouble()*((MainForm.random.Next()%2==0)?1.0:-1.0):a.values[i,j];
		}
		
		public bool IsAllDotsDead()
		{
			foreach(var d in dots)
				if(!d.dead)
					return false;
			return true;
		}
	}
}
