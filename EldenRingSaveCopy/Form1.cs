using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using EldenRingSaveCopy.Saves.Model;

namespace EldenRingSaveCopy
{
    public partial class Form1 : Form
    {
        private FileManager _fileManager;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private const int MESSAGE_ERROR = 0;
        private const int MESSAGE_INFO = 1;
        private const int MESSAGE_SUCCESS = 2;

        private BindingList<ISaveGame> sourceSaveGames = new BindingList<ISaveGame>();
        private BindingList<ISaveGame> targetSaveGames = new BindingList<ISaveGame>();

        private ISaveGame selectedSourceSave = new NullSaveGame();
        private ISaveGame selectedTargetSave = new NullSaveGame();

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
            showAdditionalInfoMessage(MESSAGE_INFO, "Select Source and Destination files and characters");
        }

        // Tries to read the current windows user name and if it suceeds at it, it uses it in the default Elden Ring savefile location
        private void setCurrentUserDirectory(ref OpenFileDialog currentDialog)
        {
            string nameDirectory = null;
            try
            {
                nameDirectory = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\EldenRing";
                currentDialog.InitialDirectory = nameDirectory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void sourceFileBrowse(object sender, EventArgs e)
        {
            sourceSaveGames.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            setCurrentUserDirectory(ref openFileDialog);
            openFileDialog.Filter = "Elden Ring Save File |ER0000.sl2|Elden Ring Coop Save File |ER0000.co2";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                _fileManager.SourcePath = openFileDialog.FileName;
                try
                {
                    _fileManager.SourceFile = File.ReadAllBytes(_fileManager.SourcePath);
                    sourceFilePath.Text = _fileManager.SourcePath;

                    for (int i = 0; i < 10; i++)
                    {
                        var newSave = new SaveGame();
                        newSave.LoadData(_fileManager.SourceFile, i);
                        if(newSave.Active)
                        {
                            sourceSaveGames.Add(newSave);
                        }
                    }

                    if(sourceSaveGames.Count > 0)
                    {
                        fromSaveSlot.SelectedIndex = 0;
                        this.selectedSourceSave = (ISaveGame)fromSaveSlot.SelectedItem;
                        showAdditionalInfoMessage(MESSAGE_INFO, "Source savegame file loaded correctly.");
                    }
                }
                catch (IOException)
                {
                    sourceFilePath.Text = "Failed to load";
                    showAdditionalInfoMessage(MESSAGE_ERROR, "Source savegame file failed to load.");
                }
            }
            CheckButtonState();
        }

        private void targetButtonBrowse(object sender, EventArgs e)
        {
            targetSaveGames.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            setCurrentUserDirectory(ref openFileDialog);
            openFileDialog.Filter = "Elden Ring Save File |ER0000.sl2|Elden Ring Coop Save File |ER0000.co2";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _fileManager.TargetPath = openFileDialog.FileName;
                try
                {
                    _fileManager.TargetFile = File.ReadAllBytes(_fileManager.TargetPath);
                    targetFilePath.Text = _fileManager.TargetPath;

                    for (int i = 0; i < 10; i++)
                    {
                        var newSave = new SaveGame();
                        newSave.LoadData(_fileManager.TargetFile, i);
                        if (!newSave.Active)
                        {
                            newSave.CharacterName = $"Slot {i + 1}";
                        }
                        targetSaveGames.Add(newSave);
                    }
                    if (targetSaveGames.Count > 0)
                    {
                        toSaveSlot.SelectedIndex = 0;
                        this.selectedTargetSave = (ISaveGame)toSaveSlot.SelectedItem;
                        showAdditionalInfoMessage(MESSAGE_INFO, "Destination savegame file loaded correctly.");
                    }
                }
                catch (IOException)
                {
                    sourceFilePath.Text = "Failed to load";
                    showAdditionalInfoMessage(MESSAGE_ERROR, "Destination savegame file failed to load.");
                }
            }
            CheckButtonState();
        }

        private void CheckButtonState()
        {
            if (_fileManager.SourceFile.Length > 0 && _fileManager.TargetFile.Length > 0 
                && _fileManager.SourcePath != _fileManager.TargetPath &&
                this.selectedSourceSave.Id != Guid.Empty && this.selectedTargetSave.Id != Guid.Empty)
            {
                copyButton.Enabled = true;
                copyButton.BackColor = Color.Goldenrod;
                copyButton.Text =
                    "Copy source character "
                    + (this.selectedSourceSave.CharacterName.Contains("Slot ") ? this.selectedSourceSave.CharacterName :
                    this.selectedSourceSave.CharacterName.Split('\0')[0])
                    + (this.selectedTargetSave.CharacterName.Contains("Slot ") ? " on destination file " + this.selectedTargetSave.CharacterName :
                    " over destination character " + this.selectedTargetSave.CharacterName.Split('\0')[0]);
            }
            else
            {
                copyButton.Enabled = false;
                copyButton.BackColor = Color.DarkOrange;
                copyButton.Text = "Select Source and Destination file and characters";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            titleBar.MouseDown += Form1_MouseDown;
            _fileManager = new FileManager();

            fromSaveSlot.DisplayMember = "CharacterName";
            //fromSaveSlot.DataSource = this.sourceSaveGames;
            fromSaveSlot.DataSource = new BindingSource() { DataSource = this.sourceSaveGames }.DataSource;
            toSaveSlot.DisplayMember = "CharacterName";
            //toSaveSlot.DataSource = this.targetSaveGames;
            toSaveSlot.DataSource = new BindingSource() { DataSource = this.targetSaveGames }.DataSource;
        }

        private void fromSaveSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            this.selectedSourceSave = (ISaveGame)ComboBox.SelectedItem;
            CheckButtonState();
        }

        private void toSaveSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            this.selectedTargetSave = (ISaveGame)ComboBox.SelectedItem;
            CheckButtonState();
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

        private int SlotStartIndex(SaveGame save)
        {
            return (SaveGame.SLOT_START_INDEX + (save.Index * 0x10) + (save.Index * SaveGame.SLOT_LENGTH));
        }

        private int HeaderStartIndex(SaveGame save)
        {
            return (SaveGame.SAVE_HEADER_START_INDEX + (save.Index * SaveGame.SAVE_HEADER_LENGTH));
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFileBackup(_fileManager.TargetPath, _fileManager.TargetFile);

                var sourceSave = (SaveGame)this.selectedSourceSave;
                var targetSave = (SaveGame)this.selectedTargetSave;
                byte[] newSave = new byte[_fileManager.TargetFile.Length];

                //Create temp working file
                Array.Copy(_fileManager.TargetFile, newSave, _fileManager.TargetFile.Length);       

                //Replace steam id in the source save with the steam id of the target save
                foreach (int idLocation in sourceSave.SaveData.StartingIndex(_fileManager.SourceID))
                {
                    Array.Copy(_fileManager.TargetID, 0, sourceSave.SaveData, idLocation, _fileManager.TargetID.Length);
                }

                //Copy source save slot to target save slot in temp file
                Array.Copy(sourceSave.SaveData, 0, newSave, SlotStartIndex(targetSave), SaveGame.SLOT_LENGTH);

                //Copy save header to temp file
                Array.Copy(sourceSave.HeaderData, 0, newSave, HeaderStartIndex(targetSave), SaveGame.SAVE_HEADER_LENGTH);

                //Mark target slot as active
                newSave[SaveGame.CHAR_ACTIVE_STATUS_START_INDEX + targetSave.Index] = 0x01;

                //Calculate checksums
                using (var md5 = MD5.Create())
                {
                    //Get slot checksum
                    md5.ComputeHash(sourceSave.SaveData);
                    //Write checksum to temp target file
                    Array.Copy(md5.Hash, 0, newSave, SlotStartIndex(targetSave) - 0x10, 0x10);
                    //get header checksum
                    md5.ComputeHash(newSave.Skip(SaveGame.SAVE_HEADERS_SECTION_START_INDEX).Take(SaveGame.SAVE_HEADERS_SECTION_LENGTH).ToArray());
                    //Write headers checksum
                    Array.Copy(md5.Hash, 0, newSave, SaveGame.SAVE_HEADERS_SECTION_START_INDEX - 0x10, 0x10);
                }

                //Write temp file to target file
                File.WriteAllBytes(_fileManager.TargetPath, newSave);

                //Delete old backup file to avoid corrupt save error
                File.Delete(_fileManager.TargetPath + ".bak");

                //Copy working file to source file to ensure each character is written to target file in the event of multiple characters being copied.
                Array.Copy(newSave, _fileManager.TargetFile, newSave.Length);

                this.targetSaveGames.RemoveAt(targetSave.Index);
                this.targetSaveGames.Insert(sourceSave.Index, sourceSave);
                toSaveSlot.SelectedIndex = targetSave.Index;

                //Indicate successful copy
                copyButton.Enabled = false;
                copyButton.Text = "Copy Successful!";
                copyButton.BackColor = Color.Gold;
                showAdditionalInfoMessage(MESSAGE_SUCCESS, "Ensure the ER0000.bak file has been deleted from save folder prior to loading.");
            }
            catch (Exception _e)
            {
                copyButton.Enabled = false;
                copyButton.Text = "Copy Failed!";
                copyButton.BackColor = Color.DarkOrange;
                byte[] err = Encoding.Default.GetBytes(_e.Message);
                File.WriteAllBytes(_fileManager.TargetPath.Replace("ER0000.sl2", "Error.log"), err);
            }
            
        }

        private void showAdditionalInfoMessage(int type, string message)
        {
            additionalInfoLabel.Text = message;
            switch (type)
            {
                case MESSAGE_ERROR:
                    additionalInfoLabel.ForeColor = Color.DarkOrange;
                    break;
                case MESSAGE_INFO:
                    additionalInfoLabel.ForeColor = Color.White;
                    break;
                case MESSAGE_SUCCESS:
                    additionalInfoLabel.ForeColor = Color.Gold;
                    break;
                default:
                    additionalInfoLabel.ForeColor= Color.White;
                    break;

            }
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
