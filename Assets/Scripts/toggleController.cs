using UnityEngine;
using System.Collections;

public class toggleController : MonoBehaviour {

    public Vector3 rotationDirection = new Vector3(0, 1, 0);
    public float speed = 100f;


    void Update()
    {
        Rotation(rotationDirection, speed);
    }

    void Rotation(Vector3 rotationDirection, float speed)
    {
        transform.RotateAround(transform.position, rotationDirection, Time.deltaTime * speed);
    }
}
