using RezervacijaHotela.Forme;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RezervacijaHotela
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ucitanaTabela;
        bool azuriraj;
        DataRowView pomocniRed;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        #region Select upiti
        static string korisnikSelect = @"Select KorisnikID as ID, Ime, Prezime, JMBG, Adresa, Grad, Kontakt  from tblKorisnik";
        static string gostSelect = @"Select GostID as ID, Ime, Prezime, JMBG, Adresa, Grad, Kontakt  from tblGost";
        static string dodatneUslugeSelect = @"Select DodatneUslugeID as ID, OpisDodatnihUsluga as 'Opis dodatnih usluga' from tblDodatneUsluge";
        static string placanjeSelect = @"Select PlacanjeID as 'ID', StatusPlacanja as 'Status plaćanja', NacinPlacanja as 'Način plaćanja' from tblPlacanje";
        static string statusApartmanaSelect = @"Select StatusApartmanaID as ID, Status from tblStatusApartmana";
        static string tipApartmanaSelect = @"Select TipApartmanaID as ID, NazivTipaApartmana as 'Naziv tipa aparmana' from tblTipApartmana";
        static string apartmanSelect = @"Select ApartmanID as ID, BrojSoba as 'Broj soba', NazivTipaApartmana as Tip, Status
                                         from tblApartman join tblTipApartmana on tblApartman.TipApartmanaID = tblTipApartmana.TipApartmanaID
                                         join tblStatusApartmana on tblApartman.StatusApartmanaID = tblStatusApartmana.StatusApartmanaID";
        static string rezervacijaSelect = @"Select RezervacijaID as 'ID', DatumRezervacije as 'Datum rezervacije' , DatumPrijave as 'Datum prijave',
                                          DatumOdjave as 'Datum odjave', tblKorisnik.Ime + ' ' + tblKorisnik.Prezime as Korisnik, BrojSoba as 'Broj soba',
                                          tblGost.Ime + ' ' + tblGost.Prezime as 'Gost', OpisDodatnihUsluga as 'Dodatne usluge', StatusPlacanja as 'Status plaćanja' 
                                          from tblRezervacija join tblKorisnik on tblRezervacija.KorisnikID = tblKorisnik.KorisnikID 
                                          join tblApartman on tblRezervacija.ApartmanID = tblApartman.ApartmanID
                                          join tblGost on tblRezervacija.GostID = tblGost.GostID 
                                          join tblDodatneUsluge on tblRezervacija.DodatneUslugeID = tblDodatneUsluge.DodatneUslugeID 
                                          join tblPlacanje on tblRezervacija.PlacanjeID = tblPlacanje.PlacanjeID"; 
        #endregion

        #region Select sa uslovom
        string selectUslovKorisnik = @"Select * from tblKorisnik where KorisnikID=";
        string selectUslovGost = @"Select * from tblGost where GostID=";
        string selectUslovDodatneUsluge = @"Select * from tblDodatneUsluge where DodatneUslugeID=";
        string selectUslovPlacanje = @"Select * from tblPlacanje where PlacanjeID=";
        string selectUslovStatusApartmana = @"Select * from tblStatusApartmana where StatusApartmanaID=";
        string selectUslovTipApartmana = @"Select * from tblTipApartmana where TipApartmanaID=";
        string selectUslovApartman = @"Select * from tblApartman where ApartmanID=";
        string selectUslovRezervacija = @"Select * from tblRezervacija where RezervacijaID=";
        #endregion

        #region Delete
        string korisnikDelete = @"Delete from tblKorisnik where KorisnikID=";
        string gostDelete = @"Delete from tblGost where GostID=";
        string dodatneUslugeDelete = @"Delete from tblDodatneUsluge where DodatneUslugeID=";
        string placanjeDelete = @"Delete from tblPlacanje where PlacanjeID=";
        string statusApartmanaDelete = @"Delete from tblStatusApartmana where StatusApartmanaID=";
        string tipApartmanaDelete = @"Delete from tblTipApartmana where TipApartmanaID=";
        string apartmanDelete = @"Delete from tblApartman where ApartmanID=";
        string rezervacijaDelete = @"Delete from tblRezervacija where RezervacijaID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentralni, korisnikSelect);
        }

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException) 
            {
                MessageBox.Show("Neuspešno učitani podaci!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnApartman_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, apartmanSelect);
        }

        private void btnDodatneUsluge_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, dodatneUslugeSelect);
        }

        private void btnGost_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, gostSelect);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, korisnikSelect);
        }

        private void btnPlacanje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, placanjeSelect);
        }

        private void btnRezervacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, rezervacijaSelect);
        }

        private void btnStatusApartmana_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, statusApartmanaSelect);
        }

        private void btnTipApartmana_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, tipApartmanaSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(apartmanSelect, StringComparison.Ordinal))
            {
                prozor = new FrmApartman();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, apartmanSelect);
            }
            else if(ucitanaTabela.Equals(dodatneUslugeSelect, StringComparison.Ordinal))
            {
                prozor = new FrmDodatneUsluge();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, dodatneUslugeSelect);
            }
            else if (ucitanaTabela.Equals(gostSelect, StringComparison.Ordinal))
            {
                prozor = new FrmGost();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, gostSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect, StringComparison.Ordinal))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(placanjeSelect, StringComparison.Ordinal))
            {
                prozor = new FrmPlacanje();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, placanjeSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect, StringComparison.Ordinal))
            {
                prozor = new FrmRezervacija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(statusApartmanaSelect, StringComparison.Ordinal))
            {
                prozor = new FrmStatusApartmana();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, statusApartmanaSelect);
            }
            else if (ucitanaTabela.Equals(tipApartmanaSelect, StringComparison.Ordinal))
            {
                prozor = new FrmTipApartmana();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, tipApartmanaSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(dodatneUslugeSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovDodatneUsluge);
                UcitajPodatke(dataGridCentralni, dodatneUslugeSelect);
            }
            else if (ucitanaTabela.Equals(gostSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovGost);
                UcitajPodatke(dataGridCentralni, gostSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKorisnik);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(apartmanSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovApartman);
                UcitajPodatke(dataGridCentralni, apartmanSelect);
            }
            else if (ucitanaTabela.Equals(placanjeSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovPlacanje);
                UcitajPodatke(dataGridCentralni, placanjeSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovRezervacija);
                UcitajPodatke(dataGridCentralni, rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(statusApartmanaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovStatusApartmana);
                UcitajPodatke(dataGridCentralni, statusApartmanaSelect);
            }
            else if (ucitanaTabela.Equals(tipApartmanaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovTipApartmana);
                UcitajPodatke(dataGridCentralni, tipApartmanaSelect);
            }
        }

        private void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                pomocniRed = red;
                SqlCommand komanda = new SqlCommand
                {
                    Connection = konekcija
                };
                komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                komanda.CommandText = selectUslov + "@id";
                SqlDataReader citac = komanda.ExecuteReader();
                komanda.Dispose();
                while (citac.Read())
                {
                    if (ucitanaTabela.Equals(apartmanSelect))
                    {
                        FrmApartman prozorApartman = new FrmApartman(azuriraj, pomocniRed);
                        prozorApartman.txtBrojSoba.Text = citac["BrojSoba"].ToString();
                        prozorApartman.cbTipApartmana.SelectedValue = citac["TipApartmanaID"].ToString();
                        prozorApartman.cbStatusApartmana.SelectedValue = citac["StatusApartmanaID"].ToString();
                        prozorApartman.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dodatneUslugeSelect))
                    {
                        FrmDodatneUsluge prozorDodatneUsluge = new FrmDodatneUsluge(azuriraj, pomocniRed);
                        prozorDodatneUsluge.txtOpisDodatnihUsluga.Text = citac["OpisDodatnihUsluga"].ToString();
                        prozorDodatneUsluge.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(gostSelect))
                    {
                        FrmGost prozorGost = new FrmGost(azuriraj, pomocniRed);
                        prozorGost.txtIme.Text = citac["Ime"].ToString();
                        prozorGost.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorGost.txtJmbg.Text = citac["JMBG"].ToString();
                        prozorGost.txtAdresa.Text = citac["Adresa"].ToString();
                        prozorGost.txtGrad.Text = citac["Grad"].ToString();
                        prozorGost.txtKontakt.Text = citac["Kontakt"].ToString();
                        prozorGost.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisnikSelect))
                    {
                        FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, pomocniRed);
                        prozorKorisnik.txtIme.Text = citac["Ime"].ToString();
                        prozorKorisnik.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorKorisnik.txtJmbg.Text = citac["JMBG"].ToString();
                        prozorKorisnik.txtAdresa.Text = citac["Adresa"].ToString();
                        prozorKorisnik.txtGrad.Text = citac["Grad"].ToString();
                        prozorKorisnik.txtKontakt.Text = citac["Kontakt"].ToString();
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(placanjeSelect))
                    {
                        FrmPlacanje prozorPlacanje = new FrmPlacanje(azuriraj, pomocniRed);
                        prozorPlacanje.cbxStatusPlacanja.IsChecked = (bool)citac["StatusPlacanja"];
                        prozorPlacanje.txtNacinPlacanja.Text = citac["NacinPlacanja"].ToString();
                        prozorPlacanje.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(statusApartmanaSelect))
                    {
                        FrmStatusApartmana prozorStatusApartmana = new FrmStatusApartmana(azuriraj, pomocniRed);
                        prozorStatusApartmana.cbxStatus.IsChecked = (bool)citac["Status"];
                        prozorStatusApartmana.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(tipApartmanaSelect))
                    {
                        FrmTipApartmana prozorTipApartmana = new FrmTipApartmana(azuriraj, pomocniRed);
                        prozorTipApartmana.txtNazivTipaApartmana.Text = citac["NazivTipaApartmana"].ToString();
                        prozorTipApartmana.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(rezervacijaSelect))
                    {
                        FrmRezervacija prozorRezervacija = new FrmRezervacija(azuriraj, pomocniRed);
                        prozorRezervacija.dpDatumRezervacije.SelectedDate = (DateTime)citac["DatumRezervacije"];
                        prozorRezervacija.dpDatumPrijave.SelectedDate = (DateTime)citac["DatumPrijave"];
                        prozorRezervacija.dpDatumOdjave.SelectedDate = (DateTime)citac["DatumOdjave"];
                        prozorRezervacija.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorRezervacija.cbApartman.SelectedValue = citac["ApartmanID"].ToString();
                        prozorRezervacija.cbGost.SelectedValue = citac["ApartmanID"].ToString();
                        prozorRezervacija.cbDodatneUsluge.SelectedValue = citac["DodatneUslugeID"].ToString();
                        prozorRezervacija.cbPlacanje.SelectedValue = citac["PlacanjeID"].ToString();
                        prozorRezervacija.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close(); 
                }
                azuriraj = false;
            }
        }

        private void btnObrii_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(apartmanSelect))
            {
                ObrisiZapis(dataGridCentralni, apartmanDelete);
                UcitajPodatke(dataGridCentralni, apartmanSelect);
            }
            else if (ucitanaTabela.Equals(dodatneUslugeSelect))
            {
                ObrisiZapis(dataGridCentralni, dodatneUslugeDelete);
                UcitajPodatke(dataGridCentralni, dodatneUslugeSelect);
            }
            else if (ucitanaTabela.Equals(gostSelect))
            {
                ObrisiZapis(dataGridCentralni, gostDelete);
                UcitajPodatke(dataGridCentralni, gostSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(dataGridCentralni, korisnikDelete);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(placanjeSelect))
            {
                ObrisiZapis(dataGridCentralni, placanjeDelete);
                UcitajPodatke(dataGridCentralni, placanjeSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                ObrisiZapis(dataGridCentralni, rezervacijaDelete);
                UcitajPodatke(dataGridCentralni, rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(statusApartmanaSelect))
            {
                ObrisiZapis(dataGridCentralni, statusApartmanaDelete);
                UcitajPodatke(dataGridCentralni, statusApartmanaSelect);
            }
            else if (ucitanaTabela.Equals(tipApartmanaSelect))
            {
                ObrisiZapis(dataGridCentralni, tipApartmanaDelete);
                UcitajPodatke(dataGridCentralni, tipApartmanaSelect);
            }
        }

        private void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    komanda.CommandText = deleteUpit + "@id";
                    komanda.ExecuteNonQuery();
                    komanda.Dispose();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
