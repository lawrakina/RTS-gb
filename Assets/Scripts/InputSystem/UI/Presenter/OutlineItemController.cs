using System.Collections.Generic;
using System.Linq;
using Abstraction;
using InputSystem.UI.Model;
using UnityEngine;


namespace InputSystem.UI.Presenter
{
    public class OutlineItemController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private Material _outLineMaterial;
        private ISelectableItem _value;

        #endregion


        #region ClassLiveCycles

        private void Start()
        {
            _model.OnUpdate += ModelOnOnUpdate;
        }

        ~OutlineItemController()
        {
            _model.OnUpdate -= ModelOnOnUpdate;
        }

        #endregion


        #region Methods

        private void ModelOnOnUpdate(ISelectableItem value)
        {
            if (_value != null)
            {
                foreach (var renderer in _value.ForMaterials)
                {
                    var list = renderer.materials
                        .Where(material => material.shader.name != _outLineMaterial.shader.name).ToList();
                    renderer.materials = list.ToArray();
                }
            }

            _value = value;

            foreach (var renderer in _value.ForMaterials)
            {
                var list = new List<Material>();
                list.Add(_outLineMaterial);
                list.AddRange(renderer.materials);

                renderer.materials = list.ToArray();
            }
        }

        #endregion
    }
}