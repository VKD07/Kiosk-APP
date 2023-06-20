using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingNameHandler : MonoBehaviour
{
    [SerializeField] string noShopErrorTxt = "Shop Not Available";
    [SerializeField] GameObject[] shopsAvailable;
    [SerializeField] List <string> shopNames;
    [SerializeField] public Transform[] stairs;

    void Start()
    {
        initShopNames();
    }

    private void initShopNames()
    {
        shopsAvailable = GameObject.FindGameObjectsWithTag("Shop");
       
        foreach(var shopName in shopsAvailable)
        {
            shopNames.Add(shopName.name);
        }
    }
    //public Transform GetBuildingLocation(string nameOfShop)
    //{
    //    //foreach(var shopName in shopNames)
    //    //{
    //    //    if (shopName.Contains(nameOfShop))
    //    //    {
    //    //        foreach(var shopLoc in shopsAvailable)
    //    //        {
    //    //            if (shopLoc.name.Contains(shopName)){
    //    //                shopLocation = shopLoc.transform;
    //    //            }
    //    //        }
    //    //    }
    //    //}

    //    shopLocation = GameObject.Find(nameOfShop).transform;
    //    return shopLocation;
    //}
}
