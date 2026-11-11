using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // diğer scriptlerden rahatça erişebilmek için instance tanımlıyor

    [SerializeField] private AudioSource sfxSource; // ses efektlerini oynatmak için ses kaynağı bileşeni atıyor
    [SerializeField] private AudioSource musicSource; // arka plan müziğini oynatmak için ses kaynağı bileşeni atıyor
    [SerializeField] private AudioClip greenBallSound; // yeşil topa deydiğimizde çalacak ses dosyası
    [SerializeField] private AudioClip redBallSound; // kırmızı topa deydiğimizde çalacak ses dosyası
    [SerializeField] private AudioClip jumpSound; // zıpladığımız zaman çalacak ses dosyası
    [SerializeField] private AudioClip backgroundMusic; // arka plan müzik dosyası

    private void Awake()
    {
        instance = this; // sınıfın referansını kendine eşitliyoruz ki her yerden çağırabilsin
    }

    void Start()
    {
        musicSource.clip = backgroundMusic; // müzik kaynağına arka plan müziğini yüklüyor
        musicSource.loop = true; // müziğin sürekli döngüde çalmasını sağlıyor
        musicSource.Play(); // müziği başlatıyor
        Debug.Log("music oynadı"); // konsola müziğin çaldığını yazdırıyor
    }

    public void PlayGreenBallSound() // yeşil top sesi için fonksiyon 
    {
        Debug.Log("green ball sesi oynatıldı"); // konsola yazdırıyor
        sfxSource.PlayOneShot(greenBallSound); // yeşil top ses efektini bir kerelik çalıyor
    }

    public void PlayRedBallSound() // kırmızı top sesi için fonksiyon 
    {
        Debug.Log("red ball sesi oynatıldı"); // konsola yazdırıyor
        sfxSource.PlayOneShot(redBallSound); // kırmızı top ses efektini bir kerelik çalıyor
    }

    public void PlayjumpSound() // zıplama sesi için fonksiyon 
    {
        Debug.Log("jump sesi oynatıldı"); // konsola yazdırıyor
        sfxSource.PlayOneShot(jumpSound); // zıplama ses efektini bir kerelik çalıyor
    }

    void Update()
    {

    }
}