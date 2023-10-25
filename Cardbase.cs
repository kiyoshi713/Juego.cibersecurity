using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Cardbase : ScriptableObject 
{
    [SerializeField] new string name;
    [SerializeField] CardType type;
    [SerializeField] int number;
    [SerializeField] Sprite icon;
    [SerializeField] string descripcion;

    public string Name { get => name; }
    public  CardType Type{ get => type ; }
    public int Number{ get => number; }
    public Sprite Icon{ get => icon; }
   public string Descripcion{ get => descripcion; }
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
