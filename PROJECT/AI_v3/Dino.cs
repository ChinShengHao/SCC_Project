using System;

namespace AI_v3
{

	public class Dino
	{
		public const int initX = 10, initY = 180;
		public const int initWidth = 40, initHeight = 76;
		public const double jumpSpeed = 0.1;
		
		public int width, height;
		public double x, y;
		
		public double jump_counter;//lower value mean jump slower
		public int walk_counter;
		
		public bool duck, jumping, dead;
		
		public NN brain;
		
		public Dino()
		{
			x = initX;
			y = initY;
			width = initWidth;
			height = initHeight;
			duck = false;
			jumping = false;
			dead = false;
			jump_counter = 0;
			walk_counter = 0;
			brain = new NN();
		}
		
		public void Duck()
		{
			this.duck = true;
			y = initY + initHeight/2;
			height = initHeight/2;
		}
		public void Unduck()
		{
			this.duck = false;
			y = initY;
			height = initHeight;
		}
		
		public void Walking()
		{
			walk_counter = 1 - walk_counter;
		}
		
		public void Jumping()
		{
			double a = 1.5;//jump height
			jump_counter += jumpSpeed;
			
			this.y = initY + ( a*jump_counter*jump_counter - 2*a*jump_counter) * height;
			
			if(jump_counter > 2.0)
			{
				jump_counter = 0;
				jumping = false;
			}
		}
	}
}
