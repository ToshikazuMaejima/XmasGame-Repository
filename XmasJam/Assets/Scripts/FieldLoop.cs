using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldLoop : MonoBehaviour
{
    [SerializeField] GameObject[] _field;
    [SerializeField] float _fieldMove = 1000.0f;    // �X�e�[�W�𓮂����l
    
    private GameObject player;      // �v���C���[���擾
    private Transform playerPos;    // �v���C���[�̈ʒu���擾
    private Transform[] transform;  // �t�B�[���h�̈ʒu���擾
    private float moveLength;       // �t�B�[���h�̓�������
    private float slippage;         // �t�B�[���h�ƌ��_�̂���

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;
        transform = new Transform[_field.Length];
        for (int i = 0; i < _field.Length; i++)
        {
            transform[i] = _field[i].GetComponent<Transform>();
        }
        moveLength = _fieldMove * _field.Length;
        slippage = transform[0].position.x;
    }

    void Update()
    {
        for (int i = 0; i < _field.Length; i++)
        {
            int playerArea = (int)(playerPos.position.x / _fieldMove);                  // �v���C���[�̈ʒu������
            int fieldArea = (int)((transform[i].position.x - slippage) / _fieldMove);   // �t�B�[���h�̈ʒu������
            // �v���C���[�̈ʒu�����悪�t�B�[���h�̈ʒu�������莟�̋��ɂ����ꍇ
            if (playerArea > fieldArea)
            {
                transform[i].position += new Vector3(moveLength, 0.0f, 0.0f);
            }
        }
    }
}
