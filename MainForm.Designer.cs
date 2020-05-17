namespace Simple_Chess_Game
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.squareNo = new System.Windows.Forms.Label();
            this.gameLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.sidePanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sidePanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.restartButton = new System.Windows.Forms.Button();
            this.gamePanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel.Controls.Add(this.label15);
            this.gamePanel.Controls.Add(this.label14);
            this.gamePanel.Controls.Add(this.label13);
            this.gamePanel.Controls.Add(this.label12);
            this.gamePanel.Controls.Add(this.label11);
            this.gamePanel.Controls.Add(this.label10);
            this.gamePanel.Controls.Add(this.label9);
            this.gamePanel.Controls.Add(this.label8);
            this.gamePanel.Controls.Add(this.label7);
            this.gamePanel.Controls.Add(this.label6);
            this.gamePanel.Controls.Add(this.label5);
            this.gamePanel.Controls.Add(this.label4);
            this.gamePanel.Controls.Add(this.label3);
            this.gamePanel.Controls.Add(this.label2);
            this.gamePanel.Controls.Add(this.label1);
            this.gamePanel.Controls.Add(this.squareNo);
            this.gamePanel.Controls.Add(this.gameLayoutPanel);
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(758, 687);
            this.gamePanel.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(597, 640);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 39);
            this.label15.TabIndex = 16;
            this.label15.Text = "H";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(522, 640);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 39);
            this.label14.TabIndex = 15;
            this.label14.Text = "G";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(447, 640);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 39);
            this.label13.TabIndex = 14;
            this.label13.Text = "F";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(372, 640);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 39);
            this.label12.TabIndex = 13;
            this.label12.Text = "E";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(297, 640);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 39);
            this.label11.TabIndex = 12;
            this.label11.Text = "D";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(222, 640);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 39);
            this.label10.TabIndex = 11;
            this.label10.Text = "C";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(147, 640);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 39);
            this.label9.TabIndex = 10;
            this.label9.Text = "B";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(72, 640);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 39);
            this.label8.TabIndex = 9;
            this.label8.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(30, 565);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 39);
            this.label7.TabIndex = 8;
            this.label7.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(30, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 39);
            this.label6.TabIndex = 7;
            this.label6.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(30, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 39);
            this.label5.TabIndex = 6;
            this.label5.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(30, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(30, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(30, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(30, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "7";
            // 
            // squareNo
            // 
            this.squareNo.AutoSize = true;
            this.squareNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.squareNo.Location = new System.Drawing.Point(30, 40);
            this.squareNo.Name = "squareNo";
            this.squareNo.Size = new System.Drawing.Size(36, 39);
            this.squareNo.TabIndex = 1;
            this.squareNo.Text = "8";
            // 
            // gameLayoutPanel
            // 
            this.gameLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameLayoutPanel.ColumnCount = 8;
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.Location = new System.Drawing.Point(72, 40);
            this.gameLayoutPanel.Name = "gameLayoutPanel";
            this.gameLayoutPanel.RowCount = 8;
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.gameLayoutPanel.Size = new System.Drawing.Size(600, 600);
            this.gameLayoutPanel.TabIndex = 0;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoPanel.Controls.Add(this.sidePanel2);
            this.infoPanel.Controls.Add(this.sidePanel1);
            this.infoPanel.Controls.Add(this.restartButton);
            this.infoPanel.Location = new System.Drawing.Point(764, 41);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(250, 600);
            this.infoPanel.TabIndex = 1;
            // 
            // sidePanel2
            // 
            this.sidePanel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sidePanel2.ColumnCount = 3;
            this.sidePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel2.Location = new System.Drawing.Point(25, 374);
            this.sidePanel2.Name = "sidePanel2";
            this.sidePanel2.RowCount = 2;
            this.sidePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidePanel2.Size = new System.Drawing.Size(198, 138);
            this.sidePanel2.TabIndex = 2;
            // 
            // sidePanel1
            // 
            this.sidePanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sidePanel1.ColumnCount = 3;
            this.sidePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sidePanel1.Location = new System.Drawing.Point(25, 149);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.RowCount = 2;
            this.sidePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidePanel1.Size = new System.Drawing.Size(198, 138);
            this.sidePanel1.TabIndex = 1;
            // 
            // restartButton
            // 
            this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.restartButton.Location = new System.Drawing.Point(80, 9);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(100, 39);
            this.restartButton.TabIndex = 0;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1023, 681);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.gamePanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1039, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1039, 690);
            this.Name = "MainForm";
            this.Text = "Chess";
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.TableLayoutPanel gameLayoutPanel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label squareNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel sidePanel2;
        private System.Windows.Forms.TableLayoutPanel sidePanel1;
    }
}

