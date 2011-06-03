using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityObjectORM;
using System.Threading;

namespace WCFLockService
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class LockService : ILockService
	{
		Dictionary<ObjectIdentifier, Lock> m_object = new Dictionary<ObjectIdentifier, Lock>();
		ReaderWriterLockSlim m_objectLock = new ReaderWriterLockSlim();

		List<ILockServiceCallback> changeSubscribers = new List<ILockServiceCallback>();
		ReaderWriterLockSlim m_subscribersLock = new ReaderWriterLockSlim();

		ILockServiceCallback GetCallback()
		{
			return OperationContext.Current.GetCallbackChannel<ILockServiceCallback>();
		}

		//public string DoWork(string value)
		//{
		//    ILockServiceCallback callback = OperationContext.Current.GetCallbackChannel<ILockServiceCallback>();
		//    new Thread(NewMethod).Start(callback);			

		//    return "Welcome " + value;
		//}

		//private void NewMethod(object ooo)
		//{
		//    ILockServiceCallback callback = ooo as ILockServiceCallback;
		//    callback.LockIsAvailable(ObjectIdentifier.ERROR_OID);
		//}

		public TryLockResult TryLock(ObjectIdentifier objectId, bool tellWhenAvailable = false)
		{
			m_objectLock.EnterUpgradeableReadLock();
			try
			{				
				Lock currentLock = null;
				if (m_object.TryGetValue(objectId, out currentLock))
				{
					// если время блокировки закончилось, то блокируем
				}
				else
				{
					m_subscribersLock.EnterWriteLock();
					try
					{
						// установить блокировку
					}
					finally
					{
						m_subscribersLock.ExitWriteLock();
					}
				}
			}
			finally
			{
				m_objectLock.ExitUpgradeableReadLock();
			}

			return new TryLockResult(true);			
		}

		public List<Lock> GetAllCurrentLock()
		{
			List<Lock> result = null;

			m_objectLock.EnterReadLock();
			try
			{				
				result = m_object.Values.ToList();
			}
			finally
			{
				m_objectLock.ExitReadLock();
			}

			return result;
		}

		public void BeginLockChangedSubscribtion()
		{
			m_subscribersLock.EnterWriteLock();
			try
			{				
				changeSubscribers.Add(GetCallback());
			}
			finally
			{
				m_subscribersLock.ExitWriteLock();
			}
		}

		public void EndLockChangedSubscribtion()
		{
			m_subscribersLock.EnterWriteLock();
			try
			{				
				changeSubscribers.Remove(GetCallback());
			}
			finally
			{
				m_subscribersLock.ExitWriteLock();
			}			
		}
	}
}
