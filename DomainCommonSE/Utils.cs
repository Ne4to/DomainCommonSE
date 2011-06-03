using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Text;

namespace DomainCommonSE
{
	public class Utils
	{
		/// <summary>
		/// Сохранение объекта в xml файл
		/// </summary>
		/// <typeparam name="T">тип объекта typeof(type)</typeparam>
		/// <param name="pObject">объект</param>
		/// <param name="fileName">путь к файлу</param>
		public static void SerializeObjectXMLFile<T>(T pObject, string fileName)
			where T : class
		{
			// если файл скрыт то временно снимаем с него эту метку, иначе не дает записать в файл
			bool wasHidden = false;
			if (File.Exists(fileName))
			{
				FileAttributes attr = File.GetAttributes(fileName);

				if ((int)(attr & FileAttributes.Hidden) > 0)
				{
					wasHidden = true;
					File.SetAttributes(fileName, File.GetAttributes(fileName) ^ FileAttributes.Hidden);
				}
			}

			// создаем корневую папку если она не существует
			Directory.CreateDirectory(Directory.GetParent(fileName).FullName);

			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (TextWriter stream = new StreamWriter(fileName))
			{
				serializer.Serialize(stream, pObject);
				stream.Close();
			}

			// восстонавливаем аттрибуты файла
			if (wasHidden)
			{
				File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);
			}
		}

		/// <summary>
		/// Загрузить объект из xml файла
		/// </summary>
		/// <typeparam name="T">тип объекта typeof(type)</typeparam>
		/// <param name="fileName">путь к файлу</param>
		/// <returns></returns>
		public static T DeserializeObjectXMLFile<T>(string fileName)
			where T : class
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (TextReader reader = new StreamReader(fileName))
			{
				T result = serializer.Deserialize(reader) as T;
				reader.Close();
				return result;
			}
		}

		public static void SerializeObjectBinaryFile<T>(T pObject, string fileName)
			where T : class
		{
			// создаем корневую папку если она не существует
			Directory.CreateDirectory(Directory.GetParent(fileName).FullName);

			using (Stream stream = new FileStream(fileName, FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, pObject);
				stream.Close();
			}
		}

		public static T DeserializeObjectBinaryFile<T>(string fileName)
			where T : class
		{
			T result = null;

			using (Stream stream = new FileStream(fileName, FileMode.Open))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				result = formatter.Deserialize(stream) as T;
				stream.Close();
			}

			return result;
		}

		public static byte[] SerializeObjectBinary<T>(T pObject)
			where T : class
		{
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(ms, pObject);

				byte[] byteArray = ms.GetBuffer();
				ms.Close();
				return byteArray;
			}
		}

		public static T DeserializeObjectBinary<T>(byte[] byteArray)
				where T : class
		{
			T result = null;

			using (MemoryStream ms = new MemoryStream(byteArray))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				result = formatter.Deserialize(ms) as T;
				ms.Close();				
			}

			return result;
		}

		public static byte[] SerializeObjectXML<T>(T pObject)
			where T : class
		{
			XmlSerializer serializer = new XmlSerializer(pObject.GetType());
			using (MemoryStream ms = new MemoryStream())
			{
				serializer.Serialize(ms, pObject);

				byte[] byteArray = ms.GetBuffer();
				ms.Close();
				return byteArray;
			}
		}

		public static T DeserializeObjectXML<T>(byte[] byteArray, Type realType)
			where T : class
		{
			XmlSerializer serializer = new XmlSerializer(realType);
			using (MemoryStream ms = new MemoryStream(byteArray))
			{
				T result = serializer.Deserialize(ms) as T;
				ms.Close();
				return result;
			}
		}

		public static bool CheckEnglishString(string value)
		{
			return Regex.IsMatch(value, "^[a-zA-Z]{1}[a-zA-Z_0-9]*$");
		}

		public static string GetBestName(string code)
		{
			if (code.Length <= 1)
				return code;

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < code.Length; i++)
			{
				if (i == 0)
				{
					sb.Append(code[0]);
					continue;
				}

				if (code[i] == '_' && code.Length > i + 1)
				{
					sb.Append(code[i + 1]);
					i++;
					continue;
				}

				sb.Append(code.ToLower()[i]);
			}

			return sb.ToString();
		}
	}
}
