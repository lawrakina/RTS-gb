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
        protected override void CreateSpecificCommand(Action<IAttackCommand> onCreate)
        {
            
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