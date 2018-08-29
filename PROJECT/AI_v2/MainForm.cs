using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AI_v2
{
	public partial class MainForm : Form
	{
		public static Random random = new Random();
		
		private Brush redbrush;
		private Brush yellowbrush;
		private Brush bluebrush;
		static public Rectangle goal;
		static public Rectangle[] obstacles;
		static public Rectangle[] eliminateRegions;
		
		private Population population;
		public const int maxStep = 100;
		public const int initialPosX = 180, initialPosY = 310;
		
		public MainForm()
		{
			InitializeComponent();
			InitializeShapes();
		}
		
		public void InitializeShapes()
		{
			population = new Population();
			
			redbrush = new SolidBrush(Color.Red);
			bluebrush = new SolidBrush(Color.Blue);
			yellowbrush = new SolidBrush(Color.Yellow);
			
			goal = new Rectangle(0, 100, 15, 15);
			obstacles = new Rectangle[1];
			obstacles[0] = new Rectangle(0, 120, 300, 10);
			eliminateRegions = new Rectangle[1];
			eliminateRegions[0] = new Rectangle(0, 120, 300, 320-120);
			//eliminateRegions[1] = new Rectangle(0, 320, 360, 160);
		}
		
		void PanelPaint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			foreach(var o in eliminateRegions)
				g.FillRectangle(yellowbrush, o);
			foreach(var o in obstacles)
				g.FillRectangle(bluebrush, o);
			g.FillRectangle(redbrush, goal);
			foreach(var d in population.dots)
				g.FillEllipse(new SolidBrush(d.color), (float)d.x, (float)d.y, d.size, d.size );
		}
		void TimerTick(object sender, EventArgs e)
		{
			//move dots
			foreach(var d in population.dots)
			{
				d.Move();
			}
			this.panel.Refresh();
			
			if( population.IsAllDotsDead() )
			{
				this.timer.Enabled = false;
				
				this.resultListBox.Items.Add("Generation : " + population.generation + " Best Score: " + population.GetBestDot().score );
				
				//eliminateRegions[0].X -= 1;
				//eliminateRegions[0].Width += 1;
				//eliminateRegions[1].Y -= 1;
				//eliminateRegions[1].Height += 1;
					
				population.NaturalSelection();
				
				this.timer.Enabled = true;
			}
		}
		void StartButtonClick(object sender, EventArgs e)
		{
			this.timer.Enabled = true;
		}
		void StopButtonClick(object sender, EventArgs e)
		{
			this.timer.Enabled = false;
		}
	}
}
