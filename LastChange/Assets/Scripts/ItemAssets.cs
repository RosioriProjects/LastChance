using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance{ get; private set; }
    public Transform pfItemWorld;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] public Sprite woodSprite;
    [SerializeField] public Sprite meatSprite;
}
