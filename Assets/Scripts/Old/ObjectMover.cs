using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
