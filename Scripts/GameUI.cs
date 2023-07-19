using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [SerializeField] Text turnResultText;
    [SerializeField] Text playerLifeText;
    [SerializeField] Text enemyLifeText;

    public void Init()
    {
        turnResultText.gameObject.SetActive(false); 
    }
    //resultado de la partida de ese turno
    public void ShowLifes (int playerLife,int enemyLife)
    {

    }
    public void ShowTurnresult(string result)
    {
        turnResultText.gameObject.SetActive(true);
        turnResultText.text = result;
    }
    public void SetupNextTurn()
    {
        turnResultText.gameObject.SetActive(false);
    }
}
