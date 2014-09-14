using System;
using System.Configuration;
using System.Windows.Forms;
using System.IO; 
using System.Text;
using System.Collections;
namespace Subindex
{

	public enum SaveDoType {Dialog,View,Nothing};

	/// <summary>
	/// 
	/// </summary>
	public class Pub
	{
		
		public static readonly string Limit="\r\n";
		public static readonly string SrtSymbol="-->";
		public static readonly string SsaSymbol="Dialogue: ";
		public static readonly string SsaLimit=",";
		public static readonly string StyleBeginChar="{";
		public static readonly string StyleEndChar="}";

		public static readonly string[] Txt=new string[]
		{
			"Current is empty!",
			"Open",
			" already exist.\r\n Replace it?",
			"Save as",
			"\r\nfile no exist ! Please recheck it",
			"Open file",
			"\r\nfile saved! View it with notepad?",
			"Save succeed",
			"File format invalid !",
			" File format invalid !",
			"Parse failed"
		};

		public static readonly string Format="HH:mm:ss,fff";
		public static readonly string FileType="SRT files (*.srt)|*.srt|SSA files (*.ssa)|*.ssa|ASS files (*.ass)|*.ass|Any Support files (*.srt,*.ssa,*.ass)|*.srt;*.ssa;*.ass|All files (*.*)|*.*";
		
		public static int BeginIndex=1;
		public static bool AutoWrap=true;
		public static bool KeepFormat=false;
		public static bool KeepLog=true;
		public static string WrapSplit=" ";
		public static string MillisecondChar=",";
		public static SaveDoType SaveDoType ;

		private static OpenFileDialog openbox;
		private static string stmp;
		public static string copyRight="";
		//public static Section copyRight

		static  Pub()
		{

		}

		private  Pub()
		{
		}


		public static string GetSetting(string Key)
		{
			string Value=null;
			try
			{
				if (AppSettings.ConfigFileExist()) Value=ConfigurationSettings.AppSettings[Key];
			}
			catch
			{
			}
			return Value;
		}

//		public static string GetSetting(string Key,string DefaultValue)
//		{
//			string Value=DefaultValue;
//			try
//			{
//				if (AppSettings.ConfigFileExist()) 
//					Value=ConfigurationSettings.AppSettings[Key];
//			}
//			catch
//			{
//			}
//			return Value;
//		}

		public static void BuildUi(Control obj)
		{
			if (obj.Controls.Count>0)
				for (int i=0;i<obj.Controls.Count;i++) BuildUi(obj.Controls[i]);
			stmp=GetSetting(obj.Name);
			if (stmp!=null) obj.Text=stmp;
			switch (obj.GetType().Name)
			{
				case "ComboBox":
					BuildComboBox(obj as ComboBox);
					break;
				case "DropDownButton":
					BuildDropDownButton(obj as DropDownButton);
					break;
			}
			//obj.MouseEnter+=new EventHandler(obj_MouseEnter);
		}

//		private static void obj_MouseEnter(object sender, EventArgs e)
//		{
//			(sender as Control).Focus();
//
//		}

		public static void BuildComboBox(ComboBox obj)
		{
			string listValue;
			for (int i=0;i<obj.Items.Count;i++)
			{
				listValue=Pub.GetSetting(obj.Name+i);
				if (listValue!=null) obj.Items[i]=listValue;
			}
			if (obj.Items.Count>0) obj.SelectedIndex=0;
		}

		public static void BuildDropDownButton(DropDownButton obj)
		{
			string listValue=null;
			for (int i=0;i<obj.Items.Count;i++)
			{
				listValue=Pub.GetSetting(obj.Name+i);
				if (listValue!=null) obj.Items[i].Text=listValue;
			}
			
		}

		public static string[] ReadFile(string FileName)
		{
			if (!FileExist(FileName)) return null;
			ArrayList list=new ArrayList(); 
			string line;
			try
			{
				using (StreamReader sr = new StreamReader(FileName,Encoding.Default))
					while ((line=sr.ReadLine())!=null) list.Add(line);
			}
			catch
			{
				throw;
			}
			return (string[]) list.ToArray(typeof(string));
		}


		public static string ReadFileString(string FileName)
		{
			if (!FileExist(FileName)) return null;
			string line;
			try
			{
				using (StreamReader sr = new StreamReader(FileName,Encoding.Default))
					line=sr.ReadToEnd();
			}
			catch
			{
				throw;
			}
			return line;
		}

		
		public static bool FileExist(string FileName)
		{
			if (FileName==null||FileName.Trim()=="") return false;
			bool exist=File.Exists(FileName);
			if (!exist)
				MessageBox.Show(FileName+GetSetting("OpenFileNoExistText").Replace(@"\r\n","\r\n"),Pub.GetSetting("OpenFileNoExistTitle"),MessageBoxButtons.OK,MessageBoxIcon.Warning);
			return exist;
		}

		public static string OpenFile()
		{
			if (openbox==null)
			{
				openbox=new OpenFileDialog();
				//				openbox.InitialDirectory = "c:\\" ;
				openbox.FilterIndex = 0 ;
				openbox.RestoreDirectory = true ;
			};
			openbox.FileName ="";
			openbox.Filter = Pub.FileType;
			openbox.ShowDialog();
			return openbox.FileName;
		}


		public static Caption LoadFile(string FileName,TextBox tb)
		{
			Caption ct=null;
			string[] buffer=Pub.ReadFile(FileName);
			if (buffer!=null)
			{
				if (tb!=null) tb.Lines=buffer;
				try 
				{
					ct=CaptionParser.Parse(buffer);
				}
				catch (ExtendException ee)
				{
					MessageBox.Show(ee.Message,Pub.GetSetting("CaptionParseExceptionTitle"),MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
			return ct;
			
		}


		public static string SaveFile(string FileBuffer)
		{
			SaveFileDialog sd=new SaveFileDialog();
			sd.Filter="SRT files (*.srt)|*.srt";
			sd.RestoreDirectory = true ;
			if (sd.ShowDialog()==DialogResult.OK)
				SaveFile(FileBuffer,sd.FileName,true);
			return sd.FileName;
		}

		public static string SaveFile(string FileBuffer,string FileName,bool OverWrite)
		{
			if  (!OverWrite&&File.Exists(FileName))
				if (MessageBox.Show(FileName+GetSetting("SaveFileOverWriteText").Replace(@"\r\n","\r\n"),GetSetting("SaveFileOverWriteTitle"),MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
					return "";
			StreamWriter sw = new StreamWriter(FileName,false,Encoding.Default);
			sw.Write(Loging(FileBuffer)); 
			sw.Close();
			switch (Pub.SaveDoType)
			{
				case SaveDoType.Dialog:
					if (MessageBox.Show(FileName+GetSetting("SaveFileSucceedText").Replace(@"\r\n","\r\n") ,Pub.GetSetting("SaveFileSucceedTitle"),MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
						goto case SaveDoType.View;
					break;
				case SaveDoType.View:
					System.Diagnostics.Process.Start("notepad.exe",FileName);
					break;
			}

			return FileName;
		}

		private static string Loging(string FileBuffer)
		{
			return FileBuffer;
		}




		public static bool GetAppReg()
		{
			bool state=false;
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot;
			Microsoft.Win32.RegistryKey ext = key.OpenSubKey(@"Subindex.exe\shell\open\command");
			if (ext!=null)
			{
				string Value="\"" + Application.ExecutablePath + "\" \"%1\"";
				state=Value==ext.GetValue("","").ToString(); 
			}
			return state;
		}

		public static bool GetRegState(string fileType)
		{
			bool state=false;
			string appName    = "Subindex.exe";
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot;
			Microsoft.Win32.RegistryKey ext = key.OpenSubKey (fileType);
			if (ext!=null)
				state=appName==ext.GetValue("","").ToString();
			return state&&GetAppReg();
		}

		public static void SetAppReg()
		{
			Microsoft.Win32.RegistryKey ext= Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"Subindex.exe\shell\open\command");
			ext.SetValue("","\"" + Application.ExecutablePath + "\" \"%1\"");
			ext.Flush();
			ext.Close();
		}

		public static void RegFileType(string fileType)
		{
			string appName    = "Subindex.exe";
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot;
			Microsoft.Win32.RegistryKey ext = key.CreateSubKey(fileType);
			string Value=ext.GetValue("","").ToString();
			if (Value!=""&&Value!=appName) ext.SetValue(appName+".Undo",Value);
			ext.SetValue("",appName);
			ext.Flush();
			ext.Close();

			key=Microsoft.Win32.Registry.CurrentUser;

			ext =key.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\"+fileType);
			Value=ext.GetValue("Application","").ToString();
			if (Value!=""&&Value!=appName) ext.SetValue(appName+".Undo",Value);
			ext.SetValue("Application",appName);
			Value=ext.GetValue("Progid","").ToString();
			if (Value!="")
			{
				ext.SetValue("Progid.Undo",Value);
				ext.DeleteValue("Progid");
			}
			ext.Flush();
			ext.Close();
			key.Close();
		}

		public static void UnRegFileType(string fileType)
		{
			string appName    = "Subindex.exe";
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot;
			Microsoft.Win32.RegistryKey ext = key.CreateSubKey(fileType);
			string Value=ext.GetValue(appName+".Undo","").ToString();
			ext.SetValue("",Value);
			if (Value!="") ext.DeleteValue(appName+".Undo");
			ext.Flush();
			ext.Close();

			key=Microsoft.Win32.Registry.CurrentUser;

			ext =key.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\"+fileType);
			Value=ext.GetValue(appName+".Undo","").ToString();
			ext.SetValue("Application",Value);
			if (Value!="") ext.DeleteValue(appName+".Undo");
			Value=ext.GetValue("Progid.Undo","").ToString();
			if (Value!="")
			{
				ext.SetValue("Progid",Value);
				ext.DeleteValue("Progid.Undo");
			}

			ext.Flush();
			ext.Close();
		}

	}
}
