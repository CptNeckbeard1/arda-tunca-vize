using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //nesneye değdiğinde çalışır
    {
        Debug.Log("Düştün!"); //konsola düştüğümüzü yazdırıyor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //sahneyi yeniden yükleyerek bölümü sıfırlıyor
    }
}
