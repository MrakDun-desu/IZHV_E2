using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// The main Obstacle behaviour.
/// </summary>
public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Mask for objects causing the obstacle to disappear.
    /// </summary>
    public LayerMask despawnLayerMask;

    /// <summary>
    /// Movement speed of this obstacle.
    /// </summary>
    [Range(1, 3)] public float movementSpeed = 1.0f;

    /// <summary>
    /// Direction of movement.
    /// </summary>
    public float2 movementDirection = new(-1.0f, 0.0f);

    /// <summary>
    /// Our RigidBody used for physics simulation.
    /// </summary>
    private Rigidbody2D mRB;

    /// <summary>
    /// Our BoxCollider used for collision detection.
    /// </summary>
    private BoxCollider2D mBC;

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    private void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
        mBC = GetComponent<BoxCollider2D>();

        mRB.velocity = movementDirection * movementSpeed;
    }

    /// <summary>
    /// Event triggered when we collide with something.
    /// </summary>
    /// <param name="other">The thing we collided with.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check the collided object against the layer mask.
        var hitDespawn = mBC.IsTouchingLayers(despawnLayerMask);

        // If we collide with any de-spawner -> destroy this object.
        if (hitDespawn)
        { Destroy(gameObject); }
    }
}
