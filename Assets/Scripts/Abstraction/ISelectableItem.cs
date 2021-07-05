using UnityEngine;


namespace Abstraction
{
    public interface ISelectableItem : IHealthHolder
    {
        Sprite Icon { get; }
        string Name { get; }
        Renderer[] ForMaterials { get; }
    }
}