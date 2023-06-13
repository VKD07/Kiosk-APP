using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchBar : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TMP_InputField searchBar;
    [SerializeField] Button submitBtn;

    [Header("Script References")]
    [SerializeField] BuildingNameHandler buildingNameHandler;
    [SerializeField] UIHandler uihandler;
    [SerializeField] Navigator navigator;

    public Transform targetLocation;
    void Start()
    {
        submitBtn.onClick.AddListener(() => GetSearchInput(""));
    }

    public void GetSearchInput(string s)
    {
        targetLocation = GameObject.Find(searchBar.text).transform;
        navigator.SetNavDestination(targetLocation);
        uihandler.SearchPanelSetActive(false);
    }
}
