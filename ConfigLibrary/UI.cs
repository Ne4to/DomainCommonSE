using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DbCommon;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary
{
	public class UI
	{
		private static UI m_instance;
		public static UI Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new UI();

				return m_instance;
			}
		}

		public event EventHandler ConnectionPluginChanged;
		public event EventHandler<ObjectSqlArgs> ObjectSqlRequest;
		public event EventHandler<UIArgs> NewConnectionOpened;
		public event EventHandler<SourceCodeArgs> SourceCodeRequest;
		public event EventHandler<ShowPropertyRequestArgs> ShowPropertyRequest;

		private UI()
		{

		}

		public void CallConnectionPluginChanged()
		{
			if (ConnectionPluginChanged != null)
				ConnectionPluginChanged(this, EventArgs.Empty);
		}

		public void ShowProperty(object editValue, DomainObjectInquiry inquiry)
		{
			if (ShowPropertyRequest != null)
				ShowPropertyRequest(this, new ShowPropertyRequestArgs(editValue, inquiry));
		}

		public void ShowObjectSql(DomainObjectInquiry app, DomainObjectConfig obj, ObjectSqlArgs.eKind kind)
		{
			if (ObjectSqlRequest != null)
				ObjectSqlRequest(this, new ObjectSqlArgs(app, obj, kind));
		}

		public void EditObjectConfig(DomainObjectInquiry inquiry, DomainObjectConfig obj = null)
		{
			using (EditObjectForm form = new EditObjectForm(inquiry, obj))
			{
				form.ShowDialog();
			}
		}

		public void DeleteObjectConfig(DomainObjectInquiry inquiry, DomainObjectConfig obj)
		{
			if (XtraMessageBox.Show(String.Format(UILocalization.DeleteEntityObjectQuestion, obj.Code), UILocalization.DeleteEntityObjectCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				inquiry.DeleteObject(obj);
			}
		}

		public void ShowNewConnectionForm(IDbCommonConnectionPlugin data = null)
		{
			using (ConnectForm form = new ConnectForm(data))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (NewConnectionOpened != null)
						NewConnectionOpened(this, new UIArgs(form.NewInquiry));
				}
			}
		}

		public void CreatePropertyConfig(DomainObjectInquiry inquiry, DomainObjectConfig obj)
		{
			using (EditPropertyForm form = new EditPropertyForm(inquiry, obj, null))
			{
				form.ShowDialog();
			}
		}

		public void EditPropertyConfig(DomainObjectInquiry inquiry, DomainPropertyConfig property)
		{
			DomainObjectConfig parentObject = inquiry.AObject[property.Owner.Code];

			using (EditPropertyForm form = new EditPropertyForm(inquiry, parentObject, property))
			{
				form.ShowDialog();
			}
		}

		public void DeletePropertyConfig(DomainObjectInquiry inquiry, DomainPropertyConfig property)
		{
			if (MessageBox.Show(String.Format(UILocalization.DeleteEntityObjectPropertyQuestion, property.Code), UILocalization.DeleteEntityObjectPropertyCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{				
				inquiry.DeleteProperty(property);
			}
		}

		public void CreateLinkConfig(DomainObjectInquiry inquiry, DomainObjectConfig obj)
		{
			using (EditLinkForm form = new EditLinkForm(inquiry))
			{
				form.ShowDialog();
			}
		}

		public void EditLinkConfig(DomainObjectInquiry inquiry, DomainLinkConfig link)
		{
			using (EditLinkForm form = new EditLinkForm(inquiry, link))
			{
				form.ShowDialog();
			}
		}

		public void DeleteLinkConfig(DomainObjectInquiry inquiry, DomainLinkConfig link)
		{
			if (MessageBox.Show(String.Format(UILocalization.DeleteEntityObjectLinkQuestion, link.Code), UILocalization.DeleteEntityObjectLinkCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				throw new NotImplementedException();
				//DomainObjectConfig parentObject = inquiry.AObject[link.BaseObjectCode];
				//inquiry.RemoveLink(parentObject, link.DirectCode);
			}
		}

		public void DeleteObjectQuery(DomainObjectInquiry inquiry, ObjectQuery query)
		{
			if (MessageBox.Show(String.Format(UILocalization.DeleteObjectQueryQuestion, query.Code), UILocalization.DeleteObjectQueryCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				inquiry.DeleteObjectQuery(query);
			}
		}

		public void CreateObjectQuery(DomainObjectInquiry inquiry)
		{
			using (EditQueryForm form = new EditQueryForm(inquiry))
			{
				form.ShowDialog();
			}
		}

		public void EditObjectQuery(DomainObjectInquiry inquiry, ObjectQuery objQuery)
		{
			using (EditQueryForm form = new EditQueryForm(inquiry, objQuery))
			{
				form.ShowDialog();
			}
		}

		public void SourceCode(string source)
		{
			if (SourceCodeRequest == null)
				return;

			SourceCodeRequest(this, new SourceCodeArgs(source));
		}
	}

	public class SourceCodeArgs : EventArgs
	{
		public string Source { get; private set; }

		public SourceCodeArgs(string source)
		{
			Source = source;
		}
	}

	public class UIArgs : EventArgs
	{
		public DomainObjectInquiry Inquiry { get; private set; }

		public UIArgs(DomainObjectInquiry inquiry)
		{
			Inquiry = inquiry;
		}
	}

	public class ObjectSqlArgs : UIArgs
	{
		public enum eKind
		{
			Select,
			Insert,
			Update,
			Delete
		}

		public DomainObjectConfig AObject { get; private set; }
		public eKind Kind { get; private set; }

		public ObjectSqlArgs(DomainObjectInquiry inquiry, DomainObjectConfig obj, eKind kind)
			: base(inquiry)
		{
			AObject = obj;
			Kind = kind;
		}
	}

	public class ShowPropertyRequestArgs : EventArgs
	{
		public object EditValue { get; private set; }
		public DomainObjectInquiry Inquiry { get; private set; }

		public ShowPropertyRequestArgs(object editValue, DomainObjectInquiry inquiry)
		{
			EditValue = editValue;
			Inquiry = inquiry;
		}
	}
}
