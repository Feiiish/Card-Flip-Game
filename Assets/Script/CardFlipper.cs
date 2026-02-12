using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Position : MonoBehaviour
{
    GameObject Item1;
    GameObject Item2;
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
                Card card = item.GetComponent<Card>();
                if (card == null) { return; }
                if (Item1 == null)
                {
                    Item1 = item; card.flip(); return;
                }
                if (Item2 == null && item != Item1)
                {
                    Item2 = item; card.flip();
                    CompareCards();
                }

            }
        }


    }

    void CompareCards()
    {
        Debug.Log("trying to compare cards ");
        int matchNumber1 = Item1.GetComponent<Card>().matchNumber;
        int matchNumber2 = Item2.GetComponent<Card>().matchNumber;
        if (matchNumber1 == matchNumber2)
        {
            StartCoroutine(ClearWithAnimation());
        }
        else
        {
            StartCoroutine(flipBackWithAnimation());
        }

    }
    IEnumerator flipBackWithAnimation()
    {
        yield return new WaitForSeconds(1f);
        Item1.GetComponent<Card>().flip();
        Item2.GetComponent<Card>().flip();
        Item1 = null;
        Item2 = null;
    }
    IEnumerator ClearWithAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        float duration = 0.2f;
        float t = 0f;

        Vector3 scale1 = Item1.transform.localScale;
        Vector3 scale2 = Item2.transform.localScale;


        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            float s = Mathf.Lerp(1f, 0f, t);

            Item1.transform.localScale = scale1 * s;
            Item2.transform.localScale = scale2 * s;

            yield return null;
        }


        Destroy(Item1);
        Destroy(Item2);
        ScoreManager.instance?.addScore();

        Item1 = null;
        Item2 = null;
    }

}
