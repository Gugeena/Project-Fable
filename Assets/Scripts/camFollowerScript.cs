using UnityEngine;

public class camFollowerScript : MonoBehaviour
{
    public Transform _followTarget;
    public float yOffset = 1.5f, zOffset = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_followTarget.position.x, _followTarget.position.y + yOffset, _followTarget.position.z + zOffset);
    }
}
