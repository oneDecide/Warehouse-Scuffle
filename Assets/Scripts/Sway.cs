using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] public float intensity; // Sway intensity
    public float smooth;                     // Sway smoothness

    private Quaternion origin_rotation;      // Original rotation of the gun
    private Vector3 origin_position;         // Original position of the gun
    private Animator animator;               // Animator component

    private void Start()
    {
        // Save the initial local rotation and position
        origin_rotation = transform.localRotation;
        origin_position = transform.localPosition;

        // Get the Animator component
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("No Animator component found on this object!");
        }
    }

    private void Update()
    {
        UpdateSway();

        // Ensure the gun's position doesn't drift
        ResetPosition();
    }

    private void UpdateSway()
    {
        // Get mouse input
        float t_x_mous = Input.GetAxis("Mouse X");
        float t_y_mous = Input.GetAxis("Mouse Y");

        // Calculate sway adjustment based on mouse input
        Quaternion x_adj = Quaternion.AngleAxis(-intensity * t_x_mous, Vector3.up);
        Quaternion y_adj = Quaternion.AngleAxis(intensity * t_y_mous, Vector3.right);
        Quaternion tgt_rotation = origin_rotation * x_adj * y_adj;

        // Apply the sway effect smoothly
        transform.localRotation = Quaternion.Lerp(transform.localRotation, tgt_rotation, Time.deltaTime * smooth);
    }

    private void ResetPosition()
    {
        // Override the gun's position to ensure it doesn't drift
        if (animator != null && animator.applyRootMotion)
        {
            // Reset position to the original local position
            transform.localPosition = origin_position;
        }
    }
}