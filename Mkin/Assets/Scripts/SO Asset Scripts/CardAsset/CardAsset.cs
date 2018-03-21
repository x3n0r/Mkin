using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions
{
    NoTarget,
    AllCreatures, 
    EnemyCreatures,
    YourCreatures, 
    AllCharacters, 
    EnemyCharacters,
    YourCharacters
}

public enum EquipSlotOptions
{
	OneHanded,
	TwoHanded,
	Class,
	Race
}

public enum UseableByOptions
{
	Everyone,
	Elfs,
	Dwarfs
}


public class CardAsset : ScriptableObject 
{
    // this object will hold the info about the most general card
    [Header("General info")]
    public CharacterAsset characterAsset;  // if this is null, it`s a neutral card
	public Sprite CardImage;
	[TextArea(2,3)]
	public string Description;  // Description for spell or character
	public bool OneTimeUse;
	public int SellValue;
	public int BonusValue;
	public EquipSlotOptions EquipmentSlot;
	public UseableByOptions UseableBy;

    [Header("Creature Info")]
    public int Level;   // =0 => spell card
	public int TreasureAmount;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int specialSpellAmount;
    //public TargetingOptions Targets;

}
