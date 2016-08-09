namespace StockMarket
{
  partial class StockViewerForm
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
      this.lUser = new System.Windows.Forms.Label();
      this.lPassword = new System.Windows.Forms.Label();
      this.tUser = new System.Windows.Forms.TextBox();
      this.tPassword = new System.Windows.Forms.TextBox();
      this.fetchButton = new System.Windows.Forms.Button();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.portfolio = new System.Windows.Forms.TabPage();
      this.Debug = new System.Windows.Forms.TabPage();
      this.tabControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // lUser
      // 
      this.lUser.AutoSize = true;
      this.lUser.Location = new System.Drawing.Point(13, 13);
      this.lUser.Name = "lUser";
      this.lUser.Size = new System.Drawing.Size(29, 13);
      this.lUser.TabIndex = 0;
      this.lUser.Text = "User";
      // 
      // lPassword
      // 
      this.lPassword.AutoSize = true;
      this.lPassword.Location = new System.Drawing.Point(13, 37);
      this.lPassword.Name = "lPassword";
      this.lPassword.Size = new System.Drawing.Size(53, 13);
      this.lPassword.TabIndex = 1;
      this.lPassword.Text = "Password";
      // 
      // tUser
      // 
      this.tUser.Location = new System.Drawing.Point(90, 10);
      this.tUser.Name = "tUser";
      this.tUser.Size = new System.Drawing.Size(100, 20);
      this.tUser.TabIndex = 2;
      // 
      // tPassword
      // 
      this.tPassword.Location = new System.Drawing.Point(90, 34);
      this.tPassword.Name = "tPassword";
      this.tPassword.Size = new System.Drawing.Size(100, 20);
      this.tPassword.TabIndex = 3;
      // 
      // fetchButton
      // 
      this.fetchButton.Location = new System.Drawing.Point(16, 70);
      this.fetchButton.Name = "fetchButton";
      this.fetchButton.Size = new System.Drawing.Size(112, 23);
      this.fetchButton.TabIndex = 4;
      this.fetchButton.Text = "Fetch stocks";
      this.fetchButton.UseVisualStyleBackColor = true;
      this.fetchButton.Click += new System.EventHandler(this.bFetchStocks_Click);
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.portfolio);
      this.tabControl.Controls.Add(this.Debug);
      this.tabControl.Location = new System.Drawing.Point(4, 99);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(475, 242);
      this.tabControl.TabIndex = 5;
      // 
      // portfolio
      // 
      this.portfolio.Location = new System.Drawing.Point(4, 22);
      this.portfolio.Name = "portfolio";
      this.portfolio.Padding = new System.Windows.Forms.Padding(3);
      this.portfolio.Size = new System.Drawing.Size(467, 216);
      this.portfolio.TabIndex = 0;
      this.portfolio.Text = "Portfolio";
      this.portfolio.UseVisualStyleBackColor = true;
      // 
      // Debug
      // 
      this.Debug.Location = new System.Drawing.Point(4, 22);
      this.Debug.Name = "Debug";
      this.Debug.Padding = new System.Windows.Forms.Padding(3);
      this.Debug.Size = new System.Drawing.Size(467, 216);
      this.Debug.TabIndex = 1;
      this.Debug.Text = "Debug";
      this.Debug.UseVisualStyleBackColor = true;
      // 
      // StockViewerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(481, 339);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.fetchButton);
      this.Controls.Add(this.tPassword);
      this.Controls.Add(this.tUser);
      this.Controls.Add(this.lPassword);
      this.Controls.Add(this.lUser);
      this.Name = "StockViewerForm";
      this.Text = "Stock Viewer";
      this.tabControl.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lUser;
    private System.Windows.Forms.Label lPassword;
    private System.Windows.Forms.TextBox tUser;
    private System.Windows.Forms.TextBox tPassword;
    private System.Windows.Forms.Button fetchButton;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage portfolio;
    private System.Windows.Forms.TabPage Debug;
  }
}

