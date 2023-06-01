using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
	private Text timerText;

	public float totalTime;
	int seconds;

	// Use this for initialization
	void Start()
	{
		timerText = GameObject.Find("Timer").GetComponent<Text>();
		seconds = 0;
	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text = "Žc‚èŽžŠÔ: " + seconds.ToString();

		if(seconds <= 0)
        {
			SceneManager.LoadScene("EndScene");
		}

	}

}