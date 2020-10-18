namespace Cyotek.Demo
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.previewImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.savePresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generateSkylineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.createSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.actualSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sizeToFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.savePresetToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.exportImageToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.generateToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.actualSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.sizeToFitToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.presetToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.seedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.Location = new System.Drawing.Point(0, 49);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.previewImageBox);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.propertyGrid);
      this.splitContainer.Size = new System.Drawing.Size(784, 490);
      this.splitContainer.SplitterDistance = 484;
      this.splitContainer.TabIndex = 0;
      // 
      // previewImageBox
      // 
      this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewImageBox.Location = new System.Drawing.Point(0, 0);
      this.previewImageBox.Name = "previewImageBox";
      this.previewImageBox.Size = new System.Drawing.Size(484, 490);
      this.previewImageBox.TabIndex = 0;
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(296, 490);
      this.propertyGrid.TabIndex = 0;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(784, 24);
      this.menuStrip.TabIndex = 1;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePresetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // savePresetToolStripMenuItem
      // 
      this.savePresetToolStripMenuItem.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Save;
      this.savePresetToolStripMenuItem.Name = "savePresetToolStripMenuItem";
      this.savePresetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.savePresetToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.savePresetToolStripMenuItem.Text = "&Save Preset...";
      this.savePresetToolStripMenuItem.Click += new System.EventHandler(this.SavePresetToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
      // 
      // exportImageToolStripMenuItem
      // 
      this.exportImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportImageToolStripMenuItem.Image")));
      this.exportImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
      this.exportImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.exportImageToolStripMenuItem.Text = "&Export Image...";
      this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.ExportImageToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Copy;
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.copyToolStripMenuItem.Text = "&Copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateSkylineToolStripMenuItem,
            this.toolStripMenuItem2,
            this.createSequenceToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // generateSkylineToolStripMenuItem
      // 
      this.generateSkylineToolStripMenuItem.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Generate;
      this.generateSkylineToolStripMenuItem.Name = "generateSkylineToolStripMenuItem";
      this.generateSkylineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.generateSkylineToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.generateSkylineToolStripMenuItem.Text = "&Generate Skyline";
      this.generateSkylineToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripButton_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(214, 6);
      // 
      // createSequenceToolStripMenuItem
      // 
      this.createSequenceToolStripMenuItem.Name = "createSequenceToolStripMenuItem";
      this.createSequenceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
      this.createSequenceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.createSequenceToolStripMenuItem.Text = "Create &Sequence...";
      this.createSequenceToolStripMenuItem.Click += new System.EventHandler(this.CreateSequenceToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualSizeToolStripMenuItem,
            this.sizeToFitToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // actualSizeToolStripMenuItem
      // 
      this.actualSizeToolStripMenuItem.Image = global::Cyotek.SkylineGenerator.Properties.Resources.ActualSize;
      this.actualSizeToolStripMenuItem.Name = "actualSizeToolStripMenuItem";
      this.actualSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
      this.actualSizeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.actualSizeToolStripMenuItem.Text = "&Actual Size";
      this.actualSizeToolStripMenuItem.Click += new System.EventHandler(this.ActualSizeToolStripButton_Click);
      // 
      // sizeToFitToolStripMenuItem
      // 
      this.sizeToFitToolStripMenuItem.Image = global::Cyotek.SkylineGenerator.Properties.Resources.SizeToFit;
      this.sizeToFitToolStripMenuItem.Name = "sizeToFitToolStripMenuItem";
      this.sizeToFitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
      this.sizeToFitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.sizeToFitToolStripMenuItem.Text = "Size to &Fit";
      this.sizeToFitToolStripMenuItem.Click += new System.EventHandler(this.SizeToFitToolStripButton_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePresetToolStripButton,
            this.exportImageToolStripButton,
            this.toolStripSeparator6,
            this.copyToolStripButton,
            this.toolStripSeparator7,
            this.generateToolStripButton,
            this.toolStripSeparator8,
            this.actualSizeToolStripButton,
            this.sizeToFitToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.presetToolStripComboBox});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(784, 25);
      this.toolStrip.TabIndex = 2;
      // 
      // savePresetToolStripButton
      // 
      this.savePresetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.savePresetToolStripButton.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Save;
      this.savePresetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.savePresetToolStripButton.Name = "savePresetToolStripButton";
      this.savePresetToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.savePresetToolStripButton.Text = "Save Preset";
      this.savePresetToolStripButton.Click += new System.EventHandler(this.SavePresetToolStripMenuItem_Click);
      // 
      // exportImageToolStripButton
      // 
      this.exportImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.exportImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exportImageToolStripButton.Image")));
      this.exportImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.exportImageToolStripButton.Name = "exportImageToolStripButton";
      this.exportImageToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.exportImageToolStripButton.Text = "Export Image";
      this.exportImageToolStripButton.Click += new System.EventHandler(this.ExportImageToolStripMenuItem_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // copyToolStripButton
      // 
      this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.copyToolStripButton.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Copy;
      this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripButton.Name = "copyToolStripButton";
      this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.copyToolStripButton.Text = "&Copy";
      this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
      // 
      // generateToolStripButton
      // 
      this.generateToolStripButton.Image = global::Cyotek.SkylineGenerator.Properties.Resources.Generate;
      this.generateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.generateToolStripButton.Name = "generateToolStripButton";
      this.generateToolStripButton.Size = new System.Drawing.Size(74, 22);
      this.generateToolStripButton.Text = "&Generate";
      this.generateToolStripButton.Click += new System.EventHandler(this.GenerateToolStripButton_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
      // 
      // actualSizeToolStripButton
      // 
      this.actualSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actualSizeToolStripButton.Image = global::Cyotek.SkylineGenerator.Properties.Resources.ActualSize;
      this.actualSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actualSizeToolStripButton.Name = "actualSizeToolStripButton";
      this.actualSizeToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.actualSizeToolStripButton.Text = "Actual Size";
      this.actualSizeToolStripButton.Click += new System.EventHandler(this.ActualSizeToolStripButton_Click);
      // 
      // sizeToFitToolStripButton
      // 
      this.sizeToFitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.sizeToFitToolStripButton.Image = global::Cyotek.SkylineGenerator.Properties.Resources.SizeToFit;
      this.sizeToFitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.sizeToFitToolStripButton.Name = "sizeToFitToolStripButton";
      this.sizeToFitToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.sizeToFitToolStripButton.Text = "Size To Fit";
      this.sizeToFitToolStripButton.Click += new System.EventHandler(this.SizeToFitToolStripButton_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
      this.toolStripLabel1.Text = "&Preset:";
      // 
      // presetToolStripComboBox
      // 
      this.presetToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.presetToolStripComboBox.Name = "presetToolStripComboBox";
      this.presetToolStripComboBox.Size = new System.Drawing.Size(121, 25);
      this.presetToolStripComboBox.Sorted = true;
      this.presetToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetToolStripComboBox_SelectedIndexChanged);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.seedToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 539);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(784, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(670, 17);
      this.toolStripStatusLabel1.Spring = true;
      this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // seedToolStripStatusLabel
      // 
      this.seedToolStripStatusLabel.Name = "seedToolStripStatusLabel";
      this.seedToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(99, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.menuStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.Text = "Cyotek Skyline Generator";
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private Cyotek.Windows.Forms.ImageBox previewImageBox;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton exportImageToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton copyToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton generateToolStripButton;
    private System.Windows.Forms.ToolStripMenuItem generateSkylineToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripButton actualSizeToolStripButton;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem actualSizeToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton sizeToFitToolStripButton;
    private System.Windows.Forms.ToolStripMenuItem sizeToFitToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripComboBox presetToolStripComboBox;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripMenuItem savePresetToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripButton savePresetToolStripButton;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel seedToolStripStatusLabel;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem createSequenceToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
  }
}

