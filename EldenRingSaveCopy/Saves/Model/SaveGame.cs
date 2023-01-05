using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingSaveCopy.Saves.Model
{
    public class SaveGame: ISaveGame
    {
        public const int SLOT_START_INDEX = 0x310;
        public const int SLOT_LENGTH = 0x280000;
        public const int SAVE_HEADERS_SECTION_START_INDEX = 0x19003B0;
        public const int SAVE_HEADERS_SECTION_LENGTH = 0x60000;
        public const int SAVE_HEADER_START_INDEX = 0x1901D0E;
        public const int SAVE_HEADER_LENGTH = 0x24C;
        public const int CHAR_ACTIVE_STATUS_START_INDEX = 0x1901D04;

        private const int CHAR_NAME_LENGTH = 0x22;
        private const int CHAR_LEVEL_LOCATION = 0x22;
        private const int CHAR_PLAYED_START_INDEX = 0x26;
        


        private bool active;
        private string characterName;
        private byte[] saveData;
        private byte[] headerData;
        private Guid id;
        private int index;

        public SaveGame()
        {
            this.active = false;
            this.characterName = string.Empty;
            this.saveData = new byte[0];
            this.id = Guid.NewGuid();
            this.index = -1;
        }

        public int Index
        {
            get => this.index;
        }

        public bool Active
        {
            get => this.active;
            set => this.active = value;
        }

        public string CharacterName
        {
            get => this.characterName;
            set => this.characterName = value ?? string.Empty;
        }

        public byte[] SaveData
        {
            get => this.saveData;
        }

        public byte[] HeaderData
        {
            get => this.headerData;
        }

        public Guid Id
        {
            get => this.id;
        }

        public int CharacterLevel { get; set; }
        public int SecondsPlayed { get; set; }

        public bool LoadData(byte[] data, int slotIndex)
        {
            try
            {
                this.index = slotIndex;
                this.active =  data.Skip(CHAR_ACTIVE_STATUS_START_INDEX).ToArray()[0 + slotIndex] == 1 ? true : false;
                this.characterName = Encoding.Unicode.GetString(data.Skip(SAVE_HEADER_START_INDEX + (slotIndex * SAVE_HEADER_LENGTH)).Take(CHAR_NAME_LENGTH).ToArray());
                this.CharacterLevel = data.Skip(SAVE_HEADER_START_INDEX + (slotIndex * SAVE_HEADER_LENGTH)).ToArray()[CHAR_LEVEL_LOCATION];
                this.SecondsPlayed = BitConverter.ToInt32(data.Skip(SAVE_HEADER_START_INDEX + (slotIndex * SAVE_HEADER_LENGTH) + CHAR_PLAYED_START_INDEX).Take(4).ToArray(), 0);
                this.saveData = data.Skip(SLOT_START_INDEX + (slotIndex * 0x10) + (slotIndex * SLOT_LENGTH)).Take(SLOT_LENGTH).ToArray();
                this.headerData = data.Skip(SAVE_HEADER_START_INDEX + (slotIndex * SAVE_HEADER_LENGTH)).Take(SAVE_HEADER_LENGTH).ToArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
