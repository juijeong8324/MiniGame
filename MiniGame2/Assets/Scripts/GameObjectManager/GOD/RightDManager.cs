using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDManager : MonoBehaviour
{
    public int bpm = 0;

    double currentTime = 0d;
    // 화살표 객체가 생성하는 시간을 측정하는 변수  

    [SerializeField] Transform appearLocation = null;
    // 화살표 객체가 생성될 위치를 담는 변수


    RightTiming theTimingManager; // TimingManager를 참조할 수 있도록 한다!! 

    private void Start()
    {
        theTimingManager = GetComponent<RightTiming>();
        theTimingManager.RightList.Add(GameObject.FindWithTag("RIGHTD"));
    }



    void Update()
    {
        
            currentTime += Time.deltaTime;

            if (currentTime >= 60d / bpm)
            {
            // 비트 한 개당 등장 속도! 
            // 예를 들어 60 / 120 = 1비트 당 0.5초
                if (ObjectPool.instance.RightQueue != null)
                {
                    GameObject t_D = ObjectPool.instance.RightQueue.Dequeue(); // queue에 담긴 객체를 빼고 
                   t_D.transform.position = appearLocation.position;
                    t_D.SetActive(true);


                    // 화살표 객체가 생성되는 순간 해당 객체를 넣어준다 
                    theTimingManager.RightList.Add(t_D);

                    currentTime -= 60d / bpm;
                }

            }

        
 


    }


}
