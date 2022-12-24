using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SprintButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isSprinting;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isSprinting = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSprinting = false;
    }
}
