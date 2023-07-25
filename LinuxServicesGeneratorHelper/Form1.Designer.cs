namespace LinuxServicesGeneratorHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup1 = new ListViewGroup("Unit", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Service", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Install", HorizontalAlignment.Left);
            propsListView = new ListView();
            serviceElements = new ComboBox();
            addProp = new Button();
            removeProp = new Button();
            previewListView = new ListView();
            fileGenButton = new Button();
            label1 = new Label();
            inputValueTextBox = new TextBox();
            saveValueButton = new Button();
            settingsPanel = new Panel();
            previewText = new RichTextBox();
            settingsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // propsListView
            // 
            propsListView.Location = new Point(12, 41);
            propsListView.MultiSelect = false;
            propsListView.Name = "propsListView";
            propsListView.Size = new Size(157, 397);
            propsListView.Sorting = SortOrder.Ascending;
            propsListView.TabIndex = 0;
            propsListView.UseCompatibleStateImageBehavior = false;
            propsListView.View = View.List;
            // 
            // serviceElements
            // 
            serviceElements.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceElements.FormattingEnabled = true;
            serviceElements.Items.AddRange(new object[] { "Unit", "Service", "Install" });
            serviceElements.Location = new Point(12, 12);
            serviceElements.Name = "serviceElements";
            serviceElements.Size = new Size(157, 23);
            serviceElements.TabIndex = 1;
            serviceElements.SelectedIndexChanged += ServiceElements_SelectedIndexChanged;
            // 
            // addProp
            // 
            addProp.Location = new Point(175, 167);
            addProp.Name = "addProp";
            addProp.Size = new Size(75, 23);
            addProp.TabIndex = 2;
            addProp.Text = "Add";
            addProp.UseVisualStyleBackColor = true;
            addProp.Click += AddProp_Click;
            // 
            // removeProp
            // 
            removeProp.Location = new Point(175, 196);
            removeProp.Name = "removeProp";
            removeProp.Size = new Size(75, 23);
            removeProp.TabIndex = 3;
            removeProp.Text = "Remove";
            removeProp.UseVisualStyleBackColor = true;
            removeProp.Click += RemoveProp_Click;
            // 
            // previewListView
            // 
            listViewGroup1.Header = "Unit";
            listViewGroup1.Name = "unitGroup";
            listViewGroup2.Header = "Service";
            listViewGroup2.Name = "serviceGroup";
            listViewGroup3.Header = "Install";
            listViewGroup3.Name = "installGroup";
            previewListView.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3 });
            previewListView.Location = new Point(256, 41);
            previewListView.MultiSelect = false;
            previewListView.Name = "previewListView";
            previewListView.Size = new Size(157, 397);
            previewListView.Sorting = SortOrder.Ascending;
            previewListView.TabIndex = 4;
            previewListView.UseCompatibleStateImageBehavior = false;
            previewListView.View = View.SmallIcon;
            // 
            // fileGenButton
            // 
            fileGenButton.Location = new Point(272, 13);
            fileGenButton.Name = "fileGenButton";
            fileGenButton.Size = new Size(90, 25);
            fileGenButton.TabIndex = 6;
            fileGenButton.Text = "Generate file";
            fileGenButton.UseVisualStyleBackColor = true;
            fileGenButton.Click += FileGenButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 16);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 7;
            label1.Text = "Input value:";
            // 
            // inputValueTextBox
            // 
            inputValueTextBox.Location = new Point(85, 13);
            inputValueTextBox.Name = "inputValueTextBox";
            inputValueTextBox.Size = new Size(100, 23);
            inputValueTextBox.TabIndex = 8;
            // 
            // saveValueButton
            // 
            saveValueButton.Location = new Point(191, 13);
            saveValueButton.Name = "saveValueButton";
            saveValueButton.Size = new Size(75, 25);
            saveValueButton.TabIndex = 9;
            saveValueButton.Text = "Save";
            saveValueButton.UseVisualStyleBackColor = true;
            saveValueButton.Click += SaveValueButton_Click;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(previewText);
            settingsPanel.Controls.Add(fileGenButton);
            settingsPanel.Controls.Add(saveValueButton);
            settingsPanel.Controls.Add(inputValueTextBox);
            settingsPanel.Controls.Add(label1);
            settingsPanel.Location = new Point(419, 41);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(369, 397);
            settingsPanel.TabIndex = 10;
            settingsPanel.Visible = false;
            // 
            // previewText
            // 
            previewText.BackColor = SystemColors.ControlLightLight;
            previewText.BorderStyle = BorderStyle.None;
            previewText.Location = new Point(3, 42);
            previewText.Name = "previewText";
            previewText.ReadOnly = true;
            previewText.Size = new Size(359, 352);
            previewText.TabIndex = 10;
            previewText.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 451);
            Controls.Add(settingsPanel);
            Controls.Add(previewListView);
            Controls.Add(removeProp);
            Controls.Add(addProp);
            Controls.Add(serviceElements);
            Controls.Add(propsListView);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Service Generator";
            Load += Form1_Load;
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView propsListView;
        private ComboBox serviceElements;
        private Button addProp;
        private Button removeProp;
        private ListView previewListView;
        private Button fileGenButton;
        private Label label1;
        private TextBox inputValueTextBox;
        private Button saveValueButton;
        private Panel settingsPanel;
        private RichTextBox previewText;
    }
}