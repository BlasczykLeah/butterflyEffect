using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteraction : MonoBehaviour
{
    public KeyCode interaction;
    List<GameObject> interactables;

    void Start()
    {
        interactables = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(interaction))
        {
            if (interactables.Count == 0) Debug.LogError("nothing to interact with");
            else Debug.Log("Interacted with " + interactables[0].name);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            //collision.GetComponent<Interactable>().outlineRenderer.enabled = true;
            collision.GetComponent<Interactable>().enableHighlight(true);
            interactables.Add(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            //collision.GetComponent<Interactable>().outlineRenderer.enabled = false;
            collision.GetComponent<Interactable>().enableHighlight(false);
            interactables.Remove(collision.gameObject);
        }
    }
}
