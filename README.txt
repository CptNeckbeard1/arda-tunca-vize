ARDA TUNCA 2602020018
Oyunumuzda çeşitlli engelleri aşarken yeşil topları toplayınca +10 puan alıp kırmızı
topları toplayınca -5 puan aldığımız ve bunları toplayarak belirli bir kotaya ulaşarak bitiş
çizgisine ulaşmaya çalışıyoruz
BallManager.cs: Karakterimizin kontrollerini, fizik ayarlamalarını, toplara değdiğimiz
zamanki etkileri, skor tablosunu ve oyunun bitirme fonksiyonlarının çalışmasını
sağlıyor

AudioManager.cs: Zıpladığımızda yeşil veya kırmızı topları topladığımızda çalan tek
seferlik seslerin ve arka planda bulundan döngüdeki şarkının çalışmasını sağlıyor
SceneController.cs: Finish bloğuna geldiğimizde karakterimizin puanı sonraki seviye
için yeterliyse sonraki sahneye geçmesini, yeterli değilse konsoldan uyarmasını
sağlıyor, en son seviyede ise sonraki sahneye geçmek yerine oyunun bitmesini
sağlıyor

DeathZone.cs: Oyuncu platformdan aşağı düşerse sonsuza kadar düşmesin diye
bölümü sıfırdan başlatmayı sağlıyor

TitleScreen.cs: bsşlangıç ekranının boşluk tuşuna basarak atlanmasına yarıyor

Karşılaşılan hatalar:
1) Noktalı virgülleri koymayı unuttum, kodda verdiği hataları inceldiğimde doğru
satırlara gidip sorunu düzelttim.
2) GreenBall ve RedBall içinden geçtiğimde hiçbir şey olmuyordu, TextMeshPRO’yu
player shpere içindeki SerializedField in içine atmadığım için kod çalışmıyormuş
hiyerarşiden içeri sürükleryerek sorunu düzelttim
3) Bitiş çizgisi çalışmıyordu, isTriggerini açarak düzelttim

Oyun unity deki başlat tuşuna basarak oynanmaya uygun haldedir
Yapay zekadan yardım aldığım yerler:
Projemde SceneManager.cs’yi yazarken ders notlarında scene manager ile ilgili bir bilgi
bulamadığım için yapay zekadan yardım aldım
Deathzone.cs’yi yazarken yapay zekadan yardım aldım

Oynanış videosu:
https://youtu.be/y-Tl2uKVnWg
