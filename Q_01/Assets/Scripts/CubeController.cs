using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; /*private 변경 2 ( 제거 ) */ set; }

    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
