using System;

namespace Subindex
{
	public enum MergeType {ByTime,ByBlock,BySerial};


	public class CaptionMerge
	{
		public CaptionMerge()
		{
		}
		public bool isRepeatHead;
		public bool isSecondTime;
		public bool isSecondFront;


		public MergeType MergeMode;
		public TimeSpan TimeIgnore;

		private Caption cap1;
		public Caption Caption1
		{
			get{return cap1;}
			set{cap1=value;}
		}

		private Caption cap2;
		public Caption Caption2
		{
			get{return cap2;}
			set{cap2=value;}
		}


		public void Switch()
		{
			Caption capTemp=cap1;
			cap1=cap2;
			cap2=capTemp;
		}

		public override string ToString()
		{
			string result="";
			if (cap1!=null&&cap2!=null)
			{
				switch (MergeMode)
				{
					case MergeType.ByTime: 
						result=TimeMerge();
						break;
					case MergeType.ByBlock:
						result=BlockMerge();
						break;
					case MergeType.BySerial:
						result=SerialMerge();
						break;
				}
			}
			return result;//isSerialMerge?SerialMerge(isByBlock):CompoMerge(isByBlock);
		}

		
		private string SerialMerge()
		{
			return cap1.ToString() + cap2.ToString(cap1.Count,cap1.GetTimeLenth());
		}

		private string TimeMerge()
		{
			Caption ct=new Caption();
			ct.AutoWrap=false;
			int index1,index2;
			int lockType;//0 no, 1 cap1, 2 cap2
			lockType=index1=index2=0;
			DateTime capTime1=new DateTime(),capTime2=new DateTime();

			while (index1<cap1.Count||index2<cap2.Count)
			{

				Section st=new Section();
				if (lockType!=1&&index1<cap1.Count) capTime1=cap1[index1].GetBeginTime();
				if (lockType!=2&&index2<cap2.Count) capTime2=cap2[index2].GetBeginTime();
				lockType=0;
				if (capTime1>capTime2&&capTime1>capTime2.Add(TimeIgnore)&&index2<cap2.Count||index1==cap1.Count) lockType=1;
				if (capTime2>capTime1&&capTime2>capTime1.Add(TimeIgnore)&&index1<cap1.Count||index2==cap2.Count) lockType=2;
				

				if (lockType!=1)
				{

					st=cap1[index1++].Copy();
					if (this.isRepeatHead||lockType==2) ct.Add(st);
				}

				if (lockType!=2)
				{
					addText(ref st,cap2[index2]);
					ct.Add(st);
					index2++;
				}

			}

			return ct.ToString();
		}

		private void addText(ref Section st,Section sec)
		{
			if (this.isRepeatHead||st.Items.Count==0) 
				st=sec.Copy();
			else
			{
				if (isSecondTime) 
				{
					st.BeginTime=sec.BeginTime;
					st.EndTime=sec.EndTime;
					st.TimeBaseLine=sec.TimeBaseLine;
				}
				if (isSecondFront)
				{
					if (Pub.AutoWrap) 
						st.Items.Insert(0,sec.Text(true,false));
					else
						st.Items.InsertRange(0,sec.Items);
				}
				else
				{
					if (Pub.AutoWrap)
                        st.Items.Add(sec.Text(true,false));
					else
						st.Items.AddRange(sec.Items);
				}
				
			}
		}

		private string BlockMerge()
		{
			Caption ct=new Caption();
			ct.AutoWrap=false;
			int max=cap1.Count>cap2.Count?cap1.Count:cap2.Count;
			for (int i=0;i<max;i++)
			{
				Section st=new Section();
				if (i<cap1.Count)
				{
					st=cap1[i].Copy();
					if (this.isRepeatHead||i>=cap2.Count) ct.Add(st);
				}

				if (i<cap2.Count)
				{
					addText(ref st,cap2[i]);
					ct.Add(st);
				}
			}

			return ct.ToString();
		}


	}
}
