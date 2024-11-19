using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;//����1 (�߰�)

    public float MoveSpeed
    {
        //����2 (����)
        //get => MoveSpeed;
        //private set => MoveSpeed = value;*/
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
