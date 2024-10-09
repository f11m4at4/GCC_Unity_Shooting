using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 녀석을 없애고 싶다.
        // 만약 총알이라면 탄창에 다시 넣어줘야한다.
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 비활성화 시켜준다.
            other.gameObject.SetActive(false);
            // 탄창에 넣어주자.
            GameObject player = GameObject.Find("Player");
            // 만약 플레이어가 있다면
            if(player)
            {
                PlayerFire pf = player.GetComponent<PlayerFire>();
                pf.bulletObjectPool.Add(other.gameObject);
            }
        }
        else if(other.gameObject.name.Contains("Enemy"))
        {
            // 비활성화 시켜준다.
            other.gameObject.SetActive(false);
            // 적 오브젝트풀에 넣어주자.
            GameObject em = GameObject.Find("EnemyManager");
            // 만약 플레이어가 있다면
            if (em)
            {
                EnemyManager manager = em.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            // 너도 죽고
            Destroy(other.gameObject);
        }
    }
}
