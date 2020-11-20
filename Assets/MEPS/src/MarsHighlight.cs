
using UnityEngine;

public class MarsHighlight : MonoBehaviour
{
    public GameLogic gameLogic;
    public SpriteRenderer spriteRenderer;
    public Color Dark;

    private void Update(){

        if (gameLogic.peopleOnShip == 0){
            spriteRenderer.color = Dark;
        }
        else{
            spriteRenderer.color = Color.white;
        }
    }
}
