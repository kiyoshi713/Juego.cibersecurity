using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitPosition : MonoBehaviour
{
    // controla la carta seleccionada
    Card submitCard;
    public Card SubmitCard { get => submitCard; }
    //convertir en clase hijo y convertir el espacio 
    public void Set(Card card)
    {
        submitCard = card;
        card.transform.SetParent(transform);
        card.transform.position = transform.position;
    }
    public void Deletecard()
    {
        Destroy(SubmitCard.gameObject);
        submitCard = null;
    }
}
