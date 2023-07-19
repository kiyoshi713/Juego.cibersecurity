using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] Cardbase[] cardbases;
    [SerializeField] Card cardPrefab;
    
    //creacion de cartas
    public Card Spawn(int number)
    {
        Card card=Instantiate(cardPrefab);
        card.Set(cardbases[number]);
        return card;
    }
}


