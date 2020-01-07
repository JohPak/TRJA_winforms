using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsHarkka
{
    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
            GetComponentListFromDB();
            GetDeviceListFromDB();
            CalcStockWorth();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }



        // Haetaan tietokannasta
        private void Button1_Click(object sender, EventArgs e)
        {
            GetComponentListFromDB();
            GetDeviceListFromDB();
            CalcStockWorth();
        }

        private void CalcStockWorth() // laskee yhteen varaston arvon
        {
            List<string> kplLista = ReadDB.Reader("kpl", "komponentti");
            List<string> hintaLista = ReadDB.Reader("hinta", "komponentti");
            double summa = 0;

            try
            {
                for (int i = 0; i < kplLista.Count; i++)
                {
                    summa += int.Parse(kplLista[i]) * double.Parse(hintaLista[i]);
                }

                stockWorth.Text = "Varaston arvo: " + summa.ToString("0.00") + " €";
            }
            catch (Exception e)
            {
                stockWorth.Text = "Varaston arvo: " + e.Message;
                //throw;
            }
                
        }

        // Haetaan tietokannasta
        private void GetComponentListFromDB()
        {
            listViewComps2.Clear();

            if (listViewComps2.Items.Count == 0)
            {
                //http://csharp.net-informations.com/gui/cs-listview.htm
                listViewComps2.View = View.Details;
                listViewComps2.GridLines = true;
                listViewComps2.FullRowSelect = true;

                // add column header
                listViewComps2.Columns.Add("Id", 40);
                listViewComps2.Columns.Add("Komponentti", 200);
                listViewComps2.Columns.Add("Kpl", 80);
                listViewComps2.Columns.Add("á-hinta", 60);
            }


            List<string> idLista = ReadDB.Reader("id","komponentti");
            List<string> nimiLista = ReadDB.Reader("nimi","komponentti");
            List<string> kplLista = ReadDB.Reader("kpl","komponentti");
            List<string> hintaLista = ReadDB.Reader("hinta","komponentti");

            for (int i = 0; i < nimiLista.Count; i++)
            {
                string[] arr = new string[4];
                ListViewItem itm;

                //Add first item
                arr[0] = idLista[i];
                arr[1] = nimiLista[i];
                arr[2] = kplLista[i];
                arr[3] = hintaLista[i];

                itm = new ListViewItem(arr);
                listViewComps2.Items.Add(itm);


            }


        }

        private void GetDeviceListFromDB()
        {
            listViewDevs.Clear();

            if (listViewDevs.Items.Count == 0)
            {
                //http://csharp.net-informations.com/gui/cs-listview.htm
                listViewDevs.View = View.Details;
                listViewDevs.GridLines = true;
                listViewDevs.FullRowSelect = true;

                // add column header
                listViewDevs.Columns.Add("Id", 40);
                listViewDevs.Columns.Add("Laite", 200);
                
            }


            List<string> idLista = ReadDB.Reader("id", "laite");
            List<string> nimiLista = ReadDB.Reader("nimi", "laite");

            for (int i = 0; i < nimiLista.Count; i++)
            {
                string[] arr = new string[2];
                ListViewItem itm;

                //Add first item
                arr[0] = idLista[i];
                arr[1] = nimiLista[i];
                

                itm = new ListViewItem(arr);
                listViewDevs.Items.Add(itm);


            }


        }

        // kun laitelistalta valitaan laite, haetaan viereiseen ruutuun sen komponentit
        private void listViewDevs_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            listViewDevComps.Clear();

            if (listViewDevComps.Items.Count == 0)
            {
                listViewDevComps.View = View.Details;
                listViewDevComps.GridLines = true;
                listViewDevComps.FullRowSelect = true;

                //add column header
                listViewDevComps.Columns.Add("Id", 40);
                listViewDevComps.Columns.Add("Komponentti", 200);
                listViewDevComps.Columns.Add("Kpl", 80);

            }

            


                // haetaan sarakkeisiin tietoja, kun joku laite on listasta valittuna ensin
                if (listViewDevs.SelectedItems.Count > 0)
                { 
                    ListViewItem item = listViewDevs.SelectedItems[0];
            

                    string whereHelper = "laitteen_osat.laite_id = " + item.SubItems[0].Text;

                    // tarkistetaan onko laitelistasta rivi valittuna
                    if (listViewDevs.SelectedItems.Count > 0)
                    {
                        // käydään hakemassa komponenttien id-numerot
                        List<string> idLista = ReadDB.Reader("komp_id", "laitteen_osat", whereHelper);
                        List<string> kompNimiLista = new List<string>();

                        // täytetään kompNimiListaa käyttämällä apuna idListaan haettujen komponettien id-numeroita
                        for (int i = 0; i < idLista.Count; i++)
                        {
                            string whereHelper_compId = "komponentti.id = " + idLista[i];
                            // käytetään apulistaa, koska muutoin joka kierroksella kompNimiLista ajautuisi yli metodin palautusarvona tulevalla listalla (joka tässä tapauksessa sisältää vain yhden komponentin nimen, ja mehän halutaan ne kaikki)
                            List<string> listHelper = ReadDB.Reader("nimi", "komponentti", whereHelper_compId);
                            kompNimiLista.Add(listHelper[0]);
                        
                        }

                        List<string> kplLista = ReadDB.Reader("komp_kpl", "laitteen_osat", whereHelper);

                        for (int i = 0; i < idLista.Count; i++)
                        {
                            string[] arr = new string[3];
                            ListViewItem itm;

                            //Add first item
                            arr[0] = idLista[i];
                            arr[1] = kompNimiLista[i];
                            arr[2] = kplLista[i];


                            itm = new ListViewItem(arr);
                            listViewDevComps.Items.Add(itm);

                        }
                    }

                }

            
            
            
        }


        private void Btn_deleteSelected_Click(object sender, EventArgs e)
        {
            int poistettava = 0;


            //tarkistetaan onko mitään valittuna, ennenkö kysytään poistamisesta
            if (listViewComps2.SelectedItems.Count > 0)
            {

                // yes/no -boksi otettu täältä https://stackoverflow.com/questions/3036829/how-do-i-create-a-message-box-with-yes-no-choices-and-a-dialogresult
                DialogResult dialogResult = MessageBox.Show($"Haluatko varmasti poistaa komponentin?", "Komponentin poisto", MessageBoxButtons.YesNo);
                     
            
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (ListViewItem eachItem in listViewComps2.SelectedItems)
                        {
                            listViewComps2.Items.Remove(eachItem);
                            poistettava = int.Parse(eachItem.Text);
                        }
                        //päivitetään poistettu rivi myös tietokantaan
                        WriteDB.DeleteItem(poistettava);
                        label1.Text = $"Poistettu: {poistettava}";
                        GetComponentListFromDB();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        listViewComps2.HideSelection = true;
                        label1.Text = "Ei poistettu mitään.";
                    }
            }



        }

        private void Button_add_button_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox_add_name.Text))|| !(string.IsNullOrEmpty(textBox_add_pcs.Text))|| !(string.IsNullOrEmpty(textBox_add_price.Text)))
            {
                WriteDB.AddItem(textBox_add_name.Text, int.Parse(textBox_add_pcs.Text), double.Parse(textBox_add_price.Text));
                label1.Text = $"Lisättiin {textBox_add_name.Text}";
                // tyhjennetään käyttäjän syötteiden tekstiboksit
                textBox_add_name.Clear();
                textBox_add_pcs.Clear();
                textBox_add_price.Clear();
                // päivitetään listan näkymä
                GetComponentListFromDB();
                // siirretään kursori nimi-kenttään valmiiksi seuraavaa lisäystä varten
                textBox_add_name.Select();
                CalcStockWorth();
            }
            else
            {
                label1.Text = "Syötä lisättävät tiedot.";
            }

            
        }




        // muokkaus- ja poistonappi aktiivisena vain, jos listasta on jotain valittuna
        // valinnan poistuessa, piilotetaan "tallenna muokkaukset" -nappi ja näytetään "lisää uusi".
        private void listViewComps2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewComps2.SelectedItems.Count > 0)
            {
                btn_editSelected.Enabled = true;
                btn_deleteSelected.Enabled = true;
            }
            else
            {
                btn_editSelected.Enabled = false;
                btn_deleteSelected.Enabled = false;
                textBox_add_name.Clear();
                textBox_add_pcs.Clear();
                textBox_add_price.Clear();
                btn_add_new.Visible = true;
                btn_saveEdits.Visible = false;
            }
        }

        // noudetaan valittu komponentti tekstikenttiin muokkausta varten
        // https://stackoverflow.com/questions/17599358/display-the-selected-row-from-listview-to-textbox
        private void btn_editSelected_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewComps2.SelectedItems[0];

            if (listViewComps2.SelectedItems.Count > 0)
            {
                textBox_add_name.Text = item.SubItems[1].Text;
                textBox_add_pcs.Text = item.SubItems[2].Text;
                textBox_add_price.Text = item.SubItems[3].Text;
                btn_add_new.Visible = false;
                btn_saveEdits.Visible = true;
            }
            
            
        }

        private void btn_saveEdits_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewComps2.SelectedItems[0];
            WriteDB.UpdateItem(textBox_add_name.Text, int.Parse(textBox_add_pcs.Text), double.Parse(textBox_add_price.Text), int.Parse(item.SubItems[0].Text));

            GetComponentListFromDB();
            label1.Text = $"Muutettu komponentin {textBox_add_name.Text} tietoja.";
            textBox_add_name.Clear();
            textBox_add_pcs.Clear();
            textBox_add_price.Clear();
            btn_editSelected.Enabled = false;
            btn_deleteSelected.Enabled = false;
            btn_add_new.Visible = true;
            btn_saveEdits.Visible = false;
            CalcStockWorth();
        }


        private void Btn_search_Click(object sender, EventArgs e)
        {
            //tyhjätään lista jotta voidaan listata hakutulokset
            listViewComps2.Clear();

            if (listViewComps2.Items.Count == 0)
            {
                //http://csharp.net-informations.com/gui/cs-listview.htm
                listViewComps2.View = View.Details;
                listViewComps2.GridLines = true;
                listViewComps2.FullRowSelect = true;

                // add column header
                listViewComps2.Columns.Add("Id", 40);
                listViewComps2.Columns.Add("Komponentti", 200);
                listViewComps2.Columns.Add("Kpl", 80);
                listViewComps2.Columns.Add("á-hinta", 60);
            }

            string whereHelper = textBox_search.Text;
            whereHelper = "komponentti.nimi LIKE '%" + whereHelper + "%'";

            //listataan hakutulokset
            List<string> idLista = ReadDB.Reader("id", "komponentti", whereHelper);
            List<string> nimiLista = ReadDB.Reader("nimi", "komponentti", whereHelper);
            List<string> kplLista = ReadDB.Reader("kpl", "komponentti", whereHelper);
            List<string> hintaLista = ReadDB.Reader("hinta", "komponentti", whereHelper);

            

            for (int i = 0; i < nimiLista.Count; i++)
            {
                string[] arr = new string[4];
                ListViewItem itm;

                //Add first item
                arr[0] = idLista[i];
                arr[1] = nimiLista[i];
                arr[2] = kplLista[i];
                arr[3] = hintaLista[i];

                itm = new ListViewItem(arr);
                listViewComps2.Items.Add(itm);


            }
        }
    }
}

