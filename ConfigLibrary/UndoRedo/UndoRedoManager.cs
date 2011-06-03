using System.Collections.Generic;

namespace DomainCommonSE.ConfigLibrary.UndoRedo
{
	public class UndoRedoManager
	{
		private List<Command> m_commands;

		public int CommandCount
		{
			get
			{
				return m_commands.Count;
			}
		}

		public int CurrentCommandIndex {get; private set;}

		public UndoRedoManager()
		{
			m_commands = new List<Command>();
			CurrentCommandIndex = -1;
		}

		public void AddCommand(Command command)
		{
			m_commands.Add(command);
			CurrentCommandIndex++;
		}

		public void AddCommandWithExecute(Command command)
		{
			AddCommand(command);
			command.Execute();
		}

		public void Undo(int levels)
		{
			for (int i = 0; i < levels; i++)
			{
				if (CurrentCommandIndex >= 0)
				{
					m_commands[CurrentCommandIndex--].UnExecute();
				}
			}
		}

		public void UndoAll()
		{
			for (int i = CurrentCommandIndex; i >= 0; i--)
			{
				m_commands[CurrentCommandIndex--].UnExecute();
			}
		}
	}
}
