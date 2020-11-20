using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float AngleMult;
    public float Velocity = 10;

    public event Action OnHit;

    #pragma warning disable 0414
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioSource audioSource;
    #pragma warning restore 0414

    private void Awake(){
        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    }
 
    private void Update()
    {
        var mouseX = camera.ScreenToWorldPoint(Input.mousePosition).x;
        mouseX = Mathf.Clamp(mouseX, MinX, MaxX);
        transform.localPosition = new Vector3(mouseX, transform.localPosition.y, 0);
    }

    
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            OnHit?.Invoke();

            var diff = transform.position.x - obj.transform.position.x;

            var rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity *= 0;
            rb.angularVelocity *= 0;

            rb.velocity = getAngle(diff * AngleMult);

            audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }

    private Vector2 getAngle(float degrees) {

        var v = new Vector2(0, Velocity);
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
     }
}
