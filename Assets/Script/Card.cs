using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public class Card : MonoBehaviour
{
    public Text AttackText;
    public Text DefenceText;
    public Text StarText;
    public Text RarityText;
    public Image Sign;
    public Text[] Powers;
    public Animator Animator;
    public GameEngine Engine;

    public GameplayCard GpCard;

    public bool Show;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.Animator.SetBool("Show", Show);
	}

    public void OnClick()
    {
        if (Engine != null)
        {
            Engine.OnClick(this);
        }
    }

    public void Assign(GameplayCard gameplayCard)
    {
        AttackText.text = gameplayCard.Attack.ToString();
        DefenceText.text = gameplayCard.Defence.ToString();
        StarText.text = gameplayCard.Level.ToString();
        RarityText.text = gameplayCard.Rarity.ToString()[0].ToString();
        Sign.sprite = gameplayCard.Definition[0].CardImage;
        Powers[0].text = gameplayCard.Definition[0].CardPower.ToString();
        Powers[1].text = "";
    }
}

[System.Serializable]
public class GameplayCard
{
    public GameplayCard(CardDefinition.Rarity rarity, int level, params CardDefinition[] definitions)
    {
        Definition = definitions;
        Rarity = rarity;
        Level = level;
    }

    public CardDefinition[] Definition;
    public CardDefinition.Rarity Rarity;
    public int Level;

    public int Attack
    {
        get
        {
            return Definition.Sum(x => x.GetAttack(Level)) / Definition.Length;
        }
    }

    public int Defence
    {
        get
        {
            return Definition.Sum(x => x.GetDefense(Level)) / Definition.Length;
        }
    }
}

[System.Serializable]
public class CardDefinition
{
    public enum Sign
    {
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn,
        Aquarius,
        Pisces,
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Mythic
    }

    public enum Power
    {
        Shield,
        Rage,
        Multiple,
        Curse,
        Zone,
        Retribute,
        Armor,
        Poison,
        Speed,
        Trample,
        Ice,
        Regeneration,
    }

    public Sign CardSign;
    public Sprite CardImage;
    public Power CardPower;
    public int BaseAttack;
    public int BaseDefense;
    public float AttackIncrement;
    public float DefenceIncrement;

    public int GetAttack(int level)
    {
        int increment = (int)(AttackIncrement * ((float)level - 1f));
        return BaseAttack + increment;
    }

    public int GetDefense(int level)
    {
        int increment = (int)(DefenceIncrement * ((float)level - 1f));
        return BaseDefense + increment;
    }
}
