using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [HideInInspector] public int score;
    [Header("制限時間")] public float limittime;
    [HideInInspector]public float FinishedTimer;
    [HideInInspector] public float time;
    [HideInInspector] public bool started;
    [HideInInspector] public bool waiting;
    [HideInInspector] public float waitingtime;
    [HideInInspector] public int gunnum;
    [HideInInspector] public int hitnum;
    [HideInInspector] public float hitpercent;
    [HideInInspector] public float pointspeed;
    [HideInInspector] public bool isitem;
    [HideInInspector] public bool ispointitem;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        pointspeed = 3f;
    }
    

}
