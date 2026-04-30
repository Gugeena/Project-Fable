using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private CharacterController _characterController;
    public float movementSpeed = 10f, rotationSpeed = 1f, jumpForce = 10f, Gravity = -30f, dashSpeed = 20f, acceleration = 10f;
    private float _rotationY;
    private float _verticalVelocity;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 moveVec)
    {
        /*
        Vector3 move =
            transform.right * moveVec.x +
            transform.forward * moveVec.y;

        move *= movementSpeed;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        */
        
        Vector3 move = (transform.forward * moveVec.y + transform.right * moveVec.x).normalized;
        move = move * movementSpeed * Time.deltaTime;
        _characterController.Move(move);

        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
    }

    public void Rotate(Vector2 lookVec)
    {
        _rotationY += lookVec.x * rotationSpeed;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }

    public void Jump()
    {
        if(_characterController.isGrounded)
        {
           _verticalVelocity = jumpForce;
        }
    }

    public void DashCall()
    {
        StartCoroutine(Dash());
    }

    public IEnumerator Dash()
    {
        float duration = 0.25f;
        float currTime = 0;

        Vector3 dashDirection = transform.forward;

        while (currTime < duration)
        {
            currTime += Time.deltaTime;
            _characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    public void FlipCall()
    {
        StartCoroutine(Flip());
    }

    public IEnumerator Flip()
    {
        float duration = 1f;
        float elapsed = 0;
        float progress = 0;
        float angle = 0;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            progress = elapsed / duration;

            angle = Mathf.Lerp(0, 360, progress);

            transform.localRotation = Quaternion.Euler(angle, 0, 0);

            yield return null;
        }   
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
