
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Sprite S1;
    public Sprite S2;
    public Sprite S3;
    public Sprite S4;
    public SpriteRenderer sr;
    public ScreenShake screenShake;

    public AudioClip[] clips;
    public AudioSource audioSource;

    private void Start(){
        InvokeRepeating ("anim", 0.1f, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            sr.sprite = S2;
            screenShake.Bump(0.25f);

            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }

    private void anim()
    {
        if (sr.sprite == S2){
            sr.sprite = S3;
        }
        else if (sr.sprite == S3){
            sr.sprite = S4;
        }
        else if (sr.sprite == S4){
            sr.sprite = S1;
        }
    }
}
