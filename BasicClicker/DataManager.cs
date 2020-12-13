using Newtonsoft.Json;
using System.IO;

namespace BasicClicker
{
    public abstract class DataManager
    {
        public static void CreateSaveFile()
        {
            SaveData data = new SaveData();
            string JSONresult = JsonConvert.SerializeObject(data);
            string filename = @"SaveFile.json";

            if (File.Exists(filename))
            {
                File.Delete(filename);
                using (var tw = new StreamWriter(filename, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
            else if (!File.Exists(filename))
            {
                using (var tw = new StreamWriter(filename, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
        }
    }

    // What types of data goes into the JSON
    public class SaveData
    {
        public int Tomatoes = 0;
    }
}