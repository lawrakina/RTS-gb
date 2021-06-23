using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;

namespace InputSystem.UI.Presenter
{
    public class SelectedItemPresenter : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SelectedItemView _view;
        [SerializeField] private SelectedItemModel _model;

        #endregion


        #region ClassLiveCycles

        private void Start()
        {
            _model.OnUpdate += UpdateView;
            UpdateView(null);
        }

        ~SelectedItemPresenter()
        {
            _model.OnUpdate -= UpdateView;
        }

        #endregion

        private void UpdateView(ISelectableItem value)
        {
            if (_model.Value == null)
            {
                _view.gameObject.SetActive(false);
                return;
            }

            _view.gameObject.SetActive(true);
            
            _view.Icon = _model.Value.Icon;
            _view.Name = _model.Value.Name;
            _view.Health = $"Health: {_model.Value.Health} / {_model.Value.MaxHealth}" ;
            _view.HealthPercent = _model.Value.Health / _model.Value.MaxHealth;
        }
    }
}