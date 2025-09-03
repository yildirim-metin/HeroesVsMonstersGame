using UnityEngine;

public class FightSceneScript : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(FightContext.Instance.EnnemyName);
    }
}
