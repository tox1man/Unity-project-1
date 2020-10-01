using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioClip[] _soundtracks;

    private AudioSource _soundTrackAudioSource;

    #endregion

    #region Unity Methods

    private void Start()
    {
        StartGame();
    }

    #endregion

    #region Methods

    private void StartGame()
    {
        GameObject enemy = gameObject.GetComponent<EnemySpawner>()._enemy;
        GameObject boss = gameObject.GetComponent<EnemySpawner>()._boss;

        EnemySpawner.SpawnEnemies(enemy);
        EnemySpawner.SpawnBosses(boss);

        UIControls.OpenMainMenu();

        _soundTrackAudioSource = GameObject.Find("SoundTrack").GetComponent<AudioSource>();
        _soundTrackAudioSource.clip = _soundtracks[Random.Range(0, _soundtracks.Length)];
        SoundManager.PlaySound("SoundTrack");

    }

    public static void WinGame()
    {
        UIControls.ShowEndGameMenu(true);
        ResetGameProgress();
    }

    public static void LoseGame()
    {
        UIControls.ShowEndGameMenu(false);
        SoundManager.StopSound("SoundTrack");
        ResetGameProgress();
    }

    private static void ResetGameProgress()
    {
        UIControls._killCount = 0;
        HitDetector._playerHit = false;
        PlayerWeapon._isReloading = false;
    }

    #endregion
}
