using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MageScootDirection // retain mage direction beyond player input  
{
    noMove = 0,
    left = 1,
    right = 2,
    noValue = 3
}

public class MageMovement : MonoBehaviour
{
    static Rigidbody2D rb;
    [SerializeField] GameObject mageGraphics; 
    static Animator anim; // Animator

    [SerializeField]float moveSpeed = 10;  // Characterspeed
    [SerializeField] float jumpHeight = 10; // Character jumphight
    static float horizontalInput; // Charactermovement direction input
    [SerializeField] float fallSpeedup = 2.5f; //Gravitation multiplier for fall speedup (Quellenverzeichnis) 
    

    static bool mageScoots = false; // Is the character moving
    static bool mayMageScoot = true;    
    double magePositionOld = 0; // Old position 0
    double magePositionCurrent = 0; // Current position 0
    static MageScootDirection scooty = MageScootDirection.noValue; // Mage direction has no value since no input has been given yet

    bool mageJumped = false; // Is the character jumping
    static int mageHasJumped = 0; // Jump counter for double jump

    static bool mayMageBadTouch = true; // Mage can be hurt 
    static bool yeetMage = false; // Mage is not being thrown back 
    
    
    bool mageTouchdown = false; // reset jump count

    // --------------------------------------------------------------------------
    public static void setMageHasJumped()
    {
        mageHasJumped = 0; // count start --> resets to 0 by collision
        anim.SetBool("isTouchingFloor", true); // condition for no jump animation
    }
    
    public static bool getMageScoots()
    {
        return mageScoots; // Is Mage moving
    }
    // --------------------------------------------------------------------------
    public static float getHorizontalInput() {
        return horizontalInput; // Return direction in which Mage is moving 
    }
    
    public static MageScootDirection getScooty()
    {
        return scooty; // Is the Mage moving
    }
    // --------------------------------------------------------------------------
    public static void setMayMageScoot(bool value)
    {
        mayMageScoot = value;
        if (value == false)
        {
            anim.SetBool("isMoving", false); //No running animation, for Mage is not running 
        }
        
    }

    public static bool getMayMageScoot()
    {
        return mayMageScoot; //Return is Mage allowed to move
    }
    // -----------------------------------------------------------------------
    public static void setMayMageBadTouch(bool value)
    {
        mayMageBadTouch = value; // Set value for Damage allowance 
        
    }

    public static bool getMayMageBadTouch()
    {
        return mayMageBadTouch; // Check if the Mage can get hurt
    }
    // --------------------------------------------------------------------------
    public static void setAnimIsDamaged(bool value)
    {
        anim.SetBool("isDamaged", value); // Get damage animation when hurt
    }

    public static Animator getAnim()
    {
        return anim; //Get the animation- NOW
    }
    public static void setYeetMage(bool value)
    {
        yeetMage = value; // Should he get thrown now?
    }
    // --------------------------------------------------------------------------

   

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = mageGraphics.GetComponent<Animator>(); // take the animator of MageGraphics
        mayMageScoot = true;
    }

    private void Start()
    {

        LevelManagement.resetScore(1000, 0);

    }



    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))  //automatic jump after touchdown and jumpcount reset is a feature ;)
        {
            mageJumped = true; //character jump start
        }

    }

    void FixedUpdate()
    {
        if (mayMageScoot)
        {
            if (rb.velocity.y < 0) // character is falling
            {
                rb.velocity += new Vector2(0, 1) * Physics2D.gravity.y * fallSpeedup * Time.deltaTime; // Gravitation Multiplier for fall speedup  
            }
            if ((mageHasJumped < 2) && mageJumped) // if mage jumped < 2 --> mage can jump again 
            {
                mageHasJumped++; // Jumpcounter ad on 
                mageJumped = false; // Resets so character doesn't jump infinitely
                rb.velocity = new Vector2(0, jumpHeight); // Force applied for jump
                anim.SetBool("isTouchingFloor", false); // Animation condition for jump --> Mage isn't touching floor

            }
            horizontalInput = Input.GetAxis("Horizontal"); // Character side movement value

            if (horizontalInput != 0)
            {
         
                if(horizontalInput < 0) // If value is smaller than 0, then ...
                {
                    scooty = MageScootDirection.left;
                    mageGraphics.transform.rotation = new Quaternion(0, 180, 0, 0); //... mirror character along y 
                }
                else if (horizontalInput > 0) //If value is biggern than 0, then ... 
                {
                    scooty = MageScootDirection.right;
                    mageGraphics.transform.rotation = new Quaternion(0, 0, 0, 0); //... reset character sprite to original position
                }
            
                transform.Translate(new Vector2(horizontalInput, 0) * moveSpeed * Time.deltaTime); // Character side movement 
                magePositionOld = System.Math.Round(magePositionCurrent, 1); // Old position variable is being overwritten by the new position variable 
                magePositionCurrent = System.Math.Round(transform.position.x, 1); // 

                anim.SetBool("isMoving", true); //If Magemovement is happening, than play running animation
                mageScoots = true; // Mage is moving
            }
            else
            {
                anim.SetBool("isMoving", false); // otherwise no animation if character isn't moving
                mageScoots = false; // Mage is not moving
            }

        }

        if(yeetMage)
        {
            anim.SetBool("isTouchingFloor", false); // Animation condition for jump --> Mage isn't touching floor
            yeetMage = false; // Yeeting is a single event
            if (scooty == MageScootDirection.left)
            {
                rb.velocity = new Vector3(5, 10f, 0);
                Debug.Log("left"); // If Mages walking direction is 'left', he'll get trown back in the other direction when damaged
            }
            else if (scooty == MageScootDirection.right)
            {
                rb.velocity = new Vector3(-5, 10f, 0);  // Same as 'left', but for 'right' side
            }
             
        }



        if ((magePositionOld >= magePositionCurrent - 0.15) && (magePositionOld <= magePositionCurrent + 0.15)) // If the old and current position are the same (with margins +/- 0.15), then...
        {
            mageScoots = false; //...he's not moving
        }

    }
}
