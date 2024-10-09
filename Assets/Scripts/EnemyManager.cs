using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð��� �ѹ��� ���� ����� �ʹ�.
public class EnemyManager : MonoBehaviour
{
    // �ʿ�Ӽ� : ������, �����ð�, ����ð�
    public GameObject enemyFactory;
    float createTime = 2;
    float currentTime = 0;

    public float minTime = 1;
    public float maxTime = 5;

    // ������ƮǮ ũ��
    public int poolSize = 10;
    // ������ƮǮ �迭
    public List<GameObject> enemyObjectPool;
    // SpawnPoint ��
    public Transform[] spawnPoints;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        // ������ƮǮ�� �����͸� �־�����.
        for(int i=0;i<poolSize;i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            // ������ƮǮ�� �־�����
            enemyObjectPool.Add(enemy);
            // ��Ȱ��ȭ ��Ű��
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �����ð��� �ѹ��� ���� ����� �ʹ�.
        // 1. �ð��� �귯���Ѵ�.
        currentTime += Time.deltaTime;
        // 2. �����ð��� �����ϱ�
        // -> ���� ����ð��� �����ð��� �ʰ��ߴٸ�
        if(currentTime > createTime)
        {
            // ������ƮǮ���� �����ͼ� Ȱ������.
            // ������ƮǮ�� ���ʹ̰� ���� ��
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                // spawnpoint ��ġ���� �������� 
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
            }
            // 5. ��� �ð� �ʱ�ȭ
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
