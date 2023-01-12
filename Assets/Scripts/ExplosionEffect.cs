using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public Rigidbody target;
    public float elapseTime;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        target.AddExplosionForce(force, transform.position, 1f);

        if (elapseTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            elapseTime -= Time.deltaTime;
        }
    }
}
