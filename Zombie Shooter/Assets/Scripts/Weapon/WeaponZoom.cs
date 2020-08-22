using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera = null;
    float zoomIn = 20f;
    float zoomOut = 48f;
    float zoomOutSensitivity = 2f;
    float zoomInSensitivity = 0.5f;
    bool zommedInToggle = false;

    [SerializeField] RigidbodyFirstPersonController fpsController;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zommedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zommedInToggle = false;
        _fpsCamera.fieldOfView = zoomOut;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zommedInToggle = true;
        _fpsCamera.fieldOfView = zoomIn;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
