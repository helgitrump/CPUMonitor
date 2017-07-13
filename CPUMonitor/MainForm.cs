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
		private double[] dataCPU;
		private PerformanceCounter pc;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			dataCPU = new double[60];
			updateChartCPU();
			pc = new PerformanceCounter("Processor Information",
			                            "% Processor Time", 
			                            "_Total");			
		}
		
		private void getPerfCounter()
		{						
			for(; true ;)
			{
				dataCPU[dataCPU.Length - 1] = Math.Round(pc.NextValue(), 0);
				Array.Copy(dataCPU, 1, dataCPU, 0, dataCPU.Length - 1);
				
				if(chartCPU.IsHandleCreated)
				{
					this.Invoke((MethodInvoker)delegate
					{
						updateChartCPU();
					});
				}
				
				Thread.Sleep(1000);
			}
		}
		
		private void updateChartCPU()
		{
			chartCPU.Series["CPU"].Points.Clear();
			chartCPU.Series["CPU"].Points.DataBindY(dataCPU);
		}
		
		private void Btn_StartAcquireClick(object sender, EventArgs e)
		{
			threadCPU = new Thread(new ThreadStart(this.getPerfCounter));
			threadCPU.IsBackground = true;
			threadCPU.Start();			
		}
	}
}
