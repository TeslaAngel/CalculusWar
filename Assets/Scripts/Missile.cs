using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public float k;
    public string missileType;
    public float AngularOffset;

    public float horizontalVelocity;
    public float horizontalVelocityDelta;

    public GameObject explosionEffect;
    public GameObject particleEffect;

    private float T = 5;
    private bool cameTar = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            explosionEffect.GetComponent<ExplosionEffect>().target = other.GetComponent<Rigidbody>();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Instantiate(particleEffect, transform.position, transform.rotation);

            if(other.GetComponent<TargetScript>().solution[0] == missileType)
            {
                other.GetComponent<TargetScript>().solution.RemoveAt(0);
            }

            Destroy(gameObject);
        }
    }

    void SyncWithFunction()
    {
        Vector3 pos = transform.position;
        if (missileType == "power rule")
        {
            //adjusting position
            pos.y = Mathf.Sin(pos.z) /*need to be substituted*/ + k * pos.z;
            //adjusting rotation
            Vector3 LookTarget = new Vector3(0, Mathf.Sin(pos.z+0.1f) /*need to be substituted*/ + k * (pos.z + 0.1f), pos.z+0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookTarget - transform.position), AngularOffset * Time.deltaTime);
        }
        else if (missileType == "chain rule")
        {
            //adjusting position
            pos.y = Mathf.Exp(1/pos.z) /*need to be substituted*/ + k * pos.z;
            //adjusting rotation
            float fpos = pos.z + 0.1f;
            Vector3 LookTarget = new Vector3(0, Mathf.Exp(1 / fpos) /*need to be substituted*/ + k * (fpos), fpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookTarget - transform.position), AngularOffset * Time.deltaTime);
        }
        else if (missileType == "product rule")
        {
            //adjusting position
            pos.y = Mathf.Log(pos.z)* Mathf.Log(pos.z) /*need to be substituted*/ + k * pos.z;
            //adjusting rotation
            float fpos = pos.z + 0.1f;
            Vector3 LookTarget = new Vector3(0, Mathf.Log(fpos) * Mathf.Log(fpos) /*need to be substituted*/ + k * (fpos), fpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookTarget - transform.position), AngularOffset * Time.deltaTime);
        }
        else if (missileType == "quotient rule")
        {
            //adjusting position
            pos.y = Mathf.Cos(pos.z)/ Mathf.Exp(pos.z) /*need to be substituted*/ + k * pos.z;
            //adjusting rotation
            float fpos = pos.z + 0.1f;
            Vector3 LookTarget = new Vector3(0, Mathf.Cos(fpos) / Mathf.Exp(fpos) /*need to be substituted*/ + k * (fpos), fpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookTarget - transform.position), AngularOffset * Time.deltaTime);
        }
        else if (missileType == "trig deriv")
        {
            //adjusting position
            pos.y = Mathf.Atan(pos.z) /*need to be substituted*/ + k * pos.z;
            //adjusting rotation
            Vector3 LookTarget = new Vector3(0, Mathf.Atan(pos.z + 0.1f) /*need to be substituted*/ + k * (pos.z + 0.1f), pos.z + 0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookTarget - transform.position), AngularOffset * Time.deltaTime);
        }

        transform.position = pos;
    }

    void Forward()
    {
        Vector3 pos = transform.position;
        pos.z += horizontalVelocity*Time.deltaTime;
        transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
        SyncWithFunction();

        horizontalVelocity += horizontalVelocityDelta * Time.deltaTime;

        T -= Time.deltaTime;
        if (T <= 0)
        {
            Destroy(gameObject);
        }
        if (T <= 4 && !cameTar)
        {
            Camera.main.GetComponent<TracingCamera>().traceTarget = transform;
            cameTar = true;
        }
    }
}