using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BasicClicker.Core.IO
{
    public class BCSaveFile : SaveFile
    {
        public override string FileName => "savedata";

        public override void Save(FileStream stream, BinaryFormatter formatter)
        {
            formatter.Serialize(stream, 1);
            formatter.Serialize(stream, "two");
        }

        public override void Load(FileStream stream, BinaryFormatter formatter)
        {
            int i = (int)formatter.Deserialize(stream);
            string s = (string)formatter.Deserialize(stream);
        }
    }
}