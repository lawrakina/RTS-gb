using Abstraction;
using UnityEngine;
using UnityEngine.AI;


namespace Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private NavMeshAgent _agent;
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            _agent.SetDestination(command.To);
            Debug.Log($"Move Unit");
        }
    }
}