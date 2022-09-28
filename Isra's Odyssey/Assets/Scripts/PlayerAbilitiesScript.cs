using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class PlayerAbilitiesScript : MonoBehaviour
{
    public GameObject[] cheatPlatforms;
    public GameObject[] Lights;
    public GameObject swordRef;
    public GameObject LightBeam;
    public GameObject IndicatorPrefab;
    public GameObject faceCube;
    public GameObject FlarePrefab;
    public GameObject tunicRef;

    public float detectionRadius;
    public float beamDuration;
    public float teleportDistance;
    public float flareThrowStrength;

    public Material darkMat;
    public Material lightMat;
    public Material shroudMat;
    public Material toonMat;


    bool LightMode = false;
    bool ShroudMode = false;
    bool beaming = false;
    bool teleportMarkerActive = false;
    bool executeTeleport = false;
    bool pushPullActive = false;
    bool canActivatePushPull = false;

    GameObject PushPullRef;
    GameObject closestLight;
    GameObject tempLightBeamAudioRef;
    GameObject indactorRef;
    [SerializeField]GameObject AimingCamera;
    [SerializeField]GameObject PlayerCamera;
    
    RaycastHit hit;
    int TestMask = 1 << 8;
    int puzzleMask = 1 << 10;

    BasicMovementScript movementRef; 
    AudioManagerScript AudioRef;   
    RespawnAreaScript respawnRef;

    //Dont worry about it
    private int curIndex = 1;

    private ControlLayout controlSystem;

    private void Awake()
    {
        controlSystem = new ControlLayout();
        controlSystem.PlayerAbilities.CastLightBeam.performed += ctx => CastLightBeam(true);
        controlSystem.PlayerAbilities.CastLightBeam.canceled += ctx => CastLightBeam(false);
        controlSystem.PlayerAbilities.Teleport.performed += ctx => HandleTeleportInput();
        controlSystem.PlayerAbilities.CancelTeleport.performed += ctx => CancelTeleportAbility();
        controlSystem.PlayerAbilities.LightMode.performed += ctx => ActivateLightMode();
        controlSystem.PlayerAbilities.PushPull.performed += ctx => PushPullMode();
        controlSystem.PlayerAbilities.Flare.performed += ctx => ThrowFlareAbility();
        controlSystem.PlayerAbilities.Shroud.performed += ctx => SetShroudMode(!ShroudMode);
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
        //Getting refs for everything
        respawnRef = FindObjectOfType<RespawnAreaScript>();
        AudioRef = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
        AimingCamera = GameObject.FindGameObjectWithTag("AimingCam");
        PlayerCamera = GameObject.FindGameObjectWithTag("3rdPersonCamera");
        movementRef = FindObjectOfType<BasicMovementScript>();
        indactorRef = Instantiate(IndicatorPrefab);
        indactorRef.SetActive(false);
        TestMask = ~TestMask;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //All calculations using raycasts get done in fixed update

        //Determine if we are in a light zone
        lightDetection();

        //For the darkness teleport ability
        if (teleportMarkerActive) 
        {
            //Move the teleport indicator 
            TeleportMarkerUpdate();
            if (executeTeleport) 
            {
                //Actually teleport the player
                TeleportAbiltiy();
            }
        }
        //Light beam ability
        lightBeamRayCast();
    }

    void Update()
    {
        //this function is where the player's control inputs are made 
        //PlayerAbilites();
        //self explanatory
        CheatCodes();
    }

    public void SetPushPullRef(GameObject obj)
    {
        PushPullRef = obj;
        if (obj == null)
        {
            canActivatePushPull = false;
        }
        else 
        {
            canActivatePushPull = true;
        }
        Debug.Log("Set Ref to: " + obj);
    }

    private void PushPullMode() 
    {
        if (!canActivatePushPull) 
        {
            return;
        }

        if (pushPullActive)
        {
            pushPullActive = false;
            movementRef.SetMovementType(MovementType.Regular);
            PushPullRef.transform.SetParent(null);
        }
        else 
        {
            pushPullActive = true;
            movementRef.SetCharacterController(false);
            movementRef.SetMovementType(MovementType.PushPull);

            for(int i = 0; i < PushPullRef.transform.childCount; i++) 
            {
                if (PushPullRef.transform.GetChild(i).CompareTag("PushPull")) 
                {
                    transform.position = PushPullRef.transform.GetChild(i).position;
                    break;
                }
            }
            transform.LookAt(PushPullRef.transform);

            PushPullRef.transform.SetParent(transform);

            movementRef.SetCharacterController(true);
        }     
    }

    private void ThrowFlareAbility() 
    {
        if (true) 
        {
            Vector3 spawnLoc = gameObject.transform.position + Camera.main.transform.forward;
            spawnLoc.y += movementRef.playerController.height;
            GameObject temp = Instantiate(FlarePrefab, spawnLoc, Quaternion.identity);

            temp.GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward + (Camera.main.transform.up * 0.5f)).normalized * flareThrowStrength,ForceMode.Impulse);
        }       
    }

    private void SetShroudMode(bool set) 
    {
        Debug.LogWarning("Shroud set to: " + set);
        ShroudMode = set;
        if (set)
        {
            tunicRef.GetComponent<MeshRenderer>().material = shroudMat;
        }
        else 
        {
            tunicRef.GetComponent<MeshRenderer>().material = toonMat;
        }
    }

    public bool GetShroudMode() 
    {
        return ShroudMode;
    }

    private void CheatCodes() 
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
        {
            //Teleporting cheats
            // Number 0
            if (Input.GetKeyDown(KeyCode.Alpha0)) 
            {
                respawnRef.CheatTeleport(0);
            }
            // Number 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                respawnRef.CheatTeleport(1);
            }
            // Number 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                respawnRef.CheatTeleport(2);
            }
            // Number 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                respawnRef.CheatTeleport(3);
            }
            // Number 4
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                respawnRef.CheatTeleport(4);
            }
            // Solves the mural puzzle
            if (Input.GetKeyDown(KeyCode.M)) 
            {
                solveMural();
            }
            // Solves the platform puzzle
            if (Input.GetKeyDown(KeyCode.P)) 
            {
                solvePlatforms();
            }
        }     
    }
    void solvePlatforms() 
    {
        //Platform A
        Vector3 newPos = cheatPlatforms[0].transform.localPosition;
        newPos.x = -10f;
        cheatPlatforms[0].transform.localPosition = newPos;
        //Platform E
        newPos = cheatPlatforms[1].transform.localPosition;
        newPos.z = 8f;
        cheatPlatforms[1].transform.localPosition = newPos;
        //Platform B
        newPos = cheatPlatforms[2].transform.localPosition;
        newPos.y = 1.75f;
        cheatPlatforms[2].transform.localPosition = newPos;
        //Platform F
        newPos = cheatPlatforms[3].transform.localPosition;
        newPos.x = -10f;
        cheatPlatforms[3].transform.localPosition = newPos;
    }

    void solveMural() 
    {
        WallGlyphScript[] gemstones = FindObjectsOfType<WallGlyphScript>();
       
        StartCoroutine(stylishSolve(gemstones));

    }
    IEnumerator stylishSolve(WallGlyphScript[] array) 
    {
        bool done = true;
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].glyphID == curIndex)
            {
                array[i].activated();
                curIndex++;
                done = false;
                break;
            }
        }
        if (!done)
        {
            StartCoroutine(stylishSolve(array));
        }
    }

    void lightDetection()
    {
        //two modes here if we are in the light and if we are not in the light
        if (!LightMode)
        {
            //If we are NOT in the light we want to check the distance between us and all our light zone objects to see if we ever get close enough to one
            foreach (GameObject i in Lights)
            {
                //This is purely for testing purpose ignore it (will probably be removed latter)
                //Debug.DrawRay(transform.position, i.transform.position - transform.position);
                detectionRadius = i.GetComponent<LightRangeComponent>().LightDetectionRadius;

                //For each light send a raycast in its direction (with length detectionRadius)
                if (Physics.Raycast(transform.position, i.transform.position - transform.position, out hit, detectionRadius))
                {
                    //check if we hit a light (raycast hit data stored in hit)
                    if (hit.collider.CompareTag("Lights"))
                    {
                        //If true then activate light mode
                        LightMode = true;

                        //This is the closest light store it for latter when determining if we are still in the light
                        closestLight = i;

                        //change our meshs to be the correct one 
                        swordRef.GetComponent<MeshRenderer>().material = lightMat;
                        //Change ambient music 
                        AudioRef.playAudio(1);

                        //No need to continue checking lights so we can break here
                        break;
                    }

                }
            }
        }
        //now we want to handle if we are in light mode 
        else
        {
            //Debug purposes only ignore this
            Debug.DrawRay(transform.position, closestLight.transform.position - transform.position);

            //Send a raycast every frame to our closestLight that we stored when we entered light mode (again with the same length of detectionRadius)
            if (!Physics.Raycast(transform.position, closestLight.transform.position - transform.position, out hit, detectionRadius))
            {
                //If we dont hit our object we have left the radius of our light meaning we should switch to dark mode
                swordRef.GetComponent<MeshRenderer>().material = darkMat;
                LightMode = false;

                //We want to make sure we only change the music if we arent entering another zone of light
                if (!checkOtherLights()) 
                {
                    //Change ambient Music
                    AudioRef.playAudio(0);
                }
                
            }
            //but if we hit an object that is not our light we also want to enter dark mode Since there is something obscuring our vision of the light
            if (hit.collider != null)
            {
                //Check if not light
                if (hit.collider.CompareTag("Ground"))
                {
                    //Enter dark mode if not light
                    swordRef.GetComponent<MeshRenderer>().material = darkMat;
                    LightMode = false;

                    //We want to make sure we only change the music if we arent entering another zone of light
                    if (!checkOtherLights())
                    {
                        //Change ambient Music
                        AudioRef.playAudio(0);
                    }
                }
            }
        }

    }

    bool checkOtherLights() 
    {
        //Copy of what happens above
        foreach (GameObject i in Lights)
        {
            detectionRadius = i.GetComponent<LightRangeComponent>().LightDetectionRadius;
            //For each light send a raycast in its direction (with length detectionRadius)
            if (Physics.Raycast(transform.position, i.transform.position - transform.position, out hit, detectionRadius))
            {
                //check if we hit a light (raycast hit data stored in hit)
                if (hit.collider.CompareTag("Lights"))
                {
                    //If true then activate light mode
                    LightMode = true;

                    //This is the closest light store it for latter when determining if we are still in the light
                    closestLight = i;

                    //change our meshs to be the correct one 
                    //MeshRenderer[] meshHolder = gameObject.GetComponentsInChildren<MeshRenderer>();
                    //foreach (MeshRenderer m in meshHolder)
                    //{
                    swordRef.GetComponent<MeshRenderer>().material = lightMat;
                    //}

                    //No need to continue checking lights so we can break here
                    return true;
                }

            }
        }
        //No lights found return false
        return false;
    }
    //These functions are all called based on events from our input system
    #region "Light Abilites"
    void ActivateLightMode() 
    {
        if (beaming)
        {
            //Beam remains until we press L again
            movementRef.setPlayerFrozen(false);
            movementRef.setConstantLook(false);
            Cursor.lockState = CursorLockMode.None;
            beaming = false;
            AimingCamera.GetComponent<CinemachineFreeLook>().Priority = 9;
            PlayerCamera.GetComponent<CinemachineFreeLook>().m_XAxis.Value = AimingCamera.GetComponent<CinemachineFreeLook>().m_XAxis.Value;
            
        }
        else
        {
            movementRef.setPlayerFrozen(true);
            movementRef.setConstantLook(true);
            Cursor.lockState = CursorLockMode.Locked;
            AudioRef.playAudio(6);
            beaming = true;
            AimingCamera.GetComponent<CinemachineFreeLook>().Priority = 11;
            AimingCamera.GetComponent<CinemachineFreeLook>().m_XAxis.Value = PlayerCamera.GetComponent<CinemachineFreeLook>().m_XAxis.Value;
            
        }
        Debug.Log(beaming);
    }

    //State determines if we are turning the ability off or on
    void CastLightBeam(bool state) 
    {
        if (state)
        {
            if (beaming)
            {
                //only turn on beam when we are beaming
                LightBeam.SetActive(true);
                faceCube.SetActive(false);

                tempLightBeamAudioRef = AudioRef.referencePlayAudio(4);
                Debug.Log("on");
            }
        }
        else 
        {
            //no need for a comparison here if we arent beaming we should turn this off anyway
            LightBeam.SetActive(false);
            faceCube.SetActive(true);

            Destroy(tempLightBeamAudioRef);
            Debug.Log("off");
        }      
    }
    #endregion
    #region "Darkness Abilities"
    void HandleTeleportInput() 
    {
        if (!LightMode) 
        {
            //Activate teleport marker
            if (!teleportMarkerActive)
            {
                teleportMarkerActive = true;
                indactorRef.SetActive(true);
                movementRef.setPlayerFrozen(true);
            }
            else
            {
                //Actually teleport
                executeTeleport = true;
                indactorRef.SetActive(false);
                movementRef.setPlayerFrozen(false);
                movementRef.resetYForce();
            }
        }     
    }

    void CancelTeleportAbility() 
    {
        if (!LightMode) 
        {
            //Cancel teleport
            if (teleportMarkerActive)
            {
                teleportMarkerActive = false;
                indactorRef.SetActive(false);
                movementRef.setPlayerFrozen(false);
            }
        }     
    }
    #endregion
    //Handle light beam interactions
    void lightBeamRayCast() 
    {
        //if the light beam is active
        if (LightBeam.activeSelf)
        {
            RaycastHit puzzleHit;
            LightBeam.transform.rotation = Camera.main.transform.rotation;
            if (Physics.Raycast(LightBeam.transform.position, LightBeam.transform.forward, out puzzleHit, 100f,puzzleMask)) 
            {
                if (puzzleHit.collider != null) 
                {
                    if (puzzleHit.collider.gameObject.CompareTag("Glyph")) 
                    {
                        puzzleHit.collider.gameObject.GetComponent<WallGlyphScript>().activated();
                        return;
                    }
                    if (puzzleHit.collider.gameObject.CompareTag("PlatformSphere")) 
                    {
                        puzzleHit.collider.gameObject.GetComponent<PlatformMovementScript>().MoveParent();
                        return;
                    }
                    if (puzzleHit.collider.gameObject.CompareTag("BurnablePlant"))
                    {
                        puzzleHit.collider.gameObject.GetComponent<BurnablePlantScript>().ActivateBurnMat();
                        return;
                    }
                }             
            }
        }
    }

    //Teleport function
    void TeleportAbiltiy()
    {
        RaycastHit collision;
        Vector3 destination = transform.position + transform.forward * teleportDistance;
        Vector3 dir = (transform.position - destination).normalized;
        if (Physics.Raycast(transform.position, -dir, out collision, teleportDistance))
        {
            destination = collision.point + collision.normal * 1.5f;
            transform.position = destination;
        }
        else
        {
            transform.position = destination;
        }
        AudioRef.playAudio(5);
        teleportMarkerActive = false;
        executeTeleport = false;
    }

    //Update teleport marker location whenever we move the camera
    void TeleportMarkerUpdate()
    {
        RaycastHit collision;
        Vector3 destination = transform.position + transform.forward * teleportDistance;      
        Vector3 dir = (transform.position - destination).normalized;
        Debug.DrawRay(gameObject.transform.position, -dir * teleportDistance, Color.green);
        if (Physics.Raycast(transform.position, -dir, out collision, teleportDistance))
        {
            destination = collision.point + collision.normal * 1.5f;
            Vector3 tempDir = (collision.point - destination).normalized;
            Debug.DrawRay(collision.point, -tempDir * 1.5f, Color.red);
            indactorRef.transform.position = destination;
        }
        else
        {
            indactorRef.transform.position = destination;
        }
    }

    //Potential timer function for later
    IEnumerator BeamAbility(float t)
    {
        LightBeam.SetActive(true);
        yield return new WaitForSeconds(t);
        LightBeam.SetActive(false);
    }

    public void Respawn(Vector3 pos) 
    {
        transform.position = pos;
    }
}

