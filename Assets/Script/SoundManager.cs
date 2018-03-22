using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour
{

    public AudioClip EnvironmentClip;
    public AudioClip OnShoot;
    public AudioClip OnBulletDestroyClip;
    //public AudioClip OnShipDestroy;

    public AudioSource EnvironmentTrack;
    public AudioSource SFXTrack;

    private void Start()
    {
        EnvironmentTrack.Play();
    }

    private void OnEnable()
    {
        BulletPoolManager.OnBulletInGame += OnBulletInGame;
    }

    private void OnBulletInGame(IBullet _IBullet)
    {
        _IBullet.OnDestroy += OnBulletDestroy;
    }

    private void OnBulletDestroy(IBullet bullet)
    {
        SetSFXTrackAndPlay(OnBulletDestroyClip);
        bullet.OnDestroy -= OnBulletDestroy;
    }

    private void SetSFXTrackAndPlay(AudioClip _audioClip)
    {
        SFXTrack.clip = _audioClip;
        SFXTrack.Play();
    }

    private void OnDisable()
    {
        BulletPoolManager.OnBulletInGame -= OnBulletInGame;
    }

    public void SetEnvironmentTrack()
    {
        EnvironmentTrack.clip = EnvironmentClip;
        EnvironmentTrack.loop = true;
        EnvironmentTrack.Play();
    }

    public void SetSFXTrack()
    {

    }

}
