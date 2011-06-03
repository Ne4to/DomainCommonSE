using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public class LoginDataSettings
	{
		const string ApplicationFolder = "DomainCommonSE";
		const string LoginDataFolder = "LoginData";

		Dictionary<string, List<ConnectionLoginData>> m_data = new Dictionary<string, List<ConnectionLoginData>>();

		public ConnectionLoginData[] GetData(IDbCommonConnectionPlugin connectionData)
		{
			return GetList(connectionData).ToArray();
		}

		public void Add(IDbCommonConnectionPlugin connectionData, ConnectionLoginData data)
		{
			List<ConnectionLoginData> list = GetList(connectionData);
			list.Add(data);

			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationFolder, LoginDataFolder, connectionData.ConnectionName, data.ConnectionName);
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			byte[] key = UnicodeEncoding.ASCII.GetBytes(System.Security.Principal.WindowsIdentity.GetCurrent().User.Value);

			byte[] subkey = GetCompressedKey(key, 32);
			Aes aes = AesCryptoServiceProvider.Create();
			aes.Key = subkey;
			aes.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };			

			byte[] byteData = Utils.SerializeObjectXML<ConnectionLoginData>(data);
			byte[] resultArray = aes.CreateEncryptor().TransformFinalBlock(byteData, 0, byteData.Length);

			File.WriteAllBytes(path, resultArray);
		}

		private static byte[] GetCompressedKey(byte[] key, int maxLength)
		{
			int keyLength = key.Length;
			byte[] subkey = new byte[maxLength];

			// копирование первой части ключа
			for (int i = 0; i < maxLength; i++)
			{
				if (i < keyLength)
					subkey[i] = key[i];
				else
					subkey[0] = 0;
			}

			int subsCount = keyLength / maxLength + (keyLength % maxLength > 0 ? 1 : 0);
			for (int i = 1; i < subsCount; i++)
			{
				for (int j = 0; j < maxLength; j++)
				{
					int index = i * maxLength + j;
					if (index < keyLength)
						subkey[j] ^= key[index];
				}
			}
			return subkey;
		}

		public bool IsNew(IDbCommonConnectionPlugin connectionData, ConnectionLoginData data)
		{
			List<ConnectionLoginData> list = GetList(connectionData);
			foreach (ConnectionLoginData listItem in list)
			{
				if (data.Equals(listItem))
					return false;
			}

			return true;
		}

		public void Remove(IDbCommonConnectionPlugin connectionData, ConnectionLoginData data)
		{
			List<ConnectionLoginData> list = GetList(connectionData);
			list.Remove(data);
		}

		private List<ConnectionLoginData> GetList(IDbCommonConnectionPlugin connectionData)
		{
			List<ConnectionLoginData> list = null;
			if (!m_data.TryGetValue(connectionData.ConnectionName, out list))
			{
				list = new List<ConnectionLoginData>();
				m_data.Add(connectionData.ConnectionName, list);

				// загрузка списка
				string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationFolder, LoginDataFolder, connectionData.ConnectionName);
				if (Directory.Exists(directoryPath))
				{
					foreach (string filePath in Directory.GetFiles(directoryPath))
					{
						try
						{
							byte[] byteArray = File.ReadAllBytes(filePath);

							byte[] key = UnicodeEncoding.ASCII.GetBytes(System.Security.Principal.WindowsIdentity.GetCurrent().User.Value);

							byte[] subkey = GetCompressedKey(key, 32);
							Aes aes = AesCryptoServiceProvider.Create();
							aes.Key = subkey;
							aes.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

							byte[] decrypted = aes.CreateDecryptor().TransformFinalBlock(byteArray, 0, byteArray.Length);

							ConnectionLoginData data = Utils.DeserializeObjectXML<ConnectionLoginData>(decrypted, connectionData.LoginDataType);
							list.Add(data);
						}
						catch (Exception) { }
					}
				}
			}

			return list;
		}
	}
}
