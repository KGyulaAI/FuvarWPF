using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfDolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarLista = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFeladat2_Click(object sender, RoutedEventArgs e)
        {
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                StreamReader streamReader = new StreamReader(fajl.FileName);
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    string[] mezok = streamReader.ReadLine().Split(";");
                    fuvarLista.Add(new Fuvar(int.Parse(mezok[0]), Convert.ToDateTime(mezok[1]), int.Parse(mezok[2]), double.Parse(mezok[3]), double.Parse(mezok[4]), double.Parse(mezok[5]), mezok[6]));
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("Nem választott fájlt!");
            }
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"3. feladat: {fuvarLista.Count} fuvar");
        }

        private void btnFeladat4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"4. feladat: {fuvarLista.Where(x => x.TaxiAzonosito == 6185).Count()} fuvar alatt: {fuvarLista.Where(x => x.TaxiAzonosito == 6185).Sum(y => y.Viteldij)}$");
        }

        private void btnFeladat5_Click(object sender, RoutedEventArgs e)
        {
            int bankkartyaDarab = 0;
            int keszpenzDarab = 0;
            int vitatottDarab = 0;
            int ingyenesDarab = 0;
            int ismeretlenDarab = 0;
            foreach (Fuvar elem in fuvarLista)
            {
                switch (elem.FizetesModja)
                {
                    case "bankkártya":
                        bankkartyaDarab++;
                        break;
                    case "készpénz":
                        keszpenzDarab++;
                        break;
                    case "vitatott":
                        vitatottDarab++;
                        break;
                    case "ingyenes":
                        ingyenesDarab++;
                        break;
                    case "ismeretlen":
                        ismeretlenDarab++;
                        break;
                }
            }
            MessageBox.Show($"5. feladat:\n\tbankkártya: {bankkartyaDarab} fuvar\n\tkészpénz: {keszpenzDarab} fuvar\n\tvitatott: {vitatottDarab} fuvar\n\tingyenes: {ingyenesDarab} fuvar\n\tismeretlen: {ismeretlenDarab} fuvar");
        }

        private void btnFeladat6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"6. feladat: {Math.Round(fuvarLista.Sum(x => x.MegtettTavolsag * 1.6), 2)}km");
        }

        //Kérem pontozni!
        private void btnFeladat8_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("hibak.txt", append:true);
            streamWriter.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            foreach (Fuvar elem in fuvarLista)
            {
                if (elem.UtazasIdotartama > 0 && elem.Viteldij > 0 && elem.MegtettTavolsag == 0)
                {
                    streamWriter.WriteLine($"{elem.TaxiAzonosito};{elem.IndulasIdopontja};{elem.UtazasIdotartama};{elem.MegtettTavolsag};{elem.Viteldij};{elem.Borravalo};{elem.FizetesModja}");
                }
            }
            streamWriter.Close();
            MessageBox.Show("8. feladat: hibak.txt létrehozva.");
        }

        //Félig van kész, kérem pontozni!
        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            double leghosszabbFuvar = 0;
            foreach (Fuvar elem in fuvarLista)
            {
                if (elem.MegtettTavolsag > leghosszabbFuvar)
                {
                    leghosszabbFuvar = elem.MegtettTavolsag;
                }
            }
            MessageBox.Show($"7. feladat: Leghosszabb fuvar: \n\tFuvar hossza: {fuvarLista.Where(x => x.MegtettTavolsag == leghosszabbFuvar)} másodperc");
        }
    }
}
