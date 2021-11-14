
namespace Lab_5
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Employee = new System.Windows.Forms.TabPage();
            this.button_DeleteEmployee = new System.Windows.Forms.Button();
            this.button_ModifyEmployee = new System.Windows.Forms.Button();
            this.button_AddEmployee = new System.Windows.Forms.Button();
            this.textBox_FName = new System.Windows.Forms.TextBox();
            this.textBox_LName = new System.Windows.Forms.TextBox();
            this.textBox_GenderEmployee = new System.Windows.Forms.TextBox();
            this.textBox_NInit = new System.Windows.Forms.TextBox();
            this.textBox_BirthDate = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Salary = new System.Windows.Forms.TextBox();
            this.textBox_Ssn = new System.Windows.Forms.TextBox();
            this.label_GenderEmployee = new System.Windows.Forms.Label();
            this.label_Salary = new System.Windows.Forms.Label();
            this.label_BirthDateEmployee = new System.Windows.Forms.Label();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_LName = new System.Windows.Forms.Label();
            this.label_MInit = new System.Windows.Forms.Label();
            this.label_FName = new System.Windows.Forms.Label();
            this.label_Ssn = new System.Windows.Forms.Label();
            this.dataGridView_Employee = new System.Windows.Forms.DataGridView();
            this.tabPage_Dependent = new System.Windows.Forms.TabPage();
            this.label_DependentOf = new System.Windows.Forms.Label();
            this.button_DeleteDependent = new System.Windows.Forms.Button();
            this.button_ModifyDependent = new System.Windows.Forms.Button();
            this.button_AddDependent = new System.Windows.Forms.Button();
            this.textBox_Relationship = new System.Windows.Forms.TextBox();
            this.textBox_BirthDateDependent = new System.Windows.Forms.TextBox();
            this.textBox_GenderDepenednt = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Relationship = new System.Windows.Forms.Label();
            this.label_BirthDateDependent = new System.Windows.Forms.Label();
            this.label_GenderDependent = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.dataGridView_Dependent = new System.Windows.Forms.DataGridView();
            this.name_Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender_Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdate_Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationship_Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependentof_Denpedent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_Project = new System.Windows.Forms.TabPage();
            this.button_DeleteProject = new System.Windows.Forms.Button();
            this.button_ModifyProject = new System.Windows.Forms.Button();
            this.button_AddProject = new System.Windows.Forms.Button();
            this.textBox_LocationProject = new System.Windows.Forms.TextBox();
            this.textBox_PNameProject = new System.Windows.Forms.TextBox();
            this.textBox_PNumberProject = new System.Windows.Forms.TextBox();
            this.label_Location = new System.Windows.Forms.Label();
            this.label_PName = new System.Windows.Forms.Label();
            this.label_PNumber = new System.Windows.Forms.Label();
            this.dataGridView_Project = new System.Windows.Forms.DataGridView();
            this.textBox_DependentOf = new System.Windows.Forms.TextBox();
            this.number_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlledby_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workson_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage_Employee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).BeginInit();
            this.tabPage_Dependent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Dependent)).BeginInit();
            this.tabPage_Project.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Project)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Employee);
            this.tabControl1.Controls.Add(this.tabPage_Dependent);
            this.tabControl1.Controls.Add(this.tabPage_Project);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Employee
            // 
            this.tabPage_Employee.Controls.Add(this.button_DeleteEmployee);
            this.tabPage_Employee.Controls.Add(this.button_ModifyEmployee);
            this.tabPage_Employee.Controls.Add(this.button_AddEmployee);
            this.tabPage_Employee.Controls.Add(this.textBox_FName);
            this.tabPage_Employee.Controls.Add(this.textBox_LName);
            this.tabPage_Employee.Controls.Add(this.textBox_GenderEmployee);
            this.tabPage_Employee.Controls.Add(this.textBox_NInit);
            this.tabPage_Employee.Controls.Add(this.textBox_BirthDate);
            this.tabPage_Employee.Controls.Add(this.textBox_Address);
            this.tabPage_Employee.Controls.Add(this.textBox_Salary);
            this.tabPage_Employee.Controls.Add(this.textBox_Ssn);
            this.tabPage_Employee.Controls.Add(this.label_GenderEmployee);
            this.tabPage_Employee.Controls.Add(this.label_Salary);
            this.tabPage_Employee.Controls.Add(this.label_BirthDateEmployee);
            this.tabPage_Employee.Controls.Add(this.label_Address);
            this.tabPage_Employee.Controls.Add(this.label_LName);
            this.tabPage_Employee.Controls.Add(this.label_MInit);
            this.tabPage_Employee.Controls.Add(this.label_FName);
            this.tabPage_Employee.Controls.Add(this.label_Ssn);
            this.tabPage_Employee.Controls.Add(this.dataGridView_Employee);
            this.tabPage_Employee.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Employee.Name = "tabPage_Employee";
            this.tabPage_Employee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Employee.Size = new System.Drawing.Size(796, 534);
            this.tabPage_Employee.TabIndex = 0;
            this.tabPage_Employee.Text = "Employee";
            this.tabPage_Employee.UseVisualStyleBackColor = true;
            // 
            // button_DeleteEmployee
            // 
            this.button_DeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteEmployee.Location = new System.Drawing.Point(6, 454);
            this.button_DeleteEmployee.Name = "button_DeleteEmployee";
            this.button_DeleteEmployee.Size = new System.Drawing.Size(183, 32);
            this.button_DeleteEmployee.TabIndex = 19;
            this.button_DeleteEmployee.Text = "Delete Employee";
            this.button_DeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // button_ModifyEmployee
            // 
            this.button_ModifyEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ModifyEmployee.Location = new System.Drawing.Point(6, 416);
            this.button_ModifyEmployee.Name = "button_ModifyEmployee";
            this.button_ModifyEmployee.Size = new System.Drawing.Size(183, 32);
            this.button_ModifyEmployee.TabIndex = 18;
            this.button_ModifyEmployee.Text = "Modify Employee";
            this.button_ModifyEmployee.UseVisualStyleBackColor = true;
            // 
            // button_AddEmployee
            // 
            this.button_AddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddEmployee.Location = new System.Drawing.Point(6, 378);
            this.button_AddEmployee.Name = "button_AddEmployee";
            this.button_AddEmployee.Size = new System.Drawing.Size(183, 32);
            this.button_AddEmployee.TabIndex = 17;
            this.button_AddEmployee.Text = "Add Employee";
            this.button_AddEmployee.UseVisualStyleBackColor = true;
            // 
            // textBox_FName
            // 
            this.textBox_FName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FName.Location = new System.Drawing.Point(6, 64);
            this.textBox_FName.Name = "textBox_FName";
            this.textBox_FName.Size = new System.Drawing.Size(212, 26);
            this.textBox_FName.TabIndex = 16;
            // 
            // textBox_LName
            // 
            this.textBox_LName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LName.Location = new System.Drawing.Point(6, 109);
            this.textBox_LName.Name = "textBox_LName";
            this.textBox_LName.Size = new System.Drawing.Size(212, 26);
            this.textBox_LName.TabIndex = 15;
            // 
            // textBox_GenderEmployee
            // 
            this.textBox_GenderEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_GenderEmployee.Location = new System.Drawing.Point(6, 154);
            this.textBox_GenderEmployee.Name = "textBox_GenderEmployee";
            this.textBox_GenderEmployee.Size = new System.Drawing.Size(108, 26);
            this.textBox_GenderEmployee.TabIndex = 14;
            // 
            // textBox_NInit
            // 
            this.textBox_NInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NInit.Location = new System.Drawing.Point(6, 199);
            this.textBox_NInit.Name = "textBox_NInit";
            this.textBox_NInit.Size = new System.Drawing.Size(230, 26);
            this.textBox_NInit.TabIndex = 13;
            // 
            // textBox_BirthDate
            // 
            this.textBox_BirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BirthDate.Location = new System.Drawing.Point(6, 244);
            this.textBox_BirthDate.Name = "textBox_BirthDate";
            this.textBox_BirthDate.Size = new System.Drawing.Size(230, 26);
            this.textBox_BirthDate.TabIndex = 12;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Address.Location = new System.Drawing.Point(6, 289);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(280, 26);
            this.textBox_Address.TabIndex = 11;
            // 
            // textBox_Salary
            // 
            this.textBox_Salary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Salary.Location = new System.Drawing.Point(6, 334);
            this.textBox_Salary.Name = "textBox_Salary";
            this.textBox_Salary.Size = new System.Drawing.Size(161, 26);
            this.textBox_Salary.TabIndex = 10;
            // 
            // textBox_Ssn
            // 
            this.textBox_Ssn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ssn.Location = new System.Drawing.Point(6, 19);
            this.textBox_Ssn.Name = "textBox_Ssn";
            this.textBox_Ssn.Size = new System.Drawing.Size(147, 26);
            this.textBox_Ssn.TabIndex = 9;
            // 
            // label_GenderEmployee
            // 
            this.label_GenderEmployee.AutoSize = true;
            this.label_GenderEmployee.Location = new System.Drawing.Point(8, 138);
            this.label_GenderEmployee.Name = "label_GenderEmployee";
            this.label_GenderEmployee.Size = new System.Drawing.Size(42, 13);
            this.label_GenderEmployee.TabIndex = 8;
            this.label_GenderEmployee.Text = "Gender";
            // 
            // label_Salary
            // 
            this.label_Salary.AutoSize = true;
            this.label_Salary.Location = new System.Drawing.Point(8, 318);
            this.label_Salary.Name = "label_Salary";
            this.label_Salary.Size = new System.Drawing.Size(36, 13);
            this.label_Salary.TabIndex = 7;
            this.label_Salary.Text = "Salary";
            // 
            // label_BirthDateEmployee
            // 
            this.label_BirthDateEmployee.AutoSize = true;
            this.label_BirthDateEmployee.Location = new System.Drawing.Point(6, 228);
            this.label_BirthDateEmployee.Name = "label_BirthDateEmployee";
            this.label_BirthDateEmployee.Size = new System.Drawing.Size(51, 13);
            this.label_BirthDateEmployee.TabIndex = 6;
            this.label_BirthDateEmployee.Text = "BirthDate";
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(8, 273);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(45, 13);
            this.label_Address.TabIndex = 5;
            this.label_Address.Text = "Address";
            // 
            // label_LName
            // 
            this.label_LName.AutoSize = true;
            this.label_LName.Location = new System.Drawing.Point(6, 93);
            this.label_LName.Name = "label_LName";
            this.label_LName.Size = new System.Drawing.Size(56, 13);
            this.label_LName.TabIndex = 4;
            this.label_LName.Text = "Last name";
            // 
            // label_MInit
            // 
            this.label_MInit.AutoSize = true;
            this.label_MInit.Location = new System.Drawing.Point(8, 183);
            this.label_MInit.Name = "label_MInit";
            this.label_MInit.Size = new System.Drawing.Size(30, 13);
            this.label_MInit.TabIndex = 3;
            this.label_MInit.Text = "MInit";
            // 
            // label_FName
            // 
            this.label_FName.AutoSize = true;
            this.label_FName.Location = new System.Drawing.Point(8, 48);
            this.label_FName.Name = "label_FName";
            this.label_FName.Size = new System.Drawing.Size(55, 13);
            this.label_FName.TabIndex = 2;
            this.label_FName.Text = "First name";
            // 
            // label_Ssn
            // 
            this.label_Ssn.AutoSize = true;
            this.label_Ssn.Location = new System.Drawing.Point(8, 3);
            this.label_Ssn.Name = "label_Ssn";
            this.label_Ssn.Size = new System.Drawing.Size(25, 13);
            this.label_Ssn.TabIndex = 1;
            this.label_Ssn.Text = "Ssn";
            // 
            // dataGridView_Employee
            // 
            this.dataGridView_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employee.Location = new System.Drawing.Point(289, 0);
            this.dataGridView_Employee.Name = "dataGridView_Employee";
            this.dataGridView_Employee.Size = new System.Drawing.Size(507, 534);
            this.dataGridView_Employee.TabIndex = 0;
            // 
            // tabPage_Dependent
            // 
            this.tabPage_Dependent.Controls.Add(this.textBox_DependentOf);
            this.tabPage_Dependent.Controls.Add(this.label_DependentOf);
            this.tabPage_Dependent.Controls.Add(this.button_DeleteDependent);
            this.tabPage_Dependent.Controls.Add(this.button_ModifyDependent);
            this.tabPage_Dependent.Controls.Add(this.button_AddDependent);
            this.tabPage_Dependent.Controls.Add(this.textBox_Relationship);
            this.tabPage_Dependent.Controls.Add(this.textBox_BirthDateDependent);
            this.tabPage_Dependent.Controls.Add(this.textBox_GenderDepenednt);
            this.tabPage_Dependent.Controls.Add(this.textBox_Name);
            this.tabPage_Dependent.Controls.Add(this.label_Relationship);
            this.tabPage_Dependent.Controls.Add(this.label_BirthDateDependent);
            this.tabPage_Dependent.Controls.Add(this.label_GenderDependent);
            this.tabPage_Dependent.Controls.Add(this.label_Name);
            this.tabPage_Dependent.Controls.Add(this.dataGridView_Dependent);
            this.tabPage_Dependent.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Dependent.Name = "tabPage_Dependent";
            this.tabPage_Dependent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Dependent.Size = new System.Drawing.Size(796, 534);
            this.tabPage_Dependent.TabIndex = 1;
            this.tabPage_Dependent.Text = "Dependent";
            this.tabPage_Dependent.UseVisualStyleBackColor = true;
            // 
            // label_DependentOf
            // 
            this.label_DependentOf.AutoSize = true;
            this.label_DependentOf.Location = new System.Drawing.Point(8, 183);
            this.label_DependentOf.Name = "label_DependentOf";
            this.label_DependentOf.Size = new System.Drawing.Size(71, 13);
            this.label_DependentOf.TabIndex = 12;
            this.label_DependentOf.Text = "DependentOf";
            // 
            // button_DeleteDependent
            // 
            this.button_DeleteDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteDependent.Location = new System.Drawing.Point(8, 318);
            this.button_DeleteDependent.Name = "button_DeleteDependent";
            this.button_DeleteDependent.Size = new System.Drawing.Size(194, 32);
            this.button_DeleteDependent.TabIndex = 11;
            this.button_DeleteDependent.Text = "Delete Dependent";
            this.button_DeleteDependent.UseVisualStyleBackColor = true;
            // 
            // button_ModifyDependent
            // 
            this.button_ModifyDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ModifyDependent.Location = new System.Drawing.Point(8, 280);
            this.button_ModifyDependent.Name = "button_ModifyDependent";
            this.button_ModifyDependent.Size = new System.Drawing.Size(194, 32);
            this.button_ModifyDependent.TabIndex = 10;
            this.button_ModifyDependent.Text = "Modify Dependent";
            this.button_ModifyDependent.UseVisualStyleBackColor = true;
            // 
            // button_AddDependent
            // 
            this.button_AddDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddDependent.Location = new System.Drawing.Point(8, 242);
            this.button_AddDependent.Name = "button_AddDependent";
            this.button_AddDependent.Size = new System.Drawing.Size(194, 32);
            this.button_AddDependent.TabIndex = 9;
            this.button_AddDependent.Text = "Add Dependent";
            this.button_AddDependent.UseVisualStyleBackColor = true;
            // 
            // textBox_Relationship
            // 
            this.textBox_Relationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Relationship.Location = new System.Drawing.Point(8, 154);
            this.textBox_Relationship.Name = "textBox_Relationship";
            this.textBox_Relationship.Size = new System.Drawing.Size(221, 26);
            this.textBox_Relationship.TabIndex = 8;
            // 
            // textBox_BirthDateDependent
            // 
            this.textBox_BirthDateDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BirthDateDependent.Location = new System.Drawing.Point(8, 109);
            this.textBox_BirthDateDependent.Name = "textBox_BirthDateDependent";
            this.textBox_BirthDateDependent.Size = new System.Drawing.Size(221, 26);
            this.textBox_BirthDateDependent.TabIndex = 7;
            // 
            // textBox_GenderDepenednt
            // 
            this.textBox_GenderDepenednt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_GenderDepenednt.Location = new System.Drawing.Point(8, 64);
            this.textBox_GenderDepenednt.Name = "textBox_GenderDepenednt";
            this.textBox_GenderDepenednt.Size = new System.Drawing.Size(123, 26);
            this.textBox_GenderDepenednt.TabIndex = 6;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name.Location = new System.Drawing.Point(8, 19);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(221, 26);
            this.textBox_Name.TabIndex = 5;
            // 
            // label_Relationship
            // 
            this.label_Relationship.AutoSize = true;
            this.label_Relationship.Location = new System.Drawing.Point(8, 138);
            this.label_Relationship.Name = "label_Relationship";
            this.label_Relationship.Size = new System.Drawing.Size(65, 13);
            this.label_Relationship.TabIndex = 4;
            this.label_Relationship.Text = "Relationship";
            // 
            // label_BirthDateDependent
            // 
            this.label_BirthDateDependent.AutoSize = true;
            this.label_BirthDateDependent.Location = new System.Drawing.Point(8, 93);
            this.label_BirthDateDependent.Name = "label_BirthDateDependent";
            this.label_BirthDateDependent.Size = new System.Drawing.Size(51, 13);
            this.label_BirthDateDependent.TabIndex = 3;
            this.label_BirthDateDependent.Text = "BirthDate";
            // 
            // label_GenderDependent
            // 
            this.label_GenderDependent.AutoSize = true;
            this.label_GenderDependent.Location = new System.Drawing.Point(8, 48);
            this.label_GenderDependent.Name = "label_GenderDependent";
            this.label_GenderDependent.Size = new System.Drawing.Size(42, 13);
            this.label_GenderDependent.TabIndex = 2;
            this.label_GenderDependent.Text = "Gender";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(8, 3);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Name";
            // 
            // dataGridView_Dependent
            // 
            this.dataGridView_Dependent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Dependent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_Dependent,
            this.gender_Dependent,
            this.birthdate_Dependent,
            this.relationship_Dependent,
            this.dependentof_Denpedent});
            this.dataGridView_Dependent.Location = new System.Drawing.Point(263, 0);
            this.dataGridView_Dependent.Name = "dataGridView_Dependent";
            this.dataGridView_Dependent.Size = new System.Drawing.Size(533, 534);
            this.dataGridView_Dependent.TabIndex = 0;
            // 
            // name_Dependent
            // 
            this.name_Dependent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name_Dependent.DataPropertyName = "Name";
            this.name_Dependent.HeaderText = "Name";
            this.name_Dependent.Name = "name_Dependent";
            // 
            // gender_Dependent
            // 
            this.gender_Dependent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gender_Dependent.DataPropertyName = "Gender";
            this.gender_Dependent.HeaderText = "Gender";
            this.gender_Dependent.Name = "gender_Dependent";
            // 
            // birthdate_Dependent
            // 
            this.birthdate_Dependent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birthdate_Dependent.DataPropertyName = "BirthDate";
            this.birthdate_Dependent.HeaderText = "BirthDate";
            this.birthdate_Dependent.Name = "birthdate_Dependent";
            // 
            // relationship_Dependent
            // 
            this.relationship_Dependent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.relationship_Dependent.DataPropertyName = "Relationship";
            this.relationship_Dependent.HeaderText = "Relationship";
            this.relationship_Dependent.Name = "relationship_Dependent";
            // 
            // dependentof_Denpedent
            // 
            this.dependentof_Denpedent.DataPropertyName = "DependentOf";
            this.dependentof_Denpedent.HeaderText = "DepedentOf";
            this.dependentof_Denpedent.Name = "dependentof_Denpedent";
            this.dependentof_Denpedent.Visible = false;
            // 
            // tabPage_Project
            // 
            this.tabPage_Project.Controls.Add(this.button_DeleteProject);
            this.tabPage_Project.Controls.Add(this.button_ModifyProject);
            this.tabPage_Project.Controls.Add(this.button_AddProject);
            this.tabPage_Project.Controls.Add(this.textBox_LocationProject);
            this.tabPage_Project.Controls.Add(this.textBox_PNameProject);
            this.tabPage_Project.Controls.Add(this.textBox_PNumberProject);
            this.tabPage_Project.Controls.Add(this.label_Location);
            this.tabPage_Project.Controls.Add(this.label_PName);
            this.tabPage_Project.Controls.Add(this.label_PNumber);
            this.tabPage_Project.Controls.Add(this.dataGridView_Project);
            this.tabPage_Project.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Project.Name = "tabPage_Project";
            this.tabPage_Project.Size = new System.Drawing.Size(796, 534);
            this.tabPage_Project.TabIndex = 2;
            this.tabPage_Project.Text = "Project";
            this.tabPage_Project.UseVisualStyleBackColor = true;
            // 
            // button_DeleteProject
            // 
            this.button_DeleteProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteProject.Location = new System.Drawing.Point(8, 244);
            this.button_DeleteProject.Name = "button_DeleteProject";
            this.button_DeleteProject.Size = new System.Drawing.Size(198, 36);
            this.button_DeleteProject.TabIndex = 9;
            this.button_DeleteProject.Text = "Delete Project";
            this.button_DeleteProject.UseVisualStyleBackColor = true;
            // 
            // button_ModifyProject
            // 
            this.button_ModifyProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ModifyProject.Location = new System.Drawing.Point(8, 202);
            this.button_ModifyProject.Name = "button_ModifyProject";
            this.button_ModifyProject.Size = new System.Drawing.Size(198, 36);
            this.button_ModifyProject.TabIndex = 8;
            this.button_ModifyProject.Text = "Modify Project";
            this.button_ModifyProject.UseVisualStyleBackColor = true;
            // 
            // button_AddProject
            // 
            this.button_AddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddProject.Location = new System.Drawing.Point(8, 160);
            this.button_AddProject.Name = "button_AddProject";
            this.button_AddProject.Size = new System.Drawing.Size(198, 36);
            this.button_AddProject.TabIndex = 7;
            this.button_AddProject.Text = "Add Project";
            this.button_AddProject.UseVisualStyleBackColor = true;
            // 
            // textBox_LocationProject
            // 
            this.textBox_LocationProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LocationProject.Location = new System.Drawing.Point(8, 115);
            this.textBox_LocationProject.Name = "textBox_LocationProject";
            this.textBox_LocationProject.Size = new System.Drawing.Size(235, 26);
            this.textBox_LocationProject.TabIndex = 6;
            // 
            // textBox_PNameProject
            // 
            this.textBox_PNameProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PNameProject.Location = new System.Drawing.Point(8, 70);
            this.textBox_PNameProject.Name = "textBox_PNameProject";
            this.textBox_PNameProject.Size = new System.Drawing.Size(235, 26);
            this.textBox_PNameProject.TabIndex = 5;
            // 
            // textBox_PNumberProject
            // 
            this.textBox_PNumberProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PNumberProject.Location = new System.Drawing.Point(8, 25);
            this.textBox_PNumberProject.Name = "textBox_PNumberProject";
            this.textBox_PNumberProject.Size = new System.Drawing.Size(111, 26);
            this.textBox_PNumberProject.TabIndex = 4;
            // 
            // label_Location
            // 
            this.label_Location.AutoSize = true;
            this.label_Location.Location = new System.Drawing.Point(8, 99);
            this.label_Location.Name = "label_Location";
            this.label_Location.Size = new System.Drawing.Size(48, 13);
            this.label_Location.TabIndex = 3;
            this.label_Location.Text = "Location";
            // 
            // label_PName
            // 
            this.label_PName.AutoSize = true;
            this.label_PName.Location = new System.Drawing.Point(8, 54);
            this.label_PName.Name = "label_PName";
            this.label_PName.Size = new System.Drawing.Size(35, 13);
            this.label_PName.TabIndex = 2;
            this.label_PName.Text = "Name";
            // 
            // label_PNumber
            // 
            this.label_PNumber.AutoSize = true;
            this.label_PNumber.Location = new System.Drawing.Point(8, 9);
            this.label_PNumber.Name = "label_PNumber";
            this.label_PNumber.Size = new System.Drawing.Size(44, 13);
            this.label_PNumber.TabIndex = 1;
            this.label_PNumber.Text = "Number";
            // 
            // dataGridView_Project
            // 
            this.dataGridView_Project.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Project.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number_Project,
            this.name_Project,
            this.location_Project,
            this.controlledby_Project,
            this.workson_Project});
            this.dataGridView_Project.Location = new System.Drawing.Point(292, 0);
            this.dataGridView_Project.Name = "dataGridView_Project";
            this.dataGridView_Project.Size = new System.Drawing.Size(504, 534);
            this.dataGridView_Project.TabIndex = 0;
            // 
            // textBox_DependentOf
            // 
            this.textBox_DependentOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DependentOf.Location = new System.Drawing.Point(8, 199);
            this.textBox_DependentOf.Name = "textBox_DependentOf";
            this.textBox_DependentOf.Size = new System.Drawing.Size(221, 26);
            this.textBox_DependentOf.TabIndex = 13;
            // 
            // number_Project
            // 
            this.number_Project.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.number_Project.DataPropertyName = "PNumber";
            this.number_Project.HeaderText = "Number";
            this.number_Project.Name = "number_Project";
            // 
            // name_Project
            // 
            this.name_Project.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name_Project.DataPropertyName = "PName";
            this.name_Project.HeaderText = "Name";
            this.name_Project.Name = "name_Project";
            // 
            // location_Project
            // 
            this.location_Project.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.location_Project.DataPropertyName = "Location";
            this.location_Project.HeaderText = "Location";
            this.location_Project.Name = "location_Project";
            // 
            // controlledby_Project
            // 
            this.controlledby_Project.DataPropertyName = "ControlledBy";
            this.controlledby_Project.HeaderText = "ControlledBy";
            this.controlledby_Project.Name = "controlledby_Project";
            this.controlledby_Project.Visible = false;
            // 
            // workson_Project
            // 
            this.workson_Project.DataPropertyName = "WorksOn";
            this.workson_Project.HeaderText = "WorksOn";
            this.workson_Project.Name = "workson_Project";
            this.workson_Project.Visible = false;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Employee.ResumeLayout(false);
            this.tabPage_Employee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).EndInit();
            this.tabPage_Dependent.ResumeLayout(false);
            this.tabPage_Dependent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Dependent)).EndInit();
            this.tabPage_Project.ResumeLayout(false);
            this.tabPage_Project.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Project)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Employee;
        private System.Windows.Forms.DataGridView dataGridView_Employee;
        private System.Windows.Forms.TabPage tabPage_Dependent;
        private System.Windows.Forms.DataGridView dataGridView_Dependent;
        private System.Windows.Forms.Label label_GenderEmployee;
        private System.Windows.Forms.Label label_Salary;
        private System.Windows.Forms.Label label_BirthDateEmployee;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_LName;
        private System.Windows.Forms.Label label_MInit;
        private System.Windows.Forms.Label label_FName;
        private System.Windows.Forms.Label label_Ssn;
        private System.Windows.Forms.TextBox textBox_FName;
        private System.Windows.Forms.TextBox textBox_LName;
        private System.Windows.Forms.TextBox textBox_GenderEmployee;
        private System.Windows.Forms.TextBox textBox_NInit;
        private System.Windows.Forms.TextBox textBox_BirthDate;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Salary;
        private System.Windows.Forms.TextBox textBox_Ssn;
        private System.Windows.Forms.Button button_DeleteEmployee;
        private System.Windows.Forms.Button button_ModifyEmployee;
        private System.Windows.Forms.Button button_AddEmployee;
        private System.Windows.Forms.Label label_Relationship;
        private System.Windows.Forms.Label label_BirthDateDependent;
        private System.Windows.Forms.Label label_GenderDependent;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Relationship;
        private System.Windows.Forms.TextBox textBox_BirthDateDependent;
        private System.Windows.Forms.TextBox textBox_GenderDepenednt;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_AddDependent;
        private System.Windows.Forms.Button button_DeleteDependent;
        private System.Windows.Forms.Button button_ModifyDependent;
        private System.Windows.Forms.TabPage tabPage_Project;
        private System.Windows.Forms.DataGridView dataGridView_Project;
        private System.Windows.Forms.Label label_Location;
        private System.Windows.Forms.Label label_PName;
        private System.Windows.Forms.Label label_PNumber;
        private System.Windows.Forms.TextBox textBox_LocationProject;
        private System.Windows.Forms.TextBox textBox_PNameProject;
        private System.Windows.Forms.TextBox textBox_PNumberProject;
        private System.Windows.Forms.Button button_DeleteProject;
        private System.Windows.Forms.Button button_ModifyProject;
        private System.Windows.Forms.Button button_AddProject;
        private System.Windows.Forms.Label label_DependentOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Dependent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender_Dependent;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdate_Dependent;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationship_Dependent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependentof_Denpedent;
        private System.Windows.Forms.TextBox textBox_DependentOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn number_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlledby_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn workson_Project;
    }
}