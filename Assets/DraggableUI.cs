using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] Vector2 startPos;
    [SerializeField] int assignedIndex;
    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        transform.SetAsLastSibling();
        GetComponent<Image>().raycastTarget = false;
        eventData.pointerDrag = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void ResetPosition()
    {
        rectTransform.localPosition = startPos;
    }

    public int GetAssignedIndex() 
    {        
        return assignedIndex;
    }

    
}
