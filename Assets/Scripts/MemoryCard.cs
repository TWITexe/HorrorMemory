using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private CardController controller;
    private int _id;

    public int Id
    {
        get
        {
            return _id;
        }
    }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    public void OnMouseEnter()
    {
        
    }
    public void OnMouseExit()
    {
        //Move your card down
    }


    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
