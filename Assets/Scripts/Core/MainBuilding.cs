using Abstraction;
using UnityEngine;


namespace Core
{
    public class MainBuilding : MonoBehaviour, ISelectableItem
    {
        #region Fields

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health;
        [SerializeField] private MeshRenderer[] _forMaterials;

        #endregion


        #region Properties

        public Sprite Icon => _icon;
        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public MeshRenderer[] ForMaterials => _forMaterials;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _forMaterials = gameObject.GetComponentsInChildren<MeshRenderer>();
        }

        #endregion
    }
}