namespace Storage
{
    partial class AddEditStockForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockType = new System.Windows.Forms.TextBox();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockCount = new System.Windows.Forms.TextBox();
            this.btnSaveAddEditStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type: ";
            // 
            // txtStockType
            // 
            this.txtStockType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockBindingSource, "TYPE", true));
            this.txtStockType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStockType.Location = new System.Drawing.Point(109, 14);
            this.txtStockType.Multiline = true;
            this.txtStockType.Name = "txtStockType";
            this.txtStockType.Size = new System.Drawing.Size(216, 35);
            this.txtStockType.TabIndex = 0;
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataSource = typeof(Model.Stock);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // txtStockName
            // 
            this.txtStockName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockBindingSource, "NAME", true));
            this.txtStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStockName.Location = new System.Drawing.Point(109, 55);
            this.txtStockName.Multiline = true;
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(216, 35);
            this.txtStockName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Price:";
            // 
            // txtStockPrice
            // 
            this.txtStockPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockBindingSource, "PRICE", true));
            this.txtStockPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStockPrice.Location = new System.Drawing.Point(109, 96);
            this.txtStockPrice.Multiline = true;
            this.txtStockPrice.Name = "txtStockPrice";
            this.txtStockPrice.Size = new System.Drawing.Size(216, 35);
            this.txtStockPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(26, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stock count";
            // 
            // txtStockCount
            // 
            this.txtStockCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockBindingSource, "STOCK_COUNT", true));
            this.txtStockCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStockCount.Location = new System.Drawing.Point(126, 162);
            this.txtStockCount.Multiline = true;
            this.txtStockCount.Name = "txtStockCount";
            this.txtStockCount.Size = new System.Drawing.Size(66, 31);
            this.txtStockCount.TabIndex = 3;
            // 
            // btnSaveAddEditStock
            // 
            this.btnSaveAddEditStock.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveAddEditStock.Location = new System.Drawing.Point(277, 208);
            this.btnSaveAddEditStock.Name = "btnSaveAddEditStock";
            this.btnSaveAddEditStock.Size = new System.Drawing.Size(135, 64);
            this.btnSaveAddEditStock.TabIndex = 4;
            this.btnSaveAddEditStock.Text = "Save";
            this.btnSaveAddEditStock.UseVisualStyleBackColor = true;
            // 
            // AddEditStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 284);
            this.Controls.Add(this.btnSaveAddEditStock);
            this.Controls.Add(this.txtStockCount);
            this.Controls.Add(this.txtStockPrice);
            this.Controls.Add(this.txtStockName);
            this.Controls.Add(this.txtStockType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditStockForm";
            this.Text = "AddEDitStockForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEDitStockForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockCount;
        private System.Windows.Forms.Button btnSaveAddEditStock;
        private System.Windows.Forms.BindingSource stockBindingSource;
    }
}