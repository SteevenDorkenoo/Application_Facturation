
namespace Facturation
{
    partial class Acceuil
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitreLabel = new System.Windows.Forms.Label();
            this.Genererbutton = new System.Windows.Forms.Button();
            this.Historiquebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturation JB2S Consulting";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TitreLabel
            // 
            this.TitreLabel.AutoSize = true;
            this.TitreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreLabel.Location = new System.Drawing.Point(175, 65);
            this.TitreLabel.Name = "TitreLabel";
            this.TitreLabel.Size = new System.Drawing.Size(449, 39);
            this.TitreLabel.TabIndex = 0;
            this.TitreLabel.Text = "Facturation JB2S Consulting";
            // 
            // Genererbutton
            // 
            this.Genererbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genererbutton.Location = new System.Drawing.Point(104, 255);
            this.Genererbutton.Name = "Genererbutton";
            this.Genererbutton.Size = new System.Drawing.Size(181, 83);
            this.Genererbutton.TabIndex = 1;
            this.Genererbutton.Text = "Génerer une facture";
            this.Genererbutton.UseVisualStyleBackColor = true;
            this.Genererbutton.Click += new System.EventHandler(this.Genererbutton_Click);
            // 
            // Historiquebutton
            // 
            this.Historiquebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Historiquebutton.Location = new System.Drawing.Point(497, 255);
            this.Historiquebutton.Name = "Historiquebutton";
            this.Historiquebutton.Size = new System.Drawing.Size(181, 83);
            this.Historiquebutton.TabIndex = 2;
            this.Historiquebutton.Text = "Dossier Factures";
            this.Historiquebutton.UseVisualStyleBackColor = true;
            this.Historiquebutton.Click += new System.EventHandler(this.Historiquebutton_Click);
            // 
            // Acceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Historiquebutton);
            this.Controls.Add(this.Genererbutton);
            this.Controls.Add(this.TitreLabel);
            this.Controls.Add(this.label1);
            this.Name = "Acceuil";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitreLabel;
        private System.Windows.Forms.Button Genererbutton;
        private System.Windows.Forms.Button Historiquebutton;
    }
}

