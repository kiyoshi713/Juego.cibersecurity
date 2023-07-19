using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class CardBase : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] CardType type;
    [SerializeField] int number;
    [SerializeField] Sprite icon;
    [TextArea]
    [SerializeField] string description;
    public string Name { get => name; }
    public CardType Type { get => type; }
    public int Number { get => number; }
    public Sprite Icon { get => icon; }
    public string Description { get => description; }
    // Start is called before the first frame update
}
    public enum CardType
    {
      tokens,
      password,
      cifradodatos,
      antivirus,
      phising,
      social,
      XSS,
      MITM,
      DDOS,
      firewalls,
      ojoclinico,
    }
