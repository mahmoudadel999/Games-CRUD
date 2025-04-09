namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images/games";
        public const string AllowedExtensions = ".png,.jpeg,.jpg";
        public const int MaxFileSizeInMB = 2;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
