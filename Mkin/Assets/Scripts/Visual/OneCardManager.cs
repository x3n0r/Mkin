using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


// holds the refs to all the Text, Images on the card
public class OneCardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text NameText;
	public Text DescriptionText;
	public Image OneTimeUseImage;
	public Text SellText;
    public Text BonusText;
	public Text EquipSlotText;
	public Text UseableByText;
	public List<GameObject> CardBackList;


    [Header("Image References")]
    public Image CardTopRibbonImage;
    public Image CardLowRibbonImage;
    public Image CardGraphicImage;
    public Image CardBodyImage;
    public Image CardFaceFrameImage;
    public Image CardFaceGlowImage;
    public Image CardBackGlowImage;

    void Awake()
    {
        if (cardAsset != null)
            ReadCardFromAsset();
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;

            CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {
        // universal actions for any Card
        // 1) apply tint
        if (cardAsset.characterAsset != null)
        {
            CardBodyImage.color = cardAsset.characterAsset.ClassCardTint;
            CardFaceFrameImage.color = cardAsset.characterAsset.ClassCardTint;
            CardTopRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
            CardLowRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
        }
        else
        {
            //CardBodyImage.color = GlobalSettings.Instance.CardBodyStandardColor;
            CardFaceFrameImage.color = Color.black;
            //CardTopRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
            //CardLowRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
        }
        // 2) add card name
        NameText.text = cardAsset.name;
        // 3) add OneTimeUse
		OneTimeUseImage.gameObject.SetActive(cardAsset.OneTimeUse);
        // 4) add description
        DescriptionText.text = cardAsset.Description;
        // 5) Change the card graphic sprite
        CardGraphicImage.sprite = cardAsset.CardImage;

		if (cardAsset.Level == 0) {
			EquipSlotText.text = cardAsset.EquipmentSlot.ToString ();
			UseableByText.text = cardAsset.UseableBy.ToString ();
			// 6) Set sell value
			if (cardAsset.SellValue != 0) {
				SellText.text = cardAsset.SellValue.ToString ();
			}
			// 7) Set Bonus Value
			if (cardAsset.BonusValue != 0) {
				BonusText.text = cardAsset.BonusValue.ToString ();
			}
		} else {
			EquipSlotText.text = "";
			UseableByText.text = "";
			// 6) Set TreasureAmount value
			if (cardAsset.TreasureAmount != 0) {
				SellText.text = cardAsset.TreasureAmount.ToString ();
			}
			// 7) Set Level as Bonus Value
			if (cardAsset.Level != 0) {
				BonusText.text = cardAsset.Level.ToString ();
			}
		}
		foreach (GameObject go in CardBackList) {
			Debug.Log ("go name:" + go.name);
			Debug.Log ("cardasset to string name:" + cardAsset.CardBack.ToString());
			if (cardAsset.CardBack.ToString() == go.name) {
				go.SetActive (true);
			} else {
				//destory
				go.SetActive (false);
			}
		}

        if (PreviewManager != null)
        {
            // this is a card and not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
