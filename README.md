# .NET-Steganographer
Steganography library and test application for hiding text or image to another image data.

Steganografi, bilginin içine başka bir bilginin gizlenmesine dayanan bir şifreleme algoritmasıdır. Dijital ortamın hayatımıza girmesinden çok daha eskilere dayanan steganografi metoda örnek olarak kafasında dövme ile yazılmış bilgileri taşıyan bir köleyi verebiliriz. Köle, sadece kafasında bir takım bilgilerin yazılı olduğunu bilmektedir ve kölenin saçlarının uzamasıyla bilgi kamufle edilmiştir. Köle, varmak istediği yere vardığında kafası yeniden kazınarak bilgi gün ışığına çıkarılmıştır.
Dijital ortamda steganografi yapılırken bilgiyi gizlemek için resim dosyalarından yararlanılmaktadır. Bu yaygınlığın denedi, diğer türlü dosyaların(örneğin text dosyalarının) kodlama biçimi gereği bilgi dosya üzerinde yapılan değişikliklerin hemen kendini ifşa ederken resim dosyaları üzerinde insan gözünün ayırt edemeyeceği düzeyde değişiklikler yapılabiliyor olmasıdır.
Dijital ortamdaki resimler çok sayıda pixelin bir araya gelmesi ile oluşmuş birer renk matrisidir aslında. Pixel, Alpha, Red, Green, Blue olmak üzere 4 farklı renk değerinin harmanlanmasıyla oluşmuş tek bir rengi ifade eder. Kısaca A, R, G, B olarak anılan bu değerlerin her birisi [0,255] kapalı aralığında değer alabilen(byte) birer pozitif tam sayıdır. Bu 4 farklı byte değeri üzerinde sayısal olarak yapılacak oynamalar resmin görünümü üzerinde doğrudan etki sahibidir. Teorik olarak bir pixel 4 farklı byte değerine sahip ise bu pixele tam olarak 4 byte büyüklüğünde veri gizleyebilirsiniz. Fakat bu işlem sonucunda resim üzerinde bozulmalar olabileceği için steganografinin tutarlılık prensibine aykırı düşmüş olabilirsiniz!
Staganografi, temel olarak bir bilgiyi başka bir bilginin içerine saklamak fikrine dayanırken tutarlılığı da gözardı etmez. Yani, bir resmin içerisine bilgi gizlemek istiyorsanız, resim üzerinde oynama yapıldığının çıplak göz ile ayırt edilmemesi gerekir. Bu sebepten ötürü resmin pixelleri içerisindeki A, R, G, B sayıları üzerinde istediğimiz değişiklikleri yaparken çıplak göz ile resim üzerinde yaptığımız düzenlemelerin anlaşılamamasına dikkat etmeliyiz! Bu noktada referans almamız gereken bitler ise LSB adını verdiğimiz en anlamsız bitler olmalıdır.

255)10 = (11111111)2

255 sayısının binary karşılığı 8 adet 1 değerinin yanyana gelmesi ile elde edilen sayıdır. Bu sayının en sağında bulunan bit LSB yani en anlamsız bit olarak ifade edilirken en solundaki bit MSB yani en anlamlı bit olarak ifade edilir. Yukarıdaki ifadede kırmızı renk ile kaplanmış olan bit binary sayının LSB seviyesindeki biti olup 20 seviyesinde bir ağrlığa sahiptir. Yani bu bitin 1 iken 0 veya 0 iken 1 olarak değişmesi, sayıyı onlu sistemde sadece 1 kadar etkiler. O halde (254)10 = (11111110)2 diyebiliriz. Peki, pixelin 255 olan R değerini 254 olarak değiştirirsem elde edilen yeni renk bir önceki renkten çok mu farklı olacak? Hayır! İnsan gözü bu değişikliği fark edemeyecektir. Ayrıca ilgili pixelin R değeri ile birlikte G ve B ve hatta A değerlerinin birlikte değiştirilmesi sonucu bir pixele enjete edebileceğimiz ver miktarı da artış gösterecektir.  Ne demek istediğimi daha iyi anlayabilmek için 50 sayısını resminin içine gizlemek istediğinizi hayal edin. Bu işlemi yapmak için tabloda gördüğünüz kırmızı renkli pixeli tercih ettiğinizi düşünün. 50 sayının binary karşılığı 110010 olduğundan ötürü elinizde toplam 6 bitlik bir sayı olmuş olur. 
(50)10 = (110010)2

Bu sayıyı resmin bir pixeline gömerken 6 biti 2’şer 2’şer R, G, B değerlerine paylaştırabilirim. Resmin kırmızı renkli pixelinin R, G ve B değerleri ilk adımda aşağıdaki gibidir.

R: 11111111
G: 00000000
B: 00000000

Her bir byte’ın son iki bitini enjekte etmek amacıyla kullandığımda 110010 sayısının ilk iki biti olan 11 R değerinin son iki bitine, ikinci iki biti olan 00 değeri G değerinin son iki bitine, son iki biti olan 10 değeri de B değerinin son iki bitine gelecektir. Sonuç olarak ilgili pixel renk kodu aşağıdaki gibi olmuş olur.

R: 11111111
G: 00000000       >>>>>   110010
B: 00000010

Sanırım bu kadar teorik bilgi yeter, şayet yazımı bu noktaya kadar okumuşsanız en kötü ihtimalle bir resmin pixellerden oluştuğunu, her bir pixelin R, G, B gibi üç adet byte büyüklüğünde sayının bir araya gelmesiyle oluşmuş tek bir rengi ifade ettiğini ve bir resmin bu pixellerden yüzlerce-binlerce barındıran bir matris olduğunu anlamışsınızdır. Yok ben kod görmek istiyorum derseniz açık kaynak olarak paylaştığım projeye bakabilirsiniz. 

Örnek steganografi test:
-------------------------------------
IConfidential secret = new ImageSteganography(image)
{
    Key = 1000,
    BaseImage = bitmap1,
};
 
var tester = new SecretInformationStaganographer(secret );
ISteganographyResult result = await tester.Inject(token);
pictSteganographedImage.Image = result.Image;
