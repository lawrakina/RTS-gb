using UnityEngine;


namespace Abstraction
{
    public interface ISelectableItem
    {
        Sprite Icon { get; }
        string Name { get; }
        float Health { get; }
        float MaxHealth { get; }
        Renderer[] ForMaterials { get; }
    }
}