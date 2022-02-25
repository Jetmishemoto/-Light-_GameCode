using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRunning : StateMachineBehaviour
{




    readonly float runMinTime = 1;
    readonly float runMaxTime = 2.7f;

    [SerializeField] float runTimer = 0;

    string [] runningStatses = {"Running_float","WalknRun" };

    void PlayRandomRun(Animator animator)
    {
        System.Random rnd = new System.Random();
        int runState = rnd.Next(runningStatses.Length);
        string runStates = runningStatses[runState];
        animator.SetTrigger(runStates);
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    //}



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        if(runTimer <= 0)
        {
            PlayRandomRun(animator);
            runTimer = Random.Range(runMinTime, runMaxTime);
        }
        else{
            runTimer -= Time.deltaTime;
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
     //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     //{
        
     //}


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}


    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
