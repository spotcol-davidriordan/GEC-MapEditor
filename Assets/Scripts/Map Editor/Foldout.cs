using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Foldout : MonoBehaviour, IPointerClickHandler
{
    public bool Open = false;
    public GameObject Content;
    public GameObject Icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        // toggle
        Open = !Open;
        Content.SetActive(Open);

        // rotate icon
        Icon.transform.rotation = Open ? Quaternion.Euler(new Vector3(0, 0, 0)) : Quaternion.Euler(new Vector3(0, 0, 90));

        // force layout rebuild
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.transform as RectTransform);
    }
}
