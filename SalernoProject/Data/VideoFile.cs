namespace SalernoProject.Data
{
    public class VideoFile
    {
        public string animeName { get; set; }
        public string openingNumber { get; set;}
        public string openingName { get; set; }
        public string filePath { get; set; }

        public VideoFile(string animeName, string openingNumber, string openingName, string filePath)
        {
            this.animeName = animeName;
            this.openingNumber = openingNumber;
            this.openingName = openingName;
            this.filePath = filePath;
        }
    }
}
