namespace ApiSep.Library.Helpers
{
    public static class DirectoryHelper
    {
        public static string CreateDirectory(string directory)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            return directory;
        }

    }
}
