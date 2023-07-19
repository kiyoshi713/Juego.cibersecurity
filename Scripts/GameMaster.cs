using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Battler player;
    [SerializeField] Battler enemy;
    [SerializeField] Cardgenerator cardgenerator;
    [SerializeField] GameObject submitButton;
    [SerializeField] GameUI gameUI;
    RuleBook ruleBook;
    private void Awake()
    {
        ruleBook=GetComponent<RuleBook>();
    }
    private void Start()
    {
        Setup();
    }
    void Setup()
    {
        gameUI.Init();
        player.Life = 4;
        enemy.Life = 4;
        player.OnSubmitAction = SubmittedAction;
        enemy.OnSubmitAction = SubmittedAction;
        SendcardsTo(player);
        SendcardsTo(enemy);
    }
    void SubmittedAction()
    {
        
        if (player.IsSubmitted && enemy.IsSubmitted)
        { submitButton.SetActive(false);
            StartCoroutine(CardsBattle());
        }//decidir resultado de la batalla
                                         
        else if (player.IsSubmitted){
            submitButton.SetActive(false);
            enemy.RandomSubmit();//el enemigo muestra una carta
}
        else if (enemy.IsSubmitted)
        {
         //esperar que el jugador muestre la carta
        }
        Debug.Log("submittedaction");
        //en caso el jugador haya entregado
    }
    void SendcardsTo(Battler battler)
    {
        for (int i = 0; i < 8; i++)
        {
            Card card = cardgenerator.Spawn(i);
            battler.SetcardTohand(card);
        }
        battler.Hand.ResetPosition();    
    }
    //resultado de la batalla de cartas
    //mostrar el resultado con un poco de retraso
    //si se termina de mostrar pasa al siguiente turno(se desace de la carta utilizada)
    IEnumerator CardsBattle()
    {
        yield return new WaitForSeconds(1f);
        Result result = ruleBook.GetResult(player, enemy);
        switch (result)
        {
            case Result.TurnWin:
            case Result.GameWin:
                gameUI.ShowTurnresult("WIN");
                enemy.Life--;
                break;
            case Result.TurnWin2:
                gameUI.ShowTurnresult("WIN");
                enemy.Life-=2;
                break;
            case Result.TurnLose2:
                gameUI.ShowTurnresult("LOSE");
                player.Life-=2;
                break;
            case Result.TurnLose:
            case Result.GameLose:
                gameUI.ShowTurnresult("LOSE");
                player.Life--;
                break;
            case Result.TurnDraw:
                gameUI.ShowTurnresult("Draw");
                break;
        }
        Debug.Log($"player.Life:{player.Life},enemy.Life:{enemy.Life}");
        yield return new WaitForSeconds(1f);
        SetupNextTurn();
    }
    //cuando se termine de mostrar, pasa al siguiente turno(desacer de la carta utilizada
    void SetupNextTurn()
    {
        player.SetupNextTurn();
        enemy.SetupNextTurn();
        gameUI.SetupNextTurn();
        submitButton.SetActive(true);
    }
}
