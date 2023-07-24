namespace LinuxServicesGeneratorHelper
{
    internal class FileBuilder
    {
        private string _path = string.Empty;

        public FileBuilder()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        public FileBuilder(string path) 
        {
            _path = path;
        }

        public void Build(List<string> selectedElements)
        {
            using StreamWriter writer = new(File.OpenWrite(_path));
            foreach (var element in selectedElements)
            {
                writer.WriteLine(element);
            }
        }

        public FileBuilder FileConnect()
        {
            SaveFileDialog saveFileDialog = new();

            saveFileDialog.InitialDirectory = _path;
            saveFileDialog.Filter = "Service Files (*.service)|*.service";
            saveFileDialog.DefaultExt = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new FileBuilder (saveFileDialog.FileName);
            }

            return null;
        }
    }
}
