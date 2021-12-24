using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dispatch_OnButtonClick : Dispatcher, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ActivateDispatcher(gameObject);
    }
}
