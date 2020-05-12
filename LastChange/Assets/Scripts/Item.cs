using UnityEngine;
using System;

public class Item 
{
    private int id_item;
    private string title;
    private string equippable_consummable;
    private int hp_modifier;
    private int armor_modifier;
    private int hunger_modifier;
    private int weather_modifier;
    private int attack_modifier;
    private int drop_modifier;
    private int speed_modifier;

    public int amount;

    public Item(int id_item, string title, string equippable_consummable, int hp_modifier, int armor_modifier, int hunger_modifier, int weather_modifier, int attack_modifier, int drop_modifier, int speed_modifier, int amount)
    {
        this.id_item = id_item;
        this.title = title;
        this.equippable_consummable = equippable_consummable;
        this.hp_modifier = hp_modifier;
        this.armor_modifier = armor_modifier;
        this.hunger_modifier = hunger_modifier;
        this.weather_modifier = weather_modifier;
        this.attack_modifier = attack_modifier;
        this.drop_modifier = drop_modifier;
        this.speed_modifier = speed_modifier;
        this.amount = amount;
    }

    public bool IsStackable()
    {
        switch (title)
        {
            default:
            case "wood":
                return true;
            case "meat":
                return false;
        }
    }
    public int GetIdItem()
    {
        return id_item;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetEquippableConsummable()
    {
        return equippable_consummable;
    }

    public int GetHpModifier()
    {
        return hp_modifier;
    }
    public int GetArmorModifier()
    {
        return armor_modifier;
    }
    public int GetHungerModifier()
    {
        return hunger_modifier;
    }
    public int GetWatherodifier()
    {
        return weather_modifier;
    }
    public int GetAttackModifier()
    {
        return attack_modifier;
    }
    public int GetDropModifier()
    {
        return drop_modifier;
    }
    public int GetSpeedModifier()
    {
        return speed_modifier;
    }

    public Sprite GetSprite()
    {
        switch (title)
        { default:
            case "wood":   return ItemAssets.Instance.woodSprite;
            case "meat":   return ItemAssets.Instance.meatSprite;
        }
    }




}
