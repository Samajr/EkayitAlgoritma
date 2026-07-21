using MySql.Data.MySqlClient;

List<string> uyeler = new List<string>();
string baglantiyolu= "Server=127.0.0.1; Port=3306;Database=ekayit;Uid=root;Pwd=;";

    while (true)
{
    
    Console.WriteLine("\n");
    Console.WriteLine("1 - Üyeleri Listele");
    Console.WriteLine("2 - Üye ekle");
    Console.WriteLine("3 - Üye sil");
    Console.WriteLine("4 - Çıkış\n");

    string secim;

    Console.WriteLine("Lütfen menü numaranızı seçiniz \n");
    secim = Console.ReadLine();
    int secilen = Convert.ToInt32(secim);
    Console.WriteLine("\n");
    if (secilen == 1)
    {
        Console.WriteLine("Üyeler Listeleniyor...\n");
        using (MySqlConnection baglanti = new MySqlConnection(baglantiyolu))
        {
            baglanti.Open();
            string sorgu = "select (uye_adi) from uyeler";
            using MySqlCommand kmt = new MySqlCommand(sorgu, baglanti);
            {
                using (MySqlDataReader oku = kmt.ExecuteReader()) 
                {
                    while (oku.Read())
                    {
                        string isim = oku["uye_adi"].ToString();
                        Console.WriteLine("- " + isim);
                    }
                }
            }
        }
    }

    else if (secilen == 2)
    {
        Console.WriteLine("Üye ekleme aktif\n");
        Console.Write("Üye adı:");
        string yeniuye;
        yeniuye = Console.ReadLine();
        using (MySqlConnection baglanti = new MySqlConnection(baglantiyolu))
        { baglanti.Open();
            string sorgu = "INSERT INTO uyeler (uye_adi) VALUES (@yeni)";
            using MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@yeni", yeniuye);
            komut.ExecuteNonQuery();

        }

        Console.WriteLine("Yeni Üye başarıyla eklendi..");
    }
    else if (secilen == 3)
    {
        Console.WriteLine("Üye silme aktif\n");
        Console.Write("Silinecek Üyenin adı : ");
        string silinecek;
        silinecek = Console.ReadLine();
         using (MySqlConnection baglanti= new MySqlConnection(baglantiyolu)) 
        {
            baglanti.Open();
            string sil = "delete from uyeler where uye_adi=@silinecek";
            using MySqlCommand komut = new MySqlCommand(sil,baglanti);
            komut.Parameters.AddWithValue("@silinecek", silinecek);
            komut.ExecuteNonQuery();
        }
        
        
        Console.WriteLine(silinecek + " üyesi başarıyla silindi ");

    }
    else if (secilen == 4)
    {
        Console.WriteLine("çıkış yapıldı..\n");
        Environment.Exit(0);
        break;
        
    }
}

