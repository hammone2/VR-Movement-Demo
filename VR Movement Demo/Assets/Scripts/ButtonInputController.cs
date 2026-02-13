using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonInputController : MonoBehaviour
{

    public InputActionReference triggerAction;

    public UnityEvent ButtonDownEvent;
    public UnityEvent ButtonUpEvent;

    private void OnEnable()
    {
        triggerAction.action.performed += OnButtonDown;
        triggerAction.action.canceled += OnButtonUp;
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.performed -= OnButtonDown;
        triggerAction.action.canceled -= OnButtonUp;
    }

    private void OnButtonDown(InputAction.CallbackContext ctx)
    {
        ButtonDownEvent.Invoke();
        Debug.Log("button down");
    }

    private void OnButtonUp(InputAction.CallbackContext ctx)
    {
        ButtonUpEvent.Invoke();
        Debug.Log("button released");
    }
}