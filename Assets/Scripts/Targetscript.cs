using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Targetscript : MonoBehaviour
{
    #region //変数を設定
    Vector3 pointpos;
    Vector3 targetpos;
    Vector3 targetmakerpos;
    List<Vector3> pointslist = new List<Vector3>();
    float spacekey;
    float hitdistance;
    float hittime;
    bool ishit;
    bool scored;
    bool isshotting;
    SpriteRenderer sp;
    GameObject Point;
    GameObject Targetmaker;
    [Header("ターゲットエフェクトを入れる(点数が高い順)")] public GameObject[] Targeteffects;
    [Header("エフェクトが現れている時間")] public float effecttime;
    [Header("足される点数の規模")] public int pointscale;
    [Header("黄金の的の色")] public Color goldcolor;

    #endregion

    void Start()
    {
        Point = GameObject.Find("Point");
        Targetmaker = GameObject.Find("TargetMaker");
        sp = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(Random.Range(-25, 28), Random.Range(3.2f, 13), Random.Range(25, 55));

    }

    void Update()
    {
        Shot();
        Effect();
        
    }

    /// <summary>
    /// 弾を発射したときの処理
    /// </summary>
    void Shot()
    {
        spacekey = Input.GetAxis("Jump");//キー入力を取得
        if (spacekey > 0 && Gamemanager.instance.time > 0 && !isshotting)
        {
            pointpos = Point.transform.position;//標準の座標
            targetpos = transform.position;//的の座標
            targetmakerpos = Targetmaker.transform.position;//プレイヤーの座標
            
            if (Gamemanager.instance.ispointitem)
            {
                //標準のリストを作る
                MakePoints();

                //標準と的の距離を測る
                hitdistance = HitDistance();

            }
            else
            {
                hitdistance = Distance(pointpos);
            }

            //弾が当たったフラグを立てる
            if (hitdistance < transform.localScale.x)
            {
                ishit = true;

            }

            //弾を打ったフラグを立てる
            isshotting = true;

        }

        //スペースキーを離す時に、弾を打った回数を１増やす
        if (isshotting && spacekey == 0f)
        {
            isshotting = false;
            Gamemanager.instance.gunnum++;
        }
    }


    /// <summary>
    ///  弾が当たった時の処理
    /// </summary>
    void Effect()
    {
        if (ishit)
        {
            sp.color = new Color(1, 1, 1, 0);
            hittime += Time.deltaTime;


            //点数を入れる処理
            if (!scored)
            {
                Gamemanager.instance.hitnum++;

                if (hitdistance < 0.5)//後で要調整
                {
                    Debug.Log(10 * pointscale + "ポイント");
                    Gamemanager.instance.score += 10 * pointscale;
                    Targeteffects[0].gameObject.SetActive(true);

                }
                else if (hitdistance < 1)
                {
                    Debug.Log(5 * pointscale + "ポイント");
                    Gamemanager.instance.score += 5 * pointscale;
                    Targeteffects[1].gameObject.SetActive(true);

                }
                else if (hitdistance < 2)
                {
                    Debug.Log(3 * pointscale + "ポイント");
                    Gamemanager.instance.score += 3 * pointscale;
                    Targeteffects[2].gameObject.SetActive(true);


                }
                else
                {
                    Debug.Log(pointscale + "ポイント");
                    Gamemanager.instance.score += 1 * pointscale;
                    Targeteffects[3].gameObject.SetActive(true);


                }
                scored = true;
            }

            //的を消す処理
            if (hittime > effecttime)
            {
                Destroy(this.gameObject);
            }
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
            newpoint = Turn45(pointpos,newpoint);
            pointslist.Add(newpoint);
        }

        //２巡目
        pointslist.Add(startpoint2);
        newpoint = startpoint2;
        for(int i = 0; i < 15; i++)
        {
            newpoint = Turn22_5(pointpos,newpoint);
            pointslist.Add(newpoint);
        }

    }

    /// <summary>
    /// 着弾点と的の中心の距離を計算する
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    float Distance(Vector3 point)
    {
        Vector3 hitpoint = (targetpos.z - point.z) / (targetmakerpos.z - point.z) * targetmakerpos + (targetpos.z - targetmakerpos.z) / (point.z - targetmakerpos.z) * point;

        return (hitpoint - targetpos).magnitude;
    }

    /// <summary>
    /// distanceの最小値を返す
    /// </summary>
    /// <returns></returns>
    float HitDistance()
    {
        List<float> distancelist = new List<float>();
        foreach (Vector3 point in pointslist)
        {
            distancelist.Add(Distance(point));
        }

        return distancelist.Min();
    }

}