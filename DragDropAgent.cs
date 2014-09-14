using System;
using System.Windows.Forms;
namespace Subindex
{
	/// <summary>
	///
	/// </summary>
	public  class DragDropAgent//4 groupBox control in runtime dragDrop support, Written By Linnet 2006-4-6 
	{
		private DragDropAgent()
		{
			// 
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// �õ�һ�������ײ㸸�ؼ��Ŀؼ��Ķ�����,��form1��groupbox1�е�textbox1,������form1.textbox1
		/// </summary>
		/// <param name="sender">Ҫ��ö������Ŀؼ�ʵ��</param>
		/// <returns></returns>
		public static string getFullName(Control sender)
		{
			string name=sender.Name;
			while (sender.Parent!=null)
				sender=sender.Parent;
			return sender.Name+"."+name;
		}

		/// <summary>
		/// ����ָ��GroupBox�ؼ����ϷŲ���,����CanDrag��CanDrop�����ϳ�/�����֧��
		/// </summary>
		/// <param name="sender">Ҫ�����Ϸ����Ե�GroupBox����</param>
		/// <param name="CanDrag">�Ƿ�����ϳ�</param>
		/// <param name="CanDrop">�Ƿ���Է���</param>
		public static void DragDropHook(GroupBox sender,bool CanDrag,bool CanDrop)
		{
			if (CanDrag) DragHook(sender);
			if (CanDrop) DropHook(sender);	
			gutPosition(sender);
		}

		/// <summary>
		/// ����ָ��GroupBox�ؼ����ϷŲ���,ͬʱ֧���ϳ��ͷ���
		/// </summary>
		/// <param name="sender">Ҫ�����Ϸ����Ե�GroupBox����</param>
		public static void DragDropHook(GroupBox sender)
		{
			DragDropHook(sender,true,true);
		}

		private static void DragHook(GroupBox sender)
		{
			sender.MouseDown+=new MouseEventHandler(Do_Drag);
		}

		private static void DropHook(GroupBox sender)
		{
			
			sender.AllowDrop=true;
			sender.DragDrop+=new DragEventHandler(Drag_Drop);
			sender.DragEnter+=new DragEventHandler(Drag_Enter);
		}


		private static void Drag_Enter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(new GroupBox().GetType()))
				e.Effect = DragDropEffects.Move ;
		}

		private  static void Do_Drag(object sender, MouseEventArgs e)
		{
			(sender as Control) .DoDragDrop(sender, DragDropEffects.Move);

		}

		private static void Drag_Drop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			try
			{

				GroupBox self=sender as GroupBox;

				GroupBox ct= e.Data.GetData(self.GetType()) as GroupBox;

				if (self==ct) return;

				Control parent=self.Parent;

				int ord=parent.Controls.GetChildIndex(self);

				int ordself=self.Top>ct.Top?ord+1:ord-1;

				DockStyle dss=self.Dock;
				self.Dock=ct.Dock;;
				ct.Dock=dss;
				//				System.Drawing.Point dps=self.Location;
				//				self.Location=ct.Location;
				//				ct.Location=dps;

				if (ordself>ord)
				{
					setPosition(self,ordself);
					setPosition(ct,ord);
				}
				else
				{
					setPosition(ct,ord);
					setPosition(self,ordself);
				}

			}
			catch (Exception ee)
			{
				System.Windows.Forms.MessageBox.Show(ee.Message,"Error");

			}
		}

		private static void gutPosition(GroupBox sender)
		{

			string order=AppSettings.ReadSetting(getFullName(sender)+":Order");
			string dock=AppSettings.ReadSetting(getFullName(sender)+":Dock");
			try
			{
				int Position=int.Parse(order);
				sender.Parent.Controls.SetChildIndex(sender,Position);
				Position=int.Parse(dock);
				sender.Dock=(DockStyle)Position;
			}
			catch
			{

			}
		}

		private static void setPosition(GroupBox sender,int Position)
		{
			sender.Parent.Controls.SetChildIndex(sender,Position);

			AppSettings.WriteSetting(getFullName(sender)+":Order",Position.ToString());
			AppSettings.WriteSetting(getFullName(sender)+":Dock",((int)sender.Dock).ToString());


		}




	}
}
