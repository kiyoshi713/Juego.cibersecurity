using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battlerhand : MonoBehaviour
{
    List<Card> list = new List<Card>();

    public void Add(Card card)
    {
        list.Add(card);
        card.transform.SetParent(transform);
    }
    public void Remove(Card card)
    {
        list.Remove(card);
    }
    public void ResetPosition()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list.Sort((card0,card1)=>card0.Base.Number - card1.Base.Number);
            float posX = (i - list.Count/2f)* 1.99f;
            list[i].transform.localPosition = new Vector3(posX, 0);
        }
    }
    public Card RandomRemove()
    {
        int r = Random.Range(0,list.Count);
        Card card = list[r];
        Remove(card);
        
        return list[r];
    }
}