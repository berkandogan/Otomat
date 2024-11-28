namespace Otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urunler = { "Fanta", "Kola", "Çikolata" };
            int[] fiyatlar = { 40, 40, 30 };
            int[] gunSonuSatis = new int[100];
            int satisIndex = 0;
            while (true)
            {          
                Console.WriteLine("**** OTOMAT MAKİNESİ ****");
                Console.WriteLine("Urun alma   1\n" +
                                  "Admin Panel 2\n" +
                                  "Çıkış       0");
                int menuSecim = Convert.ToInt32(Console.ReadLine());
                #region Urun secim            
                if (menuSecim == 1)
                {
                    urunYazma(urunler, fiyatlar);
                    Console.Write("Lütfen bir ürün giriniz: ");
                    string urun = Console.ReadLine();
                    Console.Write("Lütfen para girişi yapınız: ");
                    int fiyat = Convert.ToInt32(Console.ReadLine());
                    bool urunVarMi = false;
                    for (int i = 0; i < urunler.Length; i++)
                    {
                        if (urunler[i].ToLower() == urun.ToLower())
                        {
                            urunVarMi = true;
                            if (fiyatlar[i] == fiyat)
                            {
                                Console.WriteLine("afiyet olsun");
                                gunSonuSatis[satisIndex] = fiyatlar[i];
                                satisIndex++;
                            }
                            else if (fiyatlar[i] < fiyat)
                            {
                                Console.WriteLine($"afiyet olsun para üstü: {fiyat - fiyatlar[i]} TL alınız");
                                gunSonuSatis[satisIndex] = fiyatlar[i];
                                satisIndex++;
                            }
                            else
                            {
                                while (true)
                                {
                                    Console.WriteLine("Yetersiz bakiye. Para ekle 1, Para iade 2");
                                    string paraSecim = Console.ReadLine();
                                    if (paraSecim == "1")
                                    {
                                        Console.Write("Yatıralacak para miktarı: ");
                                        int paraSecimFiyat = Convert.ToInt32(Console.ReadLine());
                                        fiyat += paraSecimFiyat;
                                        if (fiyatlar[i] == fiyat)
                                        {
                                            Console.WriteLine("afiyet olsun");
                                            gunSonuSatis[satisIndex] = fiyatlar[i];
                                            satisIndex++;
                                            break;
                                        }
                                        else if (fiyatlar[i] < fiyat)
                                        {
                                            Console.WriteLine($"afiyet olsun para üstü: {fiyat - fiyatlar[i]} TL alınız");
                                            gunSonuSatis[satisIndex] = fiyatlar[i];
                                            satisIndex++;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{fiyatlar[i] - fiyat} TL azdır.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{fiyat} TL geri verilmiştir.");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (!urunVarMi)
                    {
                        Console.WriteLine("Yanlış ürün girildi.");
                    }
                }
                #endregion
                #region Admin Panel
                else if (menuSecim == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("** ADMIN PANEL **");
                        Console.WriteLine("Yeni Ürün Ekle        1\n" +
                                          "Ürün Güncelle         2\n" +
                                          "Ürün Sil              3\n" +
                                          "Ürünleri Listele      4\n" +
                                          "Gün Sonu Toplam Satış 5\n" +
                                          "Çıkış                 0");
                        int adminMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if(adminMenuSecim == 1)
                        {
                            Array.Resize(ref urunler, urunler.Length + 1);
                            Array.Resize(ref fiyatlar, fiyatlar.Length + 1);
                            Console.Write("Eklenecek ürünü yazın: ");
                            string yeniUrun = Console.ReadLine();
                            urunler[urunler.Length - 1] = yeniUrun;
                            Console.Write("Eklenecek ürün fiyatını yazın: ");
                            int yeniUrunFiyat = Convert.ToInt32(Console.ReadLine());
                            fiyatlar[urunler.Length - 1] = yeniUrunFiyat;
                        }
                        else if(adminMenuSecim == 2)
                        {
                            Console.Write("Güncellenecek ürünü giriniz: ");
                            string guncellenecekUrun = Console.ReadLine();
                            bool urunDegistirildi = false;
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                if (urunler[i].ToLower() == guncellenecekUrun.ToLower())
                                {
                                    Console.Write("Yeni ürünü giriniz: ");
                                    string yeniUrun = Console.ReadLine();
                                    urunler[i] = yeniUrun;
                                    Console.Write("Yeni ürünün fiyatını giriniz: ");
                                    int yeniUrunFiyat = Convert.ToInt32(Console.ReadLine());
                                    fiyatlar[i] = yeniUrunFiyat;
                                    urunDegistirildi = true;
                                }
                            }
                            if (!urunDegistirildi)
                            {
                                Console.WriteLine("Bulunmayan bir ürün girildi.");
                            }
                        }
                        else if(adminMenuSecim == 3)
                        {
                            Console.Write("Silinecek ürünü giriniz: ");
                            string silinecekUrun = Console.ReadLine();
                            bool urunDegistirildi = false;
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                if (urunler[i].ToLower() == silinecekUrun.ToLower())
                                {
                                    Array.Clear(urunler, i, 1);
                                    Array.Clear(fiyatlar, i, 1);
                                    Console.WriteLine("Ürün başarıyla silindi.");
                                    urunDegistirildi = true;
                                }
                            }
                            if (!urunDegistirildi)
                            {
                                Console.WriteLine("Bulunmayan bir ürün girildi.");
                            }
                        }
                        else if(adminMenuSecim == 4)
                        {
                            urunYazma(urunler, fiyatlar);
                        }
                        else if(adminMenuSecim == 5)
                        {
                            int toplam = 0;
                            foreach(int sayi in gunSonuSatis)
                            {
                                toplam += sayi;
                            }
                            Console.WriteLine("Gün Sonu Toplam Satış: " + toplam + " TL");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #endregion
                else
                {
                    break;
                }
            }
        }
        static void urunYazma(string[] array1, int[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine($"{array1[i]}: {array2[i]} TL");
            }
        }
    }
}
