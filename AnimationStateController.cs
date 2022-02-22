using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator _anim;



      private AnimatorStateInfo currentStateInfo_0;


    


    public void SwordAttackStateMonitor()
    {
        if (currentStateInfo_0.IsName(""))
        {

        }



    }


   

    void Awake()
    {
   

    }

    void Update()
    {

        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);

    }
}
