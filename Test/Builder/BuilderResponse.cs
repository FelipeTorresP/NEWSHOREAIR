namespace Test.Builder
{
    public class BuilderResponse
    {
        public static string BuildResponseCorrectly( string path)
        {
            return File.ReadAllText(path);
        }
    }
}