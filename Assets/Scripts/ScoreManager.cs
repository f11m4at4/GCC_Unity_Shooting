using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // ��������
    public int currentScore;
    // �������� UI ���
    public TextMeshProUGUI curScoreText;
    // �ְ�����
    public int bestScore;
    // �ְ����� UI ���
    public TextMeshProUGUI bestScoreText;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 3. ���� ������ ������Ű��
            currentScore++;
            // 4. �������� ���
            curScoreText.text = "�������� : " + currentScore;

            // �ְ������� ���ŵǾ�� �ϴ� ����?
            // 1.���� ������ �ְ� ������ �ʰ��ϸ�
            if (currentScore > bestScore)
            {
                // 2.�ְ� ������ ���� ��Ų��.
                bestScore = currentScore;
                // 3.�ְ� ���� UI �� ǥ��
                bestScoreText.text = "�ְ����� : " + bestScore;

                // �ְ� ������ ��������.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }


    // �̱��� ��ü
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �ְ����� �ҷ��ͼ� bestScore ������ �Ҵ��ϰ� ȭ�鿡 ǥ���ϰ� �ʹ�.
        // 1. �ְ����� �ҷ��;��Ѵ�.
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        // 2. UI �� ǥ��
        bestScoreText.text = "�ְ����� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
