using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointscript : MonoBehaviour
{
    #region //変数を設定
    float horizontalkey;
    float verticalkey;
    bool pointson;
    [Header("Pointsを入れる")] public GameObject Points;
    #endregion

    private void Start()
    {
        Points.SetActive(false);
    }

    void Update()
    {
        PointMove();
    }

    /// <summary>
    /// 点を動かす関数
    /// </summary>
    void PointMove()
    {
        if (Gamemanager.instance.time > 0 && Gamemanager.instance.started)
        {
            horizontalkey = Input.GetAxis("Horizontal");
            verticalkey = Input.GetAxis("Vertical");

            if (horizontalkey != 0)
            {
                transform.position += new Vector3(horizontalkey * Gamemanager.instance.pointspeed * Time.deltaTime, 0, 0);

            }
            if (verticalkey != 0)
            {
                transform.position += new Vector3(0, verticalkey * Gamemanager.instance.pointspeed * Time.deltaTime, 0);
            }
        }
        
    }

}
