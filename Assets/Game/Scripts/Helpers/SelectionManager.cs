using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject farm;
    [SerializeField] private GameObject interactionInfoUi;
    [SerializeField] private GameObject actionButton;

    // private TextMeshPro interactionText;

    // private void Start()
    // {
    //     interactionText = interactionInfoUi.transform.GetChild(0).GetComponent<TMP_Text>();
    // }
    void Update()
    {
        Vector3 origin = transform.position;
        if (Physics.SphereCast(origin, 0.5f, transform.forward, out RaycastHit hit, 3f))
        {
            var selectionTransform = hit.transform;
            if (hit.transform.GetComponent<InteractableObject>() && hit.transform.GetComponent<InteractableObject>().playerInRange == true)
            {
                var text = hit.transform.GetComponent<InteractableObject>().GetItemName();
                interactionInfoUi.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
                interactionInfoUi.SetActive(true);

                EnableActionButton(1f);
            }
            else
            {

                EnableActionButton(0.5f);
                interactionInfoUi.SetActive(false);

            }

            // Vector3 groundPosition = hit.point;
            // Debug.Log("Ground Position: " + groundPosition);
            Debug.DrawRay(origin, transform.TransformDirection(Vector3.forward * hit.distance), Color.red);

        }
        else
        {

            EnableActionButton(0.5f);
            interactionInfoUi.SetActive(false);


            Debug.DrawRay(origin, transform.TransformDirection(Vector3.forward * 5f), Color.black);

        }

    }

    private void EnableActionButton(float cor)
    {
        Color currentColor = actionButton.transform.GetComponent<Image>().color;


        currentColor.a = cor;

        actionButton.transform.GetComponent<Image>().color = currentColor;

        currentColor = actionButton.transform.GetChild(0).GetComponent<Image>().color;

        currentColor.a = cor;

        actionButton.transform.GetChild(0).GetComponent<Image>().color = currentColor;
    }
}
