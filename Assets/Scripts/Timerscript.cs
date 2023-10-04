using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerscript : MonoBehaviour
{
    Text textcomponent;
    float timedisplay;

    // Start is called before the first frame update
    void Start()
    {
        textcomponent = GetComponent<Text>();
        Gamemanager.instance.FinishedTimer = 0f;
        Gamemanager.instance.waitingtime = 0f;
        Gamemanager.instance.time = Gamemanager.instance.limittime;

    }

    // Update is called once per frame
    void Update()
    {
        //待機時間の処理
        if (Gamemanager.instance.waiting)
        {
            Gamemanager.instance.waitingtime += Time.deltaTime;


            if (Gamemanager.instance.waitingtime > 3f)
            {
                Gamemanager.instance.waitingtime = 0f;
                Gamemanager.instance.waiting = false;
                Gamemanager.instance.started = true;
            }
        }

        //制限時間の管理
        if (Gamemanager.instance.started)
        {
            if (Gamemanager.instance.time > 0f)
            {
                Gamemanager.instance.time -= Time.deltaTime;

            }
            timedisplay = Gamemanager.instance.time - Gamemanager.instance.time % 1;
            textcomponent.text = "Time:" + timedisplay;
        }
        

        //終了後の時間の管理
        if (Gamemanager.instance.time <= 0)
        {
            if (Gamemanager.instance.started)
            {
                Gamemanager.instance.started = false;
            }

            Gamemanager.instance.FinishedTimer += Time.deltaTime;
            

        }

    }
}
