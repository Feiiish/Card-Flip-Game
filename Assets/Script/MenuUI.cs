using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class exitUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //get the click object, and flip it
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject item = hit.collider.gameObject;
                if (item.name == "exit")
                {
                    Debug.Log("Going to menu");
                    Application.Quit();
                }


            }
        }
    }




}
