using UnityEngine;
using UnityEngine.InputSystem;

public class CardHoverClick : MonoBehaviour
{

    public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private bool isHovering;
    Card thiscard;
    private Collider2D col;

    void Start()
    {
        originalScale = transform.localScale;
        col = GetComponent<Collider2D>();
        thiscard = GetComponent<Card>();
    }

    void Update()
    {
        if (col == null) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        bool isMouseOver = col.OverlapPoint(mousePos);

        if (isMouseOver)
        {
            if (!isHovering)
            {
                isHovering = true;
                transform.localScale = originalScale * hoverScale;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                //pressed
            }
        }
        else
        {
            if (isHovering)
            {
                isHovering = false;
                transform.localScale = originalScale;
            }
        }
    }
}
