using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Subindex
{
	/// <summary>
	/// TimeBaseLine 的摘要说明。
	/// </summary>
	/// 	
	[DefaultEvent("ValueChanged")]
	public class TimeBaseLine : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox valueBox;
		private System.Windows.Forms.VScrollBar upDown;

		private readonly int[,] point =new  int[,] {{1,1}, {3,2}, {6,2}, {9,2}, {12,3},{12,3}};
		private DateTime timeValue=DateTime.Parse("00:00:00.000");
		private bool Symbol=true;
		private bool inputState;

		/// <summary>
		/// 数据值已改变
		/// </summary>
		public event EventHandler ValueChanged;

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TimeBaseLine()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			valueBox.SelectionStart=15;
			// TODO: 在 InitializeComponent 调用后添加任何初始化

		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.valueBox = new System.Windows.Forms.TextBox();
			this.upDown = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// valueBox
			// 
			this.valueBox.Location = new System.Drawing.Point(1, 2);
			this.valueBox.Name = "valueBox";
			this.valueBox.Size = new System.Drawing.Size(112, 21);
			this.valueBox.TabIndex = 0;
			this.valueBox.Text = " + 00:00:00,000";
			this.valueBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valueBox_KeyDown);
			this.valueBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.valueBox_MouseDown);
			this.valueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueBox_KeyPress);
			this.valueBox.DoubleClick += new System.EventHandler(this.valueBox_DoubleClick);
			this.valueBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.valueBox_MouseMove);
			// 
			// upDown
			// 
			this.upDown.LargeChange = 1;
			this.upDown.Location = new System.Drawing.Point(96, 3);
			this.upDown.Maximum = 1;
			this.upDown.Name = "upDown";
			this.upDown.Size = new System.Drawing.Size(16, 19);
			this.upDown.TabIndex = 0;
			this.upDown.Scroll += new System.Windows.Forms.ScrollEventHandler(this.upDown_Scroll);
			// 
			// TimeBaseLine
			// 
			this.Controls.Add(this.upDown);
			this.Controls.Add(this.valueBox);
			this.Name = "TimeBaseLine";
			this.Size = new System.Drawing.Size(113, 24);
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary> 
		/// 设置或返回时间基线值
		/// </summary>
		public TimeSpan Value
		{
			get
			{
				TimeSpan ts=new TimeSpan(0,timeValue.Hour,timeValue.Minute,timeValue.Second,timeValue.Millisecond);
				return Symbol?ts:-ts;
			}
			set
			{
				Symbol=value>=TimeSpan.Zero;
				ValueChange(DateTime.Parse(value.ToString()));
			}

		}




		private void valueBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{

			

			string filter=valueBox.SelectionStart<3?"+-":"0123456789";

			if (filter.IndexOf(e.KeyChar)>-1)
			{

				switch(valueBox.SelectionStart/3)
				{
					case 0:
						if (Symbol!=(e.KeyChar=='+')) SymbolChange();
						break;
					case 1:
						if (inputState)
						{
							filter=timeValue.Hour.ToString()+e.KeyChar;
							filter=filter.Substring(filter.Length-2);
							if (int.Parse(filter)>23) filter=e.KeyChar.ToString();
						}
						else 
							filter=e.KeyChar.ToString();

						inputState=int.Parse(filter)<10;
						filter+=":"+timeValue.Minute.ToString()+":"+timeValue.Second.ToString()+"."+timeValue.Millisecond.ToString();
						ValueChange(DateTime.Parse(filter));
						break;
					case 2:

						if (inputState)
						{
							filter=timeValue.Minute.ToString()+e.KeyChar;
							filter=filter.Substring(filter.Length-2);
							if (int.Parse(filter)>59) filter=e.KeyChar.ToString();
						}
						else 
							filter=e.KeyChar.ToString();

						inputState=int.Parse(filter)<10;
						filter=timeValue.Hour.ToString()+":"+ filter +":"+timeValue.Second.ToString()+"."+timeValue.Millisecond.ToString();
						ValueChange(DateTime.Parse(filter));
						break;
					case 3:
						if (inputState)
						{
							filter=timeValue.Second.ToString()+e.KeyChar;
							filter=filter.Substring(filter.Length-2);
							if (int.Parse(filter)>59) filter=e.KeyChar.ToString();
						}
						else 
							filter=e.KeyChar.ToString();

						inputState=int.Parse(filter)<10;
						filter=timeValue.Hour.ToString()+":"+ timeValue.Minute.ToString() +":"+ filter +"."+timeValue.Millisecond.ToString();
						ValueChange(DateTime.Parse(filter));
						break;
					case 4:
						if (inputState)
						{
							filter="0"+(timeValue.Millisecond).ToString()+e.KeyChar;
							filter=filter.Substring(filter.Length-3);
						}
						else 
							filter="00"+e.KeyChar.ToString();

						inputState=int.Parse(filter)<100;
						filter=timeValue.Hour.ToString()+":"+ timeValue.Minute.ToString() +":"+ timeValue.Second.ToString() +"."+ filter;
						ValueChange(DateTime.Parse(filter));
						break;
				}
			}

			e.Handled=true;

		}



		private void valueBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			

			int selPos=valueBox.SelectionStart/3;
			switch (e.KeyCode)
			{
				case Keys.Left:
					selPos=selPos>0?selPos-1:4;
					goto case Keys.Space;
				case Keys.Right:
					selPos=selPos<4?selPos+1:0;
					goto case Keys.Space;
				case Keys.Up:
					UpDown(true);
					goto case Keys.Space;
				case Keys.Down:
					UpDown(false);
					goto case Keys.Space;
				case Keys.Space:
					IndexChange(selPos);
					inputState=false;
					break;

			}
			e.Handled=true;

		}

		private void UpDown(bool isUp)
		{
			switch (valueBox.SelectionStart/3)
			{
				case 0:
					SymbolChange();
					break;
				case 1:
					ValueChange(timeValue.AddHours(isUp?1:-1));
					break;
				case 2:
					ValueChange(timeValue.AddMinutes(isUp?1:-1));
					break;
				case 3:
					ValueChange(timeValue.AddSeconds(isUp?1:-1));
					break;
				case 4:
					ValueChange(timeValue.AddMilliseconds(isUp?1:-1));
					break;
			}

		}

		
		
		private void ValueChange(DateTime newValue)
		{
			timeValue=newValue;
			Repaint();
		}
		private void SymbolChange()
		{
			Symbol=!Symbol;
			Repaint();
		}

		private void Repaint()
		{
			int i=valueBox.SelectionStart/3;
			valueBox.Text=(Symbol?" + ":" - ") + timeValue.ToString(Pub.Format);
			IndexChange(i);
			if (ValueChanged!=null) ValueChanged(this,null);
		}

		private void IndexChange(int selectIndex)
		{
			valueBox.Select(point[selectIndex,0],point[selectIndex,1]);
		}


		private void upDown_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			if (e.Type==ScrollEventType.SmallDecrement||e.Type==ScrollEventType.SmallIncrement)
				UpDown(e.NewValue==0);
		}

		private void valueBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			

			IndexChange(valueBox.SelectionStart/3);
			inputState=false;
		}

		private void valueBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			

			IndexChange(valueBox.SelectionStart/3);
		}

		private void valueBox_DoubleClick(object sender, System.EventArgs e)
		{
			

			SymbolChange();
		}

	}
}
