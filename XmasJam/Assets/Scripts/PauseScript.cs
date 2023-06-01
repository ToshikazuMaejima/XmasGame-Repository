using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject OnMenu;
    private bool pauseGame = false;

    void Start()
    {
        OnUnPause();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
            }
            else
            {
                OnUnPause();
            }
        }
    }

    public void OnPause()
    {
        OnMenu.SetActive(true);        // PanelMenu��true�ɂ���
        Time.timeScale = 0;
        pauseGame = true;

        Cursor.lockState = CursorLockMode.None;     // �W�����[�h
        Cursor.visible = true;    // �J�[�\���\��
    }

    public void OnUnPause()
    {
        OnMenu.SetActive(false);       // PanelMenu��false�ɂ���
        Time.timeScale = 1;
        pauseGame = false;

        Cursor.lockState = CursorLockMode.Locked;   // �����Ƀ��b�N
        Cursor.visible = false;     // �J�[�\����\��
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
        OnUnPause();
    }

    public void OnResume()
    {
        OnUnPause();
    }

    public void OnTitle()
    {        
        OnUnPause();
        SceneManager.LoadScene("TitleScene");
    }

    public void OnEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
                Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
