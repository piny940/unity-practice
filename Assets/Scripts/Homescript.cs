using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homescript : MonoBehaviour
{
    public void HomePush()
    {
        SceneManager.LoadScene("Home");
    }
}
