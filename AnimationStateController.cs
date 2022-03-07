using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Playa playa;
    private Animator _anim;
    private AnimatorStateInfo currentStateInfo_0;
    
    public GameObject swordPrefab;


    int isJumpingHash;
    int mainLayer;




    void Awake()
    {
        swordPrefab = GameObject.FindGameObjectWithTag("Sword");
        playa = GetComponent<Playa>();
        _anim = GetComponent<Animator>();

        isJumpingHash = Animator.StringToHash("isJumping");
        mainLayer =_anim.GetLayerIndex("Main");

    }




    private void AnimationLayerMonitor()
    {
        if (mainLayer == 0)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }



    private void IdleStatesMonitor()
    {



    }



    private void SwordAttackStateMonitor()
    {
        if (currentStateInfo_0.IsName(""))
        {
            //playa._canMove = false;

        }
        if (playa._canMove)
        {


            //print("CanMove");
        }


    }
    private bool JumpingStateMonitor()
    {
        if ( playa._Jumping == true )
        {
            _anim.SetBool(isJumpingHash, true);
        }
        return true;
    }





    void Update()
    {
        SwordAttackStateMonitor();
        IdleStatesMonitor();
        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);

    }
}
