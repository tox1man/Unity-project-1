using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public static bool AllEnemiesDead()
    {
        GameObject[] aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        return aliveEnemies.Length > 1 ? false : true;
    }

    public static void CheckWinCondition()
    {
        if (AllEnemiesDead())
        {
            GameManager.WinGame();
        }
        return;
    }
}
