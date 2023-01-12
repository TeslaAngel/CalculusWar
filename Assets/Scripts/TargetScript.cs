using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public List<string> solution = new List<string>();
    private Rigidbody rigidbody;
    public string Que;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (solution.Count <= 0)
        {
            rigidbody.AddForce(0, -9.8f, 0);
        }
    }
}
