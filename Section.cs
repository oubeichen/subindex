using System;
using System.Collections;
using System.Text;
namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class Section
	{
		public Section()
		{
			// 
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public ArrayList Items=new ArrayList(); 
		public DateTime BeginTime;
		public DateTime EndTime;
		public TimeSpan TimeBaseLine;
		public string StyleFormat;

		public string this[int index]
		{
			get	{return Items[index].ToString();}
		}

		public DateTime GetBeginTime()
		{return BeginTime.Add(TimeBaseLine);}

//		protected string Text(string WrapSplit)
//		{
//			string stmp="";
//			if (WrapSplit==null) WrapSplit=Pub.Limit;
//			for (int i=1;i<Items.Count;i++)
//				stmp+=WrapSplit+Items[i].ToString();
//			return Items.Count>0?Items[0].ToString()+stmp:stmp;
//		}

		public string Text(bool AutoWrap,bool AddFormat)
		{
			StringBuilder sb=new StringBuilder();
			string WrapSplit=AutoWrap?Pub.WrapSplit:Pub.Limit;
			for (int i=1;i<Items.Count;i++)
				sb.Append(WrapSplit+Items[i].ToString());
			if (Items.Count>0) sb.Insert(0,Items[0].ToString());
			return (AddFormat&&StyleFormat!=null?StyleFormat:"") + sb.ToString();
		}



		protected string Time(int Area)
		{   DateTime bd=BeginTime;
			DateTime ed=EndTime;
			switch (Area)
			{
				case 0:
					bd=bd.Add(TimeBaseLine);
					ed=ed.Add(TimeBaseLine);
					break;
				case 1:
					bd=bd.Add(TimeBaseLine);
					break;
				case 2:
					ed=ed.Add(TimeBaseLine);
					break;
			}
			return bd.ToString(Pub.Format)+" "+Pub.SrtSymbol+" "+ed.ToString(Pub.Format);
		}

//		public string ToString(int Index,int Area,bool AutoWrap)
//		{
//			return Index.ToString()+Pub.Limit+Time(Area)+Pub.Limit+Text(AutoWrap)+Pub.Limit+Pub.Limit;
//		}



//		protected string Time()
//		{
//			return BeginTime.Add(TimeBaseLine).ToString(Pub.Format)+Pub.SrtSymbol+EndTime.Add(TimeBaseLine).ToString(Pub.Format);
//		}

		public string ToString(int Index,int Area ,bool AutoWrap)
		{
			return Index.ToString()+Pub.Limit+Time(Area)+Pub.Limit+Text(AutoWrap,Pub.KeepFormat)+Pub.Limit+Pub.Limit;
		}

		public Section Copy()
		{
			Section st=new Section();
			st.BeginTime=this.BeginTime;
			st.EndTime=this.EndTime;
			st.StyleFormat=this.StyleFormat;
			st.TimeBaseLine=this.TimeBaseLine;
			if (Pub.AutoWrap)
				st.Items.Add(this.Text(true,false));
			else
			{
				for (int i=0;i<this.Items.Count;i++)
					st.Items.Add(this.Items[i].ToString());
			}
			return st;
		}

	}
}
