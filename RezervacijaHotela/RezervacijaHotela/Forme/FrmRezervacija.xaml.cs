using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RezervacijaHotela.Forme
{
    /// <summary>
    /// Interaction logic for FrmRezervacija.xaml
    /// </summary>
    public partial class FrmRezervacija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmRezervacija()
        {
            InitializeComponent();
            PopuniPadajuceListe();
        }

        public FrmRezervacija(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();


                string vratikorisnika = @"Select KorisnikID, Ime + ' ' + Prezime as Korisnik from tblKorisnik";
                SqlDataAdapter dakorisnik = new SqlDataAdapter(vratikorisnika, konekcija);
                DataTable dtkorisnik = new DataTable();
                dakorisnik.Fill(dtkorisnik);
                cbKorisnik.ItemsSource = dtkorisnik.DefaultView;
                dtkorisnik.Dispose();
                dakorisnik.Dispose();


                string vratiapartman = @"Select ApartmanID, BrojSoba from tblApartman";
                SqlDataAdapter daapartman = new SqlDataAdapter(vratiapartman, konekcija);
                DataTable dtapartman = new DataTable();
                daapartman.Fill(dtapartman);
                cbApartman.ItemsSource = dtapartman.DefaultView;
                dtapartman.Dispose();
                daapartman.Dispose();

                string vratigosta = @"Select GostID, Ime + ' ' + Prezime as Gost from tblGost";
                SqlDataAdapter dagost = new SqlDataAdapter(vratigosta, konekcija);
                DataTable dtgost = new DataTable();
                dagost.Fill(dtgost);
                cbGost.ItemsSource = dtgost.DefaultView;
                dtgost.Dispose();
                dagost.Dispose();

                string vratidodatneusluge = @"Select DodatneUslugeID, OpisDodatnihUsluga from tblDodatneUsluge";
                SqlDataAdapter dadodatneusluga = new SqlDataAdapter(vratidodatneusluge, konekcija);
                DataTable dtdodatneusluge = new DataTable();
                dadodatneusluga.Fill(dtdodatneusluge);
                cbDodatneUsluge.ItemsSource = dtdodatneusluge.DefaultView;
                dtdodatneusluge.Dispose();
                dadodatneusluga.Dispose();

                string vratiplacanje = @"Select PlacanjeID, NacinPlacanja from tblPlacanje";
                SqlDataAdapter daplacanje = new SqlDataAdapter(vratiplacanje, konekcija);
                DataTable dtplacanje = new DataTable();
                daplacanje.Fill(dtplacanje);
                cbPlacanje.ItemsSource = dtplacanje.DefaultView;
                dtplacanje.Dispose();
                daplacanje.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime drezervacije = (DateTime)dpDatumRezervacije.SelectedDate;
                DateTime dprijave = (DateTime)dpDatumPrijave.SelectedDate;
                DateTime dodjave = (DateTime)dpDatumOdjave.SelectedDate;
                string datumRezervacije = drezervacije.ToString("yyyy-MM-dd");
                string datumPrijave = dprijave.ToString("yyyy-MM-dd");
                string datumOdjave = dodjave.ToString("yyyy-MM-dd");
               
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@datumRezervacije", SqlDbType.DateTime).Value = datumRezervacije;
                cmd.Parameters.Add("@datumPrijave", SqlDbType.DateTime).Value = datumPrijave;
                cmd.Parameters.Add("@datumOdjave", SqlDbType.DateTime).Value = datumOdjave;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@apartmanID", SqlDbType.Int).Value = cbApartman.SelectedValue;
                cmd.Parameters.Add("@gostID", SqlDbType.Int).Value = cbGost.SelectedValue;
                cmd.Parameters.Add("@dodatneUslugeID", SqlDbType.Int).Value = cbDodatneUsluge.SelectedValue;
                cmd.Parameters.Add("@placanjeID", SqlDbType.Int).Value = cbPlacanje.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblRezervacija
                                        set DatumRezervacije=@datumRezervacije, DatumPrijave=@datumPrijave, DatumOdjave=@datumOdjave,
                                        KorisnikID=@korisnikID, ApartmanID=@apartmanID, GostID=@gostID, DodatneUslugeID=@dodatneUslugeID, PlacanjeID=@placanjeID
                                        where RezervacijaID=@id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRezervacija(DatumRezervacije, DatumPrijave, DatumOdjave, KorisnikID, ApartmanID, GostID, DodatneUslugeID, PlacanjeID)
                                  values(@datumRezervacije, @datumPrijave, @datumOdjave, @korisnikID, @apartmanID, @gostID, @dodatneUslugeID, @placanjeID);";
                }
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
