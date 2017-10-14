using System.Collections;
using UnityEngine;

public class Player_CanvasHurt : MonoBehaviour {

    public GameObject hurtCanvas;
    private Player_Master player_Master;
    [SerializeField]
    private float secondsTillHide = 2;

    private void OnEnable()
    {
        SetInitRef();
        player_Master.EventPlayerHealthDeduction += TurnOnHurtEffect;
    }

    private void OnDisable()
    {
        player_Master.EventPlayerHealthDeduction -= TurnOnHurtEffect;
    }

    void SetInitRef()
    {
        player_Master = GetComponent<Player_Master>();
    }

    void TurnOnHurtEffect(int dummy)
    {
        if(hurtCanvas != null)
        {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
        hurtCanvas.SetActive(false);
    }

}
