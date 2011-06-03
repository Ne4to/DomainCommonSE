
namespace DomainCommonSE.ConfigLibrary.UndoRedo
{
	public abstract class Command
	{
		public abstract void Execute();
		public abstract void UnExecute();
	}
}
