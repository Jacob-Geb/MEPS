
using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public event Action OnEnter;

    public AudioClip[] clips;
    public AudioSource audioSource;

    void Start(){
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            OnEnter?.Invoke();

            audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}
