using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingSaveCopy.Saves.Model
{
    public interface ISaveGame
    {
        Guid Id { get; }
        string CharacterName { get; }
    }
}
