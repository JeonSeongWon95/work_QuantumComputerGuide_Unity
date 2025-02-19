using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackGroundUI : MonoBehaviour, IDropHandler
{
    Image image;
    RectTransform rectTransform;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DraggableUI draggableUI = eventData.pointerDrag.GetComponent<DraggableUI>();

            if (draggableUI != null)
            {
                draggableUI.ResetPosition();
                draggableUI.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
}
