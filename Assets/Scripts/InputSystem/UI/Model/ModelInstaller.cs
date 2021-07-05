using Abstraction;
using UnityEditorInternal;
using UnityEngine;
using Utils;
using Zenject;


namespace InputSystem.UI.Model
{
    public class ModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsStorage _assets;
        [SerializeField] private GroundClickModel _groundClick;
        [SerializeField] private SelectedItemModel _selectClick;

        public override void InstallBindings()
        {
            //From Instance - зависимость разрешится с помощью существующего элемента
            Container.Bind<AssetsStorage>().FromInstance(_assets).AsSingle();
            Container.Bind<GroundClickModel>().FromInstance(_groundClick).AsSingle();
            Container.Bind<SelectedItemModel>().FromInstance(_selectClick).AsSingle();
            
            //без указания - будет создан новый объект
            Container.Bind<ControlButtonPanel>().AsSingle();
            Container.Bind<CommandCreator<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IAttackCommand>>().To<AttackUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IMoveCommand>>().To<MoveUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IPatrolCommand>>().To<PatrolCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IStopCommand>>().To<StopCommandCreator>().AsSingle();
        }
    }
}