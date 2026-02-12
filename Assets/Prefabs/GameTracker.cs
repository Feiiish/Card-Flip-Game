using UnityEngine;

[CreateAssetMenu(fileName = "GameTracker", menuName = "Scriptable Objects/GameTracker")]
public class GameTracker : ScriptableObject
{
    public GameSet gameSet = GameSet.Set2_3;
}
