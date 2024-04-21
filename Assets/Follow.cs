using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // target이라는 좌표로 이동 시키려고 하는 것
    public Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
