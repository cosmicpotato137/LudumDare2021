using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonControler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject icon1;
    public GameObject icon2;

    private void Start()
    {
        icon1.SetActive(false);
        icon2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        icon1.SetActive(true);
        icon2.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        icon1.SetActive(false);
        icon2.SetActive(false);
    }
}
