using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날때 한번 방향을 구하고 그리로 계속 이동하고 싶다.
public class Enemy : MonoBehaviour
{
    // 필요속성 : 이동속도
    public float speed = 5;
    // 타겟
    public Transform target;
    Vector3 dir;
    // 폭발공장
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // 타겟을 찾아야한다.
        GameObject player = GameObject.Find("Player");
        // 만약 Player 가 있다면 타겟에 값을 넣어주자
        if(player)
        {
            target = player.transform;
        }

        // 확률을 구해야 한다.
        int percent = Random.Range(1, 10);
        // 타겟이 있고 확률이 30퍼센터 안에 들어오면
        if(target && percent <= 3)
        {
            // 30% 의 확률로 타겟쪽으로 방향을 구하고
            dir = target.position - transform.position;
            dir.Normalize();
        }
        // 그렇지 않으면 그냥 아래로 방향을 설정하자
        else
        {
            dir = Vector3.down;
        }
        //  태어날때 한번 방향을 구하고
    }

    // Update is called once per frame
    void Update()
    {
        // 계속 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    // 다른 물체와 부딪히면 너도 죽고 나도 죽고싶다.
    private void OnCollisionEnter(Collision other)
    {
        // 부딪혔을때 점수를 증가시키고 싶다.
        // 3. ScoreManager 의 Get/Set 함수를 이용해서 값 설정
        ScoreManager.Instance.Score++;

        // 폭발효과를 발생시키고 싶다.
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // 만약 총알이라면 탄창에 다시 넣어줘야한다.
        if(other.gameObject.name.Contains("Bullet"))
        {
            // 비활성화 시켜준다.
            other.gameObject.SetActive(false);
            // 탄창에 넣어주자.
            GameObject player = GameObject.Find("Player");
            // 만약 플레이어가 있다면
            if (player)
            {
                PlayerFire pf = player.GetComponent<PlayerFire>();
                pf.bulletObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            // 너도 죽고
            Destroy(other.gameObject);
        }
        // 오브젝트풀에 반환 해줘야 한다.
        gameObject.SetActive(false);
        // 적 오브젝트풀에 넣어주자.
        GameObject em = GameObject.Find("EnemyManager");
        // 만약 플레이어가 있다면
        if (em)
        {
            EnemyManager manager = em.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(gameObject);
        }
    }
}
