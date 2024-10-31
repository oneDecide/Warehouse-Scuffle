using System.Collections;
using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public Transform resetPoint;
    public GameObject player;
    public GameObject screenOverlay; // UI element to darken the screen
    public float fadeDuration = 1f;
    private FPSMovement playerMovement;
    private Player playerScript;
    private Color originalOverlayColor;

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = resetPoint.position;
        }
    }
}
