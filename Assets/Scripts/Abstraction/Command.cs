using UnityEngine;
using Utils;


namespace Abstraction
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

}