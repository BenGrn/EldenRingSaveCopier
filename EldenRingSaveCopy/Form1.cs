using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace EldenRingSaveCopy
{
    public partial class Form1 : Form
    {
        private FileManager _fileManager;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int SLOT_LENGTH = 0x280000;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void sourceFileBrowse(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Elden Ring Save File |ER0000.sl2";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                _fileManager.SourcePath = openFileDialog.FileName;
                try
                {
                    _fileManager.SourceFile = File.ReadAllBytes(_fileManager.SourcePath);
                    sourceFilePath.Text = _fileManager.SourcePath;
                }
                catch (IOException)
                {
                    sourceFilePath.Text = "Failed to load";
                }
            }
            CheckButtonState();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckButtonState()
        {
            copyButton.Text = "Copy";
            if (_fileManager.SourceFile.Length > 0 && _fileManager.TargetFile.Length > 0 
                && _fileManager.SourcePath != _fileManager.TargetPath &&
                _fileManager.SourceSlot != Saves.Slot.NoSelection && _fileManager.TargetSlot != Saves.Slot.NoSelection)
            {
                copyButton.Enabled = true;
                copyButton.BackColor = Color.Lime;
            }
            else
            {
                copyButton.Enabled = false;
                copyButton.BackColor = Color.SeaGreen;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetButtonBrowse(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Elden Ring Save File |ER0000.sl2";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _fileManager.TargetPath = openFileDialog.FileName;
                try
                {
                    _fileManager.TargetFile = File.ReadAllBytes(_fileManager.TargetPath);
                    targetFilePath.Text = _fileManager.TargetPath;
                }
                catch (IOException)
                {
                    sourceFilePath.Text = "Failed to load";
                }
            }
            CheckButtonState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            titleBar.MouseDown += Form1_MouseDown;
            _fileManager = new FileManager();
        }

        private void fromSaveSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            switch (ComboBox.SelectedIndex)
            {
                case (0):
                    _fileManager.SourceSlot = Saves.Slot.Slot1;
                    break;
                case (1):
                    _fileManager.SourceSlot = Saves.Slot.Slot2;
                    break;
                case (2):
                    _fileManager.SourceSlot = Saves.Slot.Slot3;
                    break;
                case (3):
                    _fileManager.SourceSlot = Saves.Slot.Slot4;
                    break;
                case (4):
                    _fileManager.SourceSlot = Saves.Slot.Slot5;
                    break;
                case (5):
                    _fileManager.SourceSlot = Saves.Slot.Slot6;
                    break;
                case (6):
                    _fileManager.SourceSlot = Saves.Slot.Slot7;
                    break;
                case (7):
                    _fileManager.SourceSlot = Saves.Slot.Slot8;
                    break;
                case (8):
                    _fileManager.SourceSlot = Saves.Slot.Slot9;
                    break;
                case (9):
                    _fileManager.SourceSlot = Saves.Slot.Slot10;
                    break;
                default:
                    _fileManager.SourceSlot = Saves.Slot.NoSelection;
                    break;
            }
            CheckButtonState();
        }

        private void toSaveSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            switch (ComboBox.SelectedIndex)
            {
                case (0):
                    _fileManager.TargetSlot = Saves.Slot.Slot1;
                    break;
                case (1):
                    _fileManager.TargetSlot = Saves.Slot.Slot2;
                    break;
                case (2):
                    _fileManager.TargetSlot = Saves.Slot.Slot3;
                    break;
                case (3):
                    _fileManager.TargetSlot = Saves.Slot.Slot4;
                    break;
                case (4):
                    _fileManager.TargetSlot = Saves.Slot.Slot5;
                    break;
                case (5):
                    _fileManager.TargetSlot = Saves.Slot.Slot6;
                    break;
                case (6):
                    _fileManager.TargetSlot = Saves.Slot.Slot7;
                    break;
                case (7):
                    _fileManager.TargetSlot = Saves.Slot.Slot8;
                    break;
                case (8):
                    _fileManager.TargetSlot = Saves.Slot.Slot9;
                    break;
                case (9):
                    _fileManager.TargetSlot = Saves.Slot.Slot10;
                    break;
                default:
                    _fileManager.TargetSlot = Saves.Slot.NoSelection;
                    break;
            }
            CheckButtonState();
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sourceFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void titlePanel(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CreateFileBackup(string path, byte[] file)
        {
            int backupCount = 2;
            string backupPath = path.Replace("ER0000.sl2", "ER0000.backup1");
            while (File.Exists(backupPath))
            {
                backupPath = backupPath.Remove(backupPath.Length - 1, 1) + $"{backupCount}";
                backupCount++;
            }
            File.WriteAllBytes(backupPath, file);
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFileBackup(_fileManager.TargetPath, _fileManager.TargetFile);

                byte[] newSave = new byte[_fileManager.SourceFile.Length];
                byte[] slot = new byte[SLOT_LENGTH];

                Array.Copy(_fileManager.TargetFile, newSave, _fileManager.TargetFile.Length);
                Array.Copy(_fileManager.SourceFile, (int)_fileManager.SourceSlot, slot, 0, SLOT_LENGTH);
                Array.Copy(slot, 0, newSave, (int)_fileManager.TargetSlot, SLOT_LENGTH);

                foreach (int idLocation in newSave.StartingIndex(_fileManager.SourceID))
                {
                    Array.Copy(_fileManager.TargetID, 0, newSave, idLocation, _fileManager.TargetID.Length);
                }

                byte[] hash;
                using (var md5 = MD5.Create())
                {
                    md5.ComputeHash(newSave, (int)_fileManager.TargetSlot, slot.Length);
                    hash = md5.Hash;
                }

                Array.Copy(hash, 0, newSave, (int)_fileManager.TargetSlot - 16, 16);

                File.WriteAllBytes(_fileManager.TargetPath, newSave);
                File.Delete(_fileManager.TargetPath + ".bak");

                copyButton.Enabled = false;
                copyButton.Text = "Complete";
                copyButton.BackColor = Color.SeaGreen;
            }
            catch (Exception _e)
            {

                copyButton.Enabled = false;
                copyButton.Text = "Failed";
                copyButton.BackColor = Color.DarkRed;
                byte[] err = Encoding.Default.GetBytes(_e.Message);
                File.WriteAllBytes(_fileManager.TargetPath.Replace("ER0000.sl2", "Error.log"), err);
            }
            
        }
    }
}
