using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDManager : MonoBehaviour
{
    public int bpm = 0;
    // 1분당 비트수
    // 120pm = 1분에 비트가 120번 있다는 뜻 
    // 여기서는 1분에 화살표 객체가 120개 생성한다는 의미가 됨 

    double currentTime = 0d;
    // 화살표 객체가 생성하는 시간을 측정하는 변수  
    
    [SerializeField] Transform appearLocation = null;
    // 화살표 객체가 생성될 위치를 담는 변수
    

    LeftTiming theTimingManager; // TimingManager를 참조할 수 있도록 한다!! 

    private void Start()
    {
        theTimingManager = GetComponent<LeftTiming>();
        theTimingManager.LeftList.Add(GameObject.FindWithTag("LEFTD"));

    }



    void Update()
    {
        
            currentTime += Time.deltaTime;

            if(currentTime >= 60d/bpm)
            {
                // 비트 한 개당 등장 속도! 
                // 예를 들어 60 / 120 = 1비트 당 0.5초

                GameObject t_D = ObjectPool.instance.LeftQueue.Dequeue(); // queue에 담긴 객체를 빼고 
                t_D.transform.position = appearLocation.position;
                t_D.SetActive(true);
 

                // 화살표 객체가 생성되는 순간 해당 객체를 넣어준다 
                theTimingManager.LeftList.Add(t_D);

                currentTime -= 60d / bpm;
                // currentTime = 0은 안된다!
                // 왜냐하면 currentTime은 현재 딱 60d / bpm이 아닌 근삿값에 해당 
                // 실제로 시간이 소숫점 단위만큼 더 흘렀는데 그것을 무시하고 0으로 초기화시키면 소숫점 단위만큼 시간 오차 손실
                // 그 손실이 누적되다보면 게임 박자가 안 맞게 됨!!
                // 0.51005xx - 0.5를 하면 currentTime의 값(오차) = 0.01005xx이고 다음 화살표객체는 오차만큼 더 빨리 나오는 식으로 조정! 
            }

        
 


    }

   



}
