using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTagsManager : MonoBehaviour
{
    [SerializeField] Button coffeeTag;
    [SerializeField] Button fashionTag;
    [SerializeField] Button restaurantTag;

    void Start()
    {
        BtnListener(coffeeTag, "Coffee", Color.green);
        BtnListener(fashionTag, "Fashion", Color.red);
        BtnListener(restaurantTag, "Restaurant", Color.grey);
    }

    void BtnListener(Button btn, string tagName, Color shopHighLight)
    {
        btn.onClick.AddListener(() => HighlightShop(tagName, shopHighLight));
    }

    void HighlightShop(string tagName, Color shopColorHighlight)
    {
        GameObject[] shops = GameObject.FindGameObjectsWithTag(tagName);
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].GetComponent<Renderer>().material.color = shopColorHighlight;
        }
    }
}
