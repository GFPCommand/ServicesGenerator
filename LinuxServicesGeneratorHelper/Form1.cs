using System.Diagnostics;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(440, Height);

            configuredProps.Add("[Unit]");
            configuredProps.Add("");
            configuredProps.Add("[Service]");
            configuredProps.Add("");
            configuredProps.Add("[Install]");

            foreach (var item in configuredProps)
            {
                previewText.Text += $"{item}\n";
            }
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
                Size = new Size(820, Height);
                settingsPanel.Visible = true;
            }
        }

        private void RemoveProp_Click(object sender, EventArgs e)
        {
            if (previewListView.SelectedItems.Count > 0)
                previewListView.Items.RemoveAt(previewListView.SelectedIndices[0]);

            if (previewListView.Items.Count <= 0)
            {
                Size = new Size(440, Height);
                settingsPanel.Visible = false;
            }
        }

        private void SaveValueButton_Click(object sender, EventArgs e)
        {
            try
            {
                string group = $"[{previewListView.SelectedItems[0].Group}]";
                string addingValue = $"{previewListView.SelectedItems[0].Text}={inputValueTextBox.Text}";

                int val = configuredProps.IndexOf(group);

                if (!configuredProps.Contains(addingValue) && !previewText.Text.Contains(previewListView.SelectedItems[0].Text))
                {
                    configuredProps.Insert(++val, addingValue);
                    previewText.Clear();
                    foreach (var item in configuredProps)
                    {
                        previewText.Text += $"{item}\n";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select at least one item in preview list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileGenButton_Click(object sender, EventArgs e)
        {
            FileBuilder builder = new();

            string filePath = string.Empty;

            string outputDataReceived = string.Empty;
            string errorDataReceived = string.Empty;

            builder.FileConnect(out filePath)?.Build(configuredProps);

            if (MessageBox.Show($"File was generated and located in {filePath}\nWould you like to check this?", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ProcessStartInfo info = new();

                info.WindowStyle = ProcessWindowStyle.Hidden;

                if (OperatingSystem.IsLinux())
                {
                    info.FileName = "/bin/bash";
                }

                info.Arguments = $"systemd-analyze verify {filePath}";

                using (Process process = new () { StartInfo = info })
                {
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;

                    process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
                    {
                        outputDataReceived = e.Data;
                    });

                    process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
                    {
                        errorDataReceived = e.Data;
                    });

                    process.Start();
                    process.WaitForExit();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                }

                MessageBox.Show($"{outputDataReceived}");
                MessageBox.Show($"{errorDataReceived}");
            }
        }
    }
}