using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel 
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            //  EntityPersonel sınıfındaki fonksiyonları kullanmak için list den ve EntityPersonel sınıfından bir nesne türetiyoruz.
            // search sort gibi şeyleri kullanmak için List nesnesi oluşturuyoruz.
            SqlCommand komut1 = new SqlCommand("Select * from TBLBILGI", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel(); // ent ile personeldeki properties lere ulaşıyoruz >> yani tablo sütünları
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,GOREV,SEHIR,MAAS) VALUES (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Gorev);
            komut2.Parameters.AddWithValue("@p4", p.Sehir);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery(); // kayıt sayısını döndürecek
        }

        public static bool PersonelSil(int p)
        // id ekleyeceğim için int p illa  burda entity e ulaşmaya gerek yok zaten form 1 den ulaşacaz
        {
            SqlCommand komut3 = new SqlCommand("delete from TBLBILGI WHERE ID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p); // niye @p3 ?
            return komut3.ExecuteNonQuery() > 0; // bool döndürmek gerektiği için böyle yaptık.
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("UPDATE TBLBILGI SET AD=@P1,SOYAD=@P2,MAAS=@P3,SEHIR=@P4,GOREV=@P5 WHERE ID=@P6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", ent.Ad);
            komut4.Parameters.AddWithValue("@p2", ent.Soyad);
            komut4.Parameters.AddWithValue("@p3", ent.Maas);
            komut4.Parameters.AddWithValue("@p4", ent.Sehir);
            komut4.Parameters.AddWithValue("@p5", ent.Gorev);
            komut4.Parameters.AddWithValue("@p6", ent.Id);
            return komut4.ExecuteNonQuery() > 0;    
        }


    }


}

