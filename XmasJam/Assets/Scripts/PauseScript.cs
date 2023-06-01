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
        OnMenu.SetActive(true);        // PanelMenuをtrueにする
        Time.timeScale = 0;
        pauseGame = true;

        Cursor.lockState = CursorLockMode.None;     // 標準モード
        Cursor.visible = true;    // カーソル表示
    }

    public void OnUnPause()
    {
        OnMenu.SetActive(false);       // PanelMenuをfalseにする
        Time.timeScale = 1;
        pauseGame = false;

        Cursor.lockState = CursorLockMode.Locked;   // 中央にロック
        Cursor.visible = false;     // カーソル非表示
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
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
                Application.Quit();//ゲームプレイ終了
#endif
    }
}
