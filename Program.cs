//Written for Blood of the Titans. https://store.steampowered.com/app/1451230/Blood_of_Titans/
using System.IO;

namespace BotT_MGX
{
    class Program
    {
        public static BinaryReader br;
        static void Main(string[] args)
        {
            br = new BinaryReader(File.OpenRead(args[0]));
            if (new string(br.ReadChars(2)) != "SG")
            {
                throw new System.ArgumentException("Wrong File.");
            }
            br.BaseStream.Position = 36;
            System.Collections.Generic.List<Subfile> subfiles = new();
            for (int i = 0; i < 5043; i++)
            {
                subfiles.Add(new());
            }

            int n = 0;
            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "\\" + Path.GetFileNameWithoutExtension(args[0]));
            foreach (Subfile file in subfiles)
            {
                br.BaseStream.Position = file.start;

                BinaryWriter bw = new(File.Create(Path.GetDirectoryName(args[0]) + "\\" + Path.GetFileNameWithoutExtension(args[0]) + "\\" + n));

                bw.Write(br.ReadBytes(file.size));
                bw.Close();
                n++;
            }
        }
        struct Subfile
        {
            public uint unknown;
            public uint start;
            public int size;
        }
    }
}