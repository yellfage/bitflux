namespace Yellfage.Wst.Interior.Communication
{
    internal class Version : IVersion
    {
        public int Major { get; }
        public int Minor { get; }

        public Version(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }
}
