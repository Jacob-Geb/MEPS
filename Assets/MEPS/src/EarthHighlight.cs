
using UnityEngine;

public class EarthHighlight : MonoBehaviour
{
    public GameLogic gameLogic;
    public SpriteRenderer spriteRenderer;
    public Color Dark;

    private void Update(){

        if (gameLogic.peopleOnShip < 5){
            spriteRenderer.color = Color.white;
        }
        else{
            spriteRenderer.color = Dark;
        }
    }
}
