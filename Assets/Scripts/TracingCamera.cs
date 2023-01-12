using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCamera : MonoBehaviour
{

    public float LerpDelta;
    public Transform traceTarget;
    public Vector3 relativePos;

    private float CameraShake = 0;

    public Transform DefaultTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        relativePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (traceTarget)
        {
            transform.position = Vector3.Lerp(transform.position, traceTarget.position + relativePos, LerpDelta);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, DefaultTarget.position + relativePos, LerpDelta);
        }
    }
}
