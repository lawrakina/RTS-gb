using System;
using Abstraction;
using UnityEngine;


namespace InputSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectedItemModel), menuName = "Strategy/Models/SelectedItemModel", order = 1)]
    public class SelectedItemModel : ScriptableObject
    {
        private ISelectableItem _value;
        public ISelectableItem Value => _value;


        public void SetValue(ISelectableItem value)
        {
            _value = value;
            OnUpdate?.Invoke();
        }

        public event Action OnUpdate;
    }
}