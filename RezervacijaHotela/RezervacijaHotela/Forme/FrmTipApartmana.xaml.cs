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
    /// Interaction logic for FrmTipApartmana.xaml
    /// </summary>
    public partial class FrmTipApartmana : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmTipApartmana()
        {
            InitializeComponent();
            txtNazivTipaApartmana.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmTipApartmana(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtNazivTipaApartmana.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
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

                cmd.Parameters.Add("@nazivTipaApartmana", SqlDbType.NVarChar).Value = txtNazivTipaApartmana.Text;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblTipApartmana
                                        set NazivTipaApartmana=@nazivTipaApartmana where TipApartmanaID=@id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTipApartmana(NazivTipaApartmana)
                                  values(@nazivTipaApartmana);";
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
