using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandlerScript : MonoBehaviour
{
    public MovementScript ms;

    private InputAction _moveAction, _lookAction, _jumpAction, _dashAction, _flipAction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _dashAction = InputSystem.actions.FindAction("Sprint");
        _flipAction = InputSystem.actions.FindAction("FrontFlip");


        _jumpAction.performed += OnJumpPerformed;
        _flipAction.performed += OnFlipPerformed;
        _dashAction.performed += OnDashPerformed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        Vector2 lookVector = _lookAction.ReadValue<Vector2>();

        ms.Move(movementVector);
        ms.Rotate(lookVector);
    }

    private void FixedUpdate()
    {
      
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        ms.Jump();
    }

    private void OnDashPerformed(InputAction.CallbackContext context)
    {
        ms.DashCall();
    }

    private void OnFlipPerformed(InputAction.CallbackContext context)
    {
        ms.FlipCall();
    }
}
