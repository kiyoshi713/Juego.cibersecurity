using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BattlerHand : MonoBehaviour
{
    List<Card> list = new List<Card>();
    // agregar a la lista
    public void Add(Card card)
    { 
        list.Add(card);
        card.transform.SetParent(transform);
    }
    public void Remove(Card card)
    {
        list.Remove(card);
    }
    //ordenar el maso
    
    public void ResetPosition()
    { //sort: ordenar por oredn pequenyo
        list.Sort((card0, card1) => card0.Base.Number - card1.Base.Number);
        for (int i = 0; i < list.Count; i++) 
        {
            float posX = (i - list.Count/2f) * 1.99f;
            list[i].transform.localPosition = new Vector3(posX, 0);
        } }
    public Card RandomRemove()
    {
        int r = Random.Range(0, list.Count);
        Card card = list[r];
        Remove(card);
        return card;
    }
}
