using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyMisScript : MonoBehaviour
{
    public float acForce;
    public Vector3 RandomDis;
    public float Dis;
    //private Rigidbody Prigidbody;
    public GameObject Explo;
    private GameController GC;

    private float DestroyTime = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
            return;

        Instantiate(Explo, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Prigidbody = GetComponent<Rigidbody>();
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GC.EmyMisTrans.Add(transform);
        RandomDis = new Vector3(Random.Range(-Dis, Dis), Random.Range(-Dis, Dis), Random.Range(-Dis, Dis));
    }
    private void OnDestroy()
    {
        GC.EmyMisTrans.Remove(transform);
    }
    // Update is called once per frame
    void Update()
    {
        //Prigidbody.AddRelativeForce(0, 0, acForce * Time.deltaTime);
        transform.Translate(0, 0, acForce * Time.deltaTime);

        if (DestroyTime > 0)
        {
            DestroyTime -= Time.deltaTime;
        }
        else
        {
            Instantiate(Explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
