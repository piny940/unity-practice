using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbackgroundscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(484,790, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 270)
        {
            transform.position -= new Vector3(0, 30, 0);

        }
        if (Gamemanager.instance.started)
        {
            gameObject.SetActive(false);
        }


    }

    
}
