using Abstraction;
using UnityEngine;


namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"Patrol Unit");
        }
    }
}