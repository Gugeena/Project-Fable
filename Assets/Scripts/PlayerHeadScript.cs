using UnityEngine;

public class PlayerHeadScript : MonoBehaviour
{
    public Transform bodyTransform;

    [Header("Camera Rotation")]
    public float upperLookBound;
    public float lowerLookBound;

    [Header("Movement")]
    public float moveSpeed;

    private Quaternion camRotation;
    void Start()
    {

    }


    void Update()
    {
        handleRotation();
    }

    void handleRotation()
    {
        float xRot = Input.GetAxis("Mouse X");

        if (xRot != 0)
        {
            camRotation.y += xRot;
            bodyTransform.Rotate(0, xRot, 0);
        }

        float yRot = Input.GetAxis("Mouse Y");

        if (yRot != 0)
        {
            //transform.Rotate(0, 0, yRot);
            camRotation.z += yRot;
        }

        camRotation.z = Mathf.Clamp(camRotation.z, lowerLookBound, upperLookBound);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);

    }
}
