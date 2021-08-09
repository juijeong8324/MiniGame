using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    LeftTiming LTimingManager;
    RightTiming RTimingManager;
    UpTiming UTimingManager;
    DownTiming DTimingManager;

    private void Start()
    {
        LTimingManager = FindObjectOfType<LeftTiming>(); // 키를 누르면 판정할 수 있도록 TimingManager를 가져오고
        RTimingManager = FindObjectOfType<RightTiming>();
        UTimingManager = FindObjectOfType<UpTiming>();
        DTimingManager = FindObjectOfType<DownTiming>();

    }
    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                LTimingManager.CheckTiming(); // 판정해주는 함수!!  
                

            }
            //수정한 부분 
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RTimingManager.CheckTiming(); // 판정해주는 함수!!  
                

            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UTimingManager.CheckTiming(); // 판정해주는 함수!!  
                

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                DTimingManager.CheckTiming(); // 판정해주는 함수!!  
                

            }

        
        
    }
}
