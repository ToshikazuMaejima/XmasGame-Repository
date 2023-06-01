using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaController : MonoBehaviour
{
    public GameObject Present;
    //カメラ
    public GameObject Camera;
    //Xの移動制限
    //18だとちょうどいい感じでした
    public float RestrictionX = 18f;
    public float MoveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0)
        {
            return;
        }

        Vector3 pos = gameObject.transform.position;
        pos.y += -1.5f;  
        
        float x = Input.GetAxis("Move") * MoveSpeed;
        transform.Translate(0f, 0f, x);

        if (Input.GetButtonDown("Action"))
        {
            Instantiate(Present, pos, Quaternion.identity);
        }

        //カメラのポジションとサンタのポジションの差の絶対値が制限距離より大きかったら
        if(Mathf.Abs(Camera.transform.position.x-transform.position.x)>=RestrictionX)
        {
            float returnposX = transform.position.x - Camera.transform.position.x;
            returnposX = Mathf.Clamp(returnposX, -1, 1);

            //サンタのポジションをカメラのポジションに移す
            transform.position = new Vector3(Camera.transform.position.x + RestrictionX * returnposX, transform.position.y, transform.position.z);
        }
    }
}
