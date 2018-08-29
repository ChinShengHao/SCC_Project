using System;
using System.Collections;
using System.Drawing;

namespace AI_v3
{
	public class Field
	{
		private const int Count = 40;
		
		private int count = 0;
		private int obstacleMovespeed = 10;
		public Dino dino;
		
		public Array obstacles;
		
		public Field()
		{
			dino = new Dino();
			
			obstacles = new Array();
		}
		
		
		public void MoveFrame()
		{
			count++;
			
			//if( !dino.dead )
			//{
				if( this.dino.jumping )
					this.dino.Jumping();
				else
				{
					this.dino.Walking();
				}
				
				if( count >= Count )
				{
					count = 0;
					Spawn();
				}
				
				for(int i=0; i<obstacles.Count; i++)
				{
					obstacles.UpdateXAt(i, -obstacleMovespeed);
				}
				
				if( obstacles.Count > 0 )
				{
					if( obstacles.At(0).X < -obstacles.At(0).Width )
						obstacles.RemoveFirst();
				
					if( IsDinoCollideWith(obstacles.At(0)) )
						dino.dead = true;
				}
			//}
				
		}
		
		public bool IsDinoCollideWith(Rectangle r)
		{
			return r.IntersectsWith(new Rectangle((int)dino.x, (int)dino.y, dino.width, dino.height));
		}
		
		public void Spawn()
		{
			var r = new Rectangle(690, 186, 40, 70);
			obstacles.Add(r);
		}
		
	}
}
