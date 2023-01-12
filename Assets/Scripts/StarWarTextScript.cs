using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarWarTextScript : MonoBehaviour
{
    public float RollingSpeed;
    public EndGameUIScript EndGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, RollingSpeed * Time.deltaTime, 0);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            EndGameUI.EndGame();
        }
    }
}
