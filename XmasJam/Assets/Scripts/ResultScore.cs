using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text clearScore;

    // Start is called before the first frame update
    void Start()
    {
        clearScore.text = "Score: " + ScoreDirector.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
