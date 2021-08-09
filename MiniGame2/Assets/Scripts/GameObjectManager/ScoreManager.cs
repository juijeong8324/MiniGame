using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text txtScore;
    [SerializeField] int increaseScore = 10; // 노트를 맞출 때마다 10점씩 올리깅
    int currentScore = 0; // 현재 점수 

    [SerializeField] float[] weight = null; // 판정 범위에 따라 가중치를 다르게  

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    void Start()
    {
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_PlayState)
    {
        int t_increaseScore = increaseScore;

        // 가중치 계산
        t_increaseScore = (int)(t_increaseScore * weight[p_PlayState]);

        currentScore += t_increaseScore; // 이 점수를 현재 점수랑 더해주자! 
        txtScore.text = string.Format("{0:#,##0}", currentScore);
        // 숫자가 들어오면 첫 번째 자리는 무조건 띄워주도록 만들자! 그리고 세자리마다 콤마를 붙여줄 것임!  

        myAnim.SetTrigger(animScoreUp);
    }
}
