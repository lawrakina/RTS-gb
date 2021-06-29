using Abstraction;
using UnityEngine;


namespace Core.CommandExecutors
{
    public class ProduceCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Debug.Log($"Execute Produce Unit");
            Instantiate(command.UnitPrefab, transform.position + Vector3.forward * 2, Quaternion.identity);
        }
    }
}