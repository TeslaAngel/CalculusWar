using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform defaultCameraPos;
    [Space]
    private TracingCamera mainCam;
    [Space]
    public GameObject PowerRuleMissile;
    public GameObject ChainRuleMissile;
    public GameObject ProductRuleMissile;
    public GameObject QuotientRuleMissile;
    public GameObject TrigDerivMissile;
    [Space]
    public float timeLimit;
    [Space]
    public string missileLoaded = "";
    public float K = 0;
    [Space]
    public GameObject[] MissileUIs;
    public Text inputK;
    [Space]
    public EndGameUIScript EndGameUI;
    private bool HasEnd = false;
    public Text TimeLimitText;
    [Space]
    public TargetScript targetScript;
    private Transform targetTransform;
    public GameObject emyMis;
    public float emyMisInterval;
    public float emyMisMagInterval;
    private float emyMisLoading;
    private float emyMisMagLoading;
    public int emyMisMagSize;
    private int emyMisMagStorage;
    [Space]
    public List<Transform> EmyMisTrans = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.gameObject.GetComponent<TracingCamera>();
        mainCam.traceTarget = defaultCameraPos;
        targetTransform = targetScript.transform;

        emyMisLoading = emyMisInterval;
        emyMisMagLoading = emyMisMagInterval;
        emyMisMagStorage = emyMisMagSize;
    }

    public void LaunchMissile(string type, float nk)
    {
        timeLimit -= 20;
        switch (type)
        {
            case "power rule":
                PowerRuleMissile.GetComponent<Missile>().k = nk;
                Instantiate(PowerRuleMissile, playerTransform.position, playerTransform.rotation);
                //mainCam.traceTarget = PowerRuleMissile.transform;
                break;

            case "chain rule":
                ChainRuleMissile.GetComponent<Missile>().k = nk;
                Instantiate(ChainRuleMissile, playerTransform.position, playerTransform.rotation);
                //mainCam.traceTarget = ChainRuleMissile.transform;
                break;

            case "product rule":
                ProductRuleMissile.GetComponent<Missile>().k = nk;
                Instantiate(ProductRuleMissile, playerTransform.position, playerTransform.rotation);
                //mainCam.traceTarget = ProductRuleMissile.transform;
                break;

            case "quotient rule":
                QuotientRuleMissile.GetComponent<Missile>().k = nk;
                Instantiate(QuotientRuleMissile, playerTransform.position, playerTransform.rotation);
                //mainCam.traceTarget = QuotientRuleMissile.transform;
                break;

            case "trig deriv":
                TrigDerivMissile.GetComponent<Missile>().k = nk;
                Instantiate(TrigDerivMissile, playerTransform.position, playerTransform.rotation);
                //mainCam.traceTarget = TrigDerivMissile.transform;
                break;
        }
            

            
    }

    public void ManualLaunch()
    {
        LaunchMissile(missileLoaded, K);
    }

    public void LoadMissile(string type)
    {
        DeactiveAllMUI();
        switch (type)
        {
            case "power rule":
                missileLoaded = "power rule";
                MissileUIs[0].SetActive(true);
                break;
            case "chain rule":
                missileLoaded = "chain rule";
                MissileUIs[1].SetActive(true);
                break;
            case "product rule":
                missileLoaded = "product rule";
                MissileUIs[2].SetActive(true);
                break;
            case "quotient rule":
                missileLoaded = "quotient rule";
                MissileUIs[3].SetActive(true);
                break;
            case "trig deriv":
                missileLoaded = "trig deriv";
                MissileUIs[4].SetActive(true);
                break;
        }
    }

    public void AlterK()
    {
        float a = 0;
        if(float.TryParse(inputK.text, out a))
        {
            K = a;
        }
    }

    public void DeactiveAllMUI()
    {
        for(int i = 0; i < MissileUIs.Length; i++)
        {
            MissileUIs[i].SetActive(false);
        }
    }

    public void ViewToDefault()
    {
        mainCam.traceTarget = defaultCameraPos;
    }

    public void ViewToPlayer()
    {
        mainCam.traceTarget = playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit > 0)
            timeLimit -= Time.deltaTime;
        else if(!HasEnd)
        {
            timeLimit = 0;
            EndGameUI.EndGame();
            HasEnd = true;
        }
        if (targetScript.solution.Count <= 0 && !HasEnd)
        {
            EndGameUI.EndGame();
            HasEnd = true;
        }
        if (TimeLimitText)
        {
            TimeLimitText.text = "Remaining time: " + timeLimit + " s";
        }


        //EMY MISSILE ACTION
        for(int i = 0; i < EmyMisTrans.Count; i++)
        {
            Vector3 dis = EmyMisTrans[i].GetComponent<EmyMisScript>().RandomDis;
            Quaternion qua = Quaternion.Slerp(EmyMisTrans[i].rotation, Quaternion.LookRotation((playerTransform.position + dis) - EmyMisTrans[i].position), 1f * Time.deltaTime);
            EmyMisTrans[i].rotation = qua;

        }

        //Missile Launch
        if(emyMisMagLoading <= 0 && emyMisMagStorage <= 0)//load
        {
            emyMisMagLoading = emyMisMagInterval;
            emyMisMagStorage = emyMisMagSize;
        }
        else if(emyMisMagStorage <= 0)
        {
            emyMisMagLoading -= Time.deltaTime;
        }

        if (emyMisLoading <= 0 && emyMisMagStorage > 0)//shoot
        {
            Instantiate(emyMis, targetTransform.position, targetTransform.rotation);
            emyMisLoading = emyMisInterval;
            emyMisMagStorage--;
        }
        else
        {
            emyMisLoading -= Time.deltaTime;
        }

    }
}
