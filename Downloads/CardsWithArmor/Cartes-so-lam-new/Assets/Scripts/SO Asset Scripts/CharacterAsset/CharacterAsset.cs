using UnityEngine;
using System.Collections;

public enum CharClass{ Essirta, Krilshein }

public class CharacterAsset : ScriptableObject 
{
	public CharClass Class;
	public string ClassName;
	public int MaxHealth = 30;
	public int Armor = 0;
	public string HeroPowerName;
	public string HeroPower2Name;
	public Sprite AvatarImage;
    public Sprite HeroPowerIconImage;
	public Sprite HeroPower2IconImage;
    public Sprite AvatarBGImage;
    public Sprite HeroPowerBGImage;
    public Color32 AvatarBGTint;
    public Color32 HeroPowerBGTint;
    public Color32 ClassCardTint;
    public Color32 ClassRibbonsTint;
}
