using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text nameText;
    [SerializeField] Text numberText;
    [SerializeField] Image icon;
    [SerializeField] Text descriptionText;
    
    public Cardbase Base { get; private set; }
    // puede registrar las funciones
    public UnityAction<Card> OnClickcard;
    public void Set(Cardbase cardBase)
    {
        Base = cardBase;
        nameText.text=cardBase.Name;
        numberText.text = cardBase.Number.ToString();
        icon.sprite = cardBase.Icon;
        descriptionText.text = cardBase.Description;
    }
    public void OnClick()
    {
        Debug.Log("avisar");
        OnClickcard?.Invoke(this);
    }
}



