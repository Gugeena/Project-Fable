using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandlerScript : MonoBehaviour
{
    public MovementScript ms;

    private InputAction _moveAction, _lookAction, _jumpAction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _jumpAction.performed += OnJumpPerformed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveAction == null) print("null");
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        Vector2 lookVector = _lookAction.ReadValue<Vector2>();

        ms.Move(movementVector);
        ms.Rotate(lookVector);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        ms.Jump();
    }
}
