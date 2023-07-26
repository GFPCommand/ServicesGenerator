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
            File.WriteAllText(_path, string.Empty);

            using StreamWriter writer = new(File.OpenWrite(_path));

            foreach (var element in selectedElements)
            {
                writer.WriteLine(element);
            }
        }

        public FileBuilder FileConnect(out string path)
        {
            SaveFileDialog saveFileDialog = new();

            saveFileDialog.InitialDirectory = _path;
            saveFileDialog.Filter = "Service Files (*.service)|*.service";
            saveFileDialog.DefaultExt = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;

                return new FileBuilder(saveFileDialog.FileName);
            }
            else
            {

                path = saveFileDialog.FileName;

                return null;
            }
        }
    }
}
