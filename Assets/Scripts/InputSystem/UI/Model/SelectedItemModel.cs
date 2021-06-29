using System;
using Abstraction;
using UnityEngine;


namespace InputSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectedItemModel), menuName = "Strategy/" + nameof(SelectedItemModel),
        order = 1)]
    public class SelectedItemModel : ScriptableObject
    {
        #region Fields

        private ISelectableItem _value;

        public event Action<ISelectableItem> OnUpdate;

        #endregion


        #region Properties

        public ISelectableItem Value => _value;

        #endregion


        public void SetValue(ISelectableItem value)
        {
            _value = value;
            OnUpdate?.Invoke(_value);
        }
    }
}