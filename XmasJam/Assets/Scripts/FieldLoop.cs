using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldLoop : MonoBehaviour
{
    [SerializeField] GameObject[] _field;
    [SerializeField] float _fieldMove = 1000.0f;    // ステージを動かす値
    
    private GameObject player;      // プレイヤーを取得
    private Transform playerPos;    // プレイヤーの位置を取得
    private Transform[] transform;  // フィールドの位置を取得
    private float moveLength;       // フィールドの動く長さ
    private float slippage;         // フィールドと原点のずれ

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
            int playerArea = (int)(playerPos.position.x / _fieldMove);                  // プレイヤーの位置する区画
            int fieldArea = (int)((transform[i].position.x - slippage) / _fieldMove);   // フィールドの位置する区画
            // プレイヤーの位置する区画がフィールドの位置する区画より次の区画にいた場合
            if (playerArea > fieldArea)
            {
                transform[i].position += new Vector3(moveLength, 0.0f, 0.0f);
            }
        }
    }
}
