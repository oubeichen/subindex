using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;



namespace Subindex
{


	/// <summary>
	/// 带下拉菜单的Button控件。
	/// </summary>

	[DefaultEvent("Click")]

	public class DropDownButton : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ToolBarButton button;
		private System.Windows.Forms.ContextMenu menu;
		private System.Windows.Forms.MenuItem subItem;
		private System.Windows.Forms.MenuItem selfItem;

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public DropDownButton()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
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
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.button = new System.Windows.Forms.ToolBarButton();
            this.menu = new System.Windows.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.button});
            this.toolBar.ButtonSize = new System.Drawing.Size(62, 23);
            this.toolBar.Divider = false;
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.DropDownArrows = true;
            this.toolBar.Location = new System.Drawing.Point(0, -2);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(120, 34);
            this.toolBar.TabIndex = 0;
            this.toolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // button
            // 
            this.button.DropDownMenu = this.menu;
            this.button.Name = "button";
            this.button.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            // 
            // menu
            // 
            this.menu.Popup += new System.EventHandler(this.menu_Popup);
            // 
            // DropDownButton
            // 
            this.Controls.Add(this.toolBar);
            this.Name = "DropDownButton";
            this.Size = new System.Drawing.Size(76, 23);
            this.Load += new System.EventHandler(this.DropDownButton_Load);
            this.Resize += new System.EventHandler(this.DropDownButton_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		private void DropDownButton_Resize(object sender, System.EventArgs e)
		{
			toolBar.ButtonSize=new Size(this.Width-15,this.Height-1);
		}


		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			this.OnClick(e);
			
		}


		//		public delegate void DropDownEventHandler(object sender,DropDownEventArgs e);
		//
		//		public event DropDownEventHandler DropDownClick;


		private void DropDownButton_Load(object sender, System.EventArgs e)
		{
			MenuItem mi;
			for (int i=0;i<menu.MenuItems.Count;i++)
			{
				mi=menu.MenuItems[i];
				mi.Click +=new EventHandler(OnDropDownClick);
			}
			MergeMenu(-1);
		}

		private MenuItem AddMenu(Menu.MenuItemCollection Parent,string Caption,EventHandler eh)
		{
			MenuItem NewItem=null;
			int i=-1;
			if (!allowRepeat)
			{
				i=Parent.Count;
				while (i-->0)
				{
					if (Parent[i].Text==Caption)
					{
						NewItem=Parent[i];
						break;
					}
				}
			}

			if (i==-1)//is allowRepeat or !allowRepeat but is new item 
			{
				NewItem=new MenuItem(Caption,eh);
				//	NewItem.Click+=eh;
				Parent.Add(NewItem);
			}
			MergeMenu(Parent.IndexOf(NewItem));
			return NewItem;
		}

		public MenuItem AddMenu(string Caption)
		{
			if (Caption==null||Caption=="") return null;
			MenuItem mi;
			if (subItem==null)
			{
				mi=AddMenu(menu.MenuItems,Caption,new EventHandler(OnDropDownClick));
				SetDefaultItem(mi,false);
			}
			else
				mi=AddMenu(subItem.MenuItems,Caption,null);
			return mi;
		}

		private void MergeMenu(int defaultID)
		{
			if (subItem==null) return;
			int id=defaultID;
			string text=null;
			bool setParent=true;
			if (selfItem!=null&&menu.MenuItems.Contains(selfItem))
			{
				setParent=selfItem.DefaultItem||defaultID>-1;
				if (defaultID==-1)
				{
					id=selfItem.MenuItems.Count;
					while (id-->0)
						if (selfItem.MenuItems[id].DefaultItem) break;
				}
				text=selfItem.Text;
				menu.MenuItems.Remove(selfItem);
			}
			selfItem=subItem.CloneMenu();
			if (text!=null) selfItem.Text=text;
			selfItem.Enabled=selfItem.MenuItems.Count>0;
			menu.MenuItems.Add(selfItem);
			for (int i=0;i<selfItem.MenuItems.Count;i++)
				selfItem.MenuItems[i].Click+=new EventHandler(OnDropDownClick);
			if (itemTrack&&id>-1)SetDefaultItem(selfItem.MenuItems[id],setParent);
		}

		private void SetDefaultItem(MenuItem Item,bool SetParent)
		{
			if (!itemTrack||Item==null)return;
			if (SetParent&&Item.Parent as MenuItem!=null)SetDefaultItem(Item.Parent as MenuItem,true);
			Menu.MenuItemCollection Parent=Item.Parent.MenuItems;
			for (int i=0;i<Parent.Count;i++)
				Parent[i].DefaultItem=false;
			Item.DefaultItem=true;
		}


		private void menu_Popup(object sender, System.EventArgs e)
		{
			MergeMenu(-1);
		}




		public class DropDownClickEventArgs : EventArgs //1.自定义事件参数
		{
			private	MenuItem item;
			public DropDownClickEventArgs(MenuItem Item)
			{item=Item;}
			public MenuItem ClickItem 
			{  get{return item;} }
		}
		public delegate void DropDownClickEventHandler(object sender, DropDownClickEventArgs e);//2.自定义参数的自定义委托

        [Description("when Menu DropDown"), Category("Action")]
		public event DropDownClickEventHandler DropDownClick;//3.自定义委托DropDownClickEventHandler类的事件实例

		protected virtual void OnDropDownClick(System.Object sender, System.EventArgs e) //4.引发事件的过程
		{
			MenuItem mi=sender as MenuItem;
			SetDefaultItem(mi,true);
			if (DropDownClick != null) DropDownClick(this, new DropDownClickEventArgs(mi));
		}


//		[Description("用户选择下拉菜单时发生"),Category("Action")]

//		public event EventHandler DropDownClick;//1.声明通用委托类型的事件实例
//		protected virtual void OnDropDownClick(System.Object sender, System.EventArgs e) //2.引发事件的过程
//		{
//			SetDefaultItem(sender as MenuItem,true);
//			if (DropDownClick != null) DropDownClick(sender, e);
//		}



		/// <summary> 
		/// 返回或设置当前对象的文本。
		/// </summary>
		/// 

		[Description("Set Control Text"),Category("Appearance")]

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get {return button.Text;}
			set {button.Text=value;	}
		}

		public new bool Enabled
		{
			get {return button.Enabled;}
			set {button.Enabled=value;	}
		}

        [Description("Set Related Menu"), Category("Data")]

		public MenuItem SubItem
		{
			get {return subItem;}
			set	{subItem=value; }
		}
		
		private bool itemTrack;

		[Description("Set Recent Item to Default")]
		public bool ItemTrack
		{
			get {return itemTrack;}
			set	{itemTrack=value;}
		}

		private bool allowRepeat;

		[Description("AllowRepeat Menu")]
		public bool AllowRepeat
		{
			get {return allowRepeat;}
			set	{allowRepeat=value;	}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

		public Menu.MenuItemCollection Items
		{
			get	
			{
				MergeMenu(-1);
				return  menu.MenuItems;
			}
		}

	}
}
