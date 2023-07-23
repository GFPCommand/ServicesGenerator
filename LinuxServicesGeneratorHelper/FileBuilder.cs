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
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = _path;
            openFileDialog.Filter = "Service Files (*.service)|*.service";
            openFileDialog.DefaultExt = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new FileBuilder (openFileDialog.FileName);
            }

            return null;
        }
    }
}
