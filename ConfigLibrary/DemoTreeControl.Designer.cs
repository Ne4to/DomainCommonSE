namespace DomainCommonSE.ConfigLibrary
{
	partial class DemoTreeControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node6");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node7");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node8");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node9");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.treeView1.Location = new System.Drawing.Point(0, 28);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Node1";
			treeNode1.Text = "Node1";
			treeNode2.Name = "Node2";
			treeNode2.Text = "Node2";
			treeNode3.Name = "Node3";
			treeNode3.Text = "Node3";
			treeNode4.Name = "Node4";
			treeNode4.Text = "Node4";
			treeNode5.Name = "Node0";
			treeNode5.Text = "Node0";
			treeNode6.Name = "Node6";
			treeNode6.Text = "Node6";
			treeNode7.Name = "Node7";
			treeNode7.Text = "Node7";
			treeNode8.Name = "Node8";
			treeNode8.Text = "Node8";
			treeNode9.Name = "Node9";
			treeNode9.Text = "Node9";
			treeNode10.Name = "Node5";
			treeNode10.Text = "Node5";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10});
			this.treeView1.ShowLines = false;
			this.treeView1.Size = new System.Drawing.Size(282, 554);
			this.treeView1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(282, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// DemoTreeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.treeView1);
			this.Name = "DemoTreeControl";
			this.Size = new System.Drawing.Size(282, 582);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
