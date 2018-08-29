using System;
using System.Drawing;

namespace AI_v3
{
	
	public class Array
	{
		public int Count;
		Rectangle[] r;
		
		public Array()
		{
			Count = 0;
			r = new Rectangle[0];
		}
		
		public Rectangle[] GetValues()
		{
			return this.r;
		}
		
		public Rectangle At(int index)
		{
			return r[index];
		}
		
		public void SetXAt(int index, int x)
		{
			r[index].X = x;
		}
		public void UpdateXAt(int index, int x)
		{
			r[index].X += x;
		}
		public void SetYAt(int index, int y)
		{
			r[index].Y = y;
		}
		public void UpdateYAt(int index, int y)
		{
			r[index].Y += y;
		}
		
		public void Add(Rectangle rect)
		{
			Count++;
			var temp = (Rectangle[])r.Clone();
			r = new Rectangle[Count];
			for(int i=0; i<temp.Length; i++)
				r[i] = temp[i];
			r[Count-1] = rect;
		}
		
		public void RemoveFirst()
		{
			Count--;
			var temp = (Rectangle[])r.Clone();
			r = new Rectangle[Count];
			for(int i=0; i<temp.Length-1; i++)
				r[i] = temp[i+1];
		}
		
		
	}
}
