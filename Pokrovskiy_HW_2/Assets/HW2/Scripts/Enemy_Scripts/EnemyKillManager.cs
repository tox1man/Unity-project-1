using UnityEngine;


public class EnemyKillManager : MonoBehaviour
{
    private static Animator _enemyAnimator;

    private void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
    }

    public static void DeathAnimationStart()
    {
        _enemyAnimator.SetBool("isDead", true);
    }

    public static void KillEnemy(GameObject enemy)
    {
        Destroy(enemy);

        UIControls._killCount++;
        UIControls.UpdateGUIKills();

        WinCondition.CheckWinCondition();
    }
}
