using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentController : MonoBehaviour
{
    public float DropSpeed = 0.1f;
    [SerializeField] GameObject _inEffect;
    [SerializeField] GameObject _outEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        transform.Translate(0f, DropSpeed*-1f, 0f);
        if(transform.position.y<-50f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chimney"))
        {
            Destroy(gameObject);

            Effect(_inEffect);
            Effect(_inEffect);
            Effect(_inEffect);
        }
        else
        {
            Effect(_outEffect);
        }
    }

    void Effect(GameObject _effect)
    {
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(_effect);
        //�G�t�F�N�g����������ꏊ�����肷��
        effect.transform.position = gameObject.transform.position;
    }
}
