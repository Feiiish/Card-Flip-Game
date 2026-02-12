using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class Card : MonoBehaviour
{
    public int matchNumber = 0;
    [HideInInspector]
    public bool isRevealed;

    public GameObject faceUpIcon;



    public float flipDuration = 0.5f;
    private float current = 0f;
    bool flipping = false;
    void Start()
    {
        SwitchSprite();
    }
    public void flip()
    {
        Debug.Log("Flip called");
        isRevealed = !isRevealed;
        current = 0f;
        flipping = true;
    }

    void Update()
    {
        if (flipping)
        {
            current += Time.deltaTime / flipDuration;
            float angle = Mathf.Lerp(0f, 180f, current);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if (current <= 0.55 && current >= 0.45)
            {
                SwitchSprite();
            }

            if (current >= 1f)
            {
                flipping = false;
            }
        }
    }

    void SwitchSprite()
    {
        if (isRevealed && faceUpIcon != null)
        {
            faceUpIcon.SetActive(true);
        }
        else
        {
            faceUpIcon.SetActive(false);
        }
    }

}