
using UnityEngine;

public class FullShip : MonoBehaviour
{
    public GameLogic gameLogic;

    #pragma warning disable 0414
    [SerializeField]
    private AudioSource audioSource;
    #pragma warning restore 0414

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            
            gameLogic.HitEarth();
            gameLogic.HitEarth();
            gameLogic.HitEarth();
            gameLogic.HitEarth();
            gameLogic.HitEarth();

            audioSource.Play();
        }
    }
}
