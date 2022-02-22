// Namespace allows you to use ----Actions--- Used to interact with .gameOjects like coins
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Playa : MonoBehaviour
{



    IEnumerator isSliding;




    // Ref to the Models transform 
    public Transform _transform;
    public Transform chestBone;

    public Animator animator;





    public LightWeapon lightWeapon;
    public DynamicBone dynamicBone;
    public P_LightAttack p_LightAttack;
    public @Player_Inputs _player_Input;



    [SerializeField] private UltEvents.UltEvent _MyEvent;




    // Made a variable for the Rigidbody on the player --- can name it whatever
    private Rigidbody rb;


    //-- ->>>>>--------------------------------------------------------------------------------------------------------------------------- End Class Refs



    //-----------------------------------------------------------------------

    //---------------------------------------------------------------------------------    | Action Methods |


    //  Method Action to collectCoin
    public Action onCollectCoin;



    //---------------------------------------------------------------------------------- | End of Actions Methods |





    // ----------------------------------------------------   | Animator Vars |-----

    float _velocity = 0.0f;

    private AnimatorStateInfo currentStateInfo_0;
    private AnimatorStateInfo currentStateInfo_1;
    private AnimatorStateInfo currentStateInfo_2;


    [Header("-------------------Animation Variables-------------------")]
    public float _acceleration = 1.5f;
    public float _deceleration = 1.5f;
    public float _slide_Deceleration = 5f;


    [SerializeField]float _airBorneHight;
    [SerializeField] float _softAirBorneHight;

    int VelocityHash;
   float _S_landingHash;
    float _H_landingHash;



    // -----------Sword_AttackState Vars----------------------


    [SerializeField] bool swordAttackState = false;
    [SerializeField] float swoAttackStateTimer;
    [SerializeField] bool swordAttacking = false;
    //---------------------------------------------------------------------------------    


    // -----------------   ints for Animator.StringtoHash() method -------------
    int isJumpingHash;
    int Sprint_RunHash;
    int wall_Jump_LeftHash;
    int wall_Jump_RightHash;
    int airBorneHash;
    int hardLandingHash;
    int softLandingHash;
    int boostJumpHash;
    int rollingHash;
    int bounceFlipingHash;
    int isNowGroundedHash;
    int isSlidingHash;
    int isDoubleJumpingHash;
    int dd_LandingHash;
    int can_slideHash;


    int _softLandingTimeHash;
    int _hardLandingTimeHash;

    int attackinghash;
    int sideKickHash;
    int backflipkickHash;
    int fanceyTossHash;






    // --------------------------------------------------------------------------------- | Public Var floats |
    //  Adds Methods for Unity inspector ---
    //  Enables you adjust the physics listed here in the unity inspector---
    //  Also enables methods to be called in update section
    [Header("------------------Visuals_Variables-------------------")]
    public GameObject model;
    public GameObject normalModel;
    public GameObject powerUpModel;



    [Header("-----------------Movement_Acceleration_Variables------------------")]
    public float acceleration = 1.2f;
    public float deacceleration = 5.0f;
    public float lightspeeddeacceleration = 5f;




    //  [Header("helps organize your variables in unity")] ----- Separates variables right under by section in unity inspector
    [Header("--------------Movement_Variables--------------")]

    //Background statement to enable speed of player 
    [SerializeField] float speed = 0f;

    // [Range(Num, Num)] ------ Adds a sliding bar to unity for the variable right under it-----
    [Range(4f, 50f)]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] bool turningaround = false;

    [Range(4f, 50f)]
    public float movementSpeedRight = 20f;
    [Range(4f, 50f)]
    public float movementSpeedLeft = 15f;







    [Header("-------------Juming_Variables------------")]
    [SerializeField] bool _canDoubleJump = false;
    [SerializeField] bool airBorne = false;

    //     ----- NormalJumpingSpeed dictates how high the player can jump --
    [Range(0f, 20f)]
    public float normaljumpingSpeed;
    //This adds the limit of the Player jump in unity, as long as this timer contiunes run the player can jump -------
    public float jumpDuration = 0.8f;










    [Header("||------------Landing _Variables---------------||")]// ----------------------------------------------------------------------------------------------  | Landing Vars |
    public float _airBorneTimer = 0f;
    [SerializeField] float _softLandingTimer = 0f;
    [SerializeField] float hardLandingTimer = 0f;
    public float _ddLandingTimer = 0f;

    public int _fallingSpeed = 20;

    public float _fallTime = 3f;
    public int _hardfallTime = 3;
    public int _softFallTime = 1;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundTimer = 0f;
    [SerializeField] bool _softLand = false;
    [SerializeField] bool _hardLand = false;



    [Header("||-----------------------------------------------||")]
    [Range(4f, 50f)]
    public float LongJumpingSpeed = 25;
    [SerializeField]float jumpingTimer = 0.5f;
    public float verticalWallJumpingSpeed = 20f;
    public float horizontalWalljumpingSpeed = 3.5f;
    public float destroyEnemyJumpingSpeed = 9f;

    [SerializeField] float _duobleJumpSpeed = 27f;

    [SerializeField] float slideSpeed = 30f;

    //----------------------------------------------------------------------------------------------------------
    [Header("-----------------Powerups Variables-----------------")]
    public float invincibilityDuration = 10f;






    [Header("-----------------Attack Variables-----------------")]

     [SerializeField] bool attackAnimation;
      



    [Header(" ||-----------------------------------------------||")]

    [Header(" ||--------------------Bools---------------------------||")]

    //Defines Jumping logic in Private not public ----------------------->>>>>>--------------------------------------     | Private bools |
    //Need this boolin variables to begin if statement
    //All of these statements start --false; , they are enable -- true; once we put them in update section

    private bool dead = false;

    [SerializeField] bool canJump;
    [SerializeField] bool jumping = false;
    private bool jumped = false;


    private bool canWallJumpLeft = false;
    private bool canWallJumpRight = false;

    public bool lightspeed = false;

    private bool finished = false;
    private bool canMove = true;
    
    private bool wallJumpingArea = false;


    //This statement limits the deration of jump with jump timer 
 
    private float jumpingSpeed;



    public float _runningTimer = 0f;
    public float _slidingTimer = 0f;
    public bool _running = false;
    public bool _canSlide = false;

    private bool _boostJumping = false;






    private bool hasPowerUp = false;
    private bool hasInvincibility = false;



    // -------------------- Ground Check stuff----------

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    RaycastHit hit;

    float _colStartHight = 1.18f;
    private CapsuleCollider _col;

    //------------------------------------------------------------  




    // finishline logic 
    public bool Finished
    {

        get
        {
            //---
            return finished;

        }

    }



    // -------------------------------------------------------------  | Death Method |
    public bool Dead
    {
        get
        {
            return dead;

        }

    }
    // -------------------------------------------------------------  | Death Method |


    private void OnEnable()
    {
        _player_Input.C_Actions.Enable();
    }
    private void OnDisable()
    {
        _player_Input.C_Actions.Disable();
    }

// ------  Player Inputs  -------------------------------------------------------------------------------------------------- | Player Inputs |
    [SerializeField] float movementSensitivity;
    Vector2 currentMovementInput;
    Vector3 CurrentMovement;
    bool isMovingLeft;
    [SerializeField] float isMovingRightTimer= 0f;
    bool isMovingRight;
    [SerializeField] float isMovingLeftTimer = 0f;
    bool pressedJumpButton;

    public void ControllerInputs()
    {
        _player_Input = new Player_Inputs();

        _player_Input.C_Actions.Movements.started += context =>
        {
            currentMovementInput = context.ReadValue<Vector2>();
            CurrentMovement.x = currentMovementInput.x;
            isMovingLeft = currentMovementInput.x != 1;
            isMovingRight = currentMovementInput.x != -1;

        };
        _player_Input.C_Actions.Movements.canceled += context =>
        {

            currentMovementInput = context.ReadValue<Vector2>();
            CurrentMovement.x = currentMovementInput.x;

            isMovingLeft = currentMovementInput.x != 0;
            isMovingRight = currentMovementInput.x != 0;

        };
        _player_Input.C_Actions.Movements.performed += context =>
        {
            //Debug.Log(context.ReadValue<Vector2>());
            currentMovementInput = context.ReadValue<Vector2>();
            CurrentMovement.x = currentMovementInput.x;
            isMovingLeft = currentMovementInput.x != 1;
            isMovingRight = currentMovementInput.x != -1;
        };


        _player_Input.C_Actions.Jump.performed += ctx =>
        {

            pressedJumpButton = ctx.ReadValueAsButton();

        };
        _player_Input.C_Actions.Jump.canceled += ctx =>
        {
            pressedJumpButton = ctx.ReadValueAsButton();
        };
    }
    //---

    // Use this for initialization-------->>>>>>>>>>------------------------------------------------------------------------------------------>>>>>>------------------------    *| Awake Method |*

    void Awake()
    {
        ControllerInputs();

        // -------------------------------------------------------------------------------------------------------------------------------------------- | End Player Inputs |

        
        


        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _col = GetComponent<CapsuleCollider>();
        dynamicBone = GetComponent<DynamicBone>();
        lightWeapon = GetComponent<LightWeapon>();
       
        
       
        
        
        chestBone = transform.Find("spine.003");



         
        //-------------------------------------------------------------



        //    -----------Animator.StringToHash-----------

        Sprint_RunHash = Animator.StringToHash("Sprint_Run");
        wall_Jump_LeftHash = Animator.StringToHash("Left_Wall_Jump");
        wall_Jump_RightHash = Animator.StringToHash("Right_Wall_Jump");
        airBorneHash = Animator.StringToHash("airBorne");
        boostJumpHash = Animator.StringToHash("Boost_Jump");
        isJumpingHash = Animator.StringToHash("isJumping");
        rollingHash = Animator.StringToHash("Roll");
        bounceFlipingHash = Animator.StringToHash("Bounce Flip");
        VelocityHash = Animator.StringToHash("Velocity");            
        isSlidingHash = Animator.StringToHash("IsSliding");
        isDoubleJumpingHash = Animator.StringToHash("isDoubleJumping");




         can_slideHash = Animator.StringToHash("CanSlide");





// ------------------------ StringToHash-- Attacks-------------------------------------------------------------  Attacks 
        attackinghash = Animator.StringToHash("Attacking");
        sideKickHash = Animator.StringToHash("side_kick_Attack");
        backflipkickHash = Animator.StringToHash("");






        // --------------------- StringToHash-- Landings-------------------------------------------------------   Landings
        isNowGroundedHash = Animator.StringToHash("isNowGrounded");
        softLandingHash = Animator.StringToHash("SoftLand");
        hardLandingHash = Animator.StringToHash("HardLanding");
        dd_LandingHash = Animator.StringToHash("dd_landing");



      // ----------- Animator-----StringToHash-- Landings------------------------------------------------ Landings
        _softLandingTimeHash = Animator.StringToHash("_softLandingTime");
        _hardLandingTimeHash = Animator.StringToHash("_hardLandingTime");



        //






        jumpingSpeed = normaljumpingSpeed;
        //
        normalModel.SetActive(true);
        powerUpModel.SetActive(false);
     


// ------------------- corrutine bools
        attackAnimation = true;
        canJump = true;


         //----------------------------------------------------------------------------------------------->>>>>>>> *| End Awake |*
//---
        

    }

   
    // -------------------------------------------------------------------------->>>>>>>- || PlayAniamtion Method || 
    // ------------------- This takes a string as an aggrument
    //                  (Data Type ---Var Name)
    /*                       |          |
     *                       |          |
     *                       V          V                 */
    public void PlayAnim(string movementName)
    {
        animator.Play(movementName);
    }
    public void SetAnimBool(int hash,bool value)
    {
        animator.SetBool(hash,value);
    }
    public  void SetAnimeFloat(int hash, float g_Value )
    {
        animator.SetFloat(hash,g_Value);
    }
    //--------------------------------------------------------------------------->>>>>>>>>>


 /*   public void DynamicBoneAjustments(Transform bone)
    {
        
        if (dynamicBone.m_Root = bone)
        {
           dynamicBone.m_Stiffness = 0.088f;
        }

    }
   */

    public void ResetMovementspeed()
    {
        if (movementSpeed >= 13f)
        {
            movementSpeed -= lightspeeddeacceleration * Time.deltaTime;
        }
    }
    public bool Getlightspeed()
    {      
        if (movementSpeed >= 25f)
        {
         
           lightspeed = true;
       
        }
        else{
            lightspeed = false;
        }
        return true;
    }




    //---
    void ApplyPowerUp()
    {
        hasPowerUp = true;
        normalModel.SetActive(false);
        powerUpModel.SetActive(true);
    }
    //---



    //---
    void ApplyInvincibility()
    {

        hasInvincibility = true;
        StartCoroutine(InvincibilityRoutine());

    }

    //--------------------------------------------------------------------------
    private IEnumerator InvincibilityRoutine()
    {
        float initialWaitingTime = invincibilityDuration * 0.75f;
        int initialBlicks = 20;

        for (int i = 0; i < initialBlicks; i++)
        {
            model.SetActive(!model.activeSelf);
            yield return new WaitForSeconds(initialWaitingTime / initialBlicks);
        }

        float finalWaitingTime = invincibilityDuration * 0.25f;
        int finalBlicks = 35;

        for (int j = 0; j < finalBlicks; j++)
        {
            model.SetActive(!model.activeSelf);
            yield return new WaitForSeconds(finalWaitingTime / finalBlicks);
        }
        model.SetActive(true);

        hasInvincibility = false;

    }

    //----------------------------------------------------------------------------------  Brick
    public void OnDestroyBrick()
    {

        rb.velocity = new Vector3(
        rb.velocity.x,
         0,
        rb.velocity.z);

    }

    //-------------------------------------------------------------------------------------- Brick





    //----------------------------------------------------------------------------------  SkyBrick

    public void OnDestroySkyBrick()
    {

        rb.velocity = new Vector3(
        rb.velocity.x,
        0,
        rb.velocity.z);

    }
    //------------------------------------------------------------------------------------------  SkyBrick



 //---



    // ---------->>>>>>>>>-------------------------------------------------------------------------------------------------->>>>>>>>>>>------  *| MovePlayer Method |*
    public void MovePlayer()
    {
        if (dead)
        {
            return;
        }
        //         ---------------------------------------------------------------------------------------------   | Normal Movement speed |
        if (canMove)
        {       
            ////Move horizontally left to right         
            //bool pressingRightButton = Input.GetKey(KeyCode.D);
            //bool pressingLeftButton = Input.GetKey(KeyCode.A);
           

            //                      Moveing Right  -----------------------------------   |Moveing Right |
            if (isMovingRight)
            {
                _running = true;
                _canSlide = true;
                _runningTimer += Time.deltaTime; 
                 //print(_velocity);

                // Flips the char model to the right when you press the RightButton
                _transform.localRotation = Quaternion.Euler(0, 0, 0);

                rb.velocity = new Vector3(
                    movementSpeed,
                    rb.velocity.y,
                    rb.velocity.z);
                // Is the player paused ? if not move with speed ver


            }
            if (isMovingRight)
            {
                turningaround = true;
            }
            else turningaround = false;


            //           -------------------------------------------------------------------------------- | Moveing Right Animation if Statements | 


            if (isMovingRight && _velocity < 1.0f)
            {
                //Animation _velocity
                _velocity += Time.deltaTime * _acceleration;
            }

            if (isMovingRight && _velocity > 0.0f)
            {

                _velocity -= Time.deltaTime * _deceleration;
                

            }
            if (!isMovingRight && _velocity < 0.0f)
            {
                _velocity = 0.0f;
                _runningTimer = 0f;
                
                _running = false;
            }

            //                          Moveing left  --------------------------------   |Moveing Left |
            if (isMovingLeft)
            {
                _running = true;
                _canSlide = true;
                _runningTimer += Time.deltaTime;
               //print(_velocity);

                // Flips the char model to the Left when you press the LefttButton
                _transform.localRotation = Quaternion.Euler(0, -180, 0);


                rb.velocity = new Vector3(
                    -movementSpeed,
                    rb.velocity.y,
                    rb.velocity.z);
            }

            //           --------------------------------------------------------------------- | Moveing Left Animation if Statements | 
            if (isMovingLeft && _velocity < 1.0f)
            {
                _velocity += Time.deltaTime * _acceleration;
            }
            if (!isMovingLeft && _velocity > 0.0f)
            {
                _velocity -= Time.deltaTime * _deceleration;
            }
            if (!isMovingLeft && _velocity < 0.0f)
            {
                _velocity = 0.0f;
                _runningTimer = 0f;
                
                _running = false;
            }

           
        }

        //--if you can't {!} move canMove is false
        else if (!canMove)
        {
            _running = false;
            canMove = false;
            _canSlide = false;
        }
        //      animator.Set float() to acces the Float Psrameter in unitys animator componet
                SetAnimeFloat(VelocityHash, _velocity);

       

    }

    //------->>>>>>>>>>>-------------------------------------------------------------------------------------------------------------------------- | End MovePlayer Method |
 //---




//---

     // ---------- | Sliding Logic |-------------------------------------------------------------------- | Sliding |


    public void IsSliding()
    {
          isSliding = Sliding();
        bool pressingSlideButton = Input.GetKeyDown(KeyCode.N);
        if (pressingSlideButton && _runningTimer > 1.5f && Time.time > _slidingTimer)
        {
            SetAnimBool(can_slideHash,true);
            SetAnimBool(isSlidingHash, true);
            //  Change Time.time + (someNumber) if you want the player to be able to slide more often.
            _slidingTimer = Time.time + 3.3f;
            StartCoroutine(isSliding);
            _col.height = animator.GetFloat("Collider_Y");

        }
        else if (!pressingSlideButton) 
        {
            

            _slidingTimer -= _slide_Deceleration * Time.deltaTime;
            if(_slidingTimer <= -1f)
            {
                _slidingTimer = 0f;
            }
            
            SetAnimBool(isSlidingHash,false);
            SetAnimBool(can_slideHash, false);
            
        }
       

    }
   public IEnumerator Sliding()
   {
        // ---------- | Sliding Logic |-------------------------------------------------------------------- | Sliding |
        while(_canSlide && _running){

            if (IsGrounded() && movementSpeed <= 14f)
            {
                SetAnimBool(can_slideHash, true);
                SetAnimBool(isSlidingHash, true);
                movementSpeed = slideSpeed;
            }
                yield return new WaitForSeconds(0.9f);
                _col.height = _colStartHight;
            break;
        }
     
    }

    // ---------- | Sliding Logic |-------------------------------------------------------------------- | EndSliding |


//---




    // ------------------------>>>>>>>>>>>>>>>>>---------------------------------------------------------------------------------------------------------------------------------------  **| IsGrounded Bool Method |**
    // IsGrounded bool uses Phsics.Capsule method to locate the bottom of the capsule with creating a(capsuleBottom) var.
    public bool IsGrounded()
    {

//       ---------------------|| HardLanding Ray ||------------------------------------------------------------------------------------------- || HardLanding Ray ||
        // Raycast sintax this takes a layer argument at the end
        //                                                                                           _airborneHight is the length of the ray drawn
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, _airBorneHight, groundLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("hit");
            groundTimer += Time.deltaTime;

            Getlightspeed();
            canMove = true;
            
          
        }
        else
        {
            ResetMovementspeed();
            // airborneTimer was need to keep track how long the player was in the air
            _airBorneTimer += _hardfallTime * Time.deltaTime;
            groundTimer = 0f;
            hardLandingTimer += _hardfallTime * Time.deltaTime;
            _H_landingHash += _hardfallTime * Time.deltaTime;
            
            
            //---------------------------------------------------------------------------
            //Debug.Log("noHit");
            // if the the ray dosnt hit the ground then airborne is true;
            airBorne = true;
            SetAnimBool(airBorneHash,true);
            SetAnimBool(isNowGroundedHash,false);
            isGrounded = false;
        }

//            ---------------------|| HardLanding Ray ||------------------------------------------------------------------------------------------------------------------------------ || End HardLanding Ray ||
        //       Used the CheckCapsule mothed to use as a jumptimer 
        /*                                                         * 
                Vector3 to locate the bottom of the collider * 
         */
        Vector3 capsuleBottom = new Vector3
         (_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule
         (_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Collide);








        // ----------------------|| SoftLanding Ray ||---------------------------------------------------------------------------------------------------------------------------------- || SoftLanding Ray ||

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, _softAirBorneHight, groundLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            Getlightspeed();
            canMove = true;
            isGrounded = true;
            


            if (grounded
                && _softLandingTimer >= 0.4f
                && _S_landingHash > 0.4)
            {
                _softLand = true;
                airBorne = false;
                SetAnimBool(softLandingHash, true);
                _softLandingTimer -= _softFallTime * Time.deltaTime;


            }

            if (groundTimer >= 0.5f)
            {
                SetAnimBool(softLandingHash, false);
                SetAnimBool(airBorneHash, false);
                _softLand = false;
            }

            if (grounded && _S_landingHash <= 5f)
            {
                _S_landingHash = 0f;

            }

          
        }
        else
        {
           _S_landingHash += Time.deltaTime;
            groundTimer = 0f;

            

            ResetMovementspeed();
            SetAnimBool(softLandingHash, false);
            _softLandingTimer += _softFallTime * Time.deltaTime;
            isGrounded = false;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------|| End SoftLanding Ray ||>>>>




        // <<----------------------------------------------------------------------------------------------->>
        // <<----------------------------------------------------------------------------------------------->>
//---

        // <<------------------------------------------------------------------------------------------------->>
        // <<-------------------------------------------------------------------------------------------------->>



        // ---------------------|| HardLanding Ray ||------------------------------------------------------------------------------------------------------------------------------- || HardLanding Ray ||>>>>


        if (grounded)
        {
             ResetMovementspeed();

            _canDoubleJump = true;  
            SetAnimBool(dd_LandingHash, true);
            //--------------------------------------------------------------------------


            if (grounded
                && hardLandingTimer >= 5f
                && _H_landingHash >= 5f )
            {
                SetAnimBool(softLandingHash, false);
                SetAnimBool(hardLandingHash, true);
                //canMove = false;
                _hardLand = true;
                _softLand = false;

                hardLandingTimer -= _hardfallTime * Time.deltaTime;
               
            }
            else _hardLand = false;

            if (grounded
                && currentStateInfo_0.IsName("HardLanding"))
            {
                SetAnimBool(rollingHash, true);
               print("roll now");
                
            }

            if (grounded
               && currentStateInfo_0.IsName("Airborne"))
            {
                SetAnimBool(airBorneHash, false);

            }


            if (grounded 
                && _H_landingHash <= 0f)
            {
                _H_landingHash = 0f;
                SetAnimBool(rollingHash, false);
                canMove = true;
            }


            // ------------------------------------------------------------------------------------------------------------------------------------------------ || End HardLanding Ray ||>>>>

            canMove = true;
            airBorne = false;

            _airBorneTimer = 0;
            _softLandingTimer = 0f; 
            hardLandingTimer = 0f;

            
            

            _S_landingHash -= _softFallTime * Time.deltaTime;
            _H_landingHash -= _hardfallTime * Time.deltaTime;
            
           

            SetAnimBool(dd_LandingHash, false);
            
            
             
            SetAnimBool(isNowGroundedHash, true);
            SetAnimBool(airBorneHash, false);

        }
        else
        {

            SetAnimBool(hardLandingHash, false);
            _hardLand = false;
            ResetMovementspeed();
        }

        //SetAnimBool(hardLandingHash, false);

        SetAnimeFloat(_hardLandingTimeHash, _H_landingHash);
        SetAnimeFloat(_softLandingTimeHash, _S_landingHash);

        return grounded;
    }

    public void DoubleJump()
    {
        bool pressingJumpButton = Input.GetMouseButtonDown(0) || Input.GetKeyDown("space");
        if (pressingJumpButton || pressedJumpButton
            && jumped
            && _canDoubleJump)
        {
            _ddLandingTimer += _fallTime * Time.deltaTime;

            SetAnimBool(isDoubleJumpingHash, true);
            PlayAnim("Double_Jump");
            _canDoubleJump = false;
            rb.velocity = new Vector3(
           rb.velocity.x,
           _duobleJumpSpeed,
            rb.velocity.z);

        }
        else{
            SetAnimBool(isDoubleJumpingHash, false); ;

        }

        if (_ddLandingTimer  >= 0.01f)
        {
            _ddLandingTimer = 0f;
            SetAnimBool(dd_LandingHash, false);
        }
    }

    public void WallJumping()
    {
        bool pressingJumpButton = Input.GetMouseButtonDown(0) || Input.GetKeyDown("space");
        //Makes the player Wall Jump ------------------------------------------------------     | Wall Jumping |

        if (canWallJumpLeft)
        {

            speed = 0;
            if (pressingJumpButton)
            {

                SetAnimBool(isJumpingHash, false);
                animator.Play(wall_Jump_LeftHash);

                canMove = false;
                canWallJumpLeft = false;

                rb.velocity = new Vector3(
                -verticalWallJumpingSpeed,
                verticalWallJumpingSpeed,
                rb.velocity.z);


            }
            else if (!pressingJumpButton)
            {
                //             animator.Play  (animation , "0" for the very first frame and "0" so the animation is pasued)
                animator.Play(wall_Jump_LeftHash, 0, 0f);
            }

        }

        if (canWallJumpRight)
        {

            speed = 0;

            if (pressingJumpButton)
            {

                SetAnimBool(isJumpingHash, false);
                animator.Play(wall_Jump_RightHash);

                canMove = false;
                canWallJumpRight = false;

                rb.velocity = new Vector3(
                 verticalWallJumpingSpeed,
                 verticalWallJumpingSpeed,
                 rb.velocity.z);


            }
            else if (!pressingJumpButton)
            {
                //             animator.Play  (animation , "0" for the very first frame and "0" so the animation is pasued)
                animator.Play(wall_Jump_RightHash, 0, 0f);
            }


        }
        //-------------------------------------------------------------------------------------------------------       | End of Wall Jumping |
    }



    // ----------------------------------------------------------------------------------------------------------------------     *| Jumping Method |*>>>>>>>>

    //Define Method jump, This effecs the player alowing them to jump by clicking or hiting spacebar---------
    /*  This Method can be used to access the jumping logic lower in the script
     *  Use the variable (Jump)() to be called later in the script
     */
    public void Jump(bool hitenemy = false)
    {

        
        jumped = true;
        jumping = true;

        if (hitenemy)
        {
            distanceToGround = 0.3f;

            PlayAnim("Bounce Flip");
            animator.SetTrigger("hitEnemy");

            rb.velocity = new Vector3(
            rb.velocity.x,
            //set y axes to jumping speed---this calls the public float jumping speed method.
            destroyEnemyJumpingSpeed,
            rb.velocity.z);
        }
        else
        {
            /*- -------------if the player is pressing the jump button----
                               * GetComponent<rigidboby>().                             
                                This effecs the player alowing them to jump by clicking or hiting spacebar if they are grounded*/
            //PlayAnim("FrontTwistFlip");
            
            StartCoroutine(PauseJump());
            
             SetAnimBool(isJumpingHash, true);
            rb.velocity = new Vector3(
            rb.velocity.x,
            //set y axes to jumping speed---this calls the public float jumping speed method.
            normaljumpingSpeed,
            rb.velocity.z);

          
            
        }
    }

    //   ---------------------------------------------------------------------------------------------------------------------- | End Jumping Method |








    private IEnumerator PauseAnimationPlaying()
    {
        attackAnimation = false;
        //Same as P_attack.PreventSpam();
        yield return new WaitForSeconds(0.7f);
        attackAnimation = true;

    }


     void OrbAttackAnimation()
     {
        bool pressingFireButton = Input.GetKeyDown(KeyCode.J);

        if (pressingFireButton
            && p_LightAttack._canAttack == true)
        {
            //print("attack");
            SetAnimBool(attackinghash, true);
            StartCoroutine(PauseAnimationPlaying());

        }
        else SetAnimBool(attackinghash, false);

    }

    public void SwordAttack()
    {
        bool pressingSwordAttackButton = Input.GetKeyDown(KeyCode.H);
        if (pressingSwordAttackButton)
        {
            swordAttackState = true;


        }

    }


    private IEnumerator PauseJump()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpingTimer);
        canJump = true;

    }

    // ---->>>>>>>>>>>>>>>--------------------------------------------------------------------------------------->>>>>>>>>>>>>>>>------------------- | **Update Method** | ---------------  ** FOR PLAYER INPUT **
    void Update()
    {

//                Animator State Info   ---------------------------------------------------
      // Getting the current animation state--- has to be in update method
        currentStateInfo_0 = animator.GetCurrentAnimatorStateInfo(0);
        currentStateInfo_1 = animator.GetCurrentAnimatorStateInfo(1);
// ---------------Animator State Info End------------------------------------------------------------------>



        IsGrounded();
        IsSliding();
        //DoubleJump();
        WallJumping();
        OrbAttackAnimation();


        //  ------------------------------------------------ Jumping Logic---------------------------------------------------------------------------    |*Jumping Logic* |



        //   -------------------------------------------------------------------------------------------- | Pressing Jump Buttons |
        // Check for input.
        // In the updated mothed this checks if a button is being pressed 
        // Jump Button ^ Y xs                              
        // Input.GetKey("space") for spacebar;
        //                                                (0) is left mouse button
        //                                                (1) is the middle mouse button
        //This checks if button is bing pressed        // (2) is the right mouse button                                                     
        //Bool sets up logic for JumpButton           //      || means "or"
        /*                                                     |
         *                                                     |
         *                                                     |                                                         
                                                               V                         */
        bool pressingJumpButton = Input.GetMouseButtonDown(0) || Input.GetKeyDown("space");

        if (isGrounded == true
            && canJump == true
            && pressingJumpButton)
        {
            // Set the bool in the animator componet to true when you hit the jumpbutton

            SetAnimBool(isJumpingHash, true);
            //print(jumping);
            Jump();

            

        }
     

        if (isGrounded == true
            && canJump == true
            && pressedJumpButton)
        {
            SetAnimBool(isJumpingHash, true);
           //print(jumping);
            Jump();
        }
      


        if (!pressedJumpButton )
        {
            // set the animator bool back to false if NOT pressing the jumpButton
            SetAnimBool(isJumpingHash, false);
           
            //jumpingTimer = 0f;

        }
        if(!pressingJumpButton)
        {
            SetAnimBool(isJumpingHash, false);
        }



        //  -----------------------------------------------------------------------------------------------------------------------------------     *| Continued Update Methods |* 








    }




    //   ------------------------------------------------------------------------------------------------------------------------------      *| FixedUpdate Method |* ---------- FOR GAME PHYX
    void FixedUpdate()
    {
        
        

        //------- if the player dies we return_ wont run any of the player code.
        if (dead) return;

        if (wallJumpingArea) airBorne = false;
        if (airBorne && !jumped && !_boostJumping) SetAnimBool(airBorneHash, true);


       
        

        //  -------------------------------------------    | Calling MovePlayer Melthod |
        MovePlayer();
        //    -------------------------------------------
       
        

        
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------     | End of fixedUpdate Methods |

    //                            -----OnTriggerEnter has to be outside the Update Section---- 

    // Needs to be -Void onTriggerEnter- in Unity ---
    // This lets player collid or interact with objects ---
    //-------------------------------------------------------------------------------------------------------------------------------------------------      |* OnTriggerEnter |               
    void OnTriggerEnter(Collider otherCollider)
    {




        //-----------------------------------------------------------------------------------------------------------------------------  *| PowerUp |*
        if (otherCollider.GetComponent<PowerUp>() != null)
        {
            PowerUp powerUp = otherCollider.GetComponent<PowerUp>();
            powerUp.OnCollected();
            ApplyPowerUp();

        }

        //------------------------------------------------------------------------------------------------------



        // ---------------------------------------------------------------------------------------------------------------- | Enter JumpingArea |

        //--------------------------------------------------------------------------
        if (otherCollider.tag == "RightWall_JumpingArea")
        {

            SetAnimBool(isJumpingHash, false);


            canWallJumpLeft = true;
            //                                  if position.x of the player is lesser than otherCollider then run canWallJumpLeft if statement
            canWallJumpLeft = transform.position.x < otherCollider.transform.position.x;

        }
        if (otherCollider.tag == "LeftWall_JumpingArea")
        {

            SetAnimBool(isJumpingHash, false);
            canWallJumpRight = true;
            canWallJumpRight = transform.position.x > otherCollider.transform.position.x;
        }






        // -------------Need this Main_jumping_Area to made sure not to trigger the airborne animation while WallJumping---------
        if (otherCollider.CompareTag("Main_jumpingArea_col"))
        {
            SetAnimBool(airBorneHash, false);
            airBorne = false;
            canMove = false;
            wallJumpingArea = true;
            Debug.Log("WallJumpingArea");
        }



        //------------------------------------------------------------------------------------------  | Calling the long JumpBlock Script |
        if (otherCollider.GetComponent<LongJumpBlock>() != null)
        {
            _boostJumping = true;

            if (_boostJumping)
            {

                animator.SetTrigger(boostJumpHash);
                rb.velocity = new Vector3(
                rb.velocity.x,
                LongJumpingSpeed,
                rb.velocity.z);
            }
            else animator.ResetTrigger(boostJumpHash);

        }



         // --------------------------------------------------------------------------------------------------------   | OnCollect Coin |
        //      This checks for the coin script and destroys it if player interacts with .gameObject. 
        // use otherCollider.transform.GetComponet <Name of script>() != null){
        if (otherCollider.transform.GetComponent<Coin>() != null)
        {
            Destroy(otherCollider.gameObject);
            Coin coin = otherCollider.transform.GetComponent<Coin>();
            //Method Call useing the virable onCollectCoing you made.
            onCollectCoin();
            coin.onCoinCollected();

        }


        //-----------------------------------------------------------------------------------------------------------        | SpeedArea I True |
        //                                    ---() !=---  means "is different than"
        if (otherCollider.GetComponent<SpeedArea>() != null)
        {
            lightspeed = true;

            SpeedArea speedArea = otherCollider.GetComponent<SpeedArea>();
            if (speedArea.direction == Direction.Left)
            {
                movementSpeed = movementSpeedLeft;

                SetAnimBool(Sprint_RunHash, true);

            }
            else if (speedArea.direction == Direction.Right)
            {
                movementSpeed = movementSpeedRight;

                SetAnimBool(Sprint_RunHash, true);

            }


        }




        //------------------------------------------------------------------------------------------------------------ | Kill the player |

        if (otherCollider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = otherCollider.GetComponent<Enemy>();

            if (hasInvincibility == false && enemy.Dead == false)
            {
                if (hasPowerUp == false)
                {
                    Kill();
                }
                else
                {
                    hasPowerUp = false;
                    ApplyInvincibility();
                    normalModel.SetActive(true);
                    powerUpModel.SetActive(false);
                }
            }

        }



        //------------------------------------------------------------------------------------------------------------- | FinishLine |


        if (otherCollider.GetComponent<FinishLine>() != null)
        {

            hasInvincibility = true;
            finished = true;

        }



    }

    //---------------------------------------------------------------------------------------------------------------------------------------------     | *End of OnTriggerEnter |




    //----------------------------------------------------------------------------------------------     | Paused Check II |


    /* 
      public void Pause ()
      {
          paused = true;


      }
    */
    //----------------------------------------------------------------------------------------------     | End Paused Check II |






    // -----------------------------------------------------------------------------------------------------------------------------------------------------       | OnTriggerExit |
    void OnTriggerExit(Collider otherCollider)
    {



        // -------------------------------------------------------------------------------------------------------------    | SpeedArea II False |

        if (otherCollider.GetComponent<SpeedArea>() != null)
        {
            SetAnimBool(Sprint_RunHash, false);

            SpeedArea speedArea = otherCollider.GetComponent<SpeedArea>();
            if (speedArea.direction == Direction.Left && movementSpeed > 13f)
            {
                movementSpeed -= Time.deltaTime * deacceleration;

            }
            else if (speedArea.direction == Direction.Right && movementSpeed > 13f)
            {
                movementSpeed -= Time.deltaTime * deacceleration;

            }


        }




        if (otherCollider.tag == "RightWall_JumpingArea")
        {

            canWallJumpLeft = false;
        }
        if (otherCollider.tag == "LeftWall_JumpingArea")
        {

            canWallJumpRight = false;
        }
        if (otherCollider.tag == "Main_jumpingArea_col")
        {

            canMove = true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------             | End of OnTrigger Exit |

    }

    //---------------------------------------------------------------------------------------------------------------       | Kill Method |

    void Kill()
    {


        dead = true;

        GetComponent<Collider>().enabled = false;

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0f, 500f, 0f));

    }




}





