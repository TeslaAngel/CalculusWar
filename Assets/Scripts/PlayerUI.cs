using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Transform player;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 vec3 = new Vector3(player.position.x, player.position.y + 2, player.position.z);
            Vector2 vec = Camera.main.WorldToScreenPoint(vec3);
            transform.position = new Vector2(vec.x, vec.y);
        }
    }
}
