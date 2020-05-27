using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    [SerializeField] public int id_item;
    [SerializeField] public string title;
    [SerializeField] public string equippable_consummable;
    [SerializeField] public int hp_modifier;
    [SerializeField] public int armor_modifier;
    [SerializeField] public int hunger_modifier;
    [SerializeField] public int weather_modifier;
    [SerializeField] public int attack_modifier;
    [SerializeField] public int drop_modifier;
    [SerializeField] public int speed_modifier;

    [SerializeField] public int amount;
    private void Start()
    {
        ItemWorld.SpawnItemWorld(transform.position, new Item(id_item,title,equippable_consummable,hp_modifier,armor_modifier,hunger_modifier,weather_modifier,attack_modifier,drop_modifier,speed_modifier,amount));
        Destroy(gameObject);
    }
}
