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
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			// TODO: �� InitComponent ���ú�����κγ�ʼ��




		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
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
