using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{
    public float swingDelta;
    public float swingInterval;

    private float a = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        float delta = Mathf.Sin(a * swingInterval) * swingDelta;
        transform.localPosition += new Vector3(0, delta, 0) * Time.deltaTime;
    }
}
