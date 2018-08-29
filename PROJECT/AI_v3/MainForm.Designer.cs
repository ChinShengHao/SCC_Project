using System.Windows.Forms;

namespace AI_v3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label label_generationCount;
		private System.Windows.Forms.Label textLabel_generation;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button jumpbutton;
		private System.Windows.Forms.Button duckbutton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label_generationCount = new System.Windows.Forms.Label();
			this.textLabel_generation = new System.Windows.Forms.Label();
			this.startButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.stopButton = new System.Windows.Forms.Button();
			this.jumpbutton = new System.Windows.Forms.Button();
			this.duckbutton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label_generationCount);
			this.panel1.Controls.Add(this.textLabel_generation);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(686, 289);
			this.panel1.TabIndex = 0;
			this.panel1.KeyPress += new KeyPressEventHandler(Panel1KeyPress);
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			// 
			// label_generationCount
			// 
			this.label_generationCount.Location = new System.Drawing.Point(62, 5);
			this.label_generationCount.Name = "label_generationCount";
			this.label_generationCount.Size = new System.Drawing.Size(50, 16);
			this.label_generationCount.TabIndex = 1;
			this.label_generationCount.Text = "0";
			// 
			// textLabel_generation
			// 
			this.textLabel_generation.Location = new System.Drawing.Point(4, 4);
			this.textLabel_generation.Name = "textLabel_generation";
			this.textLabel_generation.Size = new System.Drawing.Size(62, 16);
			this.textLabel_generation.TabIndex = 0;
			this.textLabel_generation.Text = "Generation";
			// 
			// startButton
			// 
			this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startButton.Location = new System.Drawing.Point(13, 309);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(122, 48);
			this.startButton.TabIndex = 1;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.StartButtonClick);
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// stopButton
			// 
			this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stopButton.Location = new System.Drawing.Point(141, 309);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(122, 48);
			this.stopButton.TabIndex = 2;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
			// 
			// jumpbutton
			// 
			this.jumpbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.jumpbutton.Location = new System.Drawing.Point(269, 309);
			this.jumpbutton.Name = "jumpbutton";
			this.jumpbutton.Size = new System.Drawing.Size(122, 48);
			this.jumpbutton.TabIndex = 3;
			this.jumpbutton.Text = "Jump";
			this.jumpbutton.UseVisualStyleBackColor = true;
			this.jumpbutton.Click += new System.EventHandler(this.JumpbuttonClick);
			// 
			// duckbutton
			// 
			this.duckbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.duckbutton.Location = new System.Drawing.Point(397, 308);
			this.duckbutton.Name = "duckbutton";
			this.duckbutton.Size = new System.Drawing.Size(122, 48);
			this.duckbutton.TabIndex = 4;
			this.duckbutton.Text = "Duck";
			this.duckbutton.UseVisualStyleBackColor = true;
			this.duckbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DuckbuttonMouseDown);
			this.duckbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DuckbuttonMouseUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 369);
			this.Controls.Add(this.duckbutton);
			this.Controls.Add(this.jumpbutton);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "AI_v3";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
