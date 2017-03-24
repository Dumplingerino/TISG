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
    [SerializeField]
    private RectTransform descriptionPanel;
    private Text descriptionText;

    void Start()
    {
        descriptionText = descriptionPanel.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        descriptionPanel.anchoredPosition = Input.mousePosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            player.DropItem(slotIndex);
            OnPointerEnter(eventData);
        } else if (eventData.button == PointerEventData.InputButton.Right)
        {
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Item item = player.Inventory.GetItem(slotIndex);
        if (item == null)
        {
            descriptionPanel.gameObject.SetActive(false);
            return;
        }
        descriptionText.text = item.description + "\n\nClick to drop";
        descriptionPanel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.gameObject.SetActive(false);
    }
}
