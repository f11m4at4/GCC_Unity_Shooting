using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 현재점수
    public int currentScore;
    // 현재점수 UI 등록
    public TextMeshProUGUI curScoreText;
    // 최고점수
    public int bestScore;
    // 최고점수 UI 등록
    public TextMeshProUGUI bestScoreText;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 3. 현재 점수를 증가시키자
            currentScore++;
            // 4. 현재점수 출력
            curScoreText.text = "현재점수 : " + currentScore;

            // 최고점수가 갱신되어야 하는 조건?
            // 1.현재 점수가 최고 점수를 초과하면
            if (currentScore > bestScore)
            {
                // 2.최고 점수를 갱신 시킨다.
                bestScore = currentScore;
                // 3.최고 점수 UI 에 표시
                bestScoreText.text = "최고점수 : " + bestScore;

                // 최고 점수를 저장하자.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }


    // 싱글톤 객체
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
        // 최고점수 불러와서 bestScore 변수에 할당하고 화면에 표시하고 싶다.
        // 1. 최고점수 불러와야한다.
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        // 2. UI 에 표시
        bestScoreText.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
