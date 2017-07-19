/*
 * Created by SharpDevelop.
 * User: user
 * Date: 19.07.2017
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MultCharts
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart_CPU;
		
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart_CPU = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart_CPU)).BeginInit();
			this.SuspendLayout();
			// 
			// chart_CPU
			// 
			chartArea1.Name = "ChartArea1";
			chartArea2.Name = "ChartArea2";
			this.chart_CPU.ChartAreas.Add(chartArea1);
			this.chart_CPU.ChartAreas.Add(chartArea2);
			this.chart_CPU.Location = new System.Drawing.Point(12, 12);
			this.chart_CPU.Name = "chart_CPU";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea2";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series2.Name = "Series2";
			this.chart_CPU.Series.Add(series1);
			this.chart_CPU.Series.Add(series2);
			this.chart_CPU.Size = new System.Drawing.Size(567, 318);
			this.chart_CPU.TabIndex = 0;
			this.chart_CPU.Text = "chart_CPU";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 342);
			this.Controls.Add(this.chart_CPU);
			this.Name = "MainForm";
			this.Text = "MultCharts";
			((System.ComponentModel.ISupportInitialize)(this.chart_CPU)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
