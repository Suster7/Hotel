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
    /// Interaction logic for FrmApartman.xaml
    /// </summary>
    public partial class FrmApartman : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmApartman()
        {
            InitializeComponent();
            PopuniPadajuceListe();
            txtBrojSoba.Focus();
        }

        public FrmApartman(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            PopuniPadajuceListe();
            txtBrojSoba.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();


                string vratiTipApartmana = @"Select TipApartmanaID, NazivTipaApartmana from tblTipApartmana";
                SqlDataAdapter datipapartmana = new SqlDataAdapter(vratiTipApartmana, konekcija);
                DataTable dttipapartmana = new DataTable();
                datipapartmana.Fill(dttipapartmana);
                cbTipApartmana.ItemsSource = dttipapartmana.DefaultView;
                dttipapartmana.Dispose();
                datipapartmana.Dispose();


                string vratiStatusApartmana = @"Select StatusApartmanaID, Status from tblStatusApartmana";
                SqlDataAdapter dastatusapartmana = new SqlDataAdapter(vratiStatusApartmana, konekcija);
                DataTable dtstatusapartmana = new DataTable();
                dastatusapartmana.Fill(dtstatusapartmana);
                cbStatusApartmana.ItemsSource = dtstatusapartmana.DefaultView;
                dtstatusapartmana.Dispose();
                dastatusapartmana.Dispose();
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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@brojSoba", SqlDbType.Int).Value = txtBrojSoba.Text;
                cmd.Parameters.Add("@tipApartmanaID", SqlDbType.Int).Value = cbTipApartmana.SelectedValue;
                cmd.Parameters.Add("@statusApartmanaID", SqlDbType.Int).Value = cbStatusApartmana.SelectedValue.ToString() ;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblApartman
                                        set BrojSoba=@brojSoba, TipApartmanaID=@tipApartmanaID, StatusApartmanaID=@statusApartmanaID
                                        where ApartmanID=@id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblApartman(BrojSoba, TipApartmanaID, StatusApartmanaID)
                                  values(@brojSoba, @tipApartmanaID, @statusApartmanaID);";
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
