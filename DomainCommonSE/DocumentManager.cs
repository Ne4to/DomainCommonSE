using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCommonSE.Domain;

namespace DomainCommonSE
{
	internal class DocumentManager
	{
		private DomainObjectInquiry m_inquiry;
		private SessionIdentifier m_newSessionIdentifier = new SessionIdentifier(1);
		private Dictionary<SessionIdentifier, Document> m_document = new Dictionary<SessionIdentifier, Document>();

		public static DocumentManager Instance { get; private set; }

		public DocumentManager(DomainObjectInquiry inquiry)
		{
			if (inquiry == null)
				throw new ArgumentNullException("inquiry");

			m_inquiry = inquiry;

			Instance = this;
		}

		public void AddObject(DomainObject obj)
		{
			m_document[obj.Session].AddObject(obj);
		}

		public Document OpenDocument()
		{
			SessionIdentifier sid = m_newSessionIdentifier;
			Document newDocument = new Document(sid, m_inquiry);
			m_document.Add(sid, newDocument);
			m_newSessionIdentifier = new SessionIdentifier(sid.Id + 1);

			return newDocument;
		}

		public Document this[SessionIdentifier sessionId]
		{
			get
			{
				return m_document[sessionId];
			}
		}

		public DomainLink GetLink(SessionIdentifier sessionId, DomainLinkKey linkKey)
		{
			if (sessionId == SessionIdentifier.SHARED_SESSION)
				return null;

			return m_document[sessionId].GetLink(linkKey);
		}
		
		//public void SaveDocument(Document document)
		//{
		//    lock (objectStorage)
		//    {
		//        throw new NotImplementedException();

		//        //foreach (ObjectIdentifier objId in document.NewObject)
		//        //{
		//        //    EntityObject newObj = document.GetObject(objId);
		//        //    PutToStorage(newObj);
		//        //}

		//        //// список id объектов уже перезаписанных в хранилище			
		//        //List<ObjectIdentifier> rewritedInStorageObjects = new List<ObjectIdentifier>();

		//        //foreach (ObjectIdentifier objId in document.ChangedObjectProperty)
		//        //{
		//        //    EntityObject changePropObject = document.GetObject(objId);
		//        //    RewriteInStorage(changePropObject);
		//        //    rewritedInStorageObjects.Add(objId);
		//        //}

		//        //foreach (ObjectIdentifier objId in document.ChangedObjectLink)
		//        //{
		//        //    // при сохранении исключаем двойную запись в хранилище если кроме свойств менялись еще и ссылки
		//        //    if (!rewritedInStorageObjects.Contains(objId))
		//        //    {
		//        //        EntityObject changeLinkObject = document.GetObject(objId);
		//        //        RewriteInStorage(changeLinkObject);
		//        //    }
		//        //}

		//        //foreach (ObjectIdentifier objId in document.RemoveObjectList)
		//        //{
		//        //    RemoveFromStorage(objId);
		//        //}
		//    }

		//    UnlockAllObjectInSession(document.Session);
		//}

		//public void CancelDocument(Document document)
		//{
		//    UnlockAllObjectInSession(document.Session);
		//}

		//public void CloseDocument(Document document)
		//{
		//    UnlockAllObjectInSession(document.Session);
		//    //lock (m_document)
		//    m_document.Remove(document.Session);
		//}

		internal DomainObject GetObject(SessionIdentifier ownerSessionId, ObjectIdentifier oid)
		{
			return m_document[ownerSessionId].GetObject(oid);
		}
	}
}
