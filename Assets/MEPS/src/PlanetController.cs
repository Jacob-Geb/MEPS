
using System;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public event Action OnHit;
    public ScreenShake screenShake;
    public ParticleSystem[] ps;

    public AudioClip[] clips;
    private AudioSource audioSource;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            OnHit?.Invoke();

            if (screenShake != null){
                screenShake.Bump(0.5f);
            }

            foreach (var particle in ps){
                particle.Play();
            }   

            audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}
