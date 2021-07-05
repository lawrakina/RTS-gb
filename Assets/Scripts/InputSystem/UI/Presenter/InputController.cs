using Abstraction;
using InputSystem.UI.Model;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InputSystem.UI.Presenter
{
    public class InputController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectedItemModel _currentSelected;
        [SerializeField] private GroundClickModel _currentGroundClick;

        #endregion


        #region UnityMethods

        private void Update()
        {
            if(_eventSystem.IsPointerOverGameObject()){ return;}
            
            // select object in left click mouse
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                {
                    var selectableItem = hitInfo.collider.gameObject.GetComponent<ISelectableItem>();
                    if (selectableItem != null)
                    {
                        _currentSelected.SetValue(selectableItem);
                    }
                    else
                    {
                        _currentSelected.SetValue(null);
                    }
                }
            }

            // moving to right click mouse
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                {
                    // if(hitInfo.transform.GetComponents<>())
                    _currentGroundClick.SetValue(hitInfo.point);
                }
            }
        }

        #endregion
    }
}