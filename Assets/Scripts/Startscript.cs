using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscript : MonoBehaviour
{
   
    public void StartPush()
    {
        SceneManager.LoadScene("Stage1");
    }
}
