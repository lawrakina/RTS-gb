using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction;
using UnityEngine;
using UnityEngine.UI;


namespace InputSystem.UI.View
{
    public class ControlButtonPanelView : MonoBehaviour
    {
        [SerializeField] private Button _produceUnitButton;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _patrolButton;
        [SerializeField] private Button _stopButton;

        private Dictionary<Type, Button> _executorToButtons;
        public Action<ICommandExecutor> _onClick;

        private void Awake()
        {
            _executorToButtons = new Dictionary<Type, Button>()
            {
                {typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton},
                {typeof(CommandExecutorBase<IMoveCommand>), _moveButton},
                {typeof(CommandExecutorBase<IAttackCommand>), _attackButton},
                {typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton},
                {typeof(CommandExecutorBase<IStopCommand>), _stopButton}
            };
        }

        public void SetButtons(List<ICommandExecutor> commandExecutors)
        {
            foreach (var executor in commandExecutors)
            {
                var button =
                    _executorToButtons.FirstOrDefault(kvp => kvp.Key.IsInstanceOfType(executor)).Value;
                if (button == null)
                {
                    Debug.LogError($"Executor is not supported");
                    continue;
                }

                button.gameObject.SetActive(true);
                button.onClick.AddListener(()=> _onClick?.Invoke(executor));
            }
        }

        public void ClearButtons()
        {
            foreach (var button in _executorToButtons.Values)
            {
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
            }
        }
    }
}