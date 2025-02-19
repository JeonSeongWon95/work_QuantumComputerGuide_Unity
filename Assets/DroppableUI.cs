using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    Image targetImage;
    Color previousColor;
    RectTransform rectTransform;

    void Awake()
    {
        targetImage = transform.parent.GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        previousColor = targetImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null)
            targetImage.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if(eventData.pointerDrag != null)
            targetImage.color = previousColor;
    }

    public void OnDrop(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null)
        {
            DraggableUI draggableUI = eventData.pointerDrag.GetComponent<DraggableUI>();

            if (draggableUI != null)
            {
                draggableUI.ResetPosition();
                targetImage.color = previousColor;
                GameManager.instance.MoveStep((GameManager.GameStep)draggableUI.GetAssignedIndex());
                draggableUI.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
}
