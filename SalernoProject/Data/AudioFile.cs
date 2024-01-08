namespace SalernoProject.Data
{
    public class AudioFile
    {
        public string filePath { get; set; } 
        public string animeName { get; set; }
        public string openingNumber { get; set;}
        public string openingName { get; set; }

        public AudioFile(string animeName, string openingNumber, string openingName, string filePath)
        {
            this.animeName = animeName;
            this.openingNumber = openingNumber;
            this.openingName = openingName;
            this.filePath = filePath;
        }
    }
}
