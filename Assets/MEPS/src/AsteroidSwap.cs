
using System;
using UnityEngine;

public class AsteroidSwap : MonoBehaviour
{
    public event Action OnEnter;
    public GameObject[] earthAstroids;
    public GameObject[] marsAstroids;

    #pragma warning disable 0414
    [SerializeField]
    private AudioSource audioSource;
    #pragma warning restore 0414

    private void Start(){
        Reset();
    }

    public void Reset(){
        foreach (var ast in earthAstroids){
            ast.SetActive(false);
        }
        foreach (var ast in marsAstroids){
            ast.SetActive(true);
        }
    }

    private void toggle(){

        if (earthAstroids[0].activeInHierarchy){
            foreach (var ast in earthAstroids){
                ast.SetActive(false);
            }
            foreach (var ast in marsAstroids){
                ast.SetActive(true);
            }
        }
        else{
            foreach (var ast in earthAstroids){
                ast.SetActive(true);
            }
            foreach (var ast in marsAstroids){
                ast.SetActive(false);
            }   
        }

    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            toggle();
            audioSource.Play();
        }
    }
}
