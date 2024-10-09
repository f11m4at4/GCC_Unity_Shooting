using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력을 받아서 플레이어를 이동시키고 싶다.
        // 1. 방향을 구한다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        // 이동시킨다.
        // P = P0 + vt
        Vector3 P0 = transform.position;
        Vector3 vt = dir * speed * Time.deltaTime;
        Vector3 P = P0 + vt;
        transform.position = P;
    }
}
