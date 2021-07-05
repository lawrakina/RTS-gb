using UnityEngine;
using Utils;


namespace Abstraction
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

    public class MoveUnitCommand : IMoveCommand
    {
        public MoveUnitCommand(Vector3 to)
        {
            To = to;
        }

        public Vector3 To { get; }
    }

    public class AttackCommand : IAttackCommand
    {
        public GameObject Target { get; }
    }

    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 From { get; }
        public Vector3 To { get; }
    }

    public class StopCommand : IStopCommand
    {
    }
}