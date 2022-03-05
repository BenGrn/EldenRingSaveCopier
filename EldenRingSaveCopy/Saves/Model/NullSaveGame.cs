using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingSaveCopy.Saves.Model
{
    public class NullSaveGame: ISaveGame
    {
        public Guid Id
        {
            get => Guid.Empty;
        }

        public string CharacterName
        {
            get => string.Empty;
        }
    }
}
