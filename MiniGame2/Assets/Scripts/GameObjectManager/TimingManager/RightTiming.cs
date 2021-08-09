using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTiming : MonoBehaviour
{
    public List<GameObject> RightList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    // 판정 범위의 중심을 알려줌 
    [SerializeField] Transform[] timingRect = null;
    // 다양한 판정 범위를 보여주는 거, 이때 판정 범위는 (Perfect, great, good, miss가 될 것임)
    Vector2[] timingBox = null;
    // 실제 판정 혹은 판독에 쓰이는 거!! 

    [SerializeField] GameObject effect;
    // 충돌효과 수정한 부분 

    TextManager theManager;
    ScoreManager theScore;

    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<TextManager>();
        theScore = FindObjectOfType<ScoreManager>();

        timingBox = new Vector2[timingRect.Length];
        // timingBoX의 배열의 크기는 Rect의 개수 즉 4개임 


        for (int i = 0; i < timingRect.Length; i++) // 판정범위를 배열에 넣어주도록 한다 
        {
            timingBox[i].Set(Center.localPosition.z - (timingRect[i].transform.localScale.z / 2),
                Center.localPosition.z + (timingRect[i].transform.localScale.z / 2));
            // 최소값 = 중심 - (박스의 z축으로의 너비 / 2)
            // 최대값 = 중심 + (박스의 z축으로의 너비 / 2) 
            // 즉 각 범위를 좌표계의 위치로서 바꿔주는 작업이 되겠다!! 
        }
    }

    public void CheckTiming()
    { // 생성된 화살표 객체의 개수 만큼 즉, 리스트에 있는 노트의 개수만큼 반복문을 돌려주자 

        foreach (GameObject aObject in RightList)
        {

            if (aObject.gameObject != null)
            {
                float DPosZ = aObject.transform.localPosition.z;
                // 이때 각 화살표 객체의 Position의 z값을 받아서 
                

                for (int x = 0; x < (timingBox.Length - 1); x++)
                { // 판정범위 안에 들어왔는지 확인! 여기서 x는 상관 안 해도 된담! 

                    if (timingBox[x].x <= DPosZ && DPosZ <= timingBox[x].y)
                    {
                        
                        effect.GetComponentInChildren<ParticleSystem>().Play(); // 해당 충돌효과를 재생
                        theManager.textResult(x);

                        // 점수 증가
                        theScore.IncreaseScore(x);

                        return;
                    }


                }


            }

        }
        theManager.textResult(3);

    }
}
