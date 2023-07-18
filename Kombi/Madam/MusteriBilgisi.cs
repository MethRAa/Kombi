using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kombi.Madam
{
    class MusteriBilgisi
    {
        public int Id { get; set; }
        public string MAd { get; set; }
        public string MSoyad { get; set; }
        public string Adres { get; set; }
        public string Ariza { get; set; }
        public string DParca { get; set; }
        public double Fiyat { get; set; }

        MySqlConnection _baglan = new MySqlConnection("Server = localhost; Database = Kombi; Uid = root; pwd='13121998'");

        public void Connect() 
        {
            if (_baglan.State == ConnectionState.Closed)
            {
                _baglan.Open();
            }
        }

        public List<MusteriBilgisi> get() 
        {
            Connect();
            //order by id desc idlere ters listelemeye yarar 
            MySqlCommand cm = new MySqlCommand("Select * from MusteriBilgileri  Order by Id DESC ", _baglan);
            
            MySqlDataReader rd = cm.ExecuteReader();
           

            List<MusteriBilgisi> bilgiler = new List<MusteriBilgisi>();
            while (rd.Read())
            {
                MusteriBilgisi mb = new MusteriBilgisi();

                mb.Id = Convert.ToInt32(rd["Id"]);
                mb.MAd = rd["MAd"].ToString();
                mb.MSoyad = rd["MSoyad"].ToString();
                mb.Adres = rd["Adres"].ToString();
                mb.Ariza = rd["Ariza"].ToString();
                mb.DParca = rd["DParca"].ToString();
                mb.Fiyat = Convert.ToDouble(rd["Fiyat"]);

                bilgiler.Add(mb);
            }
            rd.Close();
            _baglan.Close();

            return bilgiler;


        }

        public List<MusteriBilgisi> get(string ara)
        {
            Connect();
            //order by id desc idlere ters listelemeye yarar 
            MySqlCommand cm = new MySqlCommand("Select * from MusteriBilgileri  where MAd like '%" + @ara + "%' Order by Id DESC ", _baglan);
            MySqlDataReader rd = cm.ExecuteReader();
            cm.Parameters.AddWithValue("@MAd", ara);
            


            List<MusteriBilgisi> bilgiler = new List<MusteriBilgisi>();
            while (rd.Read())
            {
                MusteriBilgisi mb = new MusteriBilgisi();

                mb.Id = Convert.ToInt32(rd["Id"]);
                mb.MAd = rd["MAd"].ToString();
                mb.MSoyad = rd["MSoyad"].ToString();
                mb.Adres = rd["Adres"].ToString();
                mb.Ariza = rd["Ariza"].ToString();
                mb.DParca = rd["DParca"].ToString();
                mb.Fiyat = Convert.ToDouble(rd["Fiyat"]);

                bilgiler.Add(mb);
            }
            rd.Close();
            _baglan.Close();

            return bilgiler;


        }

       

        public void Ekle (MusteriBilgisi Madam) 
        {
            Connect();

            MySqlCommand cm = new MySqlCommand(
                "insert into musteribilgileri values (@Id ,@MAd , @MSoyad ,@Adres ,@Ariza ,@DParca,@Fiyat)",_baglan);

            cm.Parameters.AddWithValue("@Id", Madam.Id);
            cm.Parameters.AddWithValue("@MAd",Madam.MAd);
            cm.Parameters.AddWithValue("@MSoyad",Madam.MSoyad);
            cm.Parameters.AddWithValue("@Adres",Madam.Adres);
            cm.Parameters.AddWithValue("@Ariza",Madam.Ariza);
            cm.Parameters.AddWithValue("@DParca",Madam.DParca);
            cm.Parameters.AddWithValue("@Fiyat",Madam.Fiyat);

            cm.ExecuteNonQuery();
            _baglan.Close();
        }

        public void Duzenle(MusteriBilgisi Madam) 
        {
            Connect();


            MySqlCommand cm = new MySqlCommand(
                "update musteribilgileri set MAd=@MAd , MSoyad=@MSoyad , Adres = @Adres , Ariza = @Ariza , DParca = @DParca, Fiyat =@Fiyat Where Id=@Id",_baglan);
            cm.Parameters.AddWithValue("@MAd",Madam.MAd);
            cm.Parameters.AddWithValue("@MSoyad",Madam.MSoyad);
            cm.Parameters.AddWithValue("@Adres",Madam.Adres);
            cm.Parameters.AddWithValue("@Ariza",Madam.Ariza);
            cm.Parameters.AddWithValue("@DParca",Madam.DParca);
            cm.Parameters.AddWithValue("@Fiyat",Madam.Fiyat);
            cm.Parameters.AddWithValue("@Id",Madam.Id);

            cm.ExecuteNonQuery();
            _baglan.Close();
        }

        public void sil (MusteriBilgisi Madam)
        {
            Connect();

            MySqlCommand cm = new MySqlCommand("Delete from musteribilgileri where Id=@Id", _baglan);

            cm.Parameters.AddWithValue("@Id",Madam.Id);

            cm.ExecuteNonQuery();
            _baglan.Close();
        }

        public void toplam(MusteriBilgisi Madam)
        {
            Connect();

            MySqlCommand cm = new MySqlCommand("Select * from musteribilgileri where Fiyat=@Fiyat");

            cm.Parameters.AddWithValue("@Fiyat",Madam.Fiyat);
            cm.ExecuteNonQuery();
            _baglan.Close();

        }




    }
}
