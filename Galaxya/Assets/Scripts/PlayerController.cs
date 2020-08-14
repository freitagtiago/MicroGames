using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float controlSpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;

    [Header("Screen Parameters")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 9f;
    

    [Header("Control Throw Based")]
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float controlRollFactor = -20f;
    float xThrow;
    float yThrow;
    bool isControlEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnable)
        {
            ProcessTranslation();
            ProcessRotation();
        }
        
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        transform.localPosition = GetXPosition();
        transform.localPosition = GetYPosition();
    }

    private Vector3 GetXPosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, xRange * -1, xRange);
        return new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private Vector3 GetYPosition()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yOffset, yRange * -1, yRange);
        return new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }  
    void OnPlayerDeath() //called by string reference
    {
        isControlEnable = false;
    }
}
