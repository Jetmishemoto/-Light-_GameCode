using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Playa playa;
    private Animator _anim;
    private AnimatorStateInfo currentStateInfo_0;




    void Awake()
    {
        playa = GetComponent<Playa>();
        _anim = GetComponent<Animator>();

    }


    public void SwordAttackStateMonitor()
    {
        if (currentStateInfo_0.IsName(""))
        {
           //playa._canMove = false;

        }
        if (playa._canMove)
        {

            
            print("CanMove");
        }


    }


   


    void Update()
    {
        SwordAttackStateMonitor();
        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);

    }
}
