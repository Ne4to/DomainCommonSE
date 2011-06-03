using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services.Implementation;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraTreeList.Nodes;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class HighlightRichEditControl : XtraUserControl
	{
		protected bool m_isRuntime;

		public string TextValue
		{
			get
			{
				return txtEdit.Text;
			}
			set
			{
				txtEdit.Text = value;

				if (m_wrapper != null)
					m_wrapper.Execute();
			}
		}

		protected MySyntaxHighlightServiceWrapper m_wrapper;

		public HighlightRichEditControl()
		{
			InitializeComponent();

			m_isRuntime = LicenseManager.UsageMode == LicenseUsageMode.Runtime;
		}

		private void txtEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.Space)
				{
					e.SuppressKeyPress = true;
					int position = txtEdit.Document.CaretPosition.ToInt();
					string prevText = txtEdit.Document.Text.Substring(0, position);
					int spaceIndex = prevText.LastIndexOf(' ');

					string lastWord = string.Empty;

					if (spaceIndex == -1)
					{
						lastWord = prevText;
					}
					else
					{
						lastWord = prevText.Substring(spaceIndex + 1);
					}					
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void HighlightRichEditControl_Load(object sender, EventArgs e)
		{
			if (m_isRuntime)
			{
				MySyntaxHighlightServiceWrapper wrapper = new MySyntaxHighlightServiceWrapper(txtEdit);
				txtEdit.RemoveService(typeof(ISyntaxHighlightService));
				txtEdit.AddService(typeof(ISyntaxHighlightService), wrapper);
				m_wrapper = wrapper;				
			}
		}

		private void txtEdit_DragEnter(object sender, DragEventArgs e)
		{
			TreeListNode node = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
			if (node == null)
				return; 
			e.Effect = DragDropEffects.Copy;
		}

		private void txtEdit_DragDrop(object sender, DragEventArgs e)
		{
			TreeListNode node = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
			if (node == null)
				return;

			if (node.Tag is DbCommonSchemeTable)
			{				
				Point pt = Units.PixelsToDocuments(txtEdit.PointToClient(new Point(e.X, e.Y)), txtEdit.DpiX, txtEdit.DpiY);
				DocumentPosition pos = txtEdit.GetPositionFromPoint(pt);

				DbCommonSchemeTable table = node.Tag as DbCommonSchemeTable;

				if (pos == null)
				{
					txtEdit.Document.InsertText(txtEdit.Document.CaretPosition, table.Name);
				}
				else
				{
					SubDocument subDoc = pos.BeginUpdateDocument();
					subDoc.InsertText(pos, table.Name);
					pos.EndUpdateDocument(subDoc);
				}

				return;
			}
		}

		private void txtEdit_MouseDown(object sender, MouseEventArgs e)
		{

		}

		private void txtEdit_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void txtEdit_DragOver(object sender, DragEventArgs e)
		{
			Point pt = Units.PixelsToDocuments(txtEdit.PointToClient(new Point(e.X, e.Y)), txtEdit.DpiX, txtEdit.DpiY);
			DocumentPosition pos = txtEdit.GetPositionFromPoint(pt);
			if (pos != null)
			{				
				txtEdit.Document.CaretPosition = pos;				
				//
			}
		}
	}

	public class MySyntaxHighlightServiceWrapper : ISyntaxHighlightService
	{
		RichEditControl m_control;
		List<int> paragraphHashes;

		public MySyntaxHighlightServiceWrapper(RichEditControl control)
		{
			m_control = control;
		}

		Dictionary<Color, List<string>> m_colorList = new Dictionary<Color, List<string>>();
		public void AddColorHighlight(Color color, params string[] value)
		{
			m_colorList.Add(color, new List<string>(value));
		}

		public void Prepare()
		{
			paragraphHashes = new List<int>();
			foreach (List<string> list in m_colorList.Values)
			{
				list.Sort(StringComparer.InvariantCultureIgnoreCase);
			}
		}

		#region ISyntaxHighlightService Members

		public void Execute()
		{
			DevExpress.XtraRichEdit.API.Native.Document doc = m_control.Document;
			//doc.BeginUpdate();
			
			//string text = doc.Text;
			//int length = text.Length;
			//bool isBeginWord = false;
			//int beginIndex = -1;
			//for (int i = 0; i < length; i++)
			//{
			//    char ch = text[i];

			//    if (!Char.IsWhiteSpace(ch) && !Char.IsPunctuation(ch))
			//    {
			//        if (!isBeginWord)
			//        {
			//            isBeginWord = true;
			//            beginIndex = i;
			//        }
			//        continue;
			//    }

			//    if (isBeginWord)
			//    {
			//        string word = text.Substring(beginIndex, i - beginIndex);

			//        DocumentRange range = doc.CreateRange(beginIndex, i - beginIndex);
			//        CharacterProperties cp = doc.BeginUpdateCharacters(range);

			//        cp.ForeColor = GetColor(word);

			//        doc.EndUpdateCharacters(cp);

			//        isBeginWord = false;
			//    }
			//}

			int paragraphCount = doc.Paragraphs.Count;
			for (int i = 0; i < paragraphCount; i++)
			{
				HighlightParagraph(i);
			}

			//doc.EndUpdate();
		}

		private Color GetColor(string word)
		{
			foreach (KeyValuePair<Color, List<string>> list in m_colorList)
			{
				if (list.Value.BinarySearch(word, StringComparer.InvariantCultureIgnoreCase) >= 0)
					return list.Key;
			}

			return Color.Black;
		}

		private void HighlightParagraph(int paragraphIndex)
		{
			DevExpress.XtraRichEdit.API.Native.Document doc = m_control.Document;
			Paragraph paragraph = doc.Paragraphs[paragraphIndex];
			DocumentRange paragraphRange = paragraph.Range;
			int paragraphStart = paragraphRange.Start.ToInt();			
			
			string text = doc.GetText(paragraphRange);
			int hash = text.GetHashCode();

			if (paragraphIndex < paragraphHashes.Count && paragraphHashes[paragraphIndex] == hash)
				return;

			int length = text.Length;
			int prevWhiteSpaceIndex = -1;

			for (int i = 0; i < length; i++)
			{
				char ch = text[i];
				if (Char.IsWhiteSpace(ch) || Char.IsPunctuation(ch))
				{
					int wordLength = i - prevWhiteSpaceIndex - 1;
					if (wordLength > 0)
					{
						int wordStart = prevWhiteSpaceIndex + 1;
						string word = text.Substring(wordStart, wordLength);

						DocumentRange range = doc.CreateRange(paragraphStart + wordStart, wordLength);
						CharacterProperties cp = doc.BeginUpdateCharacters(range);

						cp.ForeColor = GetColor(word);

						doc.EndUpdateCharacters(cp);
					}

					prevWhiteSpaceIndex = i;
				}
			}

			for (int i = paragraphHashes.Count; i <= paragraphIndex; i++)
				paragraphHashes.Add(String.Empty.GetHashCode());

			paragraphHashes[paragraphIndex] = hash;
		}
		#endregion
	}
}
