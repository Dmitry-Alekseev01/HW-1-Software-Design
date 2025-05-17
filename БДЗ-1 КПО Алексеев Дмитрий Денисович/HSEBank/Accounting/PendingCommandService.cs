using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public sealed class PendingCommandService
{
    private readonly LinkedList<IAccountingSessionCommand> _unappliedCommands = new();
    private readonly Stack<IAccountingSessionCommand> _undoneCommands = new();

    public void AddCommand(IAccountingSessionCommand command)
    {
        _unappliedCommands.AddLast(command);
        _undoneCommands.Clear();
    }

    public IReadOnlyCollection<IAccountingSessionCommand> UnappliedCommands => _unappliedCommands;

    public void UndoLastCommand()
    {
        if (_unappliedCommands.Last is not null)
        {
            var command = _unappliedCommands.Last.Value;
            _unappliedCommands.RemoveLast();
            _undoneCommands.Push(command);
        }
    }

    public void RedoUndoneCommand()
    {
        if (_undoneCommands.Count > 0)
        {
            var command = _undoneCommands.Pop();
            _unappliedCommands.AddLast(command);
        }
    }

    public void SaveChanges()
    {
        foreach (var command in _unappliedCommands)
        {
            command.Apply();
        }
        _unappliedCommands.Clear();
    }
}