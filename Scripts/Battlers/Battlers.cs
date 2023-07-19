using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battler : MonoBehaviour
{
    [SerializeField] BattlerHand hand;
    [SerializeField] SubmitPosition submitPosition;
    public bool IsSubmitted { get; private set; }
    public UnityAction OnSubmitAction;
    
    public BattlerHand Hand { get => hand; }
    public Card SubmitCard { get => submitPosition.SubmitCard; }
    public int Life { get; set; }
    public void SetcardTohand(Card card)
    {
        hand.Add(card);
        card.OnClickcard = SelectedCard;
    }
    void SelectedCard(Card card)

    {
        Debug.Log("r");
        if (IsSubmitted)
        {
            return;
        }
        //si ya esta colocado devolver a la mano
        if (submitPosition.SubmitCard)
        {
            hand.Add(submitPosition.SubmitCard);
        }
        hand.Remove(card);
        submitPosition.Set(card);
        hand.ResetPosition();
        //Debug.Log(card.Base.Number);
    }
    //no se debe cambiar la carta ya elegida
    public void OnsubmitButton()
    {
        if (submitPosition.SubmitCard)
        {
            IsSubmitted = true;
            OnSubmitAction?.Invoke();
        }
    }
    public void RandomSubmit()
    { //se extrae una carta al azar del mazo
        Card card = hand.RandomRemove();
        //entrega carta
        submitPosition.Set(card);
        //responder al gamemaster
        IsSubmitted = true;
        OnSubmitAction?.Invoke();
        hand.ResetPosition();
    }
    public void SetupNextTurn()
    {
        IsSubmitted = false;
        submitPosition.Deletecard();
    }
}
