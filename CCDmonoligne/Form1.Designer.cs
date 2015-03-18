namespace CCDmonoligne
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Bpose = new System.Windows.Forms.Button();
            this.Bquitter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Ttempspose = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.Treception = new System.Windows.Forms.TextBox();
            this.Hligne = new System.Windows.Forms.PictureBox();
            this.Hgraph = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mesure1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesure2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.résolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.légendesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bcharger = new System.Windows.Forms.Button();
            this.Bsauver = new System.Windows.Forms.Button();
            this.BcopierGraphique = new System.Windows.Forms.Button();
            this.BcopierImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.Bformat = new System.Windows.Forms.Button();
            this.Bnettete = new System.Windows.Forms.Button();
            this.Bstop = new System.Windows.Forms.Button();
            this.Bport = new System.Windows.Forms.Button();
            this.checkinverse = new System.Windows.Forms.CheckBox();
            this.checkgain = new System.Windows.Forms.CheckBox();
            this.labHeure = new System.Windows.Forms.Label();
            this.checkdeu = new System.Windows.Forms.CheckBox();
            this.checkRef = new System.Windows.Forms.CheckBox();
            this.Bcorrection = new System.Windows.Forms.Button();
            this.bpause16 = new System.Windows.Forms.Button();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labcom = new System.Windows.Forms.Label();
            this.lNiveaux = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tmax = new System.Windows.Forms.TextBox();
            this.tmult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvues = new System.Windows.Forms.Label();
            this.bsup = new System.Windows.Forms.Button();
            this.tMesure1 = new System.Windows.Forms.TextBox();
            this.tMesure2 = new System.Windows.Forms.TextBox();
            this.lpixA = new System.Windows.Forms.Label();
            this.lAng = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Hligne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hgraph)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bpose
            // 
            this.Bpose.Location = new System.Drawing.Point(17, 109);
            this.Bpose.Margin = new System.Windows.Forms.Padding(4);
            this.Bpose.Name = "Bpose";
            this.Bpose.Size = new System.Drawing.Size(100, 48);
            this.Bpose.TabIndex = 0;
            this.Bpose.Text = "Pose 12 bits";
            this.Bpose.UseVisualStyleBackColor = true;
            this.Bpose.Click += new System.EventHandler(this.Bpose_Click);
            // 
            // Bquitter
            // 
            this.Bquitter.Location = new System.Drawing.Point(802, 153);
            this.Bquitter.Margin = new System.Windows.Forms.Padding(4);
            this.Bquitter.Name = "Bquitter";
            this.Bquitter.Size = new System.Drawing.Size(100, 32);
            this.Bquitter.TabIndex = 1;
            this.Bquitter.Text = "Quitter";
            this.Bquitter.UseVisualStyleBackColor = true;
            this.Bquitter.Click += new System.EventHandler(this.Bquitter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Temps de pose (en ms)";
            // 
            // Ttempspose
            // 
            this.Ttempspose.Location = new System.Drawing.Point(19, 51);
            this.Ttempspose.Margin = new System.Windows.Forms.Padding(4);
            this.Ttempspose.Name = "Ttempspose";
            this.Ttempspose.Size = new System.Drawing.Size(52, 22);
            this.Ttempspose.TabIndex = 8;
            this.Ttempspose.Text = "0";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 307200;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.ReadBufferSize = 8200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(17, 57);
            this.comboPort.Margin = new System.Windows.Forms.Padding(4);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(104, 24);
            this.comboPort.TabIndex = 10;
            this.comboPort.SelectedIndexChanged += new System.EventHandler(this.comboPort_SelectedIndexChanged);
            // 
            // Treception
            // 
            this.Treception.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Treception.Location = new System.Drawing.Point(13, 762);
            this.Treception.Margin = new System.Windows.Forms.Padding(4);
            this.Treception.Multiline = true;
            this.Treception.Name = "Treception";
            this.Treception.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Treception.Size = new System.Drawing.Size(1126, 0);
            this.Treception.TabIndex = 13;
            this.Treception.Visible = false;
            // 
            // Hligne
            // 
            this.Hligne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hligne.BackColor = System.Drawing.Color.Black;
            this.Hligne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Hligne.Location = new System.Drawing.Point(17, 192);
            this.Hligne.Margin = new System.Windows.Forms.Padding(4);
            this.Hligne.Name = "Hligne";
            this.Hligne.Size = new System.Drawing.Size(1127, 27);
            this.Hligne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hligne.TabIndex = 15;
            this.Hligne.TabStop = false;
            // 
            // Hgraph
            // 
            this.Hgraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hgraph.BackColor = System.Drawing.Color.Black;
            this.Hgraph.ContextMenuStrip = this.contextMenuStrip1;
            this.Hgraph.Location = new System.Drawing.Point(19, 226);
            this.Hgraph.Margin = new System.Windows.Forms.Padding(4);
            this.Hgraph.Name = "Hgraph";
            this.Hgraph.Size = new System.Drawing.Size(1124, 550);
            this.Hgraph.TabIndex = 16;
            this.Hgraph.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.mesure1ToolStripMenuItem,
            this.mesure2ToolStripMenuItem,
            this.résolutionToolStripMenuItem,
            this.légendesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 130);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 24);
            this.toolStripMenuItem1.Text = "Valeur Ä";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mesure1ToolStripMenuItem
            // 
            this.mesure1ToolStripMenuItem.Name = "mesure1ToolStripMenuItem";
            this.mesure1ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.mesure1ToolStripMenuItem.Text = "Mesure 1";
            this.mesure1ToolStripMenuItem.Click += new System.EventHandler(this.mesure1ToolStripMenuItem_Click);
            // 
            // mesure2ToolStripMenuItem
            // 
            this.mesure2ToolStripMenuItem.Name = "mesure2ToolStripMenuItem";
            this.mesure2ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.mesure2ToolStripMenuItem.Text = "Mesure 2";
            this.mesure2ToolStripMenuItem.Click += new System.EventHandler(this.mesure2ToolStripMenuItem_Click);
            // 
            // résolutionToolStripMenuItem
            // 
            this.résolutionToolStripMenuItem.Name = "résolutionToolStripMenuItem";
            this.résolutionToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.résolutionToolStripMenuItem.Text = "Résolution";
            this.résolutionToolStripMenuItem.Click += new System.EventHandler(this.résolutionToolStripMenuItem_Click);
            // 
            // légendesToolStripMenuItem
            // 
            this.légendesToolStripMenuItem.Name = "légendesToolStripMenuItem";
            this.légendesToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.légendesToolStripMenuItem.Text = "Légendes";
            this.légendesToolStripMenuItem.Click += new System.EventHandler(this.légendesToolStripMenuItem_Click);
            // 
            // Bcharger
            // 
            this.Bcharger.Location = new System.Drawing.Point(12, 25);
            this.Bcharger.Margin = new System.Windows.Forms.Padding(4);
            this.Bcharger.Name = "Bcharger";
            this.Bcharger.Size = new System.Drawing.Size(100, 28);
            this.Bcharger.TabIndex = 17;
            this.Bcharger.Text = "Charger";
            this.Bcharger.UseVisualStyleBackColor = true;
            this.Bcharger.Click += new System.EventHandler(this.Bcharger_Click);
            // 
            // Bsauver
            // 
            this.Bsauver.Location = new System.Drawing.Point(12, 61);
            this.Bsauver.Margin = new System.Windows.Forms.Padding(4);
            this.Bsauver.Name = "Bsauver";
            this.Bsauver.Size = new System.Drawing.Size(100, 28);
            this.Bsauver.TabIndex = 18;
            this.Bsauver.Text = "Sauver";
            this.Bsauver.UseVisualStyleBackColor = true;
            this.Bsauver.Click += new System.EventHandler(this.Bsauver_Click);
            // 
            // BcopierGraphique
            // 
            this.BcopierGraphique.Location = new System.Drawing.Point(652, 15);
            this.BcopierGraphique.Margin = new System.Windows.Forms.Padding(4);
            this.BcopierGraphique.Name = "BcopierGraphique";
            this.BcopierGraphique.Size = new System.Drawing.Size(126, 28);
            this.BcopierGraphique.TabIndex = 19;
            this.BcopierGraphique.Text = "Copier graphique";
            this.BcopierGraphique.UseVisualStyleBackColor = true;
            this.BcopierGraphique.Click += new System.EventHandler(this.BcopierGraphique_Click);
            // 
            // BcopierImage
            // 
            this.BcopierImage.Location = new System.Drawing.Point(652, 51);
            this.BcopierImage.Margin = new System.Windows.Forms.Padding(4);
            this.BcopierImage.Name = "BcopierImage";
            this.BcopierImage.Size = new System.Drawing.Size(126, 28);
            this.BcopierImage.TabIndex = 20;
            this.BcopierImage.Text = "Copier image";
            this.BcopierImage.UseVisualStyleBackColor = true;
            this.BcopierImage.Click += new System.EventHandler(this.BcopierImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(19, 780);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1126, 16);
            this.hScrollBar1.TabIndex = 22;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HandleScroll);
            // 
            // Bformat
            // 
            this.Bformat.Location = new System.Drawing.Point(20, 134);
            this.Bformat.Margin = new System.Windows.Forms.Padding(4);
            this.Bformat.Name = "Bformat";
            this.Bformat.Size = new System.Drawing.Size(144, 28);
            this.Bformat.TabIndex = 23;
            this.Bformat.Text = "Plein format";
            this.Bformat.UseVisualStyleBackColor = true;
            this.Bformat.Click += new System.EventHandler(this.Bformat_Click);
            // 
            // Bnettete
            // 
            this.Bnettete.Location = new System.Drawing.Point(232, 109);
            this.Bnettete.Margin = new System.Windows.Forms.Padding(4);
            this.Bnettete.Name = "Bnettete";
            this.Bnettete.Size = new System.Drawing.Size(99, 48);
            this.Bnettete.TabIndex = 24;
            this.Bnettete.Text = "Netteté";
            this.Bnettete.UseVisualStyleBackColor = true;
            this.Bnettete.Click += new System.EventHandler(this.Bnettete_Click);
            // 
            // Bstop
            // 
            this.Bstop.Location = new System.Drawing.Point(337, 109);
            this.Bstop.Margin = new System.Windows.Forms.Padding(4);
            this.Bstop.Name = "Bstop";
            this.Bstop.Size = new System.Drawing.Size(99, 48);
            this.Bstop.TabIndex = 25;
            this.Bstop.Text = "Stop";
            this.Bstop.UseVisualStyleBackColor = true;
            this.Bstop.Click += new System.EventHandler(this.Bstop_Click);
            // 
            // Bport
            // 
            this.Bport.Location = new System.Drawing.Point(17, 22);
            this.Bport.Margin = new System.Windows.Forms.Padding(4);
            this.Bport.Name = "Bport";
            this.Bport.Size = new System.Drawing.Size(104, 27);
            this.Bport.TabIndex = 26;
            this.Bport.Text = "Détection";
            this.Bport.UseVisualStyleBackColor = true;
            this.Bport.Click += new System.EventHandler(this.Bport_Click);
            // 
            // checkinverse
            // 
            this.checkinverse.AutoSize = true;
            this.checkinverse.Location = new System.Drawing.Point(23, 30);
            this.checkinverse.Margin = new System.Windows.Forms.Padding(4);
            this.checkinverse.Name = "checkinverse";
            this.checkinverse.Size = new System.Drawing.Size(131, 21);
            this.checkinverse.TabIndex = 27;
            this.checkinverse.Text = "Miroir horizontal";
            this.checkinverse.UseVisualStyleBackColor = true;
            this.checkinverse.CheckedChanged += new System.EventHandler(this.checkinverse_CheckedChanged);
            // 
            // checkgain
            // 
            this.checkgain.AutoSize = true;
            this.checkgain.BackColor = System.Drawing.Color.LightGray;
            this.checkgain.Location = new System.Drawing.Point(23, 55);
            this.checkgain.Margin = new System.Windows.Forms.Padding(4);
            this.checkgain.Name = "checkgain";
            this.checkgain.Size = new System.Drawing.Size(130, 21);
            this.checkgain.TabIndex = 28;
            this.checkgain.Text = "Dynamique max";
            this.checkgain.UseVisualStyleBackColor = false;
            this.checkgain.CheckedChanged += new System.EventHandler(this.checkgain_CheckedChanged);
            // 
            // labHeure
            // 
            this.labHeure.AutoSize = true;
            this.labHeure.Location = new System.Drawing.Point(16, 164);
            this.labHeure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labHeure.Name = "labHeure";
            this.labHeure.Size = new System.Drawing.Size(79, 17);
            this.labHeure.TabIndex = 29;
            this.labHeure.Text = "Date heure";
            // 
            // checkdeu
            // 
            this.checkdeu.AutoSize = true;
            this.checkdeu.Location = new System.Drawing.Point(23, 80);
            this.checkdeu.Margin = new System.Windows.Forms.Padding(4);
            this.checkdeu.Name = "checkdeu";
            this.checkdeu.Size = new System.Drawing.Size(151, 21);
            this.checkdeu.TabIndex = 30;
            this.checkdeu.Text = "Graphique + image";
            this.checkdeu.UseVisualStyleBackColor = true;
            this.checkdeu.CheckedChanged += new System.EventHandler(this.checkdeu_CheckedChanged);
            // 
            // checkRef
            // 
            this.checkRef.AutoSize = true;
            this.checkRef.Location = new System.Drawing.Point(23, 105);
            this.checkRef.Margin = new System.Windows.Forms.Padding(4);
            this.checkRef.Name = "checkRef";
            this.checkRef.Size = new System.Drawing.Size(96, 21);
            this.checkRef.TabIndex = 32;
            this.checkRef.Text = "Référence";
            this.checkRef.UseVisualStyleBackColor = true;
            this.checkRef.CheckedChanged += new System.EventHandler(this.checkRef_CheckedChanged);
            // 
            // Bcorrection
            // 
            this.Bcorrection.Location = new System.Drawing.Point(935, 147);
            this.Bcorrection.Margin = new System.Windows.Forms.Padding(4);
            this.Bcorrection.Name = "Bcorrection";
            this.Bcorrection.Size = new System.Drawing.Size(100, 28);
            this.Bcorrection.TabIndex = 34;
            this.Bcorrection.Text = "Correction";
            this.Bcorrection.UseVisualStyleBackColor = true;
            this.Bcorrection.Visible = false;
            this.Bcorrection.Click += new System.EventHandler(this.Bcorrection_Click);
            // 
            // bpause16
            // 
            this.bpause16.Location = new System.Drawing.Point(125, 109);
            this.bpause16.Margin = new System.Windows.Forms.Padding(4);
            this.bpause16.Name = "bpause16";
            this.bpause16.Size = new System.Drawing.Size(100, 48);
            this.bpause16.TabIndex = 35;
            this.bpause16.Text = "Pose 16 bits";
            this.bpause16.UseVisualStyleBackColor = true;
            this.bpause16.Click += new System.EventHandler(this.bpause16_Click);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(80, 53);
            this.hScrollBar2.Maximum = 2000;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(307, 17);
            this.hScrollBar2.TabIndex = 36;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.checkgain);
            this.groupBox1.Controls.Add(this.Bformat);
            this.groupBox1.Controls.Add(this.checkinverse);
            this.groupBox1.Controls.Add(this.checkdeu);
            this.groupBox1.Controls.Add(this.checkRef);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(461, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(179, 175);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affichage";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.Bcharger);
            this.groupBox2.Controls.Add(this.Bsauver);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(790, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(127, 101);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fichiers";
            // 
            // labcom
            // 
            this.labcom.AutoSize = true;
            this.labcom.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labcom.Location = new System.Drawing.Point(320, 15);
            this.labcom.Name = "labcom";
            this.labcom.Size = new System.Drawing.Size(116, 17);
            this.labcom.TabIndex = 39;
            this.labcom.Text = "Caméra détectée";
            this.labcom.Visible = false;
            // 
            // lNiveaux
            // 
            this.lNiveaux.AutoSize = true;
            this.lNiveaux.Location = new System.Drawing.Point(217, 164);
            this.lNiveaux.Name = "lNiveaux";
            this.lNiveaux.Size = new System.Drawing.Size(70, 17);
            this.lNiveaux.TabIndex = 42;
            this.lNiveaux.Text = "Niveaux : ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.Bport);
            this.groupBox3.Controls.Add(this.comboPort);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(647, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 91);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ports";
            // 
            // tmax
            // 
            this.tmax.Location = new System.Drawing.Point(395, 51);
            this.tmax.Margin = new System.Windows.Forms.Padding(4);
            this.tmax.Name = "tmax";
            this.tmax.Size = new System.Drawing.Size(41, 22);
            this.tmax.TabIndex = 44;
            this.tmax.Text = "2000";
            // 
            // tmult
            // 
            this.tmult.Location = new System.Drawing.Point(96, 79);
            this.tmult.Margin = new System.Windows.Forms.Padding(4);
            this.tmult.Name = "tmult";
            this.tmult.Size = new System.Drawing.Size(51, 22);
            this.tmult.TabIndex = 45;
            this.tmult.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Séquence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "vues";
            // 
            // lvues
            // 
            this.lvues.AutoSize = true;
            this.lvues.Location = new System.Drawing.Point(241, 82);
            this.lvues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lvues.Name = "lvues";
            this.lvues.Size = new System.Drawing.Size(116, 17);
            this.lvues.TabIndex = 48;
            this.lvues.Text = "vues en mémoire";
            this.lvues.Visible = false;
            // 
            // bsup
            // 
            this.bsup.Location = new System.Drawing.Point(395, 77);
            this.bsup.Margin = new System.Windows.Forms.Padding(4);
            this.bsup.Name = "bsup";
            this.bsup.Size = new System.Drawing.Size(42, 26);
            this.bsup.TabIndex = 49;
            this.bsup.Text = "Supp";
            this.bsup.UseVisualStyleBackColor = true;
            this.bsup.Click += new System.EventHandler(this.bsup_Click);
            // 
            // tMesure1
            // 
            this.tMesure1.Location = new System.Drawing.Point(935, 13);
            this.tMesure1.Name = "tMesure1";
            this.tMesure1.Size = new System.Drawing.Size(100, 22);
            this.tMesure1.TabIndex = 51;
            this.tMesure1.Visible = false;
            // 
            // tMesure2
            // 
            this.tMesure2.Location = new System.Drawing.Point(935, 47);
            this.tMesure2.Name = "tMesure2";
            this.tMesure2.Size = new System.Drawing.Size(100, 22);
            this.tMesure2.TabIndex = 52;
            this.tMesure2.Visible = false;
            // 
            // lpixA
            // 
            this.lpixA.AutoSize = true;
            this.lpixA.Location = new System.Drawing.Point(804, 114);
            this.lpixA.Name = "lpixA";
            this.lpixA.Size = new System.Drawing.Size(68, 17);
            this.lpixA.TabIndex = 53;
            this.lpixA.Text = "par pixels";
            this.lpixA.Visible = false;
            // 
            // lAng
            // 
            this.lAng.AutoSize = true;
            this.lAng.Location = new System.Drawing.Point(820, 133);
            this.lAng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAng.Name = "lAng";
            this.lAng.Size = new System.Drawing.Size(38, 17);
            this.lAng.TabIndex = 54;
            this.lAng.Text = "vues";
            this.lAng.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1161, 805);
            this.Controls.Add(this.lAng);
            this.Controls.Add(this.lpixA);
            this.Controls.Add(this.tMesure2);
            this.Controls.Add(this.tMesure1);
            this.Controls.Add(this.bsup);
            this.Controls.Add(this.lvues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tmult);
            this.Controls.Add(this.tmax);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lNiveaux);
            this.Controls.Add(this.labcom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.bpause16);
            this.Controls.Add(this.Bcorrection);
            this.Controls.Add(this.labHeure);
            this.Controls.Add(this.Bstop);
            this.Controls.Add(this.Bnettete);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.BcopierImage);
            this.Controls.Add(this.BcopierGraphique);
            this.Controls.Add(this.Hgraph);
            this.Controls.Add(this.Hligne);
            this.Controls.Add(this.Treception);
            this.Controls.Add(this.Ttempspose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Bquitter);
            this.Controls.Add(this.Bpose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(966, 591);
            this.Name = "Form1";
            this.Text = "TivaUno 1.0 (freeware)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.Hligne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hgraph)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bpose;
        private System.Windows.Forms.Button Bquitter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ttempspose;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.TextBox Treception;
        private System.Windows.Forms.PictureBox Hligne;
        private System.Windows.Forms.Button Bcharger;
        private System.Windows.Forms.Button Bsauver;
        private System.Windows.Forms.Button BcopierGraphique;
        private System.Windows.Forms.Button BcopierImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button Bformat;
        private System.Windows.Forms.PictureBox Hgraph;
        private System.Windows.Forms.Button Bnettete;
        private System.Windows.Forms.Button Bstop;
        private System.Windows.Forms.Button Bport;
        private System.Windows.Forms.CheckBox checkinverse;
        private System.Windows.Forms.CheckBox checkgain;
        private System.Windows.Forms.Label labHeure;
        private System.Windows.Forms.CheckBox checkdeu;
        private System.Windows.Forms.CheckBox checkRef;
        private System.Windows.Forms.Button Bcorrection;
        private System.Windows.Forms.Button bpause16;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labcom;
        private System.Windows.Forms.Label lNiveaux;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tmax;
        private System.Windows.Forms.TextBox tmult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lvues;
        private System.Windows.Forms.Button bsup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mesure1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesure2ToolStripMenuItem;
        private System.Windows.Forms.TextBox tMesure1;
        private System.Windows.Forms.TextBox tMesure2;
        private System.Windows.Forms.Label lpixA;
        private System.Windows.Forms.ToolStripMenuItem résolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem légendesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lAng;
    }
}

