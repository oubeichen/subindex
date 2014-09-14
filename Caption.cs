using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class Caption
	{

		protected ArrayList list=new ArrayList(); 
		private TimeSpan timeBaseLine=new TimeSpan(0);


		private bool autoWrap=Pub.AutoWrap;
		public bool AutoWrap
		{
			get {return autoWrap;}
			set {autoWrap=value;}
		}

		private bool keepIndex;
		public bool KeepIndex
		{
			get {return keepIndex;}
			set {keepIndex=value;}
		}

		private int putValue(int Value)
		{
			Value=Value-Pub.BeginIndex;
			if (Value<0) Value=0;
			else if (Value>this.Count) Value=this.Count;
			return Value;
			//return (Value<Pub.BeginIndex?Pub.BeginIndex:Value)-Pub.BeginIndex;
		}
		private int buildFirstIndex;
		public int BuildFirstIndex
		{
			get	{return buildFirstIndex+Pub.BeginIndex;}
			set	{buildFirstIndex=putValue(value);}
		}

		//private int bLastIndex=-1;
		private int buildLastIndex;
//		{
//			get
//			{
//				if (bLastIndex==-1) bLastIndex=list.Count-1;
//				return bLastIndex;
//			}
//			set {bLastIndex=value;}
//		}

		public int BuildLastIndex
		{
			get	{return buildLastIndex+Pub.BeginIndex;}
			set	{buildLastIndex=putValue(value);}
		}

		private int adjustFirstIndex;
		public int AdjustFirstIndex
		{
			get	{return adjustFirstIndex+Pub.BeginIndex;}
			set	
			{
				adjustFirstIndex=putValue(value);
				TimeBaseLine=timeBaseLine;
			}
		}

		private int adjustLastIndex=-1;
		public int AdjustLastIndex
		{
			get	
			{
		//		if (adjustLastIndex==-1) adjustLastIndex=list.Count-1;
				return adjustLastIndex+Pub.BeginIndex;
			}
			set	
			{
				adjustLastIndex=putValue(value);
				TimeBaseLine=timeBaseLine;
			}
		}

		private int adjustArea=0;
		public int AdjustArea
		{
			get	{return adjustArea;}
			set	{adjustArea=value;}
		}

		public Caption()
		{	}


		public TimeSpan TimeBaseLine
		{
			get {return timeBaseLine;}
			set
			{
				timeBaseLine=value;
				for (int i=buildFirstIndex;i<list.Count&&i<buildLastIndex+1;i++)
				{
					if (i>=adjustFirstIndex&&i<=adjustLastIndex)
						(list[i] as Section).TimeBaseLine=timeBaseLine;
				}
					//(list[i] as Section).TimeBaseLine=(i<adjustFirstIndex||i>adjustLastIndex)?new TimeSpan(0):timeBaseLine;
			}
		}

		public void AdjustReset()
		{
			for (int i=0;i<list.Count;i++)
				(list[i] as Section).TimeBaseLine=new TimeSpan(0);
			timeBaseLine=new TimeSpan(0);
			adjustFirstIndex=0;
			adjustLastIndex=list.Count-1;
		}

		public TimeSpan GetTimeLenth()
		{
			TimeSpan ts=new TimeSpan(0);
			if (list.Count>0)
			{
				DateTime dt=(list[list.Count-1] as Section).EndTime;
				ts=new TimeSpan(0,dt.Hour,dt.Minute,dt.Second,dt.Millisecond);
			}
			return ts;
		}

		public void Add(Section Section)
		{
			list.Add(Section);
			adjustLastIndex=buildLastIndex=list.Count-1;
		}

		public void Remove(int index)
		{
			list.RemoveAt(index);
			adjustLastIndex=buildLastIndex=list.Count-1;
		}

		public int Count
		{
			get
			{
				return list.Count; 
			}
		}

		public Section this[int index]
		{
			get
			{
				return (Section) list[index];
			}

		}

		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();
			int c=buildLastIndex+1;
			if (list.Count<c) c=list.Count;
			int baseIndex=keepIndex?Pub.BeginIndex:Pub.BeginIndex-buildFirstIndex;
			for (int i=buildFirstIndex;i<c;i++)
				sb.Append((list[i] as Section).ToString(i+baseIndex,adjustArea,autoWrap));
			return sb.ToString();

		}

		public string ToString(int baseIndex,TimeSpan timeAdjust)
		{
			StringBuilder sb=new StringBuilder();
			int c=buildLastIndex+1;
			if (list.Count<c) c=list.Count;
			baseIndex+=Pub.BeginIndex;
			TimeBaseLine+=timeAdjust;
			for (int i=buildFirstIndex;i<c;i++)
				sb.Append((list[i] as Section).ToString(i+baseIndex,adjustArea,autoWrap));
			TimeBaseLine-=timeAdjust;
			return sb.ToString();

		}

		public Caption Clone(bool isFix)
		{
			Caption ct=(Caption)this.MemberwiseClone();
			if (isFix) ct.Fix();
			return ct;
		}


		public void Fix()
		{
			ArrayList newlist=new ArrayList();
			//Section sec;
			for (int i=buildFirstIndex;i<=buildLastIndex;i++)
			{
				//sec=((Section)list[i]);
				
//				switch (adjustArea)
//				{
//					case 0:
//						sec.BeginTime=sec.BeginTime.Add(sec.TimeBaseLine);
//						sec.EndTime=sec.EndTime.Add(sec.TimeBaseLine);
//						break;
//					case 1:
//						sec.BeginTime=sec.BeginTime.Add(sec.TimeBaseLine);
//						break;
//					case 2:
//						sec.EndTime=sec.EndTime.Add(sec.TimeBaseLine);
//						break;
//				}
//				sec.TimeBaseLine=new TimeSpan(0);

				newlist.Add(list[i]);
			}
			//timeBaseLine=new TimeSpan(0);
			list=newlist;
			adjustFirstIndex=buildFirstIndex=0;
			adjustLastIndex=buildLastIndex=list.Count-1;





		}



	}
}
