
namespace BatalhaNaval_Forms {
    partial class PartidaForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartidaForm));
            this.lbl_Result = new System.Windows.Forms.Label();
            this.gB_OponnentShips = new System.Windows.Forms.GroupBox();
            this.gB_YourShips = new System.Windows.Forms.GroupBox();
            this.lbl_Turn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.Location = new System.Drawing.Point(167, 66);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(58, 13);
            this.lbl_Result.TabIndex = 2;
            this.lbl_Result.Text = "Resultado:";
            // 
            // gB_OponnentShips
            // 
            this.gB_OponnentShips.BackColor = System.Drawing.Color.Transparent;
            this.gB_OponnentShips.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gB_OponnentShips.BackgroundImage")));
            this.gB_OponnentShips.Location = new System.Drawing.Point(12, 89);
            this.gB_OponnentShips.Name = "gB_OponnentShips";
            this.gB_OponnentShips.Size = new System.Drawing.Size(592, 558);
            this.gB_OponnentShips.TabIndex = 4;
            this.gB_OponnentShips.TabStop = false;
            // 
            // gB_YourShips
            // 
            this.gB_YourShips.BackColor = System.Drawing.Color.Transparent;
            this.gB_YourShips.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gB_YourShips.BackgroundImage")));
            this.gB_YourShips.Location = new System.Drawing.Point(624, 89);
            this.gB_YourShips.Name = "gB_YourShips";
            this.gB_YourShips.Size = new System.Drawing.Size(592, 558);
            this.gB_YourShips.TabIndex = 5;
            this.gB_YourShips.TabStop = false;
            // 
            // lbl_Turn
            // 
            this.lbl_Turn.AutoSize = true;
            this.lbl_Turn.Location = new System.Drawing.Point(167, 25);
            this.lbl_Turn.Name = "lbl_Turn";
            this.lbl_Turn.Size = new System.Drawing.Size(198, 13);
            this.lbl_Turn.TabIndex = 6;
            this.lbl_Turn.Text = "Espere a jogada do jogador adversário...";
            // 
            // PartidaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 659);
            this.Controls.Add(this.lbl_Turn);
            this.Controls.Add(this.gB_YourShips);
            this.Controls.Add(this.gB_OponnentShips);
            this.Controls.Add(this.lbl_Result);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 698);
            this.Name = "PartidaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartidaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.GroupBox gB_OponnentShips;
        private System.Windows.Forms.GroupBox gB_YourShips;
        private System.Windows.Forms.Label lbl_Turn;
    }
}