using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    //�e�L�X�g�̕ϐ�
    public Text scoreText;
    public GameObject comboObj;
    public Text comboText;
    public GameObject Present;
    //�X�R�A��
    public static int score;

    private int point;
    private int comboNum;
    public int combo;
    // Start is called before the first frame update
    void Start()
    {
        comboObj.SetActive(false);
        score = 0;
        point = 50;
        combo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (combo >= 15)
        {
            comboObj.SetActive(true);
            comboText.text = "Combo + " + comboNum;
        }
        else
        {
            comboObj.SetActive(false);
        }
    }
    
    public void ScoreUp()
    {
        score += point + combo;
    }

    public void ComboUp()
    {
        comboNum++;
        combo += 15;
    }

    public void ResetCombo()
    {
        comboNum = 0;
        combo = 0;
    }
}
