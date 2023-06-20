using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTagsManager : MonoBehaviour
{
    [SerializeField] Button coffeeTag;
    [SerializeField] Button fashionTag;
    [SerializeField] Button restaurantTag;

    [SerializeField] string[] shopTags;
    [SerializeField] Renderer[] level1Shops;
    [SerializeField] Renderer[] level2Shops;
    void Start()
    {
        BtnListener(coffeeTag, shopTags[0], Color.green);
        BtnListener(fashionTag, shopTags[1], Color.red);
        BtnListener(restaurantTag, shopTags[2], Color.grey);
    }

    void BtnListener(Button btn, string tagName, Color shopHighLight)
    {
        btn.onClick.AddListener(() => HighlightShop(tagName, shopHighLight));
    }

    void HighlightShop(string tagName, Color shopColorHighlight)
    {
        FindAllShopRenderers();
        GameObject[] shops = GameObject.FindGameObjectsWithTag(tagName);
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].GetComponent<Renderer>().material.color = shopColorHighlight;
        }
    }

    void FindAllShopRenderers()
    {
        level1Shops = GameObject.Find("Level1").transform.Find("Shops").GetComponentsInChildren<Renderer>();
        level2Shops = GameObject.Find("Level2").transform.Find("Shops").GetComponentsInChildren<Renderer>();
        SetColor(level1Shops, Color.white);
        SetColor(level2Shops, Color.white);
    }

    void SetColor(Renderer [] shops, Color buildingColor)
    {
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].material.color = buildingColor;
        }
    }
}
