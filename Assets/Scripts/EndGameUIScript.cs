using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameUIScript : MonoBehaviour
{
    public float SEndIn;
    public float EndIn;
    private Image image;
    [Space]
    public string SceneToJump;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        EndIn = -999;
    }

    public void EndGame()
    {
        EndIn = SEndIn;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndIn != -999 && EndIn <= SEndIn)
        {
            EndIn -= Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, (SEndIn-EndIn) / SEndIn);
        }

        if(image.color.a >= 1 && SceneToJump != "")
        {
            SceneManager.LoadScene(SceneToJump);
        }
    }
}
