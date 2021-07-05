using Abstraction;
using Zenject;


namespace InputSystem.UI.Model
{
    public class ControlButtonPanel
    {
        [Inject] private CommandCreator<IProduceUnitCommand> _produceUnitCommandCreator;
        [Inject] private CommandCreator<IAttackCommand> _attackCommandCreator;
        [Inject] private CommandCreator<IMoveCommand> _moveCommandCreator;

        public void ClickHandle(ICommandExecutor executor)
        {
            _produceUnitCommandCreator.CreateCommand(executor, (command) => executor.Execute((command)));
            _attackCommandCreator.CreateCommand(executor, (command) => executor.Execute((command)));
            _moveCommandCreator.CreateCommand(executor, (command) => executor.Execute((command)));
        }
    }
}