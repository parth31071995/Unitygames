using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")] // gives heading to all your settings 
    [Tooltip("How fast our ship moves up and down")]
    [SerializeField] float controlSpeed = 10f; 
    //if you scroll over cntrl speeed in the game, it will show you what it does
    [SerializeField] float XRange = 10f; 
    [SerializeField] float YRange = 5f; 

    [Header("Lazer Gun array")]
    [SerializeField] GameObject[] lazers;


    [Header("Screen Position Based On tuning ")]
     [SerializeField] float PositioPitchFactor = -2f; 
     [SerializeField] float ControlPitchFactor = -15f; 

    [Header("Player Input Based On tuning ")]   
     [SerializeField] float YawDueToPosition = 2f;

      [SerializeField] float RollDueToPosition = -10f;

      float XThrow;
      float YThrow;


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
         XThrow = Input.GetAxis("Horizontal");
         YThrow = Input.GetAxis("Vertical");

        float xOffset = XThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos,-XRange,XRange);

        float yOffset = YThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos,-YRange,YRange);


        transform.localPosition = new Vector3
        (clampedXPos,clampedYPos,transform.localPosition.z);

    }

    void ProcessRotation()
    {
        // Quaternion is used to rectify roataion 
        /* Rotation can be very tricky Eg if you move x first it will rotate x and z axis butif you rotate y first 
        and then x it will work properly  so thats why we use quaternion*/

        float PitchDueToPosition = transform.localPosition.y * PositioPitchFactor;
        float PitchDueToControl = YThrow * ControlPitchFactor;

        float pitch = PitchDueToPosition + PitchDueToControl; // gives current position of the ship

        float yaw = transform.localPosition.x * YawDueToPosition;
        float roll= XThrow * RollDueToPosition;

         transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);

    }

    void  ProcessFiring()
    {
        /* Fire1 is the name of the fire button i.e left control named
        in project settings - input manager */

         if(Input.GetButton("Fire1"))
         {
             SetActiveLazers(true);
         }
         else
         {
             SetActiveLazers(false);
         }
        
    }

    void SetActiveLazers(bool isActive)
    {

        foreach (GameObject lazer in lazers)
        {
          var EmissionMod = lazer.GetComponent<ParticleSystem>().emission;
          EmissionMod.enabled = isActive;
        }
    }

    

}
