using System;
using Abstraction;
using UnityEngine;


namespace InputSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectedItemModel), menuName = "Strategy/" + nameof(SelectedItemModel),
        order = 1)]
    public class SelectedItemModel : ScriptableObject
    {
        private ISelectableItem _value;

        public Action<ISelectableItem> OnUpdate;


        public ISelectableItem Value => _value;


        public void SetValue(ISelectableItem value)
        {
            _value = value;
            OnUpdate?.Invoke(_value);
        }
    }
}