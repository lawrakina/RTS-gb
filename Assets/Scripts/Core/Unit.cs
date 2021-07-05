using Abstraction;
using UnityEngine;


namespace Core
{
    public class Unit : MonoBehaviour, ISelectableItem
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health;
        [SerializeField] private Renderer[] _forMaterials;

        public Sprite Icon => _icon;
        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Renderer[] ForMaterials => _forMaterials;

        private void Awake()
        {
            _forMaterials = gameObject.GetComponentsInChildren<MeshRenderer>();
            if (_forMaterials.Length < 1)
            {
                _forMaterials = GetComponentsInChildren<SkinnedMeshRenderer>();
            }
        }
    }
}