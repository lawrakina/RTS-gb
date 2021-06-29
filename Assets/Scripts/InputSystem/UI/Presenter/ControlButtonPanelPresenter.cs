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
            //ToDo поправить создание комманд
            executor.Execute(_assets.Inject(new ProduceUnitCommand()));
            executor.Execute(_assets.Inject(new AttackCommand()));
            executor.Execute(_assets.Inject(new MoveCommand()));
            executor.Execute(_assets.Inject(new PatrolCommand()));
            executor.Execute(_assets.Inject(new StopCommand()));
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