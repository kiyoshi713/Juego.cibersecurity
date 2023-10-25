using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cardgenerator : MonoBehaviour
{
    [SerializeField] Cardbase[] cardBases;
    [SerializeField] Card cardPrefab;
    
    public Card Spawn(int number)
    {
        Card card = Instantiate (cardPrefab);
        card.Set(cardBases[number]);
        return card;
    }
}
