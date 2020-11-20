
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPTriggers : MonoBehaviour
{
    #pragma warning disable 0414
    [SerializeField]
    private PlanetController Earth;
    [SerializeField]
    private PlanetController Mars;
    [SerializeField]
    private DeathZone deathZone;
    [SerializeField]
    private PostProcessVolume ppVolume;
    #pragma warning restore 0414

    private Bloom bloom;
    private ChromaticAberration chrome;

    private float bloomVal = 0;

    public void Start()
    {
        ppVolume.profile.TryGetSettings(out bloom);
        ppVolume.profile.TryGetSettings(out chrome);

        bloomVal = 0;
                
        Earth.OnHit += HitEarth;
        Mars.OnHit += HitMars;
        // deathZone.OnEnter += OnDie;
    }

    public void Update()
    {

        if (bloomVal > 0){
            bloomVal = Mathf.Max(0f,bloomVal - (Time.deltaTime * 50f));
            bloom.intensity.value = bloomVal;
            chrome.intensity.value = bloomVal/60;
        }
    }

    private void HitEarth()
    {
        bloomVal = 20;
    }

    private void HitMars()
    {
        bloomVal = 20;
    }
}
