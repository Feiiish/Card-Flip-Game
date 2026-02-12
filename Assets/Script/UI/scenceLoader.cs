
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class scenceLoader : MonoBehaviour
{
    public string scenceName;
    public GameSet LayoutSet;
    public GameTracker gameTracker;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //get the click object, and flip it
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.Log("Try to find the item");
            if (hit.collider != null)
            {
                GameObject item = hit.collider.gameObject;
                if (item == this.gameObject)
                {
                    SceneManager.LoadScene(scenceName);
                }


            }
        }


    }

    public void setAndGoToGame()
    {
        gameTracker.gameSet = LayoutSet;
        SceneManager.LoadScene("Game");
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void exitApp()
    {
        UnityEngine.Application.Quit();
    }


}
