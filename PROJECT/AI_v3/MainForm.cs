using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AI_v3
{
	
	public partial class MainForm : Form
	{
		private Pen blackPen;
		private Field field;
		
		public MainForm()
		{
			InitializeComponent();
			InitializeObjects();
		}
		public void InitializeObjects()
		{
			blackPen = new Pen(Color.Black);
			field = new Field();
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			
			//draw dino
			g.DrawRectangle(blackPen, (int)field.dino.x, (int)field.dino.y, field.dino.width, field.dino.height);
			
			//draw obstacles
			foreach(Rectangle r in field.obstacles.GetValues())
				g.DrawRectangle(blackPen, r.X, r.Y, r.Width, r.Height);
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			field.MoveFrame();
			
			panel1.Refresh();
		}
		void Panel1KeyPress(object sender, KeyPressEventArgs e)
		{
			MessageBox.Show(e.KeyChar.ToString());
		}
		
		void StartButtonClick(object sender, EventArgs e)
		{
			this.timer1.Enabled = true;
		}
		void StopButtonClick(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
		}
		void JumpbuttonClick(object sender, EventArgs e)
		{
			this.field.dino.jumping = true;
		}
		void DuckbuttonMouseDown(object sender, MouseEventArgs e)
		{
			field.dino.Duck();
		}
		void DuckbuttonMouseUp(object sender, MouseEventArgs e)
		{
			field.dino.Unduck();
		}
		
		
	}
}
