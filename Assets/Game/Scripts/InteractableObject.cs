using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public bool playerInRange = false;

    public string GetItemName()
    {
        return ItemName;
    }


    private void OnTriggerEnter(Collider other)
    {

        playerInRange = true;

    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }


}