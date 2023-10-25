using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battler : MonoBehaviour
{
    [SerializeField] Battlerhand hand;
    [SerializeField] SubmitPosition submitPosition;
    public bool IsSubmitted { get; private set; }
    public UnityAction onSubmitAction;
    public Battlerhand Hand { get => hand; }
    public Card SubmitCard { get => submitPosition.SubmitCard; }
    public void SetcardToHand(Card card)
    {
        hand.Add(card);
        card.Onclickcard = SelectedCard;
    }
    void SelectedCard(Card card)
    {
        if (IsSubmitted)
        {
            return;
        }
        if (submitPosition.SubmitCard)
        {
            hand.Add(submitPosition.SubmitCard);
        }
        hand.Remove(card);
        submitPosition.Set(card);
        hand.ResetPosition();
        //Debug.Log(card.Base.Number);
    }
    public void OnsubmitButton()
    {
        if (submitPosition.SubmitCard)
        {
            IsSubmitted = true;
            //avisab eleccion de la carta
            onSubmitAction?.Invoke();
        }
    }
    public void RandomSubmit()
    {
        Card card = hand.RandomRemove();
        submitPosition.Set(card);
        IsSubmitted = true;
        onSubmitAction?.Invoke();
        hand.ResetPosition();
    }
    public void SetupNextTurn()
    {
        IsSubmitted = false;
        submitPosition.DeleteCard();
    }
}
