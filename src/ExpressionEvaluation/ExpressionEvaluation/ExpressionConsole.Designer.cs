namespace ExpressionEvaluation {
    partial class ExpressionConsole {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpressionConsole));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.evaluatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useCStyleExpressionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useLispStyleExpressionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteExpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printExpressionInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyBox = new System.Windows.Forms.TextBox();
            this.expressionBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluatorToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // evaluatorToolStripMenuItem
            // 
            this.evaluatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useCStyleExpressionsToolStripMenuItem,
            this.useLispStyleExpressionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.evaluatorToolStripMenuItem.Name = "evaluatorToolStripMenuItem";
            this.evaluatorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.evaluatorToolStripMenuItem.Text = "Evaluator";
            // 
            // useCStyleExpressionsToolStripMenuItem
            // 
            this.useCStyleExpressionsToolStripMenuItem.Name = "useCStyleExpressionsToolStripMenuItem";
            this.useCStyleExpressionsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.useCStyleExpressionsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.useCStyleExpressionsToolStripMenuItem.Text = "Use \'C\' Style Expressions";
            this.useCStyleExpressionsToolStripMenuItem.Click += new System.EventHandler(this.useCStyleExpressionsToolStripMenuItem_Click);
            // 
            // useLispStyleExpressionsToolStripMenuItem
            // 
            this.useLispStyleExpressionsToolStripMenuItem.Name = "useLispStyleExpressionsToolStripMenuItem";
            this.useLispStyleExpressionsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.useLispStyleExpressionsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.useLispStyleExpressionsToolStripMenuItem.Text = "Use \'Lisp\' Style Expressions";
            this.useLispStyleExpressionsToolStripMenuItem.Click += new System.EventHandler(this.useLispStyleExpressionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyResultToolStripMenuItem,
            this.copyHistoryToolStripMenuItem,
            this.pasteExpressionToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearHistoryToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyResultToolStripMenuItem
            // 
            this.copyResultToolStripMenuItem.Name = "copyResultToolStripMenuItem";
            this.copyResultToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyResultToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.copyResultToolStripMenuItem.Text = "Copy Result";
            this.copyResultToolStripMenuItem.Click += new System.EventHandler(this.copyResultToolStripMenuItem_Click);
            // 
            // copyHistoryToolStripMenuItem
            // 
            this.copyHistoryToolStripMenuItem.Name = "copyHistoryToolStripMenuItem";
            this.copyHistoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.copyHistoryToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.copyHistoryToolStripMenuItem.Text = "Copy History";
            this.copyHistoryToolStripMenuItem.Click += new System.EventHandler(this.copyHistoryToolStripMenuItem_Click);
            // 
            // pasteExpressionToolStripMenuItem
            // 
            this.pasteExpressionToolStripMenuItem.Name = "pasteExpressionToolStripMenuItem";
            this.pasteExpressionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.pasteExpressionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.pasteExpressionToolStripMenuItem.Text = "Paste Expression";
            this.pasteExpressionToolStripMenuItem.Click += new System.EventHandler(this.pasteExpressionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printExpressionInformationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // printExpressionInformationToolStripMenuItem
            // 
            this.printExpressionInformationToolStripMenuItem.Name = "printExpressionInformationToolStripMenuItem";
            this.printExpressionInformationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.printExpressionInformationToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.printExpressionInformationToolStripMenuItem.Text = "Print Info.";
            this.printExpressionInformationToolStripMenuItem.Click += new System.EventHandler(this.printExpressionInformationToolStripMenuItem_Click);
            // 
            // historyBox
            // 
            this.historyBox.BackColor = System.Drawing.SystemColors.Window;
            this.historyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.historyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyBox.ForeColor = System.Drawing.Color.Black;
            this.historyBox.Location = new System.Drawing.Point(10, 0);
            this.historyBox.Margin = new System.Windows.Forms.Padding(10);
            this.historyBox.Multiline = true;
            this.historyBox.Name = "historyBox";
            this.historyBox.ReadOnly = true;
            this.historyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.historyBox.Size = new System.Drawing.Size(687, 394);
            this.historyBox.TabIndex = 2;
            this.historyBox.TabStop = false;
            // 
            // expressionBox
            // 
            this.expressionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionBox.BackColor = System.Drawing.SystemColors.Window;
            this.expressionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expressionBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionBox.ForeColor = System.Drawing.Color.Black;
            this.expressionBox.Location = new System.Drawing.Point(10, 0);
            this.expressionBox.Name = "expressionBox";
            this.expressionBox.Size = new System.Drawing.Size(667, 20);
            this.expressionBox.TabIndex = 1;
            this.expressionBox.Enter += new System.EventHandler(this.expressionBox_Enter);
            this.expressionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expressionBox_KeyDown);
            this.expressionBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.expressionBox_KeyUp);
            this.expressionBox.Leave += new System.EventHandler(this.expressionBox_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.historyBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.splitContainer1.Panel1MinSize = 22;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.expressionBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.splitContainer1.Panel2MinSize = 20;
            this.splitContainer1.Size = new System.Drawing.Size(697, 423);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // ExpressionConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(697, 447);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExpressionConsole";
            this.Text = "Expression Evaluator";
            this.Shown += new System.EventHandler(this.ExpressionConsole_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteExpressionToolStripMenuItem;
        private System.Windows.Forms.TextBox historyBox;
        private System.Windows.Forms.TextBox expressionBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printExpressionInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaluatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useCStyleExpressionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useLispStyleExpressionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
    }
}