using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbuttonscript : MonoBehaviour
{
    public void StartPush()
    {
        Gamemanager.instance.waiting = true;
    }
}
