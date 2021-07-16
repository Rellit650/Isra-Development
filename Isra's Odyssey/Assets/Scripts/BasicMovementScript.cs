using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementScript : MonoBehaviour
{
    public CharacterController playerController;

    public float playerSpeed;
    public float playerJumpPower;

    [HideInInspector]
    public bool constantLook = false;

    float ySpeedHolder;

    float playerFrozen = 1f;

    AudioManagerScript AudioRef;
    bool impactSoundPlayed = true;

    private void Start()
    {
        AudioRef = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float HInput;
        float VInput;

        if (constantLook)
        {
            HInput = 0f;
            VInput = 1f;
        }
        else 
        {
            HInput = Input.GetAxisRaw("Horizontal");
            VInput = Input.GetAxisRaw("Vertical");
        }      

        Vector3 dir = new Vector3(HInput, 0f, VInput).normalized;
        Vector3 cameraDir = Vector3.zero;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //If we jump add the jump force
                ySpeedHolder = playerJumpPower;

                //Audio sound effects
                AudioRef.playAudio(3);
                impactSoundPlayed = false;
            }
        }
        //Maintain y velocity from last frame but add gravity every frame to it
        ySpeedHolder += Physics.gravity.y * Time.deltaTime;

        //since camera dir is reset every frame we make it equal to our velocity
        cameraDir.y = ySpeedHolder;

        //Move the player based on the force we have calculated
        playerController.Move(cameraDir * playerSpeed * Time.deltaTime * playerFrozen);

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
