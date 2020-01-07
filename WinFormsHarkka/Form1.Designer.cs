namespace WinFormsHarkka
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_listComps = new System.Windows.Forms.Button();
            this.listViewComps2 = new System.Windows.Forms.ListView();
            this.btn_deleteSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_add_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_add_pcs = new System.Windows.Forms.TextBox();
            this.textBox_add_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_add_new = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewDevs = new System.Windows.Forms.ListView();
            this.groupBoxComps = new System.Windows.Forms.GroupBox();
            this.btn_saveEdits = new System.Windows.Forms.Button();
            this.btn_editSelected = new System.Windows.Forms.Button();
            this.stockWorth = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewDevComps = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.label_search = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxComps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_listComps
            // 
            resources.ApplyResources(this.btn_listComps, "btn_listComps");
            this.btn_listComps.Name = "btn_listComps";
            this.btn_listComps.UseVisualStyleBackColor = true;
            this.btn_listComps.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listViewComps2
            // 
            resources.ApplyResources(this.listViewComps2, "listViewComps2");
            this.listViewComps2.MultiSelect = false;
            this.listViewComps2.Name = "listViewComps2";
            this.listViewComps2.UseCompatibleStateImageBehavior = false;
            this.listViewComps2.SelectedIndexChanged += new System.EventHandler(this.listViewComps2_SelectedIndexChanged);
            // 
            // btn_deleteSelected
            // 
            resources.ApplyResources(this.btn_deleteSelected, "btn_deleteSelected");
            this.btn_deleteSelected.Name = "btn_deleteSelected";
            this.btn_deleteSelected.UseVisualStyleBackColor = true;
            this.btn_deleteSelected.Click += new System.EventHandler(this.Btn_deleteSelected_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox_add_name
            // 
            resources.ApplyResources(this.textBox_add_name, "textBox_add_name");
            this.textBox_add_name.Name = "textBox_add_name";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBox_add_pcs
            // 
            resources.ApplyResources(this.textBox_add_pcs, "textBox_add_pcs");
            this.textBox_add_pcs.Name = "textBox_add_pcs";
            // 
            // textBox_add_price
            // 
            resources.ApplyResources(this.textBox_add_price, "textBox_add_price");
            this.textBox_add_price.Name = "textBox_add_price";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btn_add_new
            // 
            resources.ApplyResources(this.btn_add_new, "btn_add_new");
            this.btn_add_new.Name = "btn_add_new";
            this.btn_add_new.UseVisualStyleBackColor = true;
            this.btn_add_new.Click += new System.EventHandler(this.Button_add_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // listViewDevs
            // 
            resources.ApplyResources(this.listViewDevs, "listViewDevs");
            this.listViewDevs.MultiSelect = false;
            this.listViewDevs.Name = "listViewDevs";
            this.listViewDevs.UseCompatibleStateImageBehavior = false;
            this.listViewDevs.SelectedIndexChanged += new System.EventHandler(this.listViewDevs_SelectedIndexChanged);
            // 
            // groupBoxComps
            // 
            this.groupBoxComps.Controls.Add(this.btn_search);
            this.groupBoxComps.Controls.Add(this.label_search);
            this.groupBoxComps.Controls.Add(this.textBox_search);
            this.groupBoxComps.Controls.Add(this.btn_saveEdits);
            this.groupBoxComps.Controls.Add(this.btn_add_new);
            this.groupBoxComps.Controls.Add(this.btn_editSelected);
            this.groupBoxComps.Controls.Add(this.stockWorth);
            resources.ApplyResources(this.groupBoxComps, "groupBoxComps");
            this.groupBoxComps.Name = "groupBoxComps";
            this.groupBoxComps.TabStop = false;
            // 
            // btn_saveEdits
            // 
            this.btn_saveEdits.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btn_saveEdits, "btn_saveEdits");
            this.btn_saveEdits.Name = "btn_saveEdits";
            this.btn_saveEdits.UseVisualStyleBackColor = true;
            this.btn_saveEdits.Click += new System.EventHandler(this.btn_saveEdits_Click);
            // 
            // btn_editSelected
            // 
            resources.ApplyResources(this.btn_editSelected, "btn_editSelected");
            this.btn_editSelected.Name = "btn_editSelected";
            this.btn_editSelected.UseVisualStyleBackColor = true;
            this.btn_editSelected.Click += new System.EventHandler(this.btn_editSelected_Click);
            // 
            // stockWorth
            // 
            resources.ApplyResources(this.stockWorth, "stockWorth");
            this.stockWorth.Name = "stockWorth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.listViewDevComps);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // listViewDevComps
            // 
            resources.ApplyResources(this.listViewDevComps, "listViewDevComps");
            this.listViewDevComps.MultiSelect = false;
            this.listViewDevComps.Name = "listViewDevComps";
            this.listViewDevComps.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox_search
            // 
            resources.ApplyResources(this.textBox_search, "textBox_search");
            this.textBox_search.Name = "textBox_search";
            // 
            // label_search
            // 
            resources.ApplyResources(this.label_search, "label_search");
            this.label_search.Name = "label_search";
            // 
            // btn_search
            // 
            resources.ApplyResources(this.btn_search, "btn_search");
            this.btn_search.Name = "btn_search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_add_price);
            this.Controls.Add(this.textBox_add_pcs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_add_name);
            this.Controls.Add(this.btn_deleteSelected);
            this.Controls.Add(this.listViewComps2);
            this.Controls.Add(this.btn_listComps);
            this.Controls.Add(this.groupBoxComps);
            this.Controls.Add(this.listViewDevs);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxComps.ResumeLayout(false);
            this.groupBoxComps.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_listComps;
        private System.Windows.Forms.ListView listViewComps2;
        private System.Windows.Forms.Button btn_deleteSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_add_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_add_pcs;
        private System.Windows.Forms.TextBox textBox_add_price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_add_new;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewDevs;
        private System.Windows.Forms.GroupBox groupBoxComps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label stockWorth;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_editSelected;
        private System.Windows.Forms.Button btn_saveEdits;
        private System.Windows.Forms.ListView listViewDevComps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button btn_search;
    }
}

