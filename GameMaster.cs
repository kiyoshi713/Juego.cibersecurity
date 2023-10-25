using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Battler player;
    [SerializeField] Battler enemy;
    [SerializeField] Cardgenerator cardGenerator;
    [SerializeField] GameObject submitbutton;
    RuleBook ruleBook;
    private void Awake()
    {
        ruleBook = GetComponent<RuleBook>();
    }
    private void Start()
    {
        Setup();
    }
    void Setup()
    {
        player.onSubmitAction = SubmiteedAction;
        enemy.onSubmitAction = SubmiteedAction;
        SendCardsTo(player);
        SendCardsTo(enemy); }
    void SubmiteedAction()
    {
        if (player.IsSubmitted && enemy.IsSubmitted)
        {
            submitbutton.SetActive(false);
            StartCoroutine(CardsBattle());
        }
            //Debug.Log("avisar");
        else if (player.IsSubmitted)
        { 
            submitbutton.SetActive(false);
            enemy.RandomSubmit();
        }
        else if (enemy.IsSubmitted)
        {

        }
    }
    void SendCardsTo(Battler battler) {
        for (int i = 0; i < 8; i++)
        {
            Card card = cardGenerator.Spawn(i);
            //battler.Hand.Add(card);
            battler.SetcardToHand(card);
        }
        battler.Hand.ResetPosition(); }
    
    IEnumerator CardsBattle()
    {
        yield return new WaitForSeconds(1f);
        Result result = ruleBook.GetResult(player, enemy);
        Debug.Log(result);
        yield return new WaitForSeconds(1f);
        SetupNextTurn();
    }
    void SetupNextTurn()
    {
        player.SetupNextTurn();
        enemy.SetupNextTurn();
        submitbutton.SetActive(true);
    }
}

