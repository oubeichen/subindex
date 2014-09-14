using System;

namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class CaptionParser
	{
		private CaptionParser()
		{

		}


		public static Caption Parse(string FileName)
		{  
			return Parse(Pub.ReadFile(FileName));
		}
		


		public static Caption Parse(string[] Buffer)
		{  

			int i=0;
			int cnt=10<Buffer.Length?10:Buffer.Length;
			for (;i<cnt;i++)
				if (Buffer[i].IndexOf(Pub.SrtSymbol)>-1) break;
			Caption ct=i<10?ParseSrt(Buffer):ParseSsa(Buffer);
			if (ct.Count==0) 
			{
				ct=null;
				throw new ExtendException(0);
			//	MessageBox.Show(Pub.GetSetting("CaptionParseExceptionText"),Pub.GetSetting("CaptionParseExceptionTitle"),MessageBoxButtons.OK,MessageBoxIcon.Warning);
				
			}
			else
			{
				//if (ct[0].ToString(-1,0,false).StartsWith(Pub.copyRight)) ct.Remove(0);
				//ct.AdjustFirstIndex=ct.BuildFirstIndex=0+Pub.BeginIndex;
				//ct.AdjustLastIndex=ct.BuildLastIndex=ct.Count-1+Pub.BeginIndex;
			}
			return ct;
		}


		public static Caption ParseSrt(string[] Buffer)
		{  
			Caption cap=new Caption();
			Section sec=new Section();
			for (int i=0;i<Buffer.Length;i++)
			{
				if (Buffer[i]=="") continue;

				if (Buffer[i].IndexOf(Pub.SrtSymbol)>-1)
				{
					sec=ExtractSrtSection(Buffer[i]);
					cap.Add(sec);
				}
				else
				{
					try 
					{
						int.Parse(Buffer[i]);
					}
					catch
					{
							if (sec.Items.Count==0) sec.StyleFormat=ExtractStyle(ref Buffer[i]);
						sec.Items.Add(Buffer[i]);
					}
				}
			}
			return cap;
		}


		private static Section ExtractSrtSection(string line)
		{
			Section sec=null;
			line=line.Replace(",",".");
			int i=line.IndexOf(Pub.SrtSymbol);
			if (i>-1)
			{
				sec=new Section();
                try
                {
                    sec.BeginTime = ParseTime(line.Substring(0, i));
                    sec.EndTime = ParseTime(line.Substring(i + Pub.SrtSymbol.Length));
                }
                catch(Exception e)
                {
                    int b=1;
                    b=3;
                }
			}
			return sec;
		}

		private static DateTime ParseTime(string line)
		{
			return DateTime.Parse(line.Trim().Replace(" ","0"));
		}


		public static Caption ParseSsa(string[] Buffer)
		{  

			Caption cap=new Caption();
			for (int i=0;i<Buffer.Length;i++)
			{
				if (Buffer[i].IndexOf(Pub.SsaSymbol)>-1)
					cap.Add(ExtractSsaSection(Buffer[i]));
			}
			return cap;

		}

		
		private static Section ExtractSsaSection(string line)
		{
			Section sec=null;
			if (line.IndexOf(Pub.SsaSymbol)>-1)
			{
				string [] split=line.Split(Pub.SsaLimit.ToCharArray(),10);
				sec=new Section();
				sec.BeginTime=System.DateTime.Parse(split[1]);
				sec.EndTime=System.DateTime.Parse(split[2]);

				sec.StyleFormat=ExtractStyle(ref split[9]);
				split[9]=split[9].Replace(@"\N",@"\n");

				int i;
				while ((i=split[9].IndexOf(@"\n"))>-1)
				{
					sec.Items.Add(split[9].Substring(0,i));
					split[9]=split[9].Substring(i+2);
				}
				sec.Items.Add(split[9]);
			}

			return sec;
		}


		private static string ExtractStyle(ref string line)
		{
			string style=null;
			int i=line.IndexOf(Pub.StyleEndChar);
			if (line.IndexOf(Pub.StyleBeginChar)==0&&i>0)
			{
				style=line.Substring(0,i+1);
				line=line.Substring(i+1);
			}
			return style;
		}
	}
}
