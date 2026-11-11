using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space)) //Boşluk (Space) tuşuna basılıp basılmadığını kontrol ediyor
        {
              LoadNextLevel(); //sonraki seviyeyi yüklemek için fonksiyonumuzu çağırıyor
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
    }
}
