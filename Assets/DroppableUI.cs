using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    Image image;
    Color previousColor;
    RectTransform rectTransform;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        previousColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null)
            image.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if(eventData.pointerDrag != null)
            image.color = previousColor;
    }

    public void OnDrop(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null)
        {
            DraggableUI draggableUI = eventData.pointerDrag.GetComponent<DraggableUI>();

            if (draggableUI != null)
            {
                draggableUI.ResetPosition();
                image.color = previousColor;
                GameManager.instance.MoveStep((GameManager.GameStep)draggableUI.GetAssignedIndex());
                draggableUI.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
}
