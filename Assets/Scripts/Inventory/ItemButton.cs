using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private PlayerInteractions player;
    public int slotIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        player.DropItem(slotIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < eventData.hovered.Count; i++)
        {
            Debug.Log(eventData.hovered[i].name + " hover");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("No more");
    }
}
