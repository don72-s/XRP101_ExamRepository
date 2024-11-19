using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;//수정1 (추가)

    public float MoveSpeed
    {
        //수정2 (변경)
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
