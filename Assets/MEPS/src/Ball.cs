
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool soundFlag = false;
    private Rigidbody2D rb;
    private AudioSource sound;

    #pragma warning disable 0414
    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private float timeScale;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private Transform view;

    [SerializeField]
    private float viewAngle; 
    #pragma warning restore 0414

    private void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        Time.timeScale = timeScale;
        Physics2D.gravity = new Vector3(0, -gravity);
    }

    private void Update()
    {
        var mag = rb.velocity.magnitude;

        if (mag > maxVelocity){
            rb.velocity *= (maxVelocity/mag);
        }

        viewAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        view.transform.localRotation = Quaternion.AngleAxis(viewAngle, Vector3.forward);

        var size = 0.3f;
        var squash = Mathf.InverseLerp(0, maxVelocity, mag) * 0.2f;
        view.transform.localScale = new Vector3(size + squash, size - squash, 1);
        

        // if (rb.velocity.magnitude > maxVelocity){
        //     maxVelocity = rb.velocity.magnitude;
        // }
    }

    private void OnCollisionEnter2D(Collision2D evt)
    {
        if (sound != null && soundFlag == false)
        {
            soundFlag = true;
            sound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D evt)
    {
        soundFlag = false;
    }
}
