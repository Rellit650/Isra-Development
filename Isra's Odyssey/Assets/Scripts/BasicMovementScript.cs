using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType 
{
    Regular,
    PushPull
}

public class BasicMovementScript : MonoBehaviour
{
    public MovementType movementType;

    public CharacterController playerController;

    public float playerSpeed;
    public float playerJumpPower;

    private float speedModifier = 1f; 

    [HideInInspector]
    public bool constantLook = false;

    float ySpeedHolder;

    float playerFrozen = 1f;

    AudioManagerScript AudioRef;
    bool impactSoundPlayed = true;

    private ControlLayout controlSystem;
    private Vector2 moveVec;
    private bool jumpInput = false;
    private void Awake()
    {
        controlSystem = new ControlLayout();
        controlSystem.PlayerControls.Movement.performed += ctx => moveVec = ctx.ReadValue<Vector2>();
        controlSystem.PlayerControls.Movement.canceled += ctx => moveVec = Vector2.zero;
        controlSystem.PlayerControls.Jump.performed += ctx => jumpInput = true;
    }

    private void OnEnable()
    {
        controlSystem.Enable();
    }

    private void OnDisable()
    {
        controlSystem.Disable();
    }

    private void Start()
    {
        AudioRef = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (movementType) 
        {
            case MovementType.Regular:
                RegularMovement();
                break;
            case MovementType.PushPull:
                PushPullMovement();
                break;
        }

    }

    private void PushPullMovement() 
    {
        float HInput = moveVec.x;
        float VInput = moveVec.y;

        Vector3 dir = new Vector3(HInput, 0f, VInput).normalized;
        Vector3 cameraDir = Vector3.zero;

        //Transform our input direction based on the camera's direction
        cameraDir = Camera.main.transform.TransformDirection(dir);

        //We dont want to deal with y movement yet lets just handle our horizontal and vertical for now
        cameraDir.y = 0f;


        Vector3 UnadjustedSpeed = playerSpeed * speedModifier * Time.deltaTime * playerFrozen * cameraDir;


        //Move the player based on the force we have calculated
        playerController.Move();
    }

    private void RegularMovement() 
    {
        float HInput = moveVec.x;
        float VInput = moveVec.y;

        if (constantLook)
        {
            HInput = 0f;
            VInput = 1f;
        }

        Vector3 dir = new Vector3(HInput, 0f, VInput).normalized;
        Vector3 cameraDir = Vector3.zero;

        //Only change direction based on camera if we havent already started moving
        if (dir.magnitude >= 0.05f)
        {
            //Transform our input direction based on the camera's direction
            cameraDir = Camera.main.transform.TransformDirection(dir);

            //We dont want to deal with y movement yet lets just handle our horizontal and vertical for now
            cameraDir.y = 0f;

            //find the angle to rotate our players rotation based on our new direction
            float rotAngle = Mathf.Atan2(cameraDir.x, cameraDir.z) * Mathf.Rad2Deg;

            //rotate our player based on this angle
            gameObject.transform.rotation = Quaternion.Euler(0f, rotAngle, 0f);
        }

        //Jump controls
        if (playerController.isGrounded)
        {
            if (!impactSoundPlayed)
            {
                //Audio sound effect
                AudioRef.playAudio(2);
                impactSoundPlayed = true;
            }
            //If we are on the ground zero our y movement
            ySpeedHolder = 0f;
            if (jumpInput)
            {
                //If we jump add the jump force
                ySpeedHolder = playerJumpPower;

                //Audio sound effects
                AudioRef.playAudio(3);
                impactSoundPlayed = false;

                //Reset Jump input
                jumpInput = false;
            }
        }
        //Maintain y velocity from last frame but add gravity every frame to it
        ySpeedHolder += Physics.gravity.y * Time.deltaTime;

        //since camera dir is reset every frame we make it equal to our velocity
        cameraDir.y = ySpeedHolder;

        //Move the player based on the force we have calculated
        playerController.Move(playerSpeed * speedModifier * Time.deltaTime * playerFrozen * cameraDir);
    }

    //For things that cant be done with a timer
    public void AdjustSpeedModifier(float change)
    {
        speedModifier += change;
    }

    //Overload to have self contained timer
    public void AdjustSpeedModifier(float change, float duration) 
    {
        speedModifier += change;
        StartCoroutine(SpeedModTimer(change, duration));
    }

    IEnumerator SpeedModTimer(float change, float duration) 
    {
        yield return new WaitForSeconds(duration);
        speedModifier -= change;
    }

    //Freezes the player by zeroing out the force we add to them see the above line of code
    public void setPlayerFrozen(bool val) 
    {
        if (val)
        {
            playerFrozen = 0f;
        }
        else 
        {
            playerFrozen = 1f;
        }
    }

    public void setConstantLook(bool val) 
    {
        constantLook = val;
    }

    public void resetYForce() 
    {
        ySpeedHolder = 0f;
    }
}
