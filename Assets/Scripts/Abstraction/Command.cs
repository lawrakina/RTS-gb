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
        public Vector3 To { get; }

        public MoveUnitCommand(Vector3 to)
        {
            To = to;
        }
    }

    public class AttackUnitCommand : IAttackCommand
    {
        public IAttackable Target { get; }
     
        public AttackUnitCommand(IAttackable value)
        {
            Target = value;
            Debug.Log($"AttackUnitCommand execute");
        }
    }

    public class PatrolCommand : IPatrolCommand
    {
        public PatrolCommand(Vector3 from, Vector3 to)
        {
            From = from;
            To = to;
        }

        public Vector3 From { get; }
        public Vector3 To { get; }
    }

    public class StopCommand : IStopCommand
    {
    }
}