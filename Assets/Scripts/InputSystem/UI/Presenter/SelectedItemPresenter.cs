﻿using System;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;

namespace InputSystem.UI.Presenter
{
    public class SelectedItemPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemView _view;
        [SerializeField] private SelectedItemModel _model;

        private void Start()
        {
            _model.OnUpdate += UpdateView;
            UpdateView();
        }

        ~SelectedItemPresenter()
        {
            _model.OnUpdate -= UpdateView;
        }

        private void UpdateView()
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