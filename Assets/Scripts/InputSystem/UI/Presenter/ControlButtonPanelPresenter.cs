using System.Linq;
using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;
using Utils;


namespace InputSystem.UI.Presenter
{
    public class ControlButtonPanelPresenter: MonoBehaviour
    {
        #region fields

        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private ControlButtonPanelView _view;

        [SerializeField] private AssetsStorage _assets;
        
        #endregion
        
        #region ClassLiveCycles

        private void Start()
        {
            _model.OnUpdate += SetButtons;
            _view._onClick+= ClickHandler;
            SetButtons(null);
        }

        private void ClickHandler(ICommandExecutor executor)
        {
            //ToDo вопрос преподу: вы говорили что можно уйти от свитча, но как это сделать? Дайте мысль...
            switch (executor)
            {
                case CommandExecutorBase<IProduceUnitCommand> productExecutor:
                    productExecutor.Execute(_assets.Inject(new ProduceUnitCommand()));
                    break;
                case CommandExecutorBase<IAttackCommand> attackExecutor:
                    attackExecutor.Execute(new AttackCommand());
                    break;
                case CommandExecutorBase<IPatrolCommand> patrolExecutor:
                    patrolExecutor.Execute(new PatrolCommand());
                    break;
                case CommandExecutorBase<IStopCommand> stopExecutor:
                    stopExecutor.Execute(new StopCommand());
                    break;
                case CommandExecutorBase<IMoveCommand> moveExecutor:
                    moveExecutor.Execute(new MoveCommand());
                    break;
            }
        }

        ~ControlButtonPanelPresenter()
        {
            _view._onClick -= ClickHandler;
            _model.OnUpdate -= SetButtons;
        }

        #endregion


        private void SetButtons(ISelectableItem value)
        {
            _view.ClearButtons();
            if (_model.Value == null)
            {
                _view.ClearButtons();
                return;
            }

            var executors = (_model.Value as Component)?.GetComponents<ICommandExecutor>().ToList();
            _view.SetButtons(executors);
        }
    }
}