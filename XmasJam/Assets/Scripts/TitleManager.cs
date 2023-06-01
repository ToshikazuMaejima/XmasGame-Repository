using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject StartButton;
    private TextMeshProUGUI startText;
    private GameObject CatSceneTimeLine;

    private bool OnStertButton;
    private bool alphaChange;
    private byte alphavalue;


    // Start is called before the first frame update
    void Start()
    {
        startText = StartButton.transform.Find("StartText").GetComponent<TextMeshProUGUI>();
        CatSceneTimeLine = GameObject.Find("TitleCutScene");
        Title.SetActive(false);
        StartButton.SetActive(false);
        CatSceneTimeLine.SetActive(true);
        OnStertButton = false;
        alphaChange = false;
        alphavalue = 255;

        Cursor.lockState = CursorLockMode.None;     // 標準モード
        Cursor.visible = true;    // カーソル表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) 
            || Input.GetKeyDown(KeyCode.Return) 
            || Input.GetKeyDown(KeyCode.Mouse0))
        {
            CatSceneTimeLine.SetActive(false);
            OnStartBottonActive();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OnStertButton)
        {
            if (alphavalue <= 0)
                alphaChange = true;
            else if (alphavalue >= 255)
                alphaChange = false;

            if (alphaChange)
                alphavalue++;
            else
                alphavalue--;

            startText.color = new Color32(255, 255, 255, alphavalue);
        }
    }

    public void OnStartBottonActive()
    {
        Title.SetActive(true);
        StartButton.SetActive(true);
        OnStertButton = true;
    }
}
