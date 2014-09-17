using System;
using System.Xml;  
using System.Configuration;
using System.Reflection;
using System.IO;

namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class AppSettings
	{
		private static readonly string configFile;
		private AppSettings()
		{
			// 
			// TODO: 在此处添加构造函数逻辑
			//
		}
		static AppSettings()
		{
			configFile=getConfigFilePath();
		}
	
//		public static string ReadSetting(string key)
//		{
//			string s=null;
//			try
//			{
//
//				s= ConfigurationSettings.AppSettings[key];
//			}
//			catch (Exception e)
//			{
//				System.Windows.Forms.MessageBox.Show(e.Message);
//			}
//			return s;
//		}



		public static string ReadSetting(string Key)
		{
			string Path="/configuration/appSettings/add";
			XmlDocument doc = loadConfigDocument();
			//if (doc.SelectSingleNode(Path) == null) return null;
			XmlElement elem = (XmlElement)doc.SelectSingleNode(string.Format(Path+"[@key='{0}']", Key));
			return elem==null?null:elem.GetAttribute("value");;
		}


		public static void WriteSetting(string Key, string Value)
		{
			XmlDocument doc = loadConfigDocument();

			if (doc.SelectSingleNode("//configuration") == null)
				doc.AppendChild(doc.CreateNode(XmlNodeType.Element,"configuration",""));

			XmlNode node =  doc.SelectSingleNode("//appSettings");

			if (node == null)
			{
				node=doc.CreateNode(XmlNodeType.Element,"appSettings","");
				doc.SelectSingleNode("//configuration").AppendChild(node);
				
			}

			try
			{
				XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", Key));

				if (elem != null)
				{
					elem.SetAttribute("value", Value);
				}
				else
				{
					elem = doc.CreateElement("add");
					elem.SetAttribute("key", Key);
					elem.SetAttribute("value", Value); 
					node.AppendChild(elem);
				}
				doc.Save(configFile);
			}
			catch
			{
				throw;
			}
		}

		public static void RemoveSetting(string key)
		{
			XmlDocument doc = loadConfigDocument();

			XmlNode node =  doc.SelectSingleNode("//appSettings");

			try
			{
				if (node == null)
					throw new InvalidOperationException("appSettings section not found in config file.");
				else
				{
					node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
					doc.Save(configFile);
				}
			}
			catch (NullReferenceException e)
			{
				throw new Exception(string.Format("The key {0} does not exist.", key), e);
			}
		}

		private static XmlDocument loadConfigDocument()
		{
			XmlDocument doc = null;
			try
			{
				doc = new XmlDocument();
				doc.Load(configFile);
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
			return doc;

		}

		public static string getConfigFilePath()
		{
			string configFile=Assembly.GetExecutingAssembly().Location + ".config";
			if (!File.Exists(configFile)) CreateFile(configFile);
			return configFile;
		}

		public static bool ConfigFileExist()
		{
			string configFile=Assembly.GetExecutingAssembly().Location + ".config";
			return File.Exists(configFile);
		}

		private static void CreateFile(string FileName)
		{
			XmlTextWriter writer = new XmlTextWriter(FileName,System.Text.Encoding.Default);
			writer.WriteStartElement("configuration");
			writer.WriteStartElement("appSettings");
			writer.WriteEndElement() ;
			writer.Flush();
			writer.Close();
		}
	}



}
