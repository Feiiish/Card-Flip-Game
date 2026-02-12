
using UnityEngine;
public enum GameSet
{
    Set2_3,
    Set3_4,
    Set4_4
}


public class CardPlacer : MonoBehaviour
{
    public Transform positonHolder2_3;
    public Transform positonHolder3_4;
    public Transform positonHolder4_4;
    public Transform cardSet;
    int cardNum = 6;
    public GameTracker gameTracker;
    void Start()
    {


        Vector3[] positions = null;

        if (gameTracker.gameSet == GameSet.Set2_3)
        {
            positions = GetChildPositions(positonHolder2_3);
            cardNum = 6;
        }


        else if (gameTracker.gameSet == GameSet.Set3_4)
        {
            positions = GetChildPositions(positonHolder3_4);
            cardNum = 12;
        }

        else if (gameTracker.gameSet == GameSet.Set4_4)
        {
            positions = GetChildPositions(positonHolder4_4);
            cardNum = 16;
        }


        Transform[] newCards = getNewSuffledCards();


        for (int i = 0; i < newCards.Length && i < positions.Length; i++)
        {
            newCards[i].position = positions[i];
        }
    }


    Transform[] getNewSuffledCards()
    {
        Transform[] allCards = GetChildTrans(cardSet);

        //get cardNum cards
        Transform[] selected = new Transform[cardNum];
        for (int i = 0; i < cardNum; i++)
        {
            selected[i] = allCards[i];
        }

        //suffle
        for (int i = selected.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            (selected[i], selected[rand]) = (selected[rand], selected[i]);
        }

        return selected;
    }



    public Vector3[] GetChildPositions(Transform parent)
    {
        int count = parent.childCount;
        Vector3[] positions = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            positions[i] = parent.GetChild(i).position;
        }

        return positions;
    }


    public Transform[] GetChildTrans(Transform parent)
    {
        int count = parent.childCount;
        Transform[] positions = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            positions[i] = parent.GetChild(i).transform;
        }

        return positions;
    }


}
