using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public Interactable currentInterObjScript = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInterObj)
        {
            if (currentInterObjScript.npc)
            {
                currentInterObjScript.Talk();
            }

            if (currentInterObjScript.door)
            {
                SceneManager.LoadScene(currentInterObjScript.nextScene);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Interactable"))
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<Interactable>();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;

            }
        }

    }
}
