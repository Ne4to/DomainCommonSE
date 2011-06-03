using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityObjectORM;

namespace WCFLockService
{
	public interface ILockServiceCallback
	{
		[OperationContract(IsOneWay = true)]
		void LockIsAvailable(ObjectIdentifier objectId);
	}

	[ServiceContract(CallbackContract = typeof(ILockServiceCallback), SessionMode = SessionMode.Required)]
	public interface ILockService
	{
		[OperationContract]
		TryLockResult TryLock(ObjectIdentifier objectId, bool tellWhenAvailable = false);

		[OperationContract]
		List<Lock> GetAllCurrentLock();

		[OperationContract]
		void BeginLockChangedSubscribtion();

		[OperationContract]
		void EndLockChangedSubscribtion();
	}

	[DataContract]
	public class TryLockResult
	{
		[DataMember]
		public bool Successful { get; private set; }
		[DataMember]
		public DateTime EndLockTime { get; private set; }

		public TryLockResult(bool successful)
		{
			Successful = successful;
		}
	}

	[DataContract]
	public class Lock
	{
		[DataMember]
		public DateTime BeginTime { get; private set; }
		[DataMember]
		public ObjectIdentifier ObjectId { get; private set; }

		public Lock(DateTime beginTime, ObjectIdentifier objectId)
		{
			beginTime = BeginTime;
			ObjectId = objectId;
		}
	}
}
