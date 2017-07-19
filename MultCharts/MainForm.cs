/*
 * Created by SharpDevelop.
 * User: user
 * Date: 19.07.2017
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MultCharts
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private Thread threadCPU;
		private List<float[]> dataCPU;
		private PerformanceCounter pc;
		private CounterSample[] oldSamples;
		private CounterSample[] newSamples;
		private PerformanceCounterCategory cat;
		private string[] instances;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			pc = new PerformanceCounter("Processor Information", 
			                            "% Processor Time");
			cat = new PerformanceCounterCategory("Processor Information");
			instances = cat.GetInstanceNames();
			
			dataCPU = new List<float[]>
			{
    			new float[100],
    			new float[100]
			};			
			
			oldSamples = new CounterSample[instances.Length];
			newSamples = new CounterSample[instances.Length];
			
			for (int i = 0; i < instances.Length; i++)
			{
				pc.InstanceName = instances[i];
				oldSamples[i] = pc.NextSample();
			}
			
			threadCPU = new Thread(new ThreadStart(this.getPerfCounter));
			threadCPU.IsBackground = true;
			threadCPU.Start();			
		}
		
		private void getPerfCounter()
		{	
			int dataCPU_Last = dataCPU[0].Length - 1;			
			int instancesCount = instances.Length - 2;				
			int floatSize = sizeof(float);
			int i = 0;
			
			for(; true ;)
			{
				for (i = 0; i < instancesCount; i++)
        		{ 
					pc.InstanceName = instances[i];
					newSamples[i] = pc.NextSample();
				}
				for (i = 0; i < instancesCount; i++)
        		{ 
					dataCPU[i][dataCPU_Last] = CounterSample.Calculate(oldSamples[i], newSamples[i]);;
					Buffer.BlockCopy(dataCPU[i], 1*floatSize, dataCPU[i], 
					                 0, dataCPU_Last*floatSize);
					oldSamples[i] = newSamples[i];
        		}								
				
				if(chart_CPU.IsHandleCreated)
				{
					this.Invoke((MethodInvoker)delegate
					{
						updateChartCPU();
					});
				}
				
				Thread.Sleep(500);
			}
		}

		private void updateChartCPU()
		{
			for (int i = 0; i < chart_CPU.Series.Count; i++)
			{
				chart_CPU.Series[i].Points.DataBindY(dataCPU[i]);
			}
		}		
	}
}
