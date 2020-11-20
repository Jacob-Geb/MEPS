using UnityEngine;

public class HeightDependantBumper : MonoBehaviour
{
    #pragma warning disable 0414
    [SerializeField]
    private new Collider2D collider;
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private float activateHeight;
    [SerializeField]
    private float deactivateHeight;
    [SerializeField]
    private Sprite spriteNormal;
    [SerializeField]
    private Sprite spriteHit;
    [SerializeField]
    private SpriteRenderer colliderSprite;
    #pragma warning restore 0414

    private AudioSource sound;
    private Color white = new Color(1, 1, 1, 1);
    private Color inactive = new Color(1, 1, 1, 0.2f);

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){

            sound?.Play();

            colliderSprite.sprite = spriteHit;
            Utility.AnonInvoke(this, () => colliderSprite.sprite = spriteNormal, 0.1f);
        }
    }

    private void Update()
    {
        // if (ball.transform.position.y > activateHeight){
        //     collider.enabled = true;
        //     colliderSprite.color = white;
        // }
        // else if (ball.transform.position.y < deactivateHeight){
        //     collider.enabled = false;
        //     colliderSprite.color = inactive;
        // }
    }
}
