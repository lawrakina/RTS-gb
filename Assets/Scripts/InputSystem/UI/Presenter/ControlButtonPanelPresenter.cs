using System.Linq;
using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;
using Zenject;


namespace InputSystem.UI.Presenter
{
    public class ControlButtonPanelPresenter: MonoBehaviour
    {
        #region fields

        [SerializeField] private SelectedItemModel _selectedItem;
        [SerializeField] private ControlButtonPanelView _view;

        [Inject] private ControlButtonPanel _model;
        
        #endregion
        
        #region ClassLiveCycles

        private void Start()
        {
            _selectedItem.OnUpdate += SetButtons;
            _view._onClick+= ClickHandler;
            SetButtons(null);
        }

        private void ClickHandler(ICommandExecutor executor)
        {
            _model.ClickHandle(executor);
        }

        ~ControlButtonPanelPresenter()
        {
            _view._onClick -= ClickHandler;
            _selectedItem.OnUpdate -= SetButtons;
        }

        #endregion


        private void SetButtons(ISelectableItem value)
        {
            _view.ClearButtons();
            if (_selectedItem.Value == null)
            {
                _view.ClearButtons();
                return;
            }

            var executors = (_selectedItem.Value as Component)?.GetComponents<ICommandExecutor>().ToList();
            _view.SetButtons(executors);
        }
    }
}