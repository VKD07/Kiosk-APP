using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject searchShopPanel;
    
    public void SearchPanelSetActive(bool enable)
    {
        searchShopPanel.SetActive(enable);
    }   
}
