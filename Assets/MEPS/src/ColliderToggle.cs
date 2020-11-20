using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    public Collider2D collider;
    public ColliderToggleTrigger toggleTrigger;

    public Transform[] activateList;
    public Transform[] deactivateList;

    private void Start()
    {
        toggleTrigger.OnEnter += SwitchOn;
        toggleTrigger.OnExit += SwitchOff;

        SwitchOff();
    }

    public void SwitchOn()
    {
        collider.enabled = true;

        for (var i = 0; i < activateList.Length; i++){
            activateList[i].gameObject.SetActive(true);
        }

        for (var i = 0; i < deactivateList.Length; i++){
            deactivateList[i].gameObject.SetActive(false);
        }
    }

    public void SwitchOff()
    {
        collider.enabled = false;

        for (var i = 0; i < activateList.Length; i++){
            activateList[i].gameObject.SetActive(false);
        }

        for (var i = 0; i < deactivateList.Length; i++){
            deactivateList[i].gameObject.SetActive(true);
        }
    }
}
