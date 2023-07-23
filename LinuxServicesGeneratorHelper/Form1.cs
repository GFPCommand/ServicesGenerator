namespace LinuxServicesGeneratorHelper
{
    public partial class Form1 : Form
    {
        List<string> propsList;
        List<string> configuredProps;

        JsonLoader jsonLoader;

        public Form1()
        {
            propsList = new List<string>();
            configuredProps = new List<string>();

            jsonLoader = new JsonLoader();

            InitializeComponent();

            serviceElements.SelectedIndex = 0;

            configuredProps.Add("[Unit]");
            configuredProps.Add("");
            configuredProps.Add("[Service]");
            configuredProps.Add("");
            configuredProps.Add("[Install]");
        }

        private void ServiceElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            propsList.Clear();

            propsListView.Items.Clear();

            propsList = jsonLoader.ReadServicePropsFromJSON(serviceElements.SelectedItem.ToString() ?? "");

            foreach (var elem in propsList)
            {
                propsListView.Items.Add(elem.ToString());
            }
        }

        private void AddProp_Click(object sender, EventArgs e)
        {
            if (propsListView.SelectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem(previewListView.Groups[serviceElements.SelectedIndex])
                {
                    Text = propsListView.SelectedItems[0].Text
                };

                foreach (var elem in previewListView.Items)
                {
                    if ((elem.ToString() ?? "").Contains(item.Text)) return;
                }

                previewListView.Items.Add(item);
            }

            if (previewListView.Items.Count > 0)
            {
                fileGenButton.Visible = true;
            }


        }

        private void RemoveProp_Click(object sender, EventArgs e)
        {
            if (previewListView.SelectedItems.Count > 0)
                previewListView.Items.RemoveAt(previewListView.SelectedIndices[0]);

            if (previewListView.Items.Count <= 0)
            {
                fileGenButton.Visible = false;
            }
        }

        private void SaveValueButton_Click(object sender, EventArgs e)
        {
            string group = $"[{previewListView.SelectedItems[0].Group}]";
            string addingValue = $"{previewListView.SelectedItems[0].Text}={inputValueTextBox.Text}";

            int val = configuredProps.IndexOf(group);

            if (!configuredProps.Contains(addingValue))
            {
                configuredProps.Insert(++val, addingValue);
            }
        }

        private void FileGenButton_Click(object sender, EventArgs e)
        {
            FileBuilder builder = new();

            builder.FileConnect()?.Build(configuredProps);
        }
    }
}