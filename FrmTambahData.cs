using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Address_Book
{
    public partial class FrmTambahData : Form
    {
        bool _result = false;

        bool _addMode = false; //true : add item false : edit item

        AdressBook _addrBook = null;


        public bool Run(FrmTambahData form)
        {
            form.ShowDialog();
            return _result;
        }

        public FrmTambahData(bool addMode,AdressBook addrBook = null)
        {
            InitializeComponent();
            _addMode = addMode;
            if (addrBook != null)
            {
                _addrBook = addrBook;
                this.txtNama.Text = addrBook.Nama;
                this.txtAlamat.Text = addrBook.Alamat;
                this.txtKota.Text = addrBook.Kota;
                this.txtNoHp.Text = addrBook.NoHp;
                this.dtpTglLahir.Value = addrBook.TanggalLahir.Date;
                this.txtEmail.Text = addrBook.Email;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //validasi
            if (this.txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib isi ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNama.Focus();
            }
            else if (this.txtAlamat.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib isi ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtAlamat.Focus();
            }
            else if (this.txtKota.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib isi ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtKota.Focus();
            }
            else if (this.txtNoHp.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib isi ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoHp.Focus();
            }
            else if (this.txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib isi ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtEmail.Focus();
            }
            else
            {
                try
                {
                    //simpan data ke file
                    if (_addMode) // add new item
                    {
                        using (var fs = new FileStream("addressbook.csv", FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(fs))
                            {
                                writer.WriteLine($"{txtNama.Text.Trim()};{txtAlamat.Text.Trim()};{txtKota.Text.Trim()};{txtNoHp.Text.Trim()};{dtpTglLahir.Value.ToShortDateString()};{txtEmail.Text.Trim()};");
                            }
                        }
                    }
                    else // edit data
                    {

                    }
                    _result = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
