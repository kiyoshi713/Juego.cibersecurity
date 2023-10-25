using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Card:MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text numberText;
    [SerializeField] Image icon;
    [SerializeField] Text descriptionText;
    public Cardbase Base {get;private set;}
    public UnityAction <Card> Onclickcard;
    public void Set(Cardbase cardbase)
    {
        Base = cardbase;
        nameText.text = cardbase.Name;
        numberText.text = cardbase.Number.ToString();
        icon.sprite = cardbase.Icon;
        descriptionText.text = cardbase.Descripcion;
    }
    public void Onclick()
    {
        //Debug.Log("avisa a battler");
        Onclickcard?.Invoke(this);
    }

}
