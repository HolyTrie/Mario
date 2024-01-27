using UnityEngine;

/**
 *  This component automatically adds force and torque to its object.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class ForceAdder: MonoBehaviour {
    [SerializeField] float forceSize = 10f;
    [SerializeField] ForceMode2D forceMode = ForceMode2D.Force;
    [SerializeField] float torqueSize = 10f;
    [SerializeField] ForceMode2D torqueMode = ForceMode2D.Force;

    private Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // NOTE: When you work with a physical rigid body,
        //       all changes to the rigid body should be in FixedUpdate!
        rb.AddForce(new Vector3(0,0,forceSize), forceMode);
        rb.AddTorque(torqueSize,torqueMode);
    }
}
