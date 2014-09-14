using System;

namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class TimeUpDown :System.Windows.Forms.UpDownBase
	{
		public System.ComponentModel.Container components = null;

		public TimeUpDown()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitComponent 调用后添加任何初始化




		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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


		}
		#endregion


		public override void UpButton()
		{}
		public override void DownButton()
		{}
		protected override void UpdateEditText()
		{}
	}
}
