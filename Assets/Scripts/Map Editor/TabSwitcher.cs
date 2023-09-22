using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    public List<GameObject> Tabs = new();

    // this is kinda janky but oh well
    public void SwitchTabs(GameObject tab)
    {
        foreach (GameObject _tab in Tabs)
        {
            if (_tab == tab && !_tab.activeInHierarchy) tab.SetActive(true);
            else _tab.SetActive(false);
        }
    }
}
