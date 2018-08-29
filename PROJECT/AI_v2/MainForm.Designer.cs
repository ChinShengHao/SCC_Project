/*
 * Created by SharpDevelop.
 * User: LENOVO
 * Date: 5/24/2018
 * Time: 10:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AI_v2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.ListBox resultListBox;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Timer timer;
		
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
			this.startButton = new System.Windows.Forms.Button();
			this.resultListBox = new System.Windows.Forms.ListBox();
			this.panel = new System.Windows.Forms.Panel();
			this.stopButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startButton.Location = new System.Drawing.Point(380, 13);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(101, 60);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.StartButtonClick);
			// 
			// resultListBox
			// 
			this.resultListBox.FormattingEnabled = true;
			this.resultListBox.Location = new System.Drawing.Point(380, 79);
			this.resultListBox.Name = "resultListBox";
			this.resultListBox.Size = new System.Drawing.Size(313, 251);
			this.resultListBox.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.LightGray;
			this.panel.Location = new System.Drawing.Point(13, 13);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(360, 320);
			this.panel.TabIndex = 2;
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPaint);
			// 
			// stopButton
			// 
			this.stopButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stopButton.Location = new System.Drawing.Point(487, 13);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(101, 60);
			this.stopButton.TabIndex = 3;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
			// 
			// saveButton
			// 
			this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.Location = new System.Drawing.Point(594, 13);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(100, 60);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// timer
			// 
			this.timer.Interval = 50;
			this.timer.Tick += new System.EventHandler(this.TimerTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 347);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.resultListBox);
			this.Controls.Add(this.startButton);
			this.Name = "MainForm";
			this.Text = "AI_v2";
			this.ResumeLayout(false);

		}
	}
}
