using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer, shakeTimerTotal,startingIntensity;
    
    private void Awake() {
        Instance = this;
        cinemachineVirtualCamera=GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time){
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=intensity;
        startingIntensity=intensity;
        shakeTimer=time;
        shakeTimerTotal=time;
    }
    private void Update() {
        if (shakeTimer >0f)
        {
            shakeTimer-=Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=Mathf.Lerp(startingIntensity,0f,1-(shakeTimer/shakeTimerTotal));
        }
    }
}