
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public int peopleOnShip;
    public int maxPeopleOnShip = 5;
    public int peopleOnMars;

    #pragma warning disable 0414
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private Transform spawnPos;
    [Space]
    [SerializeField]
    private PlanetController Earth;
    [SerializeField]
    private PlanetController Mars;
    [SerializeField]
    private DeathZone deathZone;
    [SerializeField]
    private AsteroidSwap asteroidSwap;
    [Space]
    [SerializeField]
    private TextMeshPro MissionLabel;
    [SerializeField]
    private TextMeshPro ShipLabel;
    [SerializeField]
    private TextMeshPro MarsLabel;
    [SerializeField]
    private GameObject Instrux;
    #pragma warning restore 0414

    private bool alive;
    private bool readyForRestart;

    public void Start()
    {        
        Earth.OnHit += HitEarth;
        Mars.OnHit += HitMars;
        deathZone.OnEnter += OnDie;

        MissionLabel.text = ""; 
        OnDie();
    }

    public void Update()
    {
        if (!alive && Input.GetMouseButton(0) && readyForRestart){
            startNewGame();
        }
    }

    public void OnDestroy()
    {
        Earth.OnHit -= HitEarth;
        Mars.OnHit -= HitMars;
        deathZone.OnEnter -= OnDie;
    }

    private void OnDie()
    {
        alive = false;
        ball.gameObject.SetActive(false);

        Cursor.visible = true;
        MissionLabel.text = ""; 

        Invoke("showMenu", 0.3f);
    }

    private void showMenu()
    {
        Instrux.gameObject.SetActive(true);
        readyForRestart = true;
    }

    private void startNewGame()
    {
        alive = true;
        ball.gameObject.SetActive(true);
        Instrux.gameObject.SetActive(false);
        asteroidSwap.Reset();

        ball.transform.position = spawnPos.position;
        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity *= 0;
        rb.angularVelocity *= 0;

        peopleOnShip = 0;
        peopleOnMars = 0;
        updateUI();

        Cursor.visible = false;
        readyForRestart = false;
    }

    public void HitEarth()
    {
        if (peopleOnShip < maxPeopleOnShip){
            peopleOnShip++;
            updateUI();
        } 
    }

    public void HitMars()
    {
        if (peopleOnShip > 0){
            peopleOnShip--;
            peopleOnMars++;
            updateUI();
        } 
    }

    private void updateUI()
    {
        MissionLabel.text = (peopleOnShip == 0) ? "> Pick up humans on earth <" : "> Bring humans to Mars <"; 
        ShipLabel.text = (peopleOnShip < maxPeopleOnShip) ? (peopleOnShip + "") : "Max";
        MarsLabel.text = ""+peopleOnMars;
    }
}
