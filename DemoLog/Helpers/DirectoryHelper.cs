namespace DemoLog.Helpers
{
    public static class DirectoryHelper
    {
        public static bool CreateDirectory(string path)
        {
            var flag = CheckDirectoryExist(path);
            if (flag)
            {
                Directory.CreateDirectory(path);
                return true;
            }

            return false;
        }
        public static bool CheckDirectoryExist(string path)
        {
            if(Directory.Exists(path))
            {
                return true;
            }
            return false;
        }
        public static string DeleteDirectory(string path)
        {
            foreach (string filename in Directory.GetFiles(path))
            {
                File.Delete(filename);
            } 
            foreach (string subfolder in Directory.GetDirectories(path))
            {
                DeleteDirectory(subfolder);
            }
            Directory.Delete(path);
            return "Deleted Successfuly";
        }
    }
}
