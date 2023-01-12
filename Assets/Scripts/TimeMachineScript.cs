using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TimeMachineScript : MonoBehaviour
{
    public GameObject GamePanel;
    [Space]
    public GameObject VideoF1;
    public GameObject VideoF2;
    public GameObject M4;

    public void ReturnToGame()
    {
        GamePanel.SetActive(true);
        VideoF1.SetActive(false);
        VideoF2.SetActive(false);
    }

    public void PlayVF1()
    {
        GamePanel.SetActive(false);
        VideoF1.SetActive(true);
        VideoF2.SetActive(false);
        M4.SetActive(false);
    }

    public void PlayVF2()
    {
        GamePanel.SetActive(false);
        VideoF1.SetActive(false);
        VideoF2.SetActive(true);
        M4.SetActive(false);
    }

    public void PlayVM4()
    {
        GamePanel.SetActive(false);
        VideoF1.SetActive(false);
        VideoF2.SetActive(false);
        M4.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayVF1();
        }
        if (Input.GetKey(KeyCode.F2) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayVF2();
        }
        if (Input.GetKey(KeyCode.F4) && Input.GetKey(KeyCode.LeftAlt))
        {
            PlayVM4();
        }

        if (VideoF1.GetComponent<VideoPlayer>().isPaused)
        {
            ReturnToGame();
        }

        if (VideoF2.GetComponent<VideoPlayer>().isPaused)
        {
            ReturnToGame();
        }

        if (M4.GetComponent<VideoPlayer>().isPaused)
        {
            ReturnToGame();
        }
    }
}
