using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float t;

    // Update is called once per frame
    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
