
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // topun hızı  
    [SerializeField] private float jumpForce = 5f; // topun zıplama gücü
    private bool gameCompleted = false; //oyun bittiğinde kullanmamız için değişken atıyor

    private Rigidbody rb; //rigbody bileşeni ekledik
    private bool isGrounded = false; //sadece yerdeyken zıplamasını sağlamak için yerde olup olmadığını kontrol ediyor

    private float horizontal; //yatay eksen
    private float vertical; //dikey eksen
    public int Score = 0; //skor tablomuzdaki skor değerimizin başlangıç değeri
    [SerializeField] private TextMeshProUGUI scoreText; //skor tablomuzu yazdırmak için bileşen atıyor


    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //rigbodynin çalışmasını sağlıyor
    }

    private void Update() 
    {
        if (gameCompleted is true) return; //oyun bittiyse kontrolu bırakmamızı sağlıyor
        horizontal = Input.GetAxisRaw("Horizontal"); //ham yatay değer 
        vertical = Input.GetAxisRaw("Vertical"); //ham dikey değer

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //eğer yerde ise space tuşu ile zıplamamıza izin veriyor
        {
            Jump();
        }
    }

    private void FixedUpdate() //fizik hesaplamaları için FixedUpdate kullanıyor
    {
        if (gameCompleted is true) return; //oyun bittiyse fizik hesaplamasını bırakıyor
        Movement();
    }

    private void Movement() //hareket fonksiyonu oluşturuyor
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical); //dikeyde hareket etmeyeceğimiz için sıfıra kitliyor

        direction = direction.normalized; //vektörün yönünü bozmadan uzunluğunu 1 yapıyor

        rb.AddForce(direction * moveSpeed); //ivme almasını sağlıyor
    }

    private void Jump() //zıplamak için fonksiyon oluşturuyor
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //ivmeli şekilde zıplıyor
        AudioManager.instance.PlayjumpSound(); //AudioManagerda atadığımız ses dosyasını çekip kullanıyor
        isGrounded = false; //yerde olmadığını belirtiyor
        print("Zıpladın"); //konsola yazdırıyor

    }
    private void UpdateScoreUi() //skor tablomuz için fonskiyon oluşturuyor
    { 
        scoreText.text = "Score : " + Score.ToString(); //skor tablomuzu güncelliyor
    }

    private void OnCollisionEnter(Collision collision) //fizikel çarpışma olduğu için OnCollision kullandı
    {
        if (collision.gameObject.CompareTag("Ground")) //yere değdiğimiz zaman konsoldan bildirmesini sağlıyoruz ayrıca tekrar zıplayabilmemiz için isGrounded değerini true yapıyor
        {
            isGrounded = true; //tekrardan yerde olduğunu belirtiyor
            Debug.Log("Yerdesin"); //Konsola yazdırıyor
        }
    }
    private void OnTriggerEnter(Collider other) //nesneler birbiri içinden geçtiği için OnTriggerEnter kullandı
    {
        if (other.CompareTag("GreenBall")) //yeşil topa değdiğimiz zaman puan kazanmamızı, ses oynatmasını ve topun yok olmasını sağlıyor
        {
            Score += 10; //skor değerimizi 10 arttırıyor
            UpdateScoreUi(); //skor tablomuzu güncelliyor
            AudioManager.instance.PlayGreenBallSound(); //AudioManagerda atadığımız ses dosyasını çekip kullanıyor
            Debug.Log("GreenBall Score" + Score); //konsola yazdırıyor
            Destroy(other.gameObject); //çarpışma yaşandıktan sonra topun silinmesini sağlıyor
        }
        else if (other.CompareTag("RedBall")) //kırmızı topa değdiğimiz zaman puan kaybetmemizi, ses oynatmasını ve topun yok olmasını sağlıyor
        { 
            Score -= 5; //skor değerimizi 5 azaltıyor
            UpdateScoreUi(); //skor tablomuzu güncelliyor
            AudioManager.instance.PlayRedBallSound(); //AudioManagerda atadığımız ses dosyasını çekip kullanıyor
            Debug.Log("RedBall Score" + Score); //konsola yazdırıyor
            Destroy(other.gameObject); //çarpışma yaşandıktan sonra topun silinmesini sağlıyor
        }
    }

    public void CompleteGame() //oyun bitince SceneController tarafından çağrılır
    {
        gameCompleted = true;
        rb.linearVelocity = Vector3.zero; //top yuvarlanmaya devam etmesin
        rb.angularVelocity = Vector3.zero;
    }
}