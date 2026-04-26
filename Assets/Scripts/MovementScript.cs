using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private CharacterController _characterController;
    public float movementSpeed = 10f, rotationSpeed = 1f, jumpForce = 10f, Gravity = -30f;
    private float _rotationY;
    private float _verticalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 moveVec)
    {
        Vector3 move = (transform.forward * moveVec.y + transform.right * moveVec.x).normalized;
        move = move * movementSpeed * Time.deltaTime;
        _characterController.Move(move);

        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
    }

    public void Rotate(Vector2 lookVec)
    {
        _rotationY += lookVec.x * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }

    public void Jump()
    {
        if(_characterController.isGrounded)
        {
            _verticalVelocity = jumpForce;
        }
    }
}
