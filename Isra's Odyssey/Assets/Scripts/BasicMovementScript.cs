using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType 
{
    Regular,
    PushPull,
    Mantle
}

public class BasicMovementScript : MonoBehaviour
{
    public MovementType movementType;
    public CharacterController playerController;

    public float playerSpeed;
    public float playerJumpPower;
    public float mantleTime;
    [HideInInspector]
    public bool constantLook = false;

    AudioManagerScript AudioRef;
    ControlLayout controlSystem;
    GameObject PushPullRef;

    float speedModifier = 1f;
    float ySpeedHolder;
    float playerFrozen = 1f;
    float mantleTimer = 0f;
  
    bool impactSoundPlayed = true;
    bool jumpInput = false;

    Vector2 moveVec;
    Vector3 initialMantlePos;
    Vector3 pointB;
    Vector3 pointC;
    
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
        movementType = MovementType.Regular;
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
            case MovementType.Mantle:
                MantleMovement();
                break;
        }
    }

    #region Movement Functions

    private void MantleMovement() 
    {
        //Add to timer
        mantleTimer += Time.deltaTime;

        //Calculate our lerp factor
        float interFactor = mantleTimer / mantleTime;

        //apply 3 point lerp
        gameObject.transform.position = Vector3.Lerp(Vector3.Lerp(initialMantlePos, pointC, interFactor), Vector3.Lerp(pointC, pointB, interFactor), interFactor);

        //Determine if movement is completed or not
        if (mantleTimer >= mantleTime)
        {
            //reset variables and controls
            SetMovementType(MovementType.Regular);
            SetCharacterController(true);
            mantleTimer = 0f;
            ySpeedHolder = 0f;
        }
    }

    private void PushPullMovement() 
    {
        //float HInput = moveVec.x;
        float VInput = moveVec.y;

        //determine direction for cart
        Vector3 newDir = VInput * transform.forward;//-PushPullRef.transform.right;

        Vector3 UnadjustedSpeed = playerSpeed * speedModifier * Time.deltaTime * playerFrozen * newDir;

        //Move the player based on the force we have calculated
        playerController.Move(UnadjustedSpeed);
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
    #endregion Movement Functions

    public void SetMovementType(MovementType type)
    {
        movementType = type;
        if (type == MovementType.Mantle)
        {
            SetCharacterController(false);
        }
    }

    public void BeginMantle(Vector3 closestPoint, float objectHeight)
    {
        float heightDif = objectHeight - closestPoint.y;

        initialMantlePos = gameObject.transform.position;

        pointB = closestPoint;
        pointB.y += playerController.height * 0.5f + heightDif;
        pointC = new Vector3(initialMantlePos.x, pointB.y, initialMantlePos.z);

        SetMovementType(MovementType.Mantle);
    }

    public void SetCharacterController(bool active) 
    {
        playerController.enabled = active;
    }

    public void SetPushPullRef(GameObject obj) 
    {
        PushPullRef = obj;
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
