using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardStats : ScriptableObject {
    public string  cardname;
    public string description;
    public Sprite artwork;
    public int manaCost;
    public int attack;
    public int health;
    public string tire;

}
