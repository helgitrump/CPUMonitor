/*
 * Created by SharpDevelop.
 * User: user
 * Date: 12.07.2017
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading;

namespace CPUMonitor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private Thread threadCPU;
		private float[] dataCPU;
		private PerformanceCounter pc;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
								
			pc = new PerformanceCounter("Processor Information",
			                            "% Processor Time", 
			                            "_Total");
			dataCPU = new float[100];
			addChartCPUSeries();
			updateChartCPU();
		}
		
		private void addChartCPUSeries()
		{			
			int index = chartCPU.Series.Count;
			chartCPU.Series.Add(index.ToString());
			chartCPU.Series[index].ChartType = SeriesChartType.FastLine;
			chartCPU.ChartAreas[index].AxisX.Interval = 10;
			chartCPU.ChartAreas[index].AxisX.LabelStyle.Enabled = false;
			chartCPU.ChartAreas[index].AxisX.MajorTickMark.Enabled = false;
			chartCPU.ChartAreas[index].AxisY.Interval = 10;
			chartCPU.ChartAreas[index].AxisY.Maximum = 100;
			chartCPU.ChartAreas[index].AxisY.LabelStyle.Enabled = false;
			chartCPU.ChartAreas[index].AxisY.MajorTickMark.Enabled = false;			
		}
		
		private void getPerfCounter()
		{		
			for(; true ;)
			{
				dataCPU[dataCPU.Length - 1] = pc.NextValue();
				Array.Copy(dataCPU, 1, dataCPU, 0, dataCPU.Length - 1);
				
				if(chartCPU.IsHandleCreated)
				{
					this.Invoke((MethodInvoker)delegate
					{
						updateChartCPU();
					});
				}
				
				Thread.Sleep(100);
			}
		}
		
		private void updateChartCPU()
		{
			chartCPU.Series[chartCPU.Series.Count - 1].Points.DataBindY(dataCPU);
		}
		
		private void Btn_StartAcquireClick(object sender, EventArgs e)
		{
			threadCPU = new Thread(new ThreadStart(this.getPerfCounter));
			threadCPU.IsBackground = true;
			threadCPU.Start();			
		}
	}
}
