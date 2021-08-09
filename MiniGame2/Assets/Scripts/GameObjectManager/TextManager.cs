using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] Animator[] hitAnimator;
    string hit = "Hit";

    
    public void textResult(int t_num)
    {

        switch (t_num)
        {
            case 0:
                hitAnimator[0].SetTrigger(hit);
                break;

            case 1:
                hitAnimator[1].SetTrigger(hit);
                break;

            case 2:
                hitAnimator[2].SetTrigger(hit);
                break;

            case 3:
                hitAnimator[3].SetTrigger(hit);
                break;
          
        }
    }

}
