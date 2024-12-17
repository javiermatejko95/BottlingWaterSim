using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private float distance = 3f;

    [SerializeField] private LayerMask mask = default;

    [SerializeField] private TextMeshProUGUI txtMessage;

    private bool canInteract;

    private void Awake()
    {
        CursorManager.Instance.OnChangeCursorState += HandleOnChangeCursorState;

        canInteract = true;
    }

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if(!canInteract)
        {
            return;
        }

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (!txtMessage.gameObject.activeSelf)
                {
                    txtMessage.gameObject.SetActive(true);
                }

                interactable.Interact();

                //if (Input.GetKeyDown(KeyCode.E))
                //{
                //    interactable.Interact();                    
                //}
            }
        }
        else
        {
            if (txtMessage.gameObject.activeSelf)
            {
                txtMessage.gameObject.SetActive(false);
            }
        }
    }

    private void HandleOnChangeCursorState(bool status)
    {
        canInteract = status;
    }
}
