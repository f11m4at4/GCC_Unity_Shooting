using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간에 한번씩 적을 만들고 싶다.
public class EnemyManager : MonoBehaviour
{
    // 필요속성 : 적공장, 생성시간, 경과시간
    public GameObject enemyFactory;
    float createTime = 2;
    float currentTime = 0;

    public float minTime = 1;
    public float maxTime = 5;

    // 오브젝트풀 크기
    public int poolSize = 10;
    // 오브젝트풀 배열
    public List<GameObject> enemyObjectPool;
    // SpawnPoint 들
    public Transform[] spawnPoints;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        // 오브젝트풀에 데이터를 넣어주자.
        for(int i=0;i<poolSize;i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            // 오브젝트풀에 넣어주자
            enemyObjectPool.Add(enemy);
            // 비활성화 시키자
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 일정시간에 한번씩 적을 만들고 싶다.
        // 1. 시간이 흘러야한다.
        currentTime += Time.deltaTime;
        // 2. 생성시간이 됐으니까
        // -> 만약 경과시간이 생성시간을 초과했다면
        if(currentTime > createTime)
        {
            // 오브젝트풀에서 가져와서 활용하자.
            // 오브젝트풀에 에너미가 있을 때
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                // spawnpoint 위치에서 나오도록 
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
            }
            // 5. 경과 시간 초기화
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
