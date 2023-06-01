using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHome : MonoBehaviour
{
    //カウント
    float TimeCount = 10;
    //家を生成するまでのクールタイム
    float CoolTime = 8;
    //家の配列
    public GameObject[] Home = new GameObject[3];
    //カメラ
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        CoolTime=Random.Range(3,5);
        TimeCount += Time.deltaTime;
        if(TimeCount>=CoolTime)
        {
            int RandomNum=Random.Range(0, 3);
            Instantiate(Home[RandomNum], new Vector3(Camera.transform.position.x+50f, 4.5f, 0f),Quaternion.identity);
            TimeCount=0;
        }
    }
}
