using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위로 계속 이동하고 싶다.
// 필요속성 : 이동속도
public class Bullet : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 위로 계속 이동하고 싶다.
        // 1. 방향이 필요하다.
        Vector3 dir = Vector3.up;
        // 2. 이동하고 싶다.
        // P = P0 + vt
        //Vector3 P0 = transform.position;
        //Vector3 vt = dir * speed * Time.deltaTime;
        //Vector3 P = P0 + vt;
        transform.position += dir * speed * Time.deltaTime;
    }
}
