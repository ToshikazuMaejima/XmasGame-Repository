using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;     // �W�����[�h
        Cursor.visible = true;    // �J�[�\���\��
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)
            || Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
