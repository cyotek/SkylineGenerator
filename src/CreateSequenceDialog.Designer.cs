namespace Cyotek.SkylineGenerator
{
  partial class CreateSequenceDialog
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
      System.Windows.Forms.Panel previewPanel;
      System.Windows.Forms.TableLayoutPanel previewTableLayoutPanel;
      System.Windows.Forms.Label nameLabel;
      System.Windows.Forms.Label stepLabel;
      this.preview3ImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.preview2ImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.preview1ImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.hScrollBar = new System.Windows.Forms.HScrollBar();
      this.settingsGroupBox = new System.Windows.Forms.GroupBox();
      this.stepSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.pathBrowseButton = new System.Windows.Forms.Button();
      this.pathTextBox = new System.Windows.Forms.TextBox();
      this.pathLabel = new System.Windows.Forms.Label();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.previewGroupBox = new System.Windows.Forms.GroupBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.imageCountLabel = new System.Windows.Forms.Label();
      previewPanel = new System.Windows.Forms.Panel();
      previewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      nameLabel = new System.Windows.Forms.Label();
      stepLabel = new System.Windows.Forms.Label();
      previewPanel.SuspendLayout();
      previewTableLayoutPanel.SuspendLayout();
      this.settingsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.stepSizeNumericUpDown)).BeginInit();
      this.previewGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // previewPanel
      // 
      previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      previewPanel.BackColor = System.Drawing.SystemColors.Window;
      previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      previewPanel.Controls.Add(previewTableLayoutPanel);
      previewPanel.Controls.Add(this.hScrollBar);
      previewPanel.ForeColor = System.Drawing.SystemColors.WindowText;
      previewPanel.Location = new System.Drawing.Point(6, 19);
      previewPanel.Name = "previewPanel";
      previewPanel.Size = new System.Drawing.Size(764, 266);
      previewPanel.TabIndex = 0;
      // 
      // previewTableLayoutPanel
      // 
      previewTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      previewTableLayoutPanel.ColumnCount = 3;
      previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      previewTableLayoutPanel.Controls.Add(this.preview3ImageBox, 0, 0);
      previewTableLayoutPanel.Controls.Add(this.preview2ImageBox, 0, 0);
      previewTableLayoutPanel.Controls.Add(this.preview1ImageBox, 0, 0);
      previewTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
      previewTableLayoutPanel.Name = "previewTableLayoutPanel";
      previewTableLayoutPanel.RowCount = 1;
      previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 239F));
      previewTableLayoutPanel.Size = new System.Drawing.Size(754, 239);
      previewTableLayoutPanel.TabIndex = 0;
      // 
      // preview3ImageBox
      // 
      this.preview3ImageBox.AllowZoom = false;
      this.preview3ImageBox.AutoPan = false;
      this.preview3ImageBox.BackColor = System.Drawing.SystemColors.Window;
      this.preview3ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.preview3ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preview3ImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.preview3ImageBox.Location = new System.Drawing.Point(505, 3);
      this.preview3ImageBox.Name = "preview3ImageBox";
      this.preview3ImageBox.ShortcutsEnabled = false;
      this.preview3ImageBox.Size = new System.Drawing.Size(246, 233);
      this.preview3ImageBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
      this.preview3ImageBox.TabIndex = 2;
      // 
      // preview2ImageBox
      // 
      this.preview2ImageBox.AllowZoom = false;
      this.preview2ImageBox.AutoPan = false;
      this.preview2ImageBox.BackColor = System.Drawing.SystemColors.Window;
      this.preview2ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.preview2ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preview2ImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.preview2ImageBox.Location = new System.Drawing.Point(254, 3);
      this.preview2ImageBox.Name = "preview2ImageBox";
      this.preview2ImageBox.ShortcutsEnabled = false;
      this.preview2ImageBox.Size = new System.Drawing.Size(245, 233);
      this.preview2ImageBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
      this.preview2ImageBox.TabIndex = 1;
      // 
      // preview1ImageBox
      // 
      this.preview1ImageBox.AllowZoom = false;
      this.preview1ImageBox.AutoPan = false;
      this.preview1ImageBox.BackColor = System.Drawing.SystemColors.Window;
      this.preview1ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.preview1ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preview1ImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.preview1ImageBox.Location = new System.Drawing.Point(3, 3);
      this.preview1ImageBox.Name = "preview1ImageBox";
      this.preview1ImageBox.ShortcutsEnabled = false;
      this.preview1ImageBox.Size = new System.Drawing.Size(245, 233);
      this.preview1ImageBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
      this.preview1ImageBox.TabIndex = 0;
      // 
      // hScrollBar
      // 
      this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.hScrollBar.Enabled = false;
      this.hScrollBar.Location = new System.Drawing.Point(0, 245);
      this.hScrollBar.Name = "hScrollBar";
      this.hScrollBar.Size = new System.Drawing.Size(760, 17);
      this.hScrollBar.TabIndex = 1;
      this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar_Scroll);
      this.hScrollBar.ValueChanged += new System.EventHandler(this.HScrollBar_ValueChanged);
      // 
      // nameLabel
      // 
      nameLabel.AutoSize = true;
      nameLabel.Location = new System.Drawing.Point(3, 22);
      nameLabel.Name = "nameLabel";
      nameLabel.Size = new System.Drawing.Size(38, 13);
      nameLabel.TabIndex = 0;
      nameLabel.Text = "&Name:";
      // 
      // stepLabel
      // 
      stepLabel.AutoSize = true;
      stepLabel.Location = new System.Drawing.Point(3, 47);
      stepLabel.Name = "stepLabel";
      stepLabel.Size = new System.Drawing.Size(55, 13);
      stepLabel.TabIndex = 5;
      stepLabel.Text = "&Step Size:";
      // 
      // settingsGroupBox
      // 
      this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.settingsGroupBox.Controls.Add(this.stepSizeNumericUpDown);
      this.settingsGroupBox.Controls.Add(stepLabel);
      this.settingsGroupBox.Controls.Add(this.pathBrowseButton);
      this.settingsGroupBox.Controls.Add(this.pathTextBox);
      this.settingsGroupBox.Controls.Add(this.pathLabel);
      this.settingsGroupBox.Controls.Add(this.nameTextBox);
      this.settingsGroupBox.Controls.Add(nameLabel);
      this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new System.Drawing.Size(776, 100);
      this.settingsGroupBox.TabIndex = 0;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Settings";
      // 
      // stepSizeNumericUpDown
      // 
      this.stepSizeNumericUpDown.Location = new System.Drawing.Point(64, 45);
      this.stepSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.stepSizeNumericUpDown.Name = "stepSizeNumericUpDown";
      this.stepSizeNumericUpDown.Size = new System.Drawing.Size(89, 20);
      this.stepSizeNumericUpDown.TabIndex = 6;
      this.stepSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.stepSizeNumericUpDown.ValueChanged += new System.EventHandler(this.stepSizeNumericUpDown_ValueChanged);
      // 
      // pathBrowseButton
      // 
      this.pathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pathBrowseButton.Location = new System.Drawing.Point(695, 17);
      this.pathBrowseButton.Name = "pathBrowseButton";
      this.pathBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.pathBrowseButton.TabIndex = 4;
      this.pathBrowseButton.Text = "&Browse...";
      this.pathBrowseButton.UseVisualStyleBackColor = true;
      this.pathBrowseButton.Click += new System.EventHandler(this.PathBrowseButton_Click);
      // 
      // pathTextBox
      // 
      this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.pathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.pathTextBox.Location = new System.Drawing.Point(245, 19);
      this.pathTextBox.Name = "pathTextBox";
      this.pathTextBox.Size = new System.Drawing.Size(444, 20);
      this.pathTextBox.TabIndex = 3;
      // 
      // pathLabel
      // 
      this.pathLabel.AutoSize = true;
      this.pathLabel.Location = new System.Drawing.Point(207, 22);
      this.pathLabel.Name = "pathLabel";
      this.pathLabel.Size = new System.Drawing.Size(32, 13);
      this.pathLabel.TabIndex = 2;
      this.pathLabel.Text = "&Path:";
      // 
      // nameTextBox
      // 
      this.nameTextBox.Location = new System.Drawing.Point(64, 19);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(137, 20);
      this.nameTextBox.TabIndex = 1;
      // 
      // previewGroupBox
      // 
      this.previewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.previewGroupBox.Controls.Add(previewPanel);
      this.previewGroupBox.Location = new System.Drawing.Point(12, 118);
      this.previewGroupBox.Name = "previewGroupBox";
      this.previewGroupBox.Size = new System.Drawing.Size(776, 291);
      this.previewGroupBox.TabIndex = 1;
      this.previewGroupBox.TabStop = false;
      this.previewGroupBox.Text = "Preview";
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(632, 415);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(713, 415);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
      // 
      // imageCountLabel
      // 
      this.imageCountLabel.AutoSize = true;
      this.imageCountLabel.Location = new System.Drawing.Point(15, 420);
      this.imageCountLabel.Name = "imageCountLabel";
      this.imageCountLabel.Size = new System.Drawing.Size(49, 13);
      this.imageCountLabel.TabIndex = 2;
      this.imageCountLabel.Text = "0 images";
      // 
      // CreateSequenceDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.imageCountLabel);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.previewGroupBox);
      this.Controls.Add(this.settingsGroupBox);
      this.Name = "CreateSequenceDialog";
      this.Text = "Create Sequence";
      previewPanel.ResumeLayout(false);
      previewTableLayoutPanel.ResumeLayout(false);
      this.settingsGroupBox.ResumeLayout(false);
      this.settingsGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.stepSizeNumericUpDown)).EndInit();
      this.previewGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private Windows.Forms.ImageBox preview3ImageBox;
    private Windows.Forms.ImageBox preview2ImageBox;
    private Windows.Forms.ImageBox preview1ImageBox;
    private System.Windows.Forms.HScrollBar hScrollBar;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.GroupBox settingsGroupBox;
    private System.Windows.Forms.GroupBox previewGroupBox;
    private System.Windows.Forms.NumericUpDown stepSizeNumericUpDown;
    private System.Windows.Forms.Button pathBrowseButton;
    private System.Windows.Forms.TextBox pathTextBox;
    private System.Windows.Forms.Label pathLabel;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.Label imageCountLabel;
  }
}