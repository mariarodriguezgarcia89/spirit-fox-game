using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("Music")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip menuMusic;
    
    [Header("Sound Effects")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip collectGemSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip chestOpenSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private AudioClip victoryMusic;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start()
    {
        PlayMusic(menuMusic);
    }
    
    public void PlayGameMusic()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip) return; // Ya está sonando
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void PlayJump() { PlaySFX(jumpSound); }
    public void PlayCollectGem() { PlaySFX(collectGemSound); }
    public void PlayDamage() { PlaySFX(damageSound); }
    public void PlayEnemyDeath() { PlaySFX(enemyDeathSound); }
    public void PlayChestOpen() { PlaySFX(chestOpenSound); }
    public void PlayButtonClick() { PlaySFX(buttonClickSound); }
    public void PlayGameOverMusic(){ PlayMusic(gameOverMusic);}
    
    public void PlayVictoryMusic() { PlayMusic(victoryMusic); }
    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }
}