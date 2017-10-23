using System.Collections;
using UnityEngine;

public class Gun_DynamicCrosshair : MonoBehaviour {

    private Gun_Master gun_Master;
    public Transform canvasDymanicCrosshair;
    private Transform playerTransform;
    private Transform weaponCam;
    private float playerSpeed;
    private float nextCaptureTime;
    private float captureInterval = 0.5f;
    private Vector3 lastPos;
    public Animator crosshairAnimator;
    public string weaponCamName;

    void Start()
    {
        SetInitRef();
    }

    void Update()
    {
        CapturePlayerSpeed();
        ApplySpeedToAnimation();
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        playerTransform = MCP_References._player.transform;
        FindWeaponCam(playerTransform);
        SetCamOnDynamicCrosshairCanvas();
        SetPlaneDistOnDynamicCrosshairCanvas();
    }

    void CapturePlayerSpeed()
    {
        if(Time.time > nextCaptureTime)
        {
            nextCaptureTime = Time.time + captureInterval;
            playerSpeed = (playerTransform.position - lastPos).magnitude / captureInterval;
            lastPos = playerTransform.position;
            gun_Master.CallEventSpeedCaptured(playerSpeed);
        }
    }

    void ApplySpeedToAnimation()
    {
        if(crosshairAnimator != null)
        {
            crosshairAnimator.SetFloat("Speed", playerSpeed);
        }
    }

    void FindWeaponCam(Transform transformToSearchThrough)
    {
        if(transformToSearchThrough != null)
        {
            if(transformToSearchThrough.name == weaponCamName)
            {
                weaponCam = transformToSearchThrough;
                return;
            }

            foreach (Transform child in transformToSearchThrough)
            {
                FindWeaponCam(child);
            }
        }
    }

    void SetCamOnDynamicCrosshairCanvas()
    {
        if(canvasDymanicCrosshair !=null && weaponCam != null)
        {
            canvasDymanicCrosshair.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            canvasDymanicCrosshair.GetComponent<Canvas>().worldCamera = weaponCam.GetComponent<Camera>();
        }
    }

    void SetPlaneDistOnDynamicCrosshairCanvas()
    {
        if(canvasDymanicCrosshair != null)
        {
            canvasDymanicCrosshair.GetComponent<Canvas>().planeDistance = 1;
        }
    }

}
