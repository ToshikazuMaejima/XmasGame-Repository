using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyController : MonoBehaviour
{
    [SerializeField, Range(0, 999)] int _disappearNum;

    private int colNum;
    private Vector3 smoll;
    private Vector3 rotate;

    private GameObject scoreDirector;
    private bool isDestroy;

    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        colNum = 0;
        smoll = new Vector3(1.0f, 0, 1.0f);
        rotate = new Vector3(0, 540.0f, 0);

        scoreDirector = GameObject.Find("ScoreDirector");
        isDestroy = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_disappearNum == colNum)
        {
            if (!isDestroy)
            {
                isDestroy = true;
                scoreDirector.GetComponent<ScoreDirector>().ComboUp();
                scoreDirector.GetComponent<ScoreDirector>().ScoreUp();
                audioSource.PlayOneShot(sound1);
            }

            StartCoroutine(Disappear());
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (_disappearNum == 0) // 0à»äOÇæÇ¡ÇΩèÍçáÇ…èàóùÇé¿çsÇ∑ÇÈ
            return;

        if (other.CompareTag("Present"))
        {
            if (_disappearNum != colNum)
                colNum++;
        }

        if (colNum >= _disappearNum)
            return;

        if (other.CompareTag("LeftWall"))
        {
            scoreDirector.GetComponent<ScoreDirector>().ResetCombo();
        }

    }

    private IEnumerator Disappear() // èôÅXÇ…è¡Ç¶ÇÈ
    {
        gameObject.layer = 5;
        gameObject.transform.localScale -= smoll * Time.deltaTime;
        gameObject.transform.Rotate(rotate * Time.deltaTime, Space.World);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
