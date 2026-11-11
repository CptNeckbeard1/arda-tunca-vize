using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int requiredScore = 30; //bölümü geçmek için gereken minimum puan değerini belirliyor

    private void OnTriggerEnter(Collider other) //tetiklenme alanına girdiğinde çalışacak çarpışma fonksiyonunu oluşturuyor
    {
        PlayerController player = other.GetComponent<PlayerController>(); //çarpan nesnenin üzerinden PlayerController bileşenine ulaşıyor

        if (player.Score >= requiredScore) //eğer oyuncunun puanı gereken puana eşit veya fazlaysa bölümü geçmesine izin veriyor
        {
            LoadNextLevel(); //sonraki seviyeyi yüklemek için fonksiyonumuzu çağırıyor
        }
        else //puan yetersiz kaldığı durumlar için else kısmını belirliyor
        {
            Debug.Log("Yetersiz puan Gerekli: " + requiredScore + ""); //puanın yetmediğini ve gereken puanı konsola yazdırıyor
        }
    }

    private void LoadNextLevel() //sonraki seviyeye geçiş yapmak için fonksiyon oluşturuyor
    {
        int bulunanSeviye = SceneManager.GetActiveScene().buildIndex; //şu an aktif olan sahnenin sıra numarasını öğreniyor
        int sıradakiSeviye = bulunanSeviye + 1; //geçmek istediğimiz bir sonraki sahnenin numarasını hesaplıyor

        if (sıradakiSeviye < SceneManager.sceneCountInBuildSettings) //sıradaki seviye projedeki toplam sahne sınırları içinde mi diye kontrol ediyor
        {
            Debug.Log("Seviyeyi geçtin"); //konsola seviyenin başarıyla geçildiğini yazdırıyor
            SceneManager.LoadScene(sıradakiSeviye); //hesapladığımız sıradaki yeni sahneyi yüklüyor
        }
        else //oyundaki başka sahne kalmadıysa, yani oyun bittiyse çalışacak else kısmını yazzıyor
        {
            Debug.Log("Oyun bitti"); //oyunun bittiğini konsola tebrikler mesajımızı yazdırıyor
        }
    }
}