using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MainMenuAudio;
    [SerializeField] AudioSource CombatMenuAudio;
    [SerializeField] AudioSource Motor;
    [SerializeField] AudioSource ExplosionSource;
    [SerializeField] AudioClip Explosion;
    [SerializeField] AudioSource GunshotSource;
    [SerializeField] AudioClip[] Gunshots;
    [SerializeField] AudioClip[] MotorClip;

    public static AudioManager instance;

    public void Awake()
    {
        instance = this;
        MainMenuAudio.Play();
        //StartCoroutine(FadeOut(MainMenuAudio));
    }

    public void StartGameAudio()
    {
        Motor.PlayOneShot(MotorClip[0]);
        Motor.Play();
    }

    public void StartCombatAudio()
    {
        MainMenuAudio.Stop();
        StartCoroutine(FadeOut(MainMenuAudio));
        CombatMenuAudio.Play();
    }

    public void CombatEndAudio()
    {
        StartCoroutine(FadeOut(CombatMenuAudio));
        MainMenuAudio.Play();
    }

    public void ExplosionAudio()
    {
        ExplosionSource.PlayOneShot(Explosion);
    }

    public void GunshoutAudio()
    {
        GunshotSource.PlayOneShot(Gunshots[Random.Range(0, Gunshots.Length)]);
    }

    IEnumerator FadeOut(AudioSource source)
    {
        while (source.volume > 0.03f)
        {
            source.volume -= 0.02f;
            yield return null;
        }
        source.Stop();
        source.volume = 1F;
    }
}
