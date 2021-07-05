using System;
using Abstraction;
using UnityEngine;
using Utils;
using Zenject;


namespace InputSystem.UI.Model
{
    public abstract class CommandCreator<T> where T : ICommand
    {
        public void CreateCommand(ICommandExecutor executor, Action<T> onCreate)
        {
            if (executor as CommandExecutorBase<T>)
            {
                CreateSpecificCommand(onCreate);
                // executor.Execute();   
            }
        }

        protected abstract void CreateSpecificCommand(Action<T> onAction);

    }

    public class ProduceUnitCommandCreator : CommandCreator<IProduceUnitCommand>
    {
        [Inject] private AssetsStorage _assets;
        protected override void CreateSpecificCommand(Action<IProduceUnitCommand> onCreate)
        {
            onCreate?.Invoke(_assets.Inject(new ProduceUnitCommand()));
        }
    }

    public class AttackUnitCommandCreator : CommandCreator<IAttackCommand>
    {
        private SelectedItemModel _selectedItem;

        [Inject]
        public AttackUnitCommandCreator(SelectedItemModel selectedItem)
        {
            _selectedItem = selectedItem;
        }

        protected override void CreateSpecificCommand(Action<IAttackCommand> onCreate)
        {
            onCreate?.Invoke(new AttackUnitCommand((IAttackable)_selectedItem.Value));
        }
    }

    public class PatrolCommandCreator : CommandCreator<IPatrolCommand>
    {
        private SelectedItemModel _selectedItem;
        private GroundClickModel _groundClick;
        
        [Inject]
        public PatrolCommandCreator(SelectedItemModel selectedItem, GroundClickModel groundClick)
        {
            _selectedItem = selectedItem;
            _groundClick = groundClick;
        }
        
        protected override void CreateSpecificCommand(Action<IPatrolCommand> onAction)
        {
            onAction?.Invoke(new PatrolCommand(_groundClick.Value, (_selectedItem.Value as Transform).position));
        }
    }

    public class StopCommandCreator : CommandCreator<IStopCommand>
    {
        private SelectedItemModel _selectedItem;
        
        [Inject]
        public StopCommandCreator(SelectedItemModel selectedItem)
        {
            _selectedItem = selectedItem;
        }
        
        protected override void CreateSpecificCommand(Action<IStopCommand> onAction)
        {
            onAction?.Invoke(new StopCommand());
        }
    }
    
    public class MoveUnitCommandCreator : CommandCreator<IMoveCommand>
    {
        private Action<IMoveCommand> _onCreate;
        private GroundClickModel _currentGroundClick;

        [Inject]
        public MoveUnitCommandCreator(GroundClickModel currentGroundClick)
        {
            _currentGroundClick = currentGroundClick;
            _currentGroundClick.OnUpdate += HandleGroundClick;
        }

        private void HandleGroundClick()
        {
            _onCreate?.Invoke(new MoveUnitCommand(_currentGroundClick.Value));
        }

        protected override void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            _onCreate = onCreate;
        }
    }
    
}