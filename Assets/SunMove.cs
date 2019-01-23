using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 axisRotation;

    // Start is called before the first frame update
    void Start()
    {
        axisRotation = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axisRotation, speed * Time.deltaTime);
    }
}
