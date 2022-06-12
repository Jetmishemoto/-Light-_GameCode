using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordCombatManager : MonoBehaviour
{
    public static SwordCombatManager instance;

   
    public @Player_Inputs _player_Input;
           Animator _anim;

   [SerializeField]  int numOfPressedAttack = 0;
    [SerializeField] float maxComboDelay = 1f;
   [SerializeField] float cooldownTime = 2f;
    float nextFireTime = 0f;
    float lastPressedAttack = 0;
   


    int attatckAnimationsCount = 4;
    int AnimationsCounter = 0;



   private AnimatorStateInfo currentStateInfo_0;








    private bool pressedAttackButton;


    //private void OnEnable()
    //{
    //    _player_Input.C_Actions.Enable();
    //}
    //private void OnDisable()
    //{
    //    _player_Input.C_Actions.Disable();
    //}



    public void Awake()
    {
        //_player_Input = new Player_Inputs();
        _anim = GetComponent<Animator>();




        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }






    // Update is called once per frame
    void Update()
    {
        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);




        if (currentStateInfo_0.normalizedTime > 0.3f
         && currentStateInfo_0.IsName("SwoAttack_1"))
        {
            _anim.SetBool("SwoAttack_1", true);
            _anim.SetBool("SwoAttack_1", false);

        }
        

        if (currentStateInfo_0.normalizedTime > 0.3f
         && currentStateInfo_0.IsName("SwoAttack_2"))
        {
            _anim.SetBool("SwoAttack_2", true);
            _anim.SetBool("SwoAttack_2", false);
        }
      

        if (currentStateInfo_0.normalizedTime > 0.3f
       && currentStateInfo_0.IsName("SwoAttack_3"))
        {
            _anim.SetBool("SwoAttack_3", true);
            _anim.SetBool("SwoAttack_3", false);
            numOfPressedAttack = 0;
        }
      


        if(Time.time - lastPressedAttack > maxComboDelay)
        {
            numOfPressedAttack = 0;
        }

        if (Time.time > nextFireTime)
        {

            if (Input.GetKeyDown(KeyCode.K))
            {
                OnAttack();

            }


        }



        if (numOfPressedAttack == 0)
        {
            _anim.SetBool("SwoAttack_1", false);
            _anim.SetBool("SwoAttack_2", false);
            _anim.SetBool("SwoAttack_3", false);
            _anim.SetBool("SwoAttack_4", false);
        }


        print(lastPressedAttack);

    }




    public void SetAnimBool(int hash, bool value)
    {
        _anim.SetBool(hash, value);
    }

    public void OnAttack()
    {
        //_player_Input.C_Actions.SwordAttack.performed += context =>
        //{

        //    pressedAttackButton = context.ReadValueAsButton();

        //};
        //_player_Input.C_Actions.SwordAttack.canceled += context =>
        //{
        //    pressedAttackButton = context.ReadValueAsButton();
        //};


        lastPressedAttack = Time.time;
        numOfPressedAttack++;
        

        if (numOfPressedAttack == 1 && currentStateInfo_0.IsName("Swo_Idle_1")
                                    || currentStateInfo_0.IsName("Swo_Idle_2"))
        {
            _anim.SetBool("SwoAttack_1", true);
        }


        numOfPressedAttack = Mathf.Clamp(numOfPressedAttack, AnimationsCounter, attatckAnimationsCount);


        if(numOfPressedAttack >= 2 && currentStateInfo_0.normalizedTime > 0.3f
                                   && currentStateInfo_0.IsName("SwoAttack_1"))
        {
            _anim.SetBool("SwoAttack_1", false);
           _anim.SetBool("SwoAttack_2", true);

        }

        if (numOfPressedAttack >= 3 && currentStateInfo_0.normalizedTime > 0.3f
                                    && currentStateInfo_0.IsName("SwoAttack_2"))
        {
           _anim.SetBool("SwoAttack_2", false);
            _anim.SetBool("SwoAttack_3", true);

        }


        if (numOfPressedAttack >= 4 && currentStateInfo_0.normalizedTime > 0.3f
                                    && currentStateInfo_0.IsName("SwoAttack_3"))
        {
            _anim.SetBool("SwoAttack_3", false);
            _anim.SetBool("SwoAttack_4", true);

        }



    }


}
