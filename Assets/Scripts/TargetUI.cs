using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{

    public Transform target;
    private TargetScript targetScript;
    //public float yOffset;

    private Text Ttext;

    // Start is called before the first frame update
    void Start()
    {
        Ttext = GetComponent<Text>();
        targetScript = target.GetComponent<TargetScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (target)
        {
            //Vector2 vec = Camera.main.WorldToScreenPoint(target.position);
            Vector3 vec3 = new Vector3(target.position.x, target.position.y + 2, target.position.z);
            Vector2 vec = Camera.main.WorldToScreenPoint(vec3);
            transform.position = new Vector2(vec.x, vec.y);
            Ttext.text = "x: " + target.position.z + "  y: " + target.position.y + "\n  Emy: Find its Derivative!" + "\n  " + targetScript.Que;
        }
    }
}
