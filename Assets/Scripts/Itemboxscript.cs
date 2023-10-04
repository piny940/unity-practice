using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Itemboxscript : MonoBehaviour
{
    #region //変数を設定
    GameObject Point;
    GameObject Targetmaker;
    Vector3 pointpos;
    Vector3 itempos;
    Vector3 hitpoint;
    Vector3 targetmakerpos;
    List<Vector3> pointslist = new List<Vector3>();
    float spacekey;
    float hitdistance;
    bool ishit;

    #endregion

    void Start()
    {
        Point = GameObject.Find("Point");
        Targetmaker = GameObject.Find("TargetMaker");
        transform.position = new Vector3(Random.Range(-25, 28), Random.Range(3.2f, 13), Random.Range(25, 55));
    }

    void Update()
    {
        Shot();
    }

    /// <summary>
    /// 弾を発射したときの処理
    /// </summary>
    void Shot()
    {
        spacekey = Input.GetAxis("Jump");//キー入力を取得
        if (spacekey > 0 && Gamemanager.instance.time > 0)
        {


            pointpos = Point.transform.position;//標準の座標
            itempos = transform.position;//的の座標
            targetmakerpos = Targetmaker.transform.position;//プレイヤーの座標

            

            //標準と的の距離を測る
            if (Gamemanager.instance.ispointitem)
            {
                //pointitemを取っている場合
                //標準のリストを作る
                MakePoints();

                foreach(Vector3 point in pointslist)
                {
                    HitCheck(point);
                }

            }
            else
            {
                //pointitemを取っていない場合
                HitCheck(pointpos);
            }


            if (ishit)
            {
                Gamemanager.instance.hitnum++;
                Gamemanager.instance.isitem = true;
                ishit = false;
                Destroy(this.gameObject);

            }

        }

        
    }

    /// <summary>
    /// 絶対値を返す
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    float Abs(float x)
    {
        if (x >= 0)
        {
            return x;
        }
        else
        {
            return -x;
        }
    }

    /// <summary>
    ///  45度回転させる
    /// </summary>
    /// <param name="center"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    Vector3 Turn45(Vector3 center, Vector3 point)
    {
        return new Vector3(0.292f * center.x + 0.707f * (center.y + point.x - point.y), center.y + 0.707f * (point.x - center.x + point.y - center.y), point.z);
    }

    /// <summary>
    /// 22.5度回転させる
    /// </summary>
    /// <param name="center"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    Vector3 Turn22_5(Vector3 center, Vector3 point)
    {
        return new Vector3(center.x + (point.x - center.x) * 0.9238f - (point.y - center.y) * 0.3826f, center.y + (point.y - center.y) * 0.9238f + (point.x - center.x) * 0.3826f, point.z);
    }

    /// <summary>
    /// 標準のリストを作る
    /// </summary>
    void MakePoints()
    {
        Vector3 startpoint1 = new Vector3(pointpos.x + 0.35f, pointpos.y, pointpos.z);
        Vector3 startpoint2 = new Vector3(pointpos.x + 0.7f, pointpos.y, pointpos.z);
        pointslist.Add(pointpos);

        //１巡目
        pointslist.Add(startpoint1);
        Vector3 newpoint = startpoint1;
        for (int i = 0; i < 7; i++)
        {
            newpoint = Turn45(pointpos, newpoint);
            pointslist.Add(newpoint);
        }

        //２巡目
        pointslist.Add(startpoint2);
        newpoint = startpoint2;
        for (int i = 0; i < 15; i++)
        {
            newpoint = Turn22_5(pointpos, newpoint);
            pointslist.Add(newpoint);
        }

    }

    /// <summary>
    /// 弾が当たったかどうかを確認する
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    void HitCheck(Vector3 point)
    {
        Vector3 hitpoint = (itempos.z - point.z) / (targetmakerpos.z - point.z) * targetmakerpos + (itempos.z - targetmakerpos.z) / (point.z - targetmakerpos.z) * point;
        if (Abs(hitpoint.x - itempos.x) < transform.localScale.x && Abs(hitpoint.y - itempos.y) < transform.localScale.y)
        {
            ishit = true;
        }
    }

}

